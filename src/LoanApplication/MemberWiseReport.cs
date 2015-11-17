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
    public partial class MemberWiseReport : Form
    {

        string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        public MemberWiseReport()
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                try
                {
                    #region
                    
                    SqlCommand cmd = new SqlCommand("Usp_SearchMemberwiseReport", sqlCon);
                    cmd.Parameters.AddWithValue("@GroupId", Convert.ToInt32(cbgroupNames.SelectedValue.ToString()));
                    cmd.Parameters.AddWithValue("@CustomerId", Convert.ToInt32(cbMemberName.SelectedValue.ToString()));
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    

                    try
                    {
                        if (dt.Rows.Count > 0)
                        {
                            // dataset file name
                             DataSet1 dset = new DataSet1();
                             dset.Tables["Installment"].Merge(dt);
                            Memberwisrrptfile crpt = new Memberwisrrptfile();// .rpt file name
                            crpt.SetDataSource(dset.Tables["Installment"]);
                            crystalReportViewer1.ReportSource = crpt;
                            crystalReportViewer1.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Record does not available");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    #endregion
#region------try code
                    //    Memberwisrrptfile reportDocument = new Memberwisrrptfile();
                    //    ParameterField paramField = new ParameterField();
                    //    ParameterFields paramFields = new ParameterFields();
                    //    ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

                    //    paramField.Name = "@GroupId";
                    //    paramDiscreteValue.Value = cbgroupNames.SelectedValue.ToString();

                    //    paramField.CurrentValues.Add(paramDiscreteValue);
                    //    paramFields.Add(paramField);
                    //    paramFields.Add(paramField);

                    //    crystalReportViewer1.ParameterFieldInfo = paramFields;

                    //    //string reportPath = Server.MapPath("~/Memberwisrrptfile.rpt"); 
                    //    reportDocument.Load("~/Memberwisrrptfile.rpt");
                    //    reportDocument.SetParameterValue("@GroupId", cbgroupNames.SelectedValue.ToString());

                    //    crystalReportViewer1.ReportSource = reportDocument;
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

        private void SetParameterValue(string p, string p_2)
        {
            throw new NotImplementedException();
        }
        private void cbgroupNames_Click(object sender, EventArgs e)
        {
            loadMembers();
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
                    MessageBox.Show(eo.Message.ToString());
                }
            }
        }
    }
}
