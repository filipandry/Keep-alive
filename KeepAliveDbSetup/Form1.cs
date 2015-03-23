using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;

namespace KeepAliveDbSetup
{
    public partial class Form1 : Form
    {
        string sharedSecret = "_this_is_secret_PILIF_STUDIO_";
        string sqlconnectionTemplate = @"server={0};uid={1};pwd={2};Trusted_Connection=false";
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean noError = true;
            string sqlConnection = String.Format(sqlconnectionTemplate, txtServer.Text, txtUsername.Text, txtPassword.Text);
            using (SqlConnection conn = new SqlConnection(sqlConnection))
            {
                try
                {
                    conn.Open();

                    string sqlQuery = "";

                    if (chkCreate.Checked)
                    {

                        sqlQuery = "CREATE DATABASE " + txtDatabase.Text;
                    }
                    else
                    {
                        sqlQuery = "USE " + txtDatabase.Text;
                    }
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                    {
                        int result = cmd.ExecuteNonQuery();

                        cmd.CommandText = "USE " + txtDatabase.Text;
                        result = cmd.ExecuteNonQuery();

                        cmd.CommandText = "CREATE TABLE links (id INT IDENTITY NOT NULL,Url TEXT NOT NULL,PRIMARY KEY(id))";
                        result = cmd.ExecuteNonQuery();

                        cmd.CommandText = "CREATE TABLE logs (id INT IDENTITY NOT NULL,Data DATETIME NOT NULL,Log TEXT NOT NULL,PRIMARY KEY(id))";
                        result = cmd.ExecuteNonQuery();
                    }
                }
                catch (InvalidOperationException ex) { MessageBox.Show(ex.Message); noError = false; }
                catch (SqlException ex) { MessageBox.Show(ex.Message); noError = false; }
                catch (System.Configuration.ConfigurationException ex) { MessageBox.Show(ex.Message); noError = false; }

                if (!noError)
                    return;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(String.Concat(sqlConnection, ";Database=" + txtDatabase.Text));

                using (StreamWriter sw = new StreamWriter(Path.Combine(Application.StartupPath, "conf.ini")))
                {
                    sw.Write(Crypto.Crypto.EncryptStringAES(sb.ToString(), sharedSecret));
                }

                MessageBox.Show("Your database was successfully created");
                Dispose();
            }
        }
    }
}