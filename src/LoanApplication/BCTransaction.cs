using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entity;
using System.Data.SqlClient;
using BusinessLayer;
using System.Data.Sql;
using System.Configuration;

namespace LoanApplication
{
    public partial class BCTransaction : Form
    {
        //string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        int tempResult;
        DateTime EndDt;
       
        #region----------------BCTransaction----------------------
        public BCTransaction()
        {
            //this.Hide();
            //DateTime currentdate = DateTime.Now;
            //DateTime expirydate =Convert.ToDateTime("2015-07-30");
            //if (currentdate > expirydate)
            //{
            //    MessageBox.Show("You Software Is Expired");
            //    this.Close();
            //}
            //else
            //    this.Show();
            InitializeComponent();
           // txtbcdate.MaxDate = DateTime.Now.Date;
            //DueDatePicker.MaxDate = DateTime.Now.Date;
            getCustomerId();
            bindGrid();
            loadGroupNames();
            btnupdate.Visible = false;
            DueDatePicker.Text = DateTime.Today.AddDays(+5).ToShortDateString();
        }

               #endregion

        #region----------btnClose_Click-----------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region----------------btnSave_Click---------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            int GroupID = Convert.ToInt32(cbgroupname.SelectedValue.ToString());
            //int TransactionID = Convert.ToInt32(txttransationId.Text);
            //int CustID = Convert.ToInt32(txtbcreceivermember.Text);
            try
            {
                if (lblMsgTransaction.Text != "")
                {
                    if (Validate())
                    {
                        if (btnSave.Text == "Save")
                        {
                            string value = string.Empty;
                            string Output = string.Empty;
                            EntTransaction objentcustomerDetails = new EntTransaction();
                            objentcustomerDetails.TransactionId = Convert.ToInt32(txttransationId.Text);
                            objentcustomerDetails.Amount = (float)Convert.ToDouble(txtamount.Text);
                            objentcustomerDetails.Month = Convert.ToInt32(txtmonth.Text);
                            objentcustomerDetails.Member = Convert.ToInt32(txtmember.Text);
                            objentcustomerDetails.amountofmonth = (float)Convert.ToDouble(txtmonthandamount.Text);
                            objentcustomerDetails.Percentage = (float)Convert.ToDouble(txtpercenter.Text);
                            objentcustomerDetails.RemainingMonths = Convert.ToInt32(txtremainingmonths.Text);
                            objentcustomerDetails.GroupName = cbgroupname.Text;

                            objentcustomerDetails.MemberList = cbmemberlist.Text;
                            objentcustomerDetails.OffcetPrice = (float)Convert.ToDouble(txtoffcetprice.Text);
                            objentcustomerDetails.Loss = (float)Convert.ToDouble(txtloss.Text);
                            objentcustomerDetails.ActualAmountforBCCustomer = (float)Convert.ToDouble(txtactulaAmountforbccustomer.Text);
                            objentcustomerDetails.Installment = Convert.ToInt32(txtinstallment.Text);
                            objentcustomerDetails.Drawa = (float)Convert.ToDouble(txtdrawa.Text);
                            objentcustomerDetails.ActualInstallment = (float)Convert.ToDouble(txtactualInstallment.Text);
                            objentcustomerDetails.BcRecriverMember = txtbcreceivermember.Text.ToString();
                            objentcustomerDetails.BcDate = DateTime.Now;
                            objentcustomerDetails.BcDate = Convert.ToDateTime(txtbcdate.Text);
                            objentcustomerDetails.DueDate = DateTime.Now;
                            objentcustomerDetails.DueDate = Convert.ToDateTime(DueDatePicker.Text);
                            objentcustomerDetails.CustomerId = Convert.ToInt32(cbmemberlist.SelectedValue.ToString());
                            objentcustomerDetails.GroupId = Convert.ToInt32(cbgroupname.SelectedValue.ToString());

                            objentcustomerDetails.Drawa1Name = cmbDrawa1Name.Text;
                            objentcustomerDetails.Drawa2Name = cmbDrawa2Name.Text;
                            objentcustomerDetails.Drawa2Amount = Convert.ToInt32(txtdrawn2amount.Text);
                            objentcustomerDetails.RunnerUpName = cmbRunnerUp.Text;
                            objentcustomerDetails.RunnerUpAmount = Convert.ToInt32(txtrunerupAmount.Text.ToString());
                            BLTransation objblcustomerdetails = new BLTransation(); 
                            Output = objblcustomerdetails.SaveCustomer(objentcustomerDetails);
                            /*
                             * Add Payment Debit Credit code
                             */
                            //if (Convert.ToInt32(Output) > 0)
                            //{
                            //    tempResult =Convert.ToInt32(Output);
                            //}
                            ////DataSet ds = objblcustomerdetails.getData(GroupID);
                            //int count = ds.Tables[0].Rows.Count;
                            //int cnt = 0;
                            //for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                            //{

                            //}   
                            //string Payment = objblcustomerdetails.AddPayment(objentcustomerDetails);
                            if (Output == "1")
                            {
                                MessageBox.Show("This Months Transaction Saved Successfully...");
                                getGroupMembers(Convert.ToInt32(cbgroupname.SelectedValue.ToString()));
                                bindGrid();
                                clearFields();
                                getCustomerId();
                                
                            }
                            else 
                            {
                                MessageBox.Show("Sorry..! This Months Transaction Has Been Done already");
                                txtbcdate.Focus();
                                //clearFields();
                            } 
                            // clearFields();
                           
                        }
                        else
                        {
                            string value = string.Empty;
                            string Output = string.Empty;
                            EntTransaction objentcustomerDetails = new EntTransaction();
                            objentcustomerDetails.TransactionId = Convert.ToInt32(txttransationId.Text);
                            objentcustomerDetails.Amount = (float)Convert.ToDouble(txtamount.Text);
                            objentcustomerDetails.Month = Convert.ToInt32(txtmonth.Text);
                            objentcustomerDetails.Member = Convert.ToInt32(txtmember.Text);
                            objentcustomerDetails.amountofmonth = (float)Convert.ToDouble(txtmonthandamount.Text);
                            objentcustomerDetails.Percentage = (float)Convert.ToDouble(txtpercenter.Text);
                            objentcustomerDetails.RemainingMonths = Convert.ToInt32(txtremainingmonths.Text);
                            objentcustomerDetails.GroupName = cbgroupname.Text;
                            objentcustomerDetails.MemberList = cbmemberlist.Text;
                            objentcustomerDetails.OffcetPrice = (float)Convert.ToDouble(txtoffcetprice.Text);
                            objentcustomerDetails.Loss = (float)Convert.ToDouble(txtloss.Text);
                            objentcustomerDetails.ActualAmountforBCCustomer = (float)Convert.ToDouble(txtactulaAmountforbccustomer.Text);
                            objentcustomerDetails.Installment = Convert.ToInt32(txtinstallment.Text);
                            objentcustomerDetails.Drawa = (float)Convert.ToDouble(txtdrawa.Text);
                            objentcustomerDetails.ActualInstallment = (float)Convert.ToDouble(txtactualInstallment.Text);
                            objentcustomerDetails.BcRecriverMember = txtbcreceivermember.Text.ToString();
                            objentcustomerDetails.BcDate = Convert.ToDateTime(txtbcdate.Text);
                            objentcustomerDetails.DueDate = Convert.ToDateTime(DueDatePicker.Text);
                            objentcustomerDetails.GroupId = Convert.ToInt32(cbgroupname.SelectedValue.ToString());
                            objentcustomerDetails.CustomerId = Convert.ToInt32(cbmemberlist.SelectedValue.ToString());
                            objentcustomerDetails.Drawa1Name = cmbDrawa1Name.Text.ToString();
                            objentcustomerDetails.Drawa2Name = cmbDrawa2Name.Text.ToString();
                            objentcustomerDetails.Drawa2Amount = Convert.ToInt32(txtdrawn2amount.Text);
                            objentcustomerDetails.RunnerUpName = cmbRunnerUp.Text.ToString();
                            objentcustomerDetails.RunnerUpAmount = Convert.ToInt32(txtrunerupAmount.Text.ToString());
                            BLTransation objblcustomerdetails = new BLTransation();

                            Output = objblcustomerdetails.SaveCustomer(objentcustomerDetails);
                            if (Output == "1")
                            {
                                MessageBox.Show("Transactions updated Successfully...");
                            }
                            else
                            {
                                MessageBox.Show("Transactions not updated");
                            }
                           
                            clearFields();
                           
                            bindGrid();
                            txtbcreceivermember.Text = "";
                            btnSave.Text = "Save";
                            getCustomerId();
                            //  getCustomerId();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Group First");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        
        }
         #endregion

        //private void getMaxRecord(int groupId)
        //{
        //        int groupId;
        //        SqlConnection con = new SqlConnection(ConnectionString);
        //        using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
        //        {
        //            try
        //            {
        //                #region
        //                con.Open();
        //                SqlCommand cmd = new SqlCommand("Usp_GetMaxTransactionGroupID", con);
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                SqlDataAdapter da = new SqlDataAdapter(cmd);
        //                DataTable dt = new DataTable();
        //                da.Fill(dt);
        //                try
        //                {
        //                    if (dt.Rows.Count > 0)
        //                    {
        //                        foreach(DataRow row in dt.Rows)
        //                        {
        //                           groupId = row.Field<int>("GroupId");
        //                           getGroupMembers(groupId);
        //                        }
        //                    } 
        //                } 
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show(ex.Message.ToString());
        //                }
        //                finally
        //                {
        //                    cmd.Dispose();
        //                    con.Close();
        //                    con.Dispose();
        //                }
        //                #endregion
        //            }
        //            catch (Exception eo)
        //            {
        //                MessageBox.Show(eo.Message.ToString());
        //            }
        //        }
        //}

        #region----------------getGroupMembers---------------------
        private void getGroupMembers(int groupId)
        {  
            SqlConnection con = new SqlConnection(ConnectionString);
            EntTransaction objentcustomerDetails = new EntTransaction();
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    #region
                    con.Open(); 
                    SqlCommand cmd = new SqlCommand("Usp_GetGroupMembers", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GroupId", groupId);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    try
                    {
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                getInstallmentId();
                                string Output;
                                objentcustomerDetails.MemberList = row.Field<String>("Name");
                                objentcustomerDetails.CustomerId = row.Field<int>("CustomerId");

                                objentcustomerDetails.InstallmentId = Convert.ToInt32(lblInstallmentID.Text);
                                objentcustomerDetails.Amount = (float)Convert.ToDouble(txtamount.Text);
                                objentcustomerDetails.Month = Convert.ToInt32(txtmonth.Text);
                                objentcustomerDetails.amountofmonth = (float)Convert.ToDouble(txtmonthandamount.Text);
                                objentcustomerDetails.GroupName = cbgroupname.Text;
                                objentcustomerDetails.ActualAmountforBCCustomer = (float)Convert.ToDouble(txtactulaAmountforbccustomer.Text);
                                objentcustomerDetails.ActualInstallment = (float)Convert.ToDouble(txtactualInstallment.Text); 
                                objentcustomerDetails.GroupId = Convert.ToInt32(cbgroupname.SelectedValue.ToString());
                                objentcustomerDetails.InstallmentStatus = "Pending";
                                objentcustomerDetails.BcDate = DateTime.Now;
                                objentcustomerDetails.BcDate = Convert.ToDateTime(txtbcdate.Text);
                                objentcustomerDetails.TransactionId = Convert.ToInt32(txttransationId.Text);
                                BLInstallment objblcustomerdetails = new BLInstallment(); 
                                Output = objblcustomerdetails.SaveInstallmentForGroupMembers(objentcustomerDetails);
                                //MessageBox.Show("Installment Saved Successfully For Group Members");
                            } 
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

        #region----------------getInstallmentId---------------------
        private void getInstallmentId()
        {
            //string InstallmentId;
            SqlConnection con = new SqlConnection(ConnectionString); 
            con.Open(); 
            SqlCommand cmd = new SqlCommand("Usp_GetInstallmentId", con); 
            cmd.CommandType = CommandType.StoredProcedure; 
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDa.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                    { 
                        int a = 1;
                         lblInstallmentID.Text= Convert.ToString(a); 
                    }
                    else
                    {
                        lblInstallmentID.Text = dt.Rows[0][0].ToString(); 
                    }
                }
            }
           // return InstallmentId;
        }
        #endregion

        #region----------------button1_Click---------------------
        private void button1_Click(object sender, EventArgs e)
        {
            clearFields();
            getCustomerId();
        }
        #endregion

        #region----------------clearFields----------------------
        private void clearFields()
        {
            txtbcreceivermember.Text = "";
            txtactualInstallment.Text = "0.00";
            txtdrawa.Text = "00";
            txtdrawn2amount.Text = "00";
            txtrunerupAmount.Text = "00";
            cmbDrawa2Name.Text = "Select";
            cmbDrawa1Name.Text = "Select";
            cmbRunnerUp.Text = "Select";
            txtinstallment.Text = "0.00";
            txtactulaAmountforbccustomer.Text = "00";
            txtoffcetprice.Text = "0.00";
            txtloss.Text = "0.00";
            txtremainingmonths.Text = "0";
            txtpercenter.Text = "2";
            txtmonthandamount.Text = "0.00";
            txtmonth.Text = "0";
            txtamount.Text = "00";
            txtbcreceivermember.Text = ""; 
            txtremainingmonths.Text = "0";   
            txtbcdate.Text = "";
            cbgroupname.Text = "SELECT";
            lblMsgTransaction.Text = "";
            txtmember.Text = "";
            txtinstallment.Text = "00";
            txtactualInstallment.Text = "00.0";
            txtactulaAmountforbccustomer.Text = null;
            cbmemberlist.DataSource = null;
            DueDatePicker.Text = DateTime.Now.ToString();
            txtbcdate.Text = DateTime.Now.ToString();
            
            
        }
        #endregion

        #region----------------button2_Click----------------------
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region----------------getCustomerId----------------------
        public void getCustomerId()
        {

            BLTransation obblcustomerDetails = new BLTransation();
            DataTable dt = obblcustomerDetails.getCustomerId();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                    {

                        int a = 1;
                        txttransationId.Text = Convert.ToString(a);
                    }
                    else
                    {
                        txttransationId.Text = dt.Rows[0][0].ToString();

                    }
                }
            }
        }
        #endregion

        #region----------------bindGrid----------------------
        private void bindGrid()
        {
            DataTable dt = new DataTable();
            BLTransation objBL = new BLTransation();
            dt = objBL.BindFullGrid();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderCell.Value = "TransactionId";
                dataGridView1.Columns[0].Visible = false;
                //dataGridView1.Columns[1].HeaderCell.Value = "Transaction No";
                dataGridView1.Columns[1].HeaderCell.Value = "Group Name"; 
                dataGridView1.Columns[2].HeaderCell.Value = "Amount";
                dataGridView1.Columns[3].HeaderCell.Value = "Month Duration";
                dataGridView1.Columns[4].HeaderCell.Value = "No. Member";
                dataGridView1.Columns[5].HeaderCell.Value = "Amount Of Month";
                dataGridView1.Columns[6].HeaderCell.Value = "Percentage";
                dataGridView1.Columns[7].HeaderCell.Value = "Remaining Months";
                dataGridView1.Columns[8].HeaderCell.Value = "Member Name";
                dataGridView1.Columns[9].HeaderCell.Value = "Offcet Price";
                dataGridView1.Columns[10].HeaderCell.Value = "Loss";
                dataGridView1.Columns[11].HeaderCell.Value = "Actual Amount";
                dataGridView1.Columns[12].HeaderCell.Value = "Actual Installment";
                dataGridView1.Columns[13].HeaderCell.Value = "BC Date";
                dataGridView1.Columns[14].HeaderCell.Value = "Due Date";
                dataGridView1.Columns[15].HeaderCell.Value = "GroupId";
                dataGridView1.Columns[15].Visible = false;
                dataGridView1.Columns[16].HeaderCell.Value = "CustomerId";
                dataGridView1.Columns[16].Visible = false;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.Refresh();
                dataGridView1.Show();
            } 
        }
        #endregion

