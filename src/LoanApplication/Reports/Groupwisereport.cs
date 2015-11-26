using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Windows.Forms;
using System.Globalization;
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

        #region------------------btnSearch_Click--------------------------
        private void btnSearch_Click(object sender, EventArgs e)
        {

            int GroupId;
            GroupId = Convert.ToInt32(cbgroupNames.SelectedValue.ToString());

            ReportDocument reportDocument = new ReportDocument();
            ParameterField paramField = new ParameterField();
            ParameterFields paramFields = new ParameterFields();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            string ReportPath = ConfigurationManager.AppSettings["ReportPath"];

            paramField.Name = "@GroupId";
            paramDiscreteValue.Value = 1;
            reportDocument.Load(ReportPath + "Reports\\GroupWise_CrystalReport.rpt");

            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.DatabaseName = "DB_LoanApplication";
            //connectionInfo.UserID = "wms";           
            //connectionInfo.Password = "wms";
            connectionInfo.IntegratedSecurity = true;
            SetDBLogonForReport(connectionInfo, reportDocument);

            reportDocument.SetParameterValue("@GroupId", GroupId);
            GroupWisecrystalReport.ReportSource = reportDocument;
            GroupWisecrystalReport.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
        }
        #endregion

        #region---------------SetDBLogonForReport----------------
        private void SetDBLogonForReport(CrystalDecisions.Shared.ConnectionInfo connectionInfo, CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument)
        {
            Tables tables = reportDocument.Database.Tables;
           
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
            {
                TableLogOnInfo tableLogonInfo = table.LogOnInfo;
                tableLogonInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(tableLogonInfo);
                
            }
        }
        #endregion

        //    using (SqlConnection sqlCon = new SqlConnection(ConnectionString))

        //        try
        //        {


        //            GroupWise_CrystalReportNew reportDocument = new GroupWise_CrystalReportNew();
        //            ParameterField paramField = new ParameterField();
        //            ParameterFields paramFields = new ParameterFields();
        //            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();


        //            paramField.Name = "@GroupId";
        //            paramDiscreteValue.Value = cbgroupNames.SelectedValue.ToString();

        //            paramField.CurrentValues.Add(paramDiscreteValue);
        //            paramFields.Add(paramField);
        //            paramFields.Add(paramField);
        //            crystalReportViewer1.ParameterFieldInfo = paramFields;


        //            reportDocument.Load("~/GroupWise_CrystalReportNew.rpt");

        //            reportDocument.SetParameterValue("@GroupId", cbgroupNames.SelectedValue.ToString());
        //            crystalReportViewer1.ReportSource = reportDocument;

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message.ToString());
        //        }
        //        finally
        //        {

        //        }
    }
}
    

                       
      