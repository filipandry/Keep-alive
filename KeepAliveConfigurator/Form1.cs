using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KeepAliveConfigurator
{
    public partial class Form1 : Form
    {
        string confFile = Path.Combine(Application.StartupPath, "conf.ini");
        string sharedSecret = "_this_is_secret_PILIF_STUDIO_";
        string connString = "";

        int CurrID = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(confFile))
            {
                using (StreamReader mySR = new StreamReader(confFile))
                {
                    connString = Crypto.Crypto.DecryptStringAES(mySR.ReadToEnd(), sharedSecret);
                    FillGrid();
                    FillForm();
                }
            }
            else
            {
                toolStrip1.Enabled = false;
                MessageBox.Show("Please setup the database first");
            }
        }

        private void FillForm()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM settings",conn))
                {
                    using (SqlDataReader myR = cmd.ExecuteReader())
                    {
                        while (myR.Read())
                        {
                            switch (myR["Field"].ToString())
                            {
                                case "Logs":
                                    chkLog.Checked = myR["Value"].ToString() == "Y";
                                    break;
                            }

                        }
                    }
                }
            }
        }

        private void btnTBNew_Click(object sender, EventArgs e)
        {
            New();
        }

        void New()
        {
            txtUrl.Text = "";
            CurrID = 0;
            FillGrid();
        }

        private void btnTBSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                if (CurrID == 0)
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO links (Url) VALUES ('" + txtUrl.Text.Replace("'", "''") + "')", conn))
                    {
                        int result = cmd.ExecuteNonQuery(); 
                        FillGrid();
                    }
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE links SET Url = '" + txtUrl.Text.Replace("'", "''") + "' WHERE id = " + CurrID, conn))
                    {
                        int result = cmd.ExecuteNonQuery(); 
                        FillGrid();
                    }
                }
                New();
            }
        }

        private void btnTBOpen_Click(object sender, EventArgs e)
        {
            OpenRow();
        }
        void OpenRow()
        {
            if (grdUrls.CurrentRow == null)
                return;

            int id = Convert.ToInt32(grdUrls.CurrentRow.Cells["id"].Value.ToString());

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT id,url FROM links WHERE id = " + id, conn))
                {
                    using (SqlDataReader myR = cmd.ExecuteReader())
                    {
                        if (myR.Read())
                        {
                            CurrID = myR.GetInt32(0);
                            txtUrl.Text = myR.GetString(1);
                        }
                    }
                }
            }
        }

        private void btnTBDelete_Click(object sender, EventArgs e)
        {
            if (grdUrls.CurrentRow == null)
                return;

            int id = Convert.ToInt32(grdUrls.CurrentRow.Cells["id"].Value.ToString());

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM links WHERE id = " + id, conn))
                {
                    int result = cmd.ExecuteNonQuery();
                    FillGrid();
                }
            }
        }

        void FillGrid()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {

                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM links", conn))
                {
                    DataTable myDT = ExecuteDataTable(cmd);

                    grdUrls.DataSource = myDT;

                    grdUrls.Columns[0].Visible = false;
                    grdUrls.Columns[1].Visible = true;
                    grdUrls.Columns[1].ReadOnly = false;
                    grdUrls.Columns[1].Width = 500;
                }
            }
        }

        public DataTable ExecuteDataTable(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            // Preserve the state and Keep the connection open if the 
            // connection is already open or close it before returning;
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable sch = reader.GetSchemaTable();
            if (sch != null)
            {
                foreach (DataRow row in sch.Rows)
                {
                    dt.Columns.Add(row["ColumnName"].ToString(), (Type)row["DataType"]);
                }

                int fc = reader.FieldCount;
                DataRow rw;
                while (reader.Read())
                {
                    rw = dt.NewRow();
                    for (int i = 0; i < fc; i++)
                    {
                        rw[i] = reader.GetValue(i);
                    }
                    dt.Rows.Add(rw);
                }
            }
            reader.Close();

            return dt;
        }


        public Boolean AddCol(DataGridView grid,string MappingName, string HeaderName, Boolean ColVisible, Boolean ColReadOnly, int ColWidth)
        {
            Boolean result = false;
            DataGridViewColumn myCol = new DataGridViewColumn();
            myCol.DataPropertyName = MappingName;
            myCol.HeaderText = HeaderName;
            myCol.Name = MappingName;
                    myCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            myCol.Width = ColWidth;
            myCol.Visible = ColVisible;
            myCol.ReadOnly = ColReadOnly;
            try
            {
                if (grid.Columns.Add(myCol) == 0)
                    result = true;
            }
            catch { }
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void grdUrls_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenRow();
        }

        private void chkLog_CheckedChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE settings SET Value = @value WHERE Field = @field",conn))
                {
                    cmd.Parameters.AddWithValue("@value", chkLog.Checked ? "Y" : "N");
                    cmd.Parameters.AddWithValue("@field", "Logs");

                    int result = cmd.ExecuteNonQuery();
                    FillGrid();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM logs",conn))
                {
                    int result = cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
