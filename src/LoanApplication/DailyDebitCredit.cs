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
    public partial class DailyDebitCredit : Form
    {
        public DailyDebitCredit()
        {
            InitializeComponent();
            loadGroupNames();
        }

        #region------------------------loadGroupNames()------------------------
        private void loadGroupNames()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
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
                    #endregion
                }
                catch (Exception eo)
                {
                    MessageBox.Show(eo.Message.ToString());
                }
            }
        }
        #endregion

        #region-------------------btnSearch------------------------------
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (lblGroupName.Text != "")
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))

                    try
                    {
                        DebitCredit_CrystalReportNew reportDocument = new DebitCredit_CrystalReportNew();
                        ParameterField paramField = new ParameterField();
                        ParameterFields paramFields = new ParameterFields();
                        ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

                        paramField.Name = "@GroupId";
                  
                        paramDiscreteValue.Value = cbgroupNames.SelectedValue.ToString();
                      

                        paramField.CurrentValues.Add(paramDiscreteValue);
                        paramFields.Add(paramField);
                        paramFields.Add(paramField);
                        DebitandCreditcrystalReport.ParameterFieldInfo = paramFields;
                        
                        //string reportPath = Server.MapPath("~/Memberwisrrptfile.rpt"); 
                        reportDocument.Load("~/DebitCredit_CrystalReportNew.rpt");
                        //reportDocument.Load(@"D:\New folder\Loanapp11sep\10092015 Loan\Loan-25-07-2015\source\LoanApplication\LoanApplication\Memberwisrrptfile.rpt");
                        reportDocument.SetParameterValue("@GroupId", cbgroupNames.SelectedValue.ToString());
              
                       
                       DebitandCreditcrystalReport.ReportSource = reportDocument;                    
                       
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

      
    }

}
