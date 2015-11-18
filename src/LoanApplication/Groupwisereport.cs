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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))

                try
                {


                    GroupWise_CrystalReportNew reportDocument = new GroupWise_CrystalReportNew();
                    ParameterField paramField = new ParameterField();
                    ParameterFields paramFields = new ParameterFields();
                    ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();


                    paramField.Name = "@GroupId";
                    paramDiscreteValue.Value = cbgroupNames.SelectedValue.ToString();

                    paramField.CurrentValues.Add(paramDiscreteValue);
                    paramFields.Add(paramField);
                    paramFields.Add(paramField);
                    crystalReportViewer1.ParameterFieldInfo = paramFields;
                    
                    //string reportPath = Server.MapPath("~/Memberwisrrptfile.rpt"); 
                    reportDocument.Load("~/GroupWise_CrystalReportNew.rpt");
                    //reportDocument.Load(@"D:\New folder\Loanapp11sep\10092015 Loan\Loan-25-07-2015\source\LoanApplication\LoanApplication\Memberwisrrptfile.rpt");
                    reportDocument.SetParameterValue("@GroupId", cbgroupNames.SelectedValue.ToString());
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
                       
      