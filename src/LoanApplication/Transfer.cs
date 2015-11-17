using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using BusinessLayer;
using System.Data.Sql;
using System.Configuration;
using System.Windows.Forms;

namespace LoanApplication
{
    public partial class Transfer : Form
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

        public Transfer()
        {
            InitializeComponent();
            GetGroupNames(); 
        }

        private void GetGroupMembers()
        {
            //SqlConnection con = new SqlConnection(ConnectionString);
            //using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            //{
            //    try
            //    {
            //        #region
            //        con.Open(); 
            //        SqlCommand cmd = new SqlCommand("Usp_GetMembersofGroup", con); 
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@GroupId", Convert.ToInt32(cmbGroupName.SelectedValue.ToString()));
            //        SqlDataAdapter da = new SqlDataAdapter(cmd);
            //        DataTable dt = new DataTable();
            //        da.Fill(dt);
            //        try
            //        {
            //            if (dt.Rows.Count > 0)
            //            {
            //                cmbMemberName.DataSource = dt;
            //                cmbMemberName.DisplayMember = "Name";
            //                cmbMemberName.ValueMember = "CustomerId";
            //                cmbMemberName.Text = "select";
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message.ToString());
            //        }
            //        finally
            //        {
            //            cmd.Dispose();
            //            con.Close();
            //            con.Dispose();
            //        }
            //        #endregion
            //    }
            //    catch (Exception eo)
            //    {
            //        MessageBox.Show(eo.Message.ToString());
            //    }
            //}
        }

        private void GetGroupNames()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Usp_LoadGroupNames", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    cmbGroupName.ValueMember = "GroupId";
                    cmbGroupName.DisplayMember = "GroupName"; 
                    cmbGroupName.DataSource = dt;
                    //cmbGroupName.Text = "Select";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (lblMessegeTransfer.Text != "")
            {
                export();
                lblMessegeTransfer.Text = "";
            }
            else
            {
                lblMessegeTransfer.ForeColor = System.Drawing.Color.Red;
                lblMessegeTransfer.Text = "Please Select Group For Search";
            }
        } 

        private void export()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                DateTime CurrentDate = DateTime.Now.Date;
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_GetInstallmentTransfer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@GroupId", cmbGroupName.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@CurrentDate", CurrentDate);
                string result=cmd.ExecuteNonQuery().ToString();
                if (result == "-1")
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            //Build the Text file data.
                            string txt = string.Empty;
                            foreach (DataRow row in dt.Rows)
                            {
                                foreach (DataColumn column in dt.Columns)
                                {
                                    //Add the Data rows.
                                    txt += row[column.ColumnName].ToString() + ",";
                                
                                }
                                //Add new line.

                                int lastindex = txt.LastIndexOf(',');
                                txt = txt.Remove(lastindex, 1);
                                txt += "\r\n";
                            }
                            string f = "D:\\ReceiveInstallment.dat";
                            System.IO.StreamWriter objw;
                            objw = new System.IO.StreamWriter(f);
                            objw.Write(txt);
                            objw.Close();
                            MessageBox.Show("Record Transfered Successfully In Your Hard Drive in ReceiveInstallment.dat File.!!!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Record Does Not Found In Selected Group");
                }
            } 
        }

        private void cmbGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetGroupMembers();
            
        }

        private void cmbGroupName_Click(object sender, EventArgs e)
        {
            lblMessegeTransfer.ForeColor = System.Drawing.Color.Green;
            lblMessegeTransfer.Text = "You Are Selected " + cmbGroupName.Text + " Group";
            if (lblMessegeTransfer.Text != "")
            {
                GetGroupMembers();
            }
            else
            {
                lblMessegeTransfer.ForeColor = System.Drawing.Color.Red;
                lblMessegeTransfer.Text = "Please Select Group For Search";
            }
        }
    }
}
