using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Net;
using System.IO;
namespace LoanApplication
{
    public partial class Groupwisereport : Form
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        public Groupwisereport()
        {
            InitializeComponent();
            loadGroupNames();
        }

        #region-------------------------loadGroupNames()--------------------------------
        private void loadGroupNames()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            SqlConnection con = new SqlConnection(ConnectionString);

            {
                try
                {
                   
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

                            cbgroupNames.Items.Insert(0, new ListItem("-Select-"));
                            cbgroupNames.DataSource = dt;

                            cbgroupNames.DisplayMember = "GroupName";
                            cbgroupNames.ValueMember = "GroupId";


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


                    
                }
                catch (Exception eo)
                {
                    MessageBox.Show(eo.Message.ToString());
                }
            }
        }
        #endregion

        #region-----------------------btnSearch------------------------------------
        private void btnSearch_Click(object sender, EventArgs e)
        {                                           
        //            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
        //                try
        //                {
        //                    #region
        //                    //SqlCommand cmd = new SqlCommand("Usp_SearchGroupwiseReport", sqlCon);
        //                    //cmd.Parameters.AddWithValue("@GroupId", Convert.ToInt32(cbgroupNames.SelectedValue.ToString()));
        //                    //cmd.CommandType = CommandType.StoredProcedure;
        //                    //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //                    //DataTable dt = new DataTable();
        //                    //da.Fill(dt);
        //                    //try
        //                    //{
        //                    //    if (dt.Rows.Count > 0)
        //                    //    {
        //                    //        DataSet1 dset = new DataSet1(); // dataset file name
        //                    //        dset.Tables["Transactions"].Merge(dt);
        //                    //        GroupwiseReport crpt = new GroupwiseReport();// .rpt file name
        //                    //        crpt.SetDataSource(dset.Tables["Transactions"]);
        //                    //        crystalReportViewer1.ReportSource = crpt;
        //                    //        crystalReportViewer1.Refresh();
        //                    //    }
        //                    //    else
        //                    //    {
        //                    //        MessageBox.Show("Record does not available");
        //                    //    }
        //                    //}
        //                    //catch (Exception ex)
        //                    //{
        //                    //    MessageBox.Show(ex.Message.ToString());
        //                    //}
        //                    #endregion
        //                    GroupWise_CrystalReport reportDocument = new GroupWise_CrystalReport();
        //                    ParameterField paramField = new ParameterField();
        //                    ParameterFields paramFields = new ParameterFields();
        //                    ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

        //                    paramField.Name = "@GroupId";
        //                    paramDiscreteValue.Value = cbgroupNames.SelectedValue.ToString();

        //                    paramField.CurrentValues.Add(paramDiscreteValue);
        //                    paramFields.Add(paramField);
        //                    paramFields.Add(paramField);
        //                    crystalReportViewer1.ParameterFieldInfo = paramFields;

        //                    //string reportPath = Server.MapPath("~/Memberwisrrptfile.rpt"); 
        //                    reportDocument.Load("~/GroupWise_CrystalReport.rpt");
        //                    reportDocument.SetParameterValue("@GroupId", cbgroupNames.SelectedValue.ToString());
        //                    crystalReportViewer1.ReportSource = reportDocument;
        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show(ex.Message.ToString());
        //                }
        //                finally
        //                {
        //                }                                                     
       }
        #endregion
      
        }
    }

