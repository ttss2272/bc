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

namespace LoanApplication.Reports
{
    public partial class Datewise_Monthly_Transaction_Report : Form
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        public Datewise_Monthly_Transaction_Report()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string BcDate;
            string DueDate;

            BcDate = Convert.ToString(dtpfromdate.Text);
            DueDate = Convert.ToString(dtpTodate.Text);

            ReportDocument reportDocument = new ReportDocument();
            ParameterField paramField = new ParameterField();
            ParameterFields paramFields = new ParameterFields();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            string ReportPath = ConfigurationManager.AppSettings["ReportPath"];

            paramField.Name = "@BcDate";
            paramField.Name = "@DueDate";
            paramDiscreteValue.Value = 1;
            reportDocument.Load(ReportPath + "Reports\\DateWiseTransactionReport.rpt");

            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.DatabaseName = "DB_LoanApplication";
            //connectionInfo.UserID = "wms";           
            //connectionInfo.Password = "wms";
            connectionInfo.IntegratedSecurity = true;
            SetDBLogonForReport(connectionInfo, reportDocument);

            reportDocument.SetParameterValue("@BcDate", BcDate);
            reportDocument.SetParameterValue("@DueDate", DueDate);
            DatewisecrystalReport.ReportSource = reportDocument;
            DatewisecrystalReport.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
        }

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
    }
}
