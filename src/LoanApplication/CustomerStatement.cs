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
//using System.Web.HttpContext;

namespace LoanApplication
{
    public partial class CustomerStatement : Form
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        public CustomerStatement()
        {
            InitializeComponent();
            loadGroupNames();
        }

        private void CustomerStatement_Load(object sender, EventArgs e)
        { 
           
            //loadMembers(); 
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
                            //cbgroupNames.Items.Insert(0, new ListItem("-Select-"));
                            
                            cbgroupNames.DisplayMember = "GroupName";
                            cbgroupNames.ValueMember = "GroupId";
                            cbgroupNames.DataSource = dt;
                            cbgroupNames.Text = "--Select--";
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
                    throw eo;
                }
            }
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
                        cmd.Parameters.AddWithValue("@GroupId", Convert.ToInt32(cbgroupNames.SelectedValue.ToString()));
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        try
                        {
                            if (dt.Rows.Count > 0)
                            {
                                cbMemberName.DataSource = dt;
                                cbMemberName.DisplayMember = "Name";
                                cbMemberName.ValueMember = "CustomerId";
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
                    throw eo;
                }
            
            }  
        }
        #region----------------------btnSearch-----------------
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (lblCustMsg.Text != "")
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                
                    try
                    {
                        #region
                        //SqlCommand cmd = new SqlCommand("Usp_SearchMemberwiseReport", sqlCon);
                        //cmd.Parameters.AddWithValue("@GroupId", Convert.ToInt32(cbgroupNames.SelectedValue.ToString()));
                        //cmd.Parameters.AddWithValue("@CustomerId", Convert.ToInt32(cbMemberName.SelectedValue.ToString()));
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //SqlDataAdapter da = new SqlDataAdapter(cmd);
                        //DataTable dt = new DataTable();
                        //da.Fill(dt);
                        //try
                        //{
                        //    if (dt.Rows.Count > 0)
                        //    {
                                                Memberwisrrptfile reportDocument = new Memberwisrrptfile();
                                                ParameterField paramField = new ParameterField();
                                                ParameterFields paramFields = new ParameterFields();
                                                ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue(); 

                                                paramField.Name = "@GroupId";
                                                paramDiscreteValue.Value =cbgroupNames.SelectedValue.ToString();
                                                paramField.Name = "@CustomerId";
                                                paramDiscreteValue.Value = cbMemberName.SelectedValue.ToString();

                                                paramField.CurrentValues.Add(paramDiscreteValue);
                                                paramFields.Add(paramField);
                                                paramFields.Add(paramField);
                                                crystalReportViewer1.ParameterFieldInfo = paramFields; 
                                                
                                                //string reportPath = Server.MapPath("~/Memberwisrrptfile.rpt"); 
                                                reportDocument.Load("~/Memberwisrrptfile.rpt"); 
                                                //reportDocument.Load(@"D:\New folder\Loanapp11sep\10092015 Loan\Loan-25-07-2015\source\LoanApplication\LoanApplication\Memberwisrrptfile.rpt");
                                                reportDocument.SetParameterValue("@GroupId", cbgroupNames.SelectedValue.ToString());
                                                reportDocument.SetParameterValue("@CustomerId", cbMemberName.SelectedValue.ToString());
                                                crystalReportViewer1.ReportSource = reportDocument;
                                               // crystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
                                               // Session["ReportDocument"] = reportDocument;

                                //DataSet1 dset = new DataSet1(); // dataset file name 
                                //dset.Tables["Installment"].Merge(dt);
                                //Memberwisrrptfile crpt = new Memberwisrrptfile(); // .rpt file name
                                //crpt.SetDataSource(dset.Tables["Installment"]);
                                //crystalReportViewer1.ReportSource = crpt;
                                //crystalReportViewer1.Refresh();
                            //}
                            //else
                            //{
                            //    MessageBox.Show("Record does not available");
                            //}
                        //}
                        //catch (Exception ex)
                        //{
                        //    MessageBox.Show(ex.Message.ToString());
                        //}
             
                        #endregion
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
                MessageBox.Show("Please Select Group For Search");
            }
        }
        #endregion

        private void cbgroupNames_Click(object sender, EventArgs e)
        {
             
        }

        private void cbgroupNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbgroupNames.Text != "SELECT")
            {
                lblCustMsg.ForeColor = System.Drawing.Color.Green;
                lblCustMsg.Text = "You are Selected " + cbgroupNames.Text + "Group";
                if (lblCustMsg.Text != "")
                {
                    loadMembers();
                }
                else
                {
                    lblCustMsg.ForeColor = System.Drawing.Color.Red;
                    lblCustMsg.Text = "Please Select Group First";
                }
            }
        }
    }
}

//Kunal
//(6:06:23 PM) sir tumhi crystal Report using SP MXNG made kelet ka

//Kalpesh
//(6:08:33 PM) ReportDocument reportDocument = new ReportDocument();
//                ParameterField paramField = new ParameterField();
//                ParameterFields paramFields = new ParameterFields();
//                ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
//                paramField.Name = "@from";
//                paramDiscreteValue.Value = txtFrom.Text.ToString();

//                paramField.Name = "@To";
//                paramDiscreteValue.Value = txtTo.Text.ToString();
//                paramField.Name = "@ClientId";
//                paramDiscreteValue.Value = ddlClientName.SelectedValue.ToString();

//                paramField.CurrentValues.Add(paramDiscreteValue);
//                paramFields.Add(paramField);
//                paramFields.Add(paramField);
//                CrystalReportViewer1.ParameterFieldInfo = paramFields;

//                string reportPath = Server.MapPath("~/Rpt/crDateTurnArroundReport.rpt";
                
//                reportDocument.Load(reportPath);
//                reportDocument.SetParameterValue("@from", txtFrom.Text.ToString());
//                reportDocument.SetParameterValue("@To", txtTo.Text.ToString());
//                reportDocument.SetParameterValue("@ClientId", ddlClientName.SelectedValue.ToString());
//                CrystalReportViewer1.ReportSource = reportDocument;
//                CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
//                Session["ReportDocument"] = reportDocument;
//(6:09:14 PM) protected void Page_Load(object sender, EventArgs e)
//        {
//            try
//            {
//                if (!IsPostBack)
//                {
//                    Session["ReportDocument"] = null;     
//                }
//                else
//                {
//                    if (Session["ReportDocument"] != null)
//                    {
//                        ReportDocument doc = (ReportDocument)Session["ReportDocument"];
//                        CrystalReportViewer1.ReportSource = doc;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                lblCatchError.Text = ex.Message.ToString();
//            }
//        }