        #region----------------btnSearch_Click----------------------
        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchData();
        }
        #endregion

        #region----------------searchData----------------------
        private void searchData()
        { 
            EntTransaction objentransaction = new EntTransaction();
            objentransaction.FromDate = Convert.ToDateTime(txtfromDate.Text.ToString());
            objentransaction.ToDate = Convert.ToDateTime(txtToDate.Text.ToString());
            BLTransation objbltransation = new BLTransation();
            DataTable dt = objbltransation.searchData(objentransaction);
            // SqlDataAdapter da = new SqlDataAdapter();
            // da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
                dataGridView1.Show();
            }
            else
            {
                MessageBox.Show("Record does not found..");
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                dataGridView1.Show();
            }
        }
        #endregion

        #region----------------btnDelete_Click----------------------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You Want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                deleteRecord();
            }
            else
            {

            }
        }
        #endregion

        #region----------------deleteRecord----------------------
        public void deleteRecord()
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                    EntTransaction objent = new EntTransaction();
                    objent.TransactionId = id;
                    BLTransation objbl = new BLTransation();
                    int result = objbl.delertRecord(objent);
                    if (result > 0)
                    {
                        MessageBox.Show("Record deleted Successfully..");
                        bindGrid();
                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("please select record first");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region----------------btnupdate_Click----------------------
        private void btnupdate_Click(object sender, EventArgs e)
        {
            updateTransaction();
        }
        #endregion

        #region----------------updateTransaction----------------------
        private void updateTransaction()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txttransationId.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value);
                int TransactionID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                DataTable dt = new DataTable();
                BLTransation objBL = new BLTransation();
                dt = objBL.FetchTransaction(TransactionID);

                if (dt.Rows.Count > 0)
                { 
                    txtmonth.Text = dt.Rows[0]["DurMonth"].ToString();
                    txtmember.Text = dt.Rows[0]["Member"].ToString();
                    txtmonthandamount.Text = dt.Rows[0]["amountofmonth"].ToString();
                    txtpercenter.Text = Convert.ToString( dt.Rows[0]["Percentage"]);
                    txtremainingmonths.Text = dt.Rows[0]["RemainingMonths"].ToString();
                    cbgroupname.SelectedValue = dt.Rows[0]["GroupId"].ToString(); 
                    cbmemberlist.Text = dt.Rows[0]["MemberList"].ToString();
                    txtoffcetprice.Text = dt.Rows[0]["OffcetPrice"].ToString();
                    txtamount.Text = dt.Rows[0]["Amount"].ToString(); 
                    txtloss.Text = dt.Rows[0]["Loss"].ToString(); 
                    txtactulaAmountforbccustomer.Text = dt.Rows[0]["ActualAmountforBCCustomer"].ToString();
                    txtinstallment.Text = dt.Rows[0]["Installment"].ToString();
                    cmbDrawa1Name.Text = dt.Rows[0]["Drawa1Name"].ToString(); 
                    txtdrawa.Text = dt.Rows[0]["Drawa"].ToString();
                    txtactualInstallment.Text = dt.Rows[0]["ActualInstallment"].ToString(); 
                    txtbcdate.Text = dt.Rows[0]["BcDate"].ToString();
                    DueDatePicker.Text = dt.Rows[0]["DueDate"].ToString();
                    cmbDrawa2Name.Text = dt.Rows[0]["Drawa2Name"].ToString();
                    txtdrawn2amount.Text = dt.Rows[0]["Drawa2Amount"].ToString();
                    cmbRunnerUp.Text = dt.Rows[0]["RunnerUpName"].ToString();
                    txtrunerupAmount.Text = dt.Rows[0]["RunnerUpAmount"].ToString();
                    //loadGroupNames();
                    loadMembers();
                }
                tabControl1.SelectedIndex = 0;
                btnSave.Text = "Update";
            }
            else
            {
                MessageBox.Show("Please Select the record..");

            } 
        }
        #endregion 

        #region----------------txtremainingmonths_TextChanged----------------------
        private void txtremainingmonths_TextChanged(object sender, EventArgs e)
        {
            if (txtremainingmonths.Text != "")
            {
                try
                {
                    float bcamount = (float)Convert.ToDecimal(txtamount.Text.ToString());
                    float bcpercentage = (float)Convert.ToDecimal(txtpercenter.Text.ToString());
                    int remainingmonth = Convert.ToInt32(txtremainingmonths.Text.ToString());
                    txtoffcetprice.Text = Convert.ToString(bcamount * bcpercentage * remainingmonth);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            } 
        }
        #endregion

        #region----------------txtloss_TextChanged----------------------
        private void txtloss_TextChanged(object sender, EventArgs e)
        {
            if (txtloss.Text != "")
            {
                try
                {
                    float bcamount = (float)Convert.ToDecimal(txtamount.Text.ToString());
                    float bcloss = (float)Convert.ToDecimal(txtloss.Text.ToString());
                    if (bcamount == 0.0)
                    {
                        MessageBox.Show("Please Enter Amount Before Entering Loss");
                    }
                    else if (bcamount <= bcloss)
                    {
                        MessageBox.Show("Please Enter Proper Loss Amount as Concern to Amount");
                    }
                    else
                    {
                        txtactulaAmountforbccustomer.Text = Convert.ToString(bcamount - bcloss);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            //else if (txtamount.Text == "00")
            //{
            //    MessageBox.Show("Please Enter Amount Before Entering Loss");
            //}
        }
        #endregion

        #region----------------txtinstallment_TextChanged----------------------
        private void txtinstallment_TextChanged(object sender, EventArgs e)
        {



        }
        #endregion

        //private void txtpercenter_TextChanged(object sender, EventArgs e)
        //{
        //    float bcamount = (float)Convert.ToDecimal(txtamount.Text.ToString());
        //    float bcpercentage = (float)Convert.ToDecimal(txtpercenter.Text.ToString());
        //    int remainingmonth = Convert.ToInt32(txtremainingmonths.Text.ToString());
        //    txtoffcetprice.Text = Convert.ToString(bcamount * bcpercentage * remainingmonth);

        //}

        #region----------------txtdrawa_TextChanged----------------------
        private void txtdrawa_TextChanged(object sender, EventArgs e)
        {
            //if (cmbDrawa1Name.Text == "Select")
            //{
            //    //txtdrawa.Enabled = false;
            //    MessageBox.Show("Please Select Drawa 1 Name From Group");
            //    txtdrawa.Text = "00";
            //}
            if (txtdrawa.Text != "")
            {
                if (txtinstallment.Text != "0.00")
                {
                    try
                    {
                        //txtdrawa.Enabled = true ;
                        int installment = Convert.ToInt32(txtinstallment.Text.ToString());
                        int drawa = Convert.ToInt32(txtdrawa.Text.ToString());
                        int drawa2 = Convert.ToInt32(txtdrawn2amount.Text.ToString());
                        int runnerUp = Convert.ToInt32(txtrunerupAmount.Text.ToString());
                        int member = Convert.ToInt32(txtmember.Text.ToString());
                        //int actualinstallment = installment + ((drawa + drawa2 + runnerUp) / member);
                        int actualinstallment = installment + (drawa + drawa2 + runnerUp);
                        txtactualInstallment.Text = Convert.ToString(actualinstallment);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Installment Amount Is Must for Calculate Actual Installment");
                }
            }
        }
        #endregion

        #region--------------------------------Validate()----------------------------
        public bool Validate()
        {
           
            DateTime Dudt = Convert.ToDateTime(DueDatePicker.Text);
            DateTime CuDt = Convert.ToDateTime(txtbcdate.Text);
            
            if (string.IsNullOrEmpty(txtamount.Text) || txtamount.Text=="00")
            {
                MessageBox.Show("Amount Can Not be Empty..");
                return false;
            } 

            else if (string.IsNullOrEmpty(txtmonth.Text))
            {
                MessageBox.Show("Month Can Not be Empty..");
                return false;
            }
            else if (string.IsNullOrEmpty(cbmemberlist.Text))
            {
                MessageBox.Show("Member Can Not be Empty..");
                return false;
            }

            else if (cbmemberlist.SelectedItem.ToString().Equals("Select"))
             {
                  MessageBox.Show("Member Can Not be Empty..");
                return false;
             }
            else if (string.IsNullOrEmpty(txtmonthandamount.Text))
            {
                MessageBox.Show("Amount of month can not be empty");
                return false;
            }
            else if (string.IsNullOrEmpty(txtpercenter.Text))
            {
                MessageBox.Show("Percenter can not be empty");
                return false;
            }
            else if (string.IsNullOrEmpty(txtremainingmonths.Text))
            {
                MessageBox.Show("remaining month can not be empty");
                return false;
            }
            else if (cbmemberlist.Text == null)
            {
                MessageBox.Show("Please select member list");
                return false;
            }

            else if (string.IsNullOrEmpty(txtoffcetprice.Text))
            {
                MessageBox.Show("Offcet price can not be empty");
                return false;
            }
            else if (string.IsNullOrEmpty(txtloss.Text) || txtloss.Text=="0.00")
            {
                MessageBox.Show("Loss can not be empty");
                return false;
            }
            else if (Convert.ToDouble( txtloss.Text) < Convert.ToDouble( txtoffcetprice.Text))
            {
                MessageBox.Show("Loss Price Must be Greater Than Offcet Price");
                txtloss.Focus();
                return false;
            }

            else if (string.IsNullOrEmpty(txtactulaAmountforbccustomer.Text))
            {
                MessageBox.Show("Actual for bc customer amount can not be empty");
                return false;
            }

            else if (string.IsNullOrEmpty(txtinstallment.Text))
            {
                MessageBox.Show("Installment amount can not be empty");
                return false;
            }
            else if (string.IsNullOrEmpty(txtdrawa.Text))
            {
                MessageBox.Show("Drawa amount can not be empty");
                return false;
            }
            else if (string.IsNullOrEmpty(txtactualInstallment.Text))
            {
                MessageBox.Show("Actual installment can not be empty");
                return false;
            }
            else if (string.IsNullOrEmpty(txtbcreceivermember.Text))
            {
                MessageBox.Show("BC Receiver Member can not be empty");
                return false;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtbcreceivermember.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show(" Receiver name should be  characters only");
                //txtcustomername.Text.Remove(txtcustomername.Text.Length - 1);
                return false;
            }
            else if (string.IsNullOrEmpty(txtbcdate.Text))
            {
                MessageBox.Show("BC Date  can not be empty");
                return false;
            }
            

            else if (Dudt < CuDt)
            {
               MessageBox.Show("Due Date Must be Greater Than Current Date");
                return false ;
            }

            else if (EndDt < CuDt)
            {
                MessageBox.Show("Current Date Must Be Less Than"+ EndDt.ToString("dd/MM/yyyy"));
                return false;
 
            }
            else
            {
                return true;
            }


        }
        #endregion

        #region------------------All KeyPress Events---------------------------------

        private void cbgroupname_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cbgroupname_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbgroupname.Text != "SELECT")
                {
                    lblMsgTransaction.ForeColor = System.Drawing.Color.Green;
                    lblMsgTransaction.Text = "You Are Selected " + cbgroupname.Text + " Group";
                    if (lblMsgTransaction.Text != "")
                    {
                        loadMembers();
                        getRemainingmonths();
                        GetBCAmount();
                        BindDrawa1();
                        BindDrawa2();
                        BindRunnerUp();
                        getEndDate();

                    }
                    else
                    {
                        lblMsgTransaction.ForeColor = System.Drawing.Color.Red;
                        lblMsgTransaction.Text = "Please Select Group First";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        #region---------------GetBCAmount---------------------------------
        private void GetBCAmount()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    #region
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Usp_GetBCAmount", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GroupId", Convert.ToInt32(cbgroupname.SelectedValue.ToString()));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    try
                    {
                        if (dt.Rows.Count > 0)
                        {
                            txtamount.Text = "";
                            txtamount.Text = dt.Rows[0][0].ToString();
                            
                    
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

        private void txtamount_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtmonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void txtmember_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void txtmonthandamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void txtpercenter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void txtremainingmonths_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }



        private void txtloss_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void txtactulaAmountforbccustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void txtinstallment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void txtdrawa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void txtactualInstallment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void txtamount_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        #endregion

        #region----------------loadGroupNames----------------------
        private void loadGroupNames()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    #region
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Usp_LoadActiveGroupNames", con); 
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt); 
                    try
                    {
                        if (dt.Rows.Count > 0)
                        {
                            // cbgroupname.Items.Insert(0, new ListItem("-Select-")); 
                            cbgroupname.ValueMember = "GroupId";
                            cbgroupname.DisplayMember = "GroupName";
                            cbgroupname.DataSource = dt;
                            //cbgroupname.Text = "--Select--";
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

        #region----------------loadMembers----------------------
        public void loadMembers()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    #region
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Usp_GetMembersListNotInBCTransaction", con); 
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GroupId", Convert.ToInt32(cbgroupname.SelectedValue.ToString()));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    SqlCommand cmd1 = new SqlCommand("CountGroupMembers", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@GroupId", Convert.ToInt32(cbgroupname.SelectedValue.ToString()));
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1); 
                    try
                    {
                        if (dt.Rows.Count > 0)
                        {
                            string counts = dt.Rows.Count.ToString();
                            txtmember.Text = dt1.Rows[0]["NoOfMembers"].ToString();
                            txtmonth.Text = dt1.Rows[0]["NoOfMembers"].ToString();
                            //txtmonth.Text = counts;
                            //txtmember.Text = counts;
                            cbmemberlist.DataSource = dt;
                            cbmemberlist.DisplayMember = "Name";
                            cbmemberlist.ValueMember = "CustomerId";
                            txtbcreceivermember.Text = cbmemberlist.Text.ToString();
                        }
                        else
                        {
                            cbmemberlist.DataSource = null;
                            txtbcreceivermember.Text = "";
                            txtmember.Text = "";
                            txtmonth.Text = "";
                           DialogResult result= MessageBox.Show("There is No Members in Group or BC Is Closed","Add Member", MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);
                           //if (result.Equals(DialogResult.OK))
                           //{
                           //    BCConfirmCustomerDetails addmember = new BCConfirmCustomerDetails();
                           //    this.Hide();
                           //    addmember.Show();
                           //}
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

       #region----------------BindRunnerUp----------------------
        private void BindRunnerUp()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Usp_GetMembersofGroup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GroupId", Convert.ToInt32(cbgroupname.SelectedValue.ToString()));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    try
                    {
                        if (dt.Rows.Count > 0)
                        {

                            //string counts = dt.Rows.Count.ToString();
                            //txtmember.Text = counts;
                            //txtmonth.Text = counts;

                            cmbRunnerUp.DataSource = dt;
                            cmbRunnerUp.DisplayMember = "Name";
                            cmbRunnerUp.ValueMember = "CustomerId";
                            cmbRunnerUp.Text = "Select";
                            //cmbRunnerUp.SelectedIndex = -1;
                            //cmbRunnerUp.SelectedIndex = cmbRunnerUp.Items.(-1);
                            //txtbcreceivermember.Text = cbmemberlist.Text.ToString(); 
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

        #region----------------BindDrawa2----------------------
        private void BindDrawa2()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Usp_GetMembersofGroup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GroupId", Convert.ToInt32(cbgroupname.SelectedValue.ToString()));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    try
                    {
                        if (dt.Rows.Count > 0)
                        {
                            cmbDrawa2Name.DataSource = dt;
                            cmbDrawa2Name.DisplayMember = "Name";
                            cmbDrawa2Name.ValueMember = "CustomerId";
                            //cmbDrawa2Name.DropDownStyle = ComboBoxStyle.DropDownList;
                            cmbDrawa2Name.Text = "Select";
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

        #region-------------------------------BindDrawa1----------
        private void BindDrawa1()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Usp_GetMembersofGroup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GroupId", Convert.ToInt32(cbgroupname.SelectedValue.ToString()));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    try
                    {
                        if (dt.Rows.Count > 0)
                        {

                            //string counts = dt.Rows.Count.ToString();
                            //txtmember.Text = counts;
                            //txtmonth.Text = counts;

                            cmbDrawa1Name.DataSource = dt;
                            cmbDrawa1Name.DisplayMember = "Name";
                            cmbDrawa1Name.ValueMember = "CustomerId";
                            cmbDrawa1Name.Text = "Select";
                            //txtbcreceivermember.Text = cbmemberlist.Text.ToString();

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

        #region----------------getRemainingmonths----------------------
        private void getRemainingmonths()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    #region
                    con.Open(); 
                    SqlCommand cmd = new SqlCommand("Usp_GetRemainingMonths", con); 
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GroupId", Convert.ToInt32(cbgroupname.SelectedValue.ToString()));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt); 
                    try
                    { 
                        if (dt.Rows.Count > 0)
                        {
                            int remainmonths = Convert.ToInt32(dt.Rows[0][0]);
                            txtremainingmonths.Text = Convert.ToString(remainmonths);
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

        #region----------------txtamount_TextChanged----------------------
        private void txtamount_TextChanged(object sender, EventArgs e)
        {
            if (txtamount.Text != "")
            {
                try
                {
                    int Percentage;
                    if (txtmember.Text != "")
                    {
                        int member = Convert.ToInt32(txtmember.Text.ToString());
                        int ammount = Convert.ToInt32(txtamount.Text.ToString());
                        if (txtpercenter.Text == "")
                            MessageBox.Show("Please Enter Proper Percentage");
                        else
                        {
                            Percentage = Convert.ToInt32(txtpercenter.Text.ToString());
                            int remainingmonths = ammount / member;
                            txtmonthandamount.Text = Convert.ToString(remainingmonths);
                            calculateoffcetprice();
                        }
                    }

                }
                catch (Exception ex)
                {
                   MessageBox.Show( ex.Message.ToString());
                }
            }
        }
        #endregion

        #region----------------calculateoffcetprice----------------------
        private void calculateoffcetprice()
        {
            int remainmonth;
            int member = Convert.ToInt32(txtmember.Text.ToString());
            int ammount = Convert.ToInt32(txtamount.Text.ToString());
            int Percentage = Convert.ToInt32(txtpercenter.Text.ToString());
            if (txtremainingmonths.Text == "0" )
                remainmonth = 1;
            else if (txtremainingmonths.Text == "")
            {
                remainmonth = 0;
            }
            else
                remainmonth = Convert.ToInt32(txtremainingmonths.Text);
            int offcetprice = ammount * Percentage * remainmonth / 100;
            txtoffcetprice.Text = Convert.ToString(offcetprice); 
            //    remainmonth = Convert.ToInt32(txtremainingmonths.Text);
            //int tempamt = ammount * Percentage;
            //int offcetprice = tempamt * member / 100;
            //txtoffcetprice.Text = Convert.ToString(offcetprice); 
        }
        #endregion

        #region----------------txtactulaAmountforbccustomer_TextChanged----------------------
        private void txtactulaAmountforbccustomer_TextChanged(object sender, EventArgs e)
        {
            if (txtactulaAmountforbccustomer.Text != "")
            {
                try
                {
                    if (txtmember.Text != "")
                    {
                        int member = Convert.ToInt32(txtmember.Text.ToString());
                        int actualamount = Convert.ToInt32(txtactulaAmountforbccustomer.Text.ToString());
                        int inst = actualamount / member;
                        txtinstallment.Text = Convert.ToString(inst);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        #endregion

        #region----------------cbmemberlist_SelectedIndexChanged----------------------
        private void cbmemberlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtbcreceivermember.Text = cbmemberlist.Text;
        }
        #endregion

        #region----------------cbmemberlist_Click----------------------
        private void cbmemberlist_Click(object sender, EventArgs e)
        {
            txtbcreceivermember.Text = cbmemberlist.SelectedItems.ToString();
        }
        #endregion

        #region----------------button1_Click_1----------------------
        private void button1_Click_1(object sender, EventArgs e)
        {
            clearFields();
            getCustomerId();
        }
        #endregion

        #region----------------txtbcreceivermember_TextChanged----------------------
        private void txtbcreceivermember_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region----------------txtpercenter_TextChanged----------------------
        private void txtpercenter_TextChanged(object sender, EventArgs e)
        {
            if (txtpercenter.Text != "")
            {
                try
                {
                    calculateoffcetprice();
                }
                catch (Exception ex)
                { 
                    MessageBox.Show(ex.Message.ToString());
                } 
            }
        }
        #endregion

        #region------UnUsed Label Events---------------------------------------
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        #endregion

        #region------txtdrawn2amount_TextChanged---------------------------------------
        private void txtdrawn2amount_TextChanged(object sender, EventArgs e)
        {
            //if (cmbDrawa2Name.Text == "Select")
            //{
            //    MessageBox.Show("Please Select Drawa 2 From Group");
            //    txtdrawn2amount.Text = "00";
            //}
            if (txtdrawn2amount.Text != "")
            {
                if (txtinstallment.Text != "0.00")
                {
                    try
                    {
                        int installment = Convert.ToInt32(txtinstallment.Text.ToString());
                        int drawa = Convert.ToInt32(txtdrawa.Text.ToString());
                        int drawa2 = Convert.ToInt32(txtdrawn2amount.Text.ToString());
                        int runnerUp = Convert.ToInt32(txtrunerupAmount.Text.ToString());
                        int member = Convert.ToInt32(txtmember.Text.ToString());
                        //int actualinstallment = installment + ((drawa + drawa2 + runnerUp) / member);
                        int actualinstallment = installment + (drawa + drawa2 + runnerUp);
                        txtactualInstallment.Text = Convert.ToString(actualinstallment);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Installment Amount Is Must for Calculate Actual Installment");
                }
            }
        }
         #endregion

         #region------txtrunerupAmount_TextChanged---------------------------------------
        private void txtrunerupAmount_TextChanged(object sender, EventArgs e)
        {
            //if (cmbRunnerUp.Text == "Select")
            //{
            //    MessageBox.Show("Please Select Runer Up From Group");
            //    txtrunerupAmount.Text = "00";
            //}
             if (txtrunerupAmount.Text != "")
            {
                if (txtinstallment.Text != "0.00")
                {
                    try
                    {
                        int installment = Convert.ToInt32(txtinstallment.Text.ToString());
                        int drawa = Convert.ToInt32(txtdrawa.Text.ToString());
                        int drawa2 = Convert.ToInt32(txtdrawn2amount.Text.ToString());
                        int runnerUp = Convert.ToInt32(txtrunerupAmount.Text.ToString());
                        int member = Convert.ToInt32(txtmember.Text.ToString());
                        int actualinstallment = installment + ((drawa + drawa2 + runnerUp) / member);
                        //int actualinstallment = installment + (drawa + drawa2 + runnerUp);
                        txtactualInstallment.Text = Convert.ToString(actualinstallment);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Installment Amount Is Must for Calculate Actual Installment");
                }
            }
        }
        #endregion

        private void cmbDrawa1Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void getEndDate()
        {
            if (cbgroupname.SelectedValue.ToString() != "0")
            {
                BLTransation objTransaction = new BLTransation();

                DataTable dt = objTransaction.GetEndDate(Convert.ToInt32(cbgroupname.SelectedValue));
                if (dt.Rows.Count != 0)
                {
                    EndDt = Convert.ToDateTime(dt.Rows[0]["EndDate"]);
                }
            }
        }

        private void txtbcdate_ValueChanged(object sender, EventArgs e)
        {
            DateTime _date = Convert.ToDateTime(txtbcdate.Text);
            _date = _date.AddDays(5);
            DueDatePicker.Text = _date.ToString();

        }

        private void DueDatePicker_ValueChanged(object sender, EventArgs e)
        {
           
        }

       
    }
}
