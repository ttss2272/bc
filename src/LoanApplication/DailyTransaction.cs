using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Net;
namespace LoanApplication
{
    public partial class DailyTransaction : Form
    {
        public DailyTransaction()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))                                  

                    try
                    {
                        DailyTransactionRpt reportDocument = new DailyTransactionRpt();
                        ParameterField paramField = new ParameterField();
                        ParameterFields paramFields = new ParameterFields();
                        ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

                        paramField.Name = "@BcDate";
                        paramField.Name = "@DueDate";

                        paramDiscreteValue.Value = dtpfromdate.Text;
                        paramDiscreteValue.Value = dtpTodate.Text;

                        paramField.CurrentValues.Add(paramDiscreteValue);
                        paramFields.Add(paramField);
                        paramFields.Add(paramField);
                        crystalReportViewer1.ParameterFieldInfo = paramFields;
                        
                        //string reportPath = Server.MapPath("~/Memberwisrrptfile.rpt"); 
                        reportDocument.Load("~/DailyTransactionRpt.rpt");
                        //reportDocument.Load(@"D:\New folder\Loanapp11sep\10092015 Loan\Loan-25-07-2015\source\LoanApplication\LoanApplication\Memberwisrrptfile.rpt");
                        reportDocument.SetParameterValue("@BcDate", dtpfromdate.Text);
                        reportDocument.SetParameterValue("@DueDate", dtpTodate.Text);
                       
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

    }
}

                    #region
                    //if (cbTodaysTransaction.Checked == true)
                    //{
                    //    fromdate = Convert.ToDateTime(DateTime.Now);
                    //    todate = Convert.ToDateTime(DateTime.Now);
                    //    dtpfromdate.Enabled = false;
                    //    dtpTodate.Enabled = false;

                    //}
                    //else
                    //{
                    //    fromdate = Convert.ToDateTime(dtpfromdate.Text);
                    //    todate = Convert.ToDateTime(dtpTodate.Text);
                    //    dtpfromdate.Enabled = true;
                    //    dtpTodate.Enabled = true;
                    //}
                    #endregion
                    #region
                    //            SqlCommand cmd = new SqlCommand("Usp_SearchDatabydate", sqlCon);
                    //            cmd.Parameters.AddWithValue("@FromDate", Convert.ToDateTime(dtpfromdate.Text));
                    //            cmd.Parameters.AddWithValue("@ToDate", Convert.ToDateTime(dtpTodate.Text));
                    //            cmd.CommandType = CommandType.StoredProcedure;
                    //            SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //            DataTable dt = new DataTable();
                    //            da.Fill(dt); 
                    //            try
                    //            { 
                    //                if (dt.Rows.Count > 0)
                    //                {
                    //                    DataSet1 dset = new DataSet1(); // dataset file name
                    //                    dset.Tables["Transactions"].Merge(dt,true,MissingSchemaAction.Ignore);
                    //                    DailyTransactionRpt crpt = new DailyTransactionRpt();// .rpt file name
                    //                    crpt.SetDataSource(dset.Tables["Transactions"]);
                    //                    crystalReportViewer1.ReportSource = crpt;
                    //                    crystalReportViewer1.Refresh(); 
                    //                }
                    //                else
                    //                { 
                    //                    MessageBox.Show("Record does not available");
                    //                } 
                    //            } 
                    //            catch (Exception ex)
                    //            { 
                    //               MessageBox.Show(ex.Message.ToString()); 
                    //            } 

                    //        }
                    //        catch (Exception ex)
                    //        {
                    //           MessageBox.Show(ex.Message.ToString());
                    //        }
                    //        finally
                    //        { 
                    //        }
                    //
                    #endregion
                
        
    



