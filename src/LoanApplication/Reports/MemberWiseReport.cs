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
    public partial class MemberWiseReport : Form
    {

        string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        public MemberWiseReport()
        {
            InitializeComponent();
            loadGroupNames();

        }

        #region-----------------loadGroupNames()---------------
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int GroupId;
            int CustomerId;

            GroupId = Convert.ToInt32(cbgroupNames.SelectedValue.ToString());
            CustomerId = Convert.ToInt32(cbMemberName.SelectedValue.ToString());

            ReportDocument reportDocument = new ReportDocument();
            ParameterField paramField = new ParameterField();
            ParameterFields paramFields = new ParameterFields();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            string ReportPath = ConfigurationManager.AppSettings["ReportPath"];

            paramField.Name = "@GroupId";
            paramField.Name = "@CustomerId";
            paramDiscreteValue.Value = 1;
            reportDocument.Load(ReportPath + "Reports\\MemberWise_CrystalReport.rpt");

            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.DatabaseName = "DB_LoanApplication";
            //connectionInfo.UserID = "wms";           
            //connectionInfo.Password = "wms";
            connectionInfo.IntegratedSecurity = true;
            SetDBLogonForReport(connectionInfo, reportDocument);

            reportDocument.SetParameterValue("@GroupId", GroupId);
            reportDocument.SetParameterValue("@CustomerId", CustomerId);
            MemberWisecrystalReport.ReportSource = reportDocument;
            MemberWisecrystalReport.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
        }

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

         #region-------------cbgroupNames_Click()----------------
         private void cbgroupNames_Click(object sender, EventArgs e)
        {
            loadMembers();
        }
        #endregion

         #region----------------------loadMembers()---------------
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
                    MessageBox.Show(eo.Message.ToString());
                }
            }
        }
        #endregion     

         private void cbgroupNames_Click_1(object sender, EventArgs e)
         {
             loadMembers();
         }
    }
}
