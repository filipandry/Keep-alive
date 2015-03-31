using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Net;


namespace KeepAlive
{
    public partial class KeepAlive : ServiceBase
    {
        System.Timers.Timer myTimer;
        System.Timers.Timer keepAliveTimer;

        string confFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini");
        string logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
        string sharedSecret = "_this_is_secret_PILIF_STUDIO_";
        string connString = "";

        Boolean WriteLog = true;

        List<string> urls = new List<string>();
        object lockObj = new object();

        public KeepAlive()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            myTimer = new System.Timers.Timer();
            myTimer.Interval = Minute.MinutesToMiliseconds(1);
            myTimer.Elapsed += myTimer_Elapsed;
            myTimer.Enabled = true;
            myTimer.Start();
            CheckConf();
        }

        void myTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            CheckConf();  
        }

        void CheckConf()
        {
            if (File.Exists(confFile))
            {
                LogToFile("Conf file found");
                myTimer.Stop();
                myTimer.Enabled = false;



                using (StreamReader mySR = new StreamReader(confFile))
                {
                    connString = Crypto.Crypto.DecryptStringAES(mySR.ReadToEnd(), sharedSecret);
                }

                FillParams();

                Log("Start program", true);

                keepAliveTimer = new System.Timers.Timer();
                keepAliveTimer.Interval = Minute.MinutesToMiliseconds(1);
                keepAliveTimer.Elapsed += keepAliveTimer_Elapsed;
                keepAliveTimer.Enabled = true;
                keepAliveTimer.Start();



                UpdateList();
                PingList();
            }
            else
            {
                LogToFile("Conf file not found");
            }
        }

        private void FillParams()
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT * FROM Settings",conn))
                using (SqlDataReader myR = cmd.ExecuteReader())
                {
                    while (myR.Read())
                    {
                        Log("Load param " + myR["Field"].ToString() + " = " + myR["Value"].ToString(), true);
                        switch (myR["Field"].ToString())
                        {
                            case "Logs":
                                WriteLog = myR["Value"].ToString() == "Y";
                                break;
                        }

                    }
                }
            }
        }

        void Log(string text)
        {
            Log(text, WriteLog);
        }

        void Log(string text, Boolean writeLog)
        {
            if (!writeLog)
                return;

            using (var conn = new SqlConnection(connString))
            {
                conn.Open();

                try
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO logs (data,log) VALUES (@data,@log)", conn))
                    {
                        cmd.Parameters.Add("@data", SqlDbType.DateTime);
                        cmd.Parameters["@data"].Value = DateTime.Now;

                        cmd.Parameters.AddWithValue("@log", text);
                        int result = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    LogToFile(ex.Message);
                }
            }
        }

        void LogToFile(string text)
        {
            using(StreamWriter sw = new StreamWriter(logFile,true))
            {
                sw.WriteLine(DateTime.Now.ToString() + " - " + text);
            }
        }

        void UpdateList()
        {
            lock (lockObj)
            {
                Log("Update links' list",true);
                urls.Clear();
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM links ORDER BY ID", conn))
                        {
                            using (SqlDataReader myR = cmd.ExecuteReader())
                            {
                                while (myR.Read())
                                {
                                    urls.Add(myR.GetString(1));
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Log(ex.Message);
                    }
                }
                Log("End update list",true);
            }
        }

        void keepAliveTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            FillParams();
            UpdateList();
            PingList();
        }

        void PingList()
        {
            lock (lockObj)
            {
                Log("Start Ping",true);

                urls.ForEach(url =>
                {
                    try
                    {
                        if (!url.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                        {
                            Log("Url " + url + " doesn't start with http");
                            return;
                        }

                        Log("Start ping " + url);
                        var request = WebRequest.Create(url) as HttpWebRequest;
                        if (request != null)
                        {
                            using (request.GetResponse() as HttpWebResponse) { }
                        }
                        Log("Ping successfully: " + url);
                    }
                    catch
                    {
                        Log("Could not ping " + url);
                    }
                });
                Log("End ping",true);
            }
        }

        protected override void OnStop()
        {
            Log("The service was stopped", true);
            myTimer.Stop();
            if (keepAliveTimer != null)
            {
                keepAliveTimer.Stop();
            }
            else
                myTimer.Stop();
        }

        protected override void OnPause()
        {
            Log("The service was paused", true);
            base.OnPause();

            myTimer.Stop();
            if (keepAliveTimer != null)
            {
                keepAliveTimer.Stop();
            }
            else
                myTimer.Stop();
        }

        protected override void OnContinue()
        {
            Log("The service was resumed", true);
            base.OnContinue();
            if (keepAliveTimer != null)
            {
                keepAliveTimer.Start();
            }
            else
                myTimer.Start();
        }
    }

    static class Minute
    {
        public static int MinutesToMiliseconds(int minutes)
        {
            return minutes * 1000 * 60;
        }
    }
}
