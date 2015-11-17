using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAcessLayer;
using Entity;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Net;
using System.IO; 


namespace LoanApplication
{
    public partial class PendingPaymentReport : Form
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        public PendingPaymentReport()
        {
            InitializeComponent();
            loadGroupNames();
        }
        private void loadGroupNames()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            {
                try
                {
                    #region
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Usp_LoadGroupNames", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    try
                    {
                        if (dt.Rows.Count > 0)
                        {
                            //cbGroupName.Items.Insert(0, new ListItem("-Select-"));
                            
                            cbGroupName.DisplayMember = "GroupName";
                            cbGroupName.ValueMember = "GroupId";
                            cbGroupName.DataSource = dt;
                            cbGroupName.Text = "--Select--";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    finally
                    {
                        cmd.Dispose();
                        con.Close();
                        con.Dispose();
                    }
                    #endregion
                }
                catch (Exception eo)
                {
                    MessageBox.Show(eo.Message.ToString());
                }
            }
        }

        private void cbGroupName_Click(object sender, EventArgs e)
        {
            
        }

        public void loadMembers()
        {
            
                SqlConnection con = new SqlConnection(ConnectionString);
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        #region
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Usp_GetMembersofGroup", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@GroupId", Convert.ToInt32(cbGroupName.SelectedValue.ToString()));
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        try
                        {
                            if (dt.Rows.Count > 0)
                            {
                                CbcustomerName.DataSource = dt;
                                CbcustomerName.DisplayMember = "Name";
                                CbcustomerName.ValueMember = "CustomerId";


                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                        finally
                        {
                            cmd.Dispose();
                            con.Close();
                            con.Dispose();
                        }

                        #endregion
                    }
                    catch (Exception eo)
                    {
                        MessageBox.Show(eo.Message.ToString());
                    }
                }
            }

        private void cbGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGroupName.Text != "SELECT")
            {
                lblPendingMsg.ForeColor = System.Drawing.Color.Green;
                lblPendingMsg.Text = "You are Selected " + cbGroupName.Text + " Group";
                if (lblPendingMsg.Text != "")
                {

                    loadMembers();

                }


                else
                {
                    lblPendingMsg.ForeColor = System.Drawing.Color.Red;
                    lblPendingMsg.Text = "Please Select Group First";
                }
            }

        }
        
           

        

        private void btnSearch_Click(object sender, EventArgs e)
        {
           

        }

        //private void cbGroupName_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //if (cbGroupName.Text != "SELECT")
        //    //{
        //    //    lblPendingMsg.ForeColor = System.Drawing.Color.Green;
        //    //    lblPendingMsg.Text = "You are Selected " + cbGroupName.Text + " Group";
        //    //    if (lblPendingMsg.Text != "")
        //    //    {

        //    //            loadMembers();

        //    //    }   
        //    //        else
        //    //        {
        //    //            lblPendingMsg.ForeColor = System.Drawing.Color.Red;
        //    //            lblPendingMsg.Text = "Please Select Group First";
        //    //        }
        //    //    }

        //    //}

        //}
        private void CbcustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            if (cbGroupName.Text != "SELECT")
            {
                if (lblPendingMsg.Text != "")
                {
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                        try
                        {
                            #region
                            //SqlCommand cmd = new SqlCommand("Usp_SearchPendingInstallmentReport", sqlCon);
                            //cmd.Parameters.AddWithValue("@GroupId", Convert.ToInt32(cbGroupName.SelectedValue.ToString()));
                            //cmd.Parameters.AddWithValue("@CustomerId", Convert.ToInt32(CbcustomerName.SelectedValue.ToString()));
                            //cmd.CommandType = CommandType.StoredProcedure;
                            //SqlDataAdapter da = new SqlDataAdapter(cmd);
                            //DataTable dt = new DataTable();
                            //da.Fill(dt);
                            //try
                            //{
                            //    if (dt.Rows.Count > 0)
                            //    {
                            //        DataSet1 dset = new DataSet1(); // dataset file name 
                            //        // DataSet1 dset2 = new DataSet1();
                            //        dset.Tables["Installment"].Merge(dt);
                            //        //dset2.Tables["Transactions"].Merge(dt);
                            //        Memberwisrrptfile crpt = new Memberwisrrptfile();// .rpt file name
                            //        crpt.SetDataSource(dset.Tables["Installment"]);
                            //        //crpt.SetDataSource(dset.Tables["Transactions"]);
                            //        crystalReportViewer1.ReportSource = crpt;
                            //        crystalReportViewer1.Refresh();
                            //    }
                            //    else
                            //    {
                            //        MessageBox.Show("Record does not available");
                            //    }
                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message.ToString());
                            //}
                            #endregion
                            PendingPayment reportDocument = new PendingPayment();
                            ParameterField paramField = new ParameterField();
                            ParameterFields paramFields = new ParameterFields();
                            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

                            paramField.Name = "@GroupId";
                            paramDiscreteValue.Value = cbGroupName.SelectedValue.ToString();
                            paramField.Name = "@CustomerId";
                            paramDiscreteValue.Value = CbcustomerName.SelectedValue.ToString();

                            paramField.CurrentValues.Add(paramDiscreteValue);
                            paramFields.Add(paramField);
                            paramFields.Add(paramField);
                            crystalReportViewer1.ParameterFieldInfo = paramFields;

                            //string reportPath = Server.MapPath("~/Memberwisrrptfile.rpt"); 
                            //reportDocument.Load("~/PendingPayment.rpt");
                            reportDocument.Load("~/PendingPayment.rpt");
                            reportDocument.SetParameterValue("@GroupId", cbGroupName.SelectedValue.ToString());
                            reportDocument.SetParameterValue("@CustomerId", CbcustomerName.SelectedValue.ToString());
                            crystalReportViewer1.ReportSource = reportDocument;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                        finally
                        {

                        }
                }
                else
                {
                    MessageBox.Show("Please Select Group First");
                }
            }
            else
            {
                MessageBox.Show("Please Select Group First");
            }
        }

        private void CbcustomerName_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        
    }
}
