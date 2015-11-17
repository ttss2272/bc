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
namespace LoanApplication
{
    public partial class Payment : Form
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        double InstallmentAmount, PaymentAmount,CurrBal,PendingAmount;
        int installmentID;
        string InstallmentStatus;
        public Payment()
        {
            InitializeComponent();
            LoadGroupNames();
            
        }
        #region--------------------------------LoadGroupName--------------------------------
        private void LoadGroupNames()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Usp_LoadGroupNames", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    cbGroupName.ValueMember = "GroupId";
                    cbGroupName.DisplayMember = "GroupName";
                    cbGroupName.DataSource = dt;
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
        #region---------------------------GroupNameSelectedIndexChange-----------------------------
        private void cbGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (cbGroupName.Text != "SELECT")
                {
                    lblMessege.ForeColor = System.Drawing.Color.Green;
                    lblMessege.Text = "You Are Selected " + cbGroupName.Text + " Group";
                    if (lblMessege.Text != "")
                    {
                        
                        txtduration.Text = "0";
                        cbPaymentmode.SelectedText = "Select";
                        txtinstallmentAmount.Text = "0";
                        txtPaymentDate.Text = DateTime.Now.Date.ToShortDateString();
                        txtpaymentAmount.Text = "0";
                        txtPendingAmount.Text = "0";
                        txtCurrentBalance.Text = "0";
                        loadMember();
                        
                    }
                    else
                    {
                        lblMessege.ForeColor = System.Drawing.Color.Red;
                        lblMessege.Text = "Please Select Group First";
                    }
                    lblMessege.Text = "You Are Selected " + cbGroupName.Text + " Group";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #region---------------------LoadMember----------------------------
        private void loadMember()
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
                    cmd.Parameters.AddWithValue("@GroupId", Convert.ToInt32(cbGroupName.SelectedValue.ToString()));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    try
                    {
                        if (dt.Rows.Count > 0)
                        {
                            
                            cbmemberName1.DisplayMember = "Name";
                            cbmemberName1.ValueMember = "CustomerId";

                            cbmemberName1.DataSource = dt;
                            cbmemberName1.SelectedValue = "0";
                          
                        }
                        else
                        {
                            cbmemberName1.Text = "Select";
                            cbmemberName1.DataSource = null;
                        }
                        lblMessege.Text = "You Are Selected " + cbGroupName.Text + " Group";
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
        #region-----------------------MemberNameSelectedIndexChange---------------------------
        private void cbmemberName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetDetailsOfInstallment();
              
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        #region-----------CaclculatePendingAmount----------------------------------
        private void CalculatePendingAmount()
        {
            if (txtpaymentAmount.Text != "")
            {
                //InstallmentAmount = Convert.ToDouble(txtPendingAmount.Text);
                PaymentAmount = Convert.ToDouble(txtpaymentAmount.Text);
                double NewPendingAmount= PendingAmount - PaymentAmount;
                if (NewPendingAmount < 0)
                {
                    MessageBox.Show("Paid Amount Must Be Less Than or Equal to Pending Amount", "Invalid Payment Amount", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                txtpaymentAmount.Text = "0";
                }
                else if(cbmemberName1.Text!="Select")
                {
                    txtPendingAmount.Text = Convert.ToString(NewPendingAmount);
                }
            }
        }
        #endregion
        #region---------------------------GetDetailsOfInstallment-------------------------------------
        private void GetDetailsOfInstallment()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {

                    
                    #region
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Usp_GetDetailsofInstallment", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GroupId", Convert.ToInt32(cbGroupName.SelectedValue.ToString()));
                    cmd.Parameters.AddWithValue("@MemberId",Convert.ToInt32(cbmemberName1.SelectedValue.ToString()));

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    try
                    {
                        if (dt.Rows.Count > 0)
                        {
                            
                            txtduration.Text = dt.Rows[0]["DurationInMonths"].ToString();
                            txtinstallmentAmount.Text = dt.Rows[0]["InstallmentAmount"].ToString();
                            CurrBal =Convert.ToDouble(dt.Rows[0]["CurrentBalance"].ToString());
                            installmentID =Convert.ToInt32(dt.Rows[0]["InstallmentID"].ToString());
                            txtPendingAmount.Text = dt.Rows[0]["PendingAmount"].ToString();
                            PendingAmount = Convert.ToDouble(dt.Rows[0]["PendingAmount"]);
                            txtCurrentBalance.Text = dt.Rows[0]["CurrentBalance"].ToString();
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
        #region-----------------PageLoad-------------------------------------
        private void Payment_Load(object sender, EventArgs e)
        {
            cbPaymentmode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPaymentmode.SelectedIndex = 0;
        }
        #endregion
        #region----------PaymentModeSelectedIndexChange------------------------------
        private void cbPaymentmode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPaymentmode.Text == "CASH")
            {
                txtchequeNo.Text = "0";
                txtchequeNo.Enabled = false;

            }
            else
            {
                txtchequeNo.Enabled = true;
            }
        }
        #endregion

        #region---------------------PaymentAmountTextChange-------------------
        private void txtpaymentAmount_TextChanged(object sender, EventArgs e)
        {
           
            if (txtpaymentAmount.Text != "")
            {
               
                if (System.Text.RegularExpressions.Regex.IsMatch(txtpaymentAmount.Text, "[^0-9.]"))
                {
                    MessageBox.Show("Payment amount should be in only number format");
                    txtpaymentAmount.Text.Remove(txtpaymentAmount.Text.Length - 1);
                    txtpaymentAmount.Text = "";
                }
               
                else
                {
                    try
                    {
                        CalculatePendingAmount();
                        calculateCurrentBalance();

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }
        #region------------CalculateCurrentBalance----------------------------
        private void calculateCurrentBalance()
        {
            double NewcurrentBalance, PaymentAmount;
            if (txtpaymentAmount.Text != "")
            {
                if (txtpaymentAmount.Text == "")
                {
                    PaymentAmount = 0;
                }
                else
                {
                    PaymentAmount = Convert.ToDouble(txtpaymentAmount.Text);
                }



                NewcurrentBalance = Convert.ToDouble(CurrBal - PaymentAmount);
                txtCurrentBalance.Text = Convert.ToString(NewcurrentBalance);
            }
        }
        #endregion
        #region---------------PaidClick---------------------------------
        private void btnPaid_Click(object sender, EventArgs e)
        {
            double PaymentAmt, PendingtAmt;
            PaymentAmt = Convert.ToDouble(txtpaymentAmount.Text);
            PendingtAmt = Convert.ToDouble(txtPendingAmount.Text);
            if (lblMessege.Text != "" && cbmemberName1.SelectedValue.ToString() != "Select")
            {
                if (PaymentAmount>PendingAmount)
                {
                    MessageBox.Show("Payment Amount must be less than Pending Amount", "Invalid Payment Amount", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    txtpaymentAmount.Text = "0";
                    txtpaymentAmount.Focus();
                }
                else
                {

                    PaidPayment();
                }
                //txtPendingAmount.Text = "0";
                //txtCurrentBalance.Text = "0";
            }
            else
            {
                MessageBox.Show("Please Select Group And Member First");
            }
        }
        #region----------------PaidPAyment----------------------------------
        private void PaidPayment()
        {
            DateTime PaymentDate=Convert.ToDateTime(txtPaymentDate.Text);
            try
            {
                double PendindingAmt;
                PendindingAmt = Convert.ToDouble(txtPendingAmount.Text);
                int CustId = Convert.ToInt32(cbmemberName1.SelectedValue.ToString());
                int GroupId = Convert.ToInt32(cbGroupName.SelectedValue.ToString());
                if (btnPaid.Text == "Paid")
                {
                    if(Validate1())
                    {                       
                    SqlConnection con = new SqlConnection(ConnectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Usp_PaidPayment", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InstallmentID", installmentID);
                    cmd.Parameters.AddWithValue("@PaidAmount", txtpaymentAmount.Text);
                    cmd.Parameters.AddWithValue("@PaymentDate", PaymentDate);
                    cmd.Parameters.AddWithValue("@PaymentMode", cbPaymentmode.Text);
                    cmd.Parameters.AddWithValue("@ChequeNo", txtchequeNo.Text);
                    cmd.Parameters.AddWithValue("@GroupId", GroupId);
                   
                   
                    if (PendindingAmt>0)
                    {
                        InstallmentStatus = "Pending";
                    }
                    else
                    {
                        InstallmentStatus = "Paid";
                      
                    }
                    cmd.Parameters.AddWithValue("@InstallmentStatus", InstallmentStatus);
                    cmd.Parameters.AddWithValue("@PendingAmount", txtPendingAmount.Text);
                    cmd.Parameters.AddWithValue("@CustomerId", CustId);
                    string strMessage = Convert.ToString(cmd.ExecuteScalar());
                    MessageBox.Show("Payment Paid Sucessfully..");
                    txtPendingAmount.Text = "0";
                    txtCurrentBalance.Text = "0";
                    con.Close();
                    ClearAll();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        #region--------------------Validate()------------------------------
        private bool Validate1()
        {
            if (cbGroupName.SelectedValue.ToString() == "SELECT")
            {
                MessageBox.Show("Please Select Group Name");
                return false;
            }
            else if (cbmemberName1.SelectedValue.ToString() == "Select")
            {
                MessageBox.Show("Please Select Member Name");
                return false;
            }
            else if (txtPaymentDate.Text == null || txtPaymentDate.Text == "")
            {
                MessageBox.Show("Payment Date Can Not Be empty");
                return false;
            }
            else if (cbPaymentmode.Text == "Select")
            {
                MessageBox.Show("Payment Mode can not be empty");
                return false;
            }
            else if (cbPaymentmode.Text == "CHEQUE" && txtchequeNo.Text == "0")
            {
                MessageBox.Show("Cheque Number can not be empty");
                txtchequeNo.Focus();
                return false;

            }
            else if (string.IsNullOrEmpty(txtpaymentAmount.Text))
            {
                MessageBox.Show("Payment Amount can Not be Empty..");
                return false;
            }
            else if (txtpaymentAmount.Text == "0" || txtpaymentAmount.Text == "00")
            {
                MessageBox.Show("Please Enter Payment Amount");
                return false;
            }


            else
            {
                return true;
            }
        }
        #endregion
        #endregion

        #endregion

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbGroupName.SelectedValue != "0" && cbmemberName1.SelectedValue != "0" && txtpaymentAmount.Text != "0" && txtpaymentAmount.Text != "" && cbPaymentmode.SelectedText != "Select")
                {
                    DialogResult Rst = MessageBox.Show("Do You want to Save Details", "Save", MessageBoxButtons.YesNo);
                    if (Rst == DialogResult.Yes)
                    {
                        PaidPayment();
                        ClearAll();
                        txtPendingAmount.Text = "0";
                    }
                    else
                    {
                        ClearAll();
                        txtPendingAmount.Text = "0";
                    }
                }
                else
                {
                    ClearAll();
                    txtPendingAmount.Text = "0";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #region-------------ClearAll-----------------------------------
        private void ClearAll()
        {
                lblMessege.Text = "";
               
            cbGroupName.SelectedValue = "0";
            cbmemberName1.SelectedValue = "0";
            txtduration.Text = "0";
            txtinstallmentAmount.Text = "00";
            txtPendingAmount.Text = "0";
            cbPaymentmode.Text = "Select";
            txtchequeNo.Text = "0";
            txtpaymentAmount.Text = "00";
            txtCurrentBalance.Text = "0";
            if (txtPendingAmount.Text!="0")
            {
                txtPendingAmount.Text = "0";
            }
        }
        #endregion
        #region--------------------Close------------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        
        #endregion


        #endregion
        #endregion

    }
}
