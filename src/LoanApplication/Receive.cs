using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BusinessLayer;
using System.Data.Sql;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace LoanApplication
{
    public partial class Receive : Form
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        public Receive()
        {
            InitializeComponent();
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            CreateDataTableFromFile();
        }

        private void CreateDataTableFromFile()
        {
            
            SqlConnection con = new SqlConnection(ConnectionString);
            DataTable dt = new DataTable();
            DataRow dr;

            con.Open();
            DataColumn dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "CustomerGroupId";
            dc.Unique = false;
            dt.Columns.Add(dc);
            DataColumn dc7 = new DataColumn();
            dc7.DataType = System.Type.GetType("System.String");
            dc7.ColumnName = "ReceiveAmt";
            dc7.Unique = false;
            dt.Columns.Add(dc7);
            DataColumn dc1 = new DataColumn();
            dc1.DataType = System.Type.GetType("System.String");
            dc1.ColumnName = "Name";
            dc1.Unique = false;
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn();
            dc2.DataType = System.Type.GetType("System.String");
            dc2.ColumnName = "PendingAmount";
            dc2.Unique = false;
            dt.Columns.Add(dc2);
            DataColumn dc3 = new DataColumn();
            dc3.DataType = System.Type.GetType("System.String");
            dc3.ColumnName = "BcDate";
            dc3.Unique = false;
            dt.Columns.Add(dc3);
            DataColumn dc4 = new DataColumn();
            dc4.DataType = System.Type.GetType("System.String");
            dc4.ColumnName = "ReceiveAmount";
            dc4.Unique = false;
            dt.Columns.Add(dc4);
            //DataColumn dc5 = new DataColumn();
            //dc5.DataType = System.Type.GetType("System.String");
            //dc5.ColumnName = "Balance";
            //dc5.Unique = false;
            //dt.Columns.Add(dc5);
            //DataColumn dc6 = new DataColumn();
            //dc6.DataType = System.Type.GetType("System.String");
            //dc6.ColumnName = "InstallmentDate";
            //dc6.Unique = false;
            //dt.Columns.Add(dc6);
            StreamReader sr = new StreamReader(@"D:\ReceiveInstallment.dat");
            string input;
            string result = null;
           // SqlCommand cmd = null;
            while ((input = sr.ReadLine()) != null)
            {
                string[] s = input.Split(new char[] { ',' });
                dr = dt.NewRow();
                dr["CustomerGroupId"] = s[0];
                dr["ReceiveAmt"] = s[1];
                dr["Name"] = s[2];
                dr["PendingAmount"] = s[3];
                dr["BcDate"] = s[4];
                dr["ReceiveAmount"] = s[5];
                //dr["Balance"] = s[6];
                //dr["InstallmentDate"] = s[7];
                string date =Convert.ToString(dr["BcDate"]);
                DateTime bcdate = DateTime.ParseExact(date, "dd.mm.yyyy", CultureInfo.InvariantCulture);
               
                dt.Rows.Add(dr);
                SqlCommand cmd = new SqlCommand("USP_ReceiveInstallment", con);
                cmd.CommandType = CommandType.StoredProcedure;
            
                cmd.Parameters.AddWithValue("@CustomerGroupId", Convert.ToInt32(dr["CustomerGroupId"]));
                cmd.Parameters.AddWithValue("@ReceiveAmt",Convert.ToDouble(dr["ReceiveAmt"]));
                cmd.Parameters.AddWithValue("@Name", dr["Name"]);
                cmd.Parameters.AddWithValue("@PendingAmount", Convert.ToDouble(dr["PendingAmount"]));
                cmd.Parameters.AddWithValue("@BcDate", bcdate);
                if (dr["ReceiveAmount"] != "")

                    cmd.Parameters.AddWithValue("@ReceiveAmount", Convert.ToDouble(dr["ReceiveAmount"]));
                
                //else
                //    cmd.Parameters.AddWithValue("@PaymentAmount", 00);
                //if (dr["Balance"] != "")
                //    cmd.Parameters.AddWithValue("@Balance", Convert.ToInt32(dr["Balance"]));
                //else
                //    cmd.Parameters.AddWithValue("@Balance", 00);
                //if (dr["InstallmentDate"] != "")
                //    cmd.Parameters.AddWithValue("@InstallmentDate", Convert.ToDateTime(dr["InstallmentDate"]));
                //else
                //    cmd.Parameters.AddWithValue("@InstallmentDate", DBNull.Value);
                result = cmd.ExecuteNonQuery().ToString();
            }
            
            if (result == "2")
            {
                MessageBox.Show("Record Received Succesfully In Your Database");
            }
            else
            {
                MessageBox.Show("Record Does Not Found In Stored File");
            }

            // MessageBox.Show("Record Does Not Found In Stored File");
            sr.Close();
            con.Close();

        }
    }
}
