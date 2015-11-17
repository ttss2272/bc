using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BusinessLayer;
using System.Data.Sql;
using System.Configuration;
using System.Text.RegularExpressions;
namespace LoanApplication
{
    public partial class PrivateLoan : Form
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        public PrivateLoan()
        {
            InitializeComponent();
            getCustomerId();
            loadGrid();
            cbPaymentmode.Text = "--Select--";

        }

        public void getCustomerId()
        { 
            SqlConnection con = new SqlConnection(ConnectionString); 
            con.Open(); 
            SqlCommand cmd = new SqlCommand("Usp_GetLoanId", con); 
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
                        txttransactionId.Text = Convert.ToString(a); 
                    }
                    else
                    {
                        txttransactionId.Text = dt.Rows[0][0].ToString(); 
                    }
                }
            }  
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtAmount.Text != "" && txtcurrentAddress.Text != "" && txtPermanantAddress.Text != "" && txtEmailId.Text != "" && txtmobileNo.Text != "" && cbPaymentmode.Text != "--Select--" && txtAmount.Text != "" && txtduration.Text != "" && txtinterest.Text != "")
                {
                    DialogResult Result = MessageBox.Show("Entered Recrod Is not Saved Do You Want To Save?", "Info", MessageBoxButtons.YesNo);
                    if (Result.Equals(DialogResult.Yes))
                    {
                        saveInstallment();
                        loadGrid();
                        ClearFields();
                    }
                    else
                    {
                        ClearFields();
                    }

                }
                else
                {
                    ClearFields();
                }
            }
 
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            saveInstallment();
            loadGrid();
            
            

        }
        #region----------------------------EmailVAlidation-----------------------------
        //public void EmailValid()
        //{
        //    bool isEmail = Regex.IsMatch(txtEmailId.Text.Trim(), @"\A(?:[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?)\Z");
        //    if (!isEmail)
        //    {
        //        MessageBox.Show("Enter Valid Email ID..e.g:abc@gmail.com");
        //        txtEmailId.Text = "";
        //        return;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Valid Email ID...");
        //    }
        //}
        #endregion

        private void saveInstallment()
        {
            try
            {
                if (Validate())
                {
                    if (btnSave.Text == "Save")
                    {
                        SqlConnection con = new SqlConnection(ConnectionString);

                        con.Open();


                        SqlCommand cmd = new SqlCommand("Usp_SavePrivateLoanDetails", con);

                        cmd.CommandType = CommandType.StoredProcedure;

                        try
                        {

                            cmd.Parameters.AddWithValue("@TransactionId", txttransactionId.Text.ToString());
                            cmd.Parameters.AddWithValue("@FullName", txtfullname.Text.ToString());
                          
                            cmd.Parameters.AddWithValue("@CurrentAddress", txtcurrentAddress.Text.ToString());
                            cmd.Parameters.AddWithValue("@PermanantAddress",txtPermanantAddress.Text.ToString());
                            cmd.Parameters.AddWithValue("@EmailId", txtEmailId.Text.ToString());
                            cmd.Parameters.AddWithValue("@MobileNO",txtmobileNo.Text.ToString());
                            cmd.Parameters.AddWithValue("@TransactionDate", Convert.ToDateTime(txtinstallmentDate.Text.ToString()));
                            cmd.Parameters.AddWithValue("@PymentMode", cbPaymentmode.Text.ToString());
                            cmd.Parameters.AddWithValue("@ChequeNo", txtchequeNo.Text.ToString());
                            cmd.Parameters.AddWithValue("@Amount", Convert.ToDouble(txtAmount.Text.ToString()));
                            cmd.Parameters.AddWithValue("@Duration", txtduration.Text.ToString());
                            cmd.Parameters.AddWithValue("@Interest", Convert.ToDouble(txtinterest.Text.ToString()));
                           
                            string strMessage = Convert.ToString(cmd.ExecuteScalar());
                            if (strMessage == "This record already exists!")
                            {
                                MessageBox.Show(strMessage);
                            }
                            else
                            {
                                MessageBox.Show("Data Saved  Sucessfully..");
                                
                            }

                            con.Close();
                            ClearFields();


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
                    else
                    {
                        SqlConnection con = new SqlConnection(ConnectionString);

                        con.Open();


                        SqlCommand cmd = new SqlCommand("Usp_UpdatePrivateLoanDetails", con);

                        cmd.CommandType = CommandType.StoredProcedure;

                        try
                        {

                            cmd.Parameters.AddWithValue("@TransactionId", txttransactionId.Text.ToString());
                            cmd.Parameters.AddWithValue("@FullName", txtfullname.Text.ToString());

                            cmd.Parameters.AddWithValue("@CurrentAddress", txtcurrentAddress.Text.ToString());
                            cmd.Parameters.AddWithValue("@PermanantAddress", txtPermanantAddress.Text.ToString());
                            cmd.Parameters.AddWithValue("@EmailId", txtEmailId.Text.ToString());
                            cmd.Parameters.AddWithValue("@MobileNO", txtmobileNo.Text.ToString());
                            cmd.Parameters.AddWithValue("@TransactionDate", Convert.ToDateTime(txtinstallmentDate.Text.ToString()));
                            cmd.Parameters.AddWithValue("@PymentMode", cbPaymentmode.Text.ToString());
                            cmd.Parameters.AddWithValue("@ChequeNo", txtchequeNo.Text.ToString());
                            cmd.Parameters.AddWithValue("@Amount", Convert.ToDouble(txtAmount.Text.ToString()));
                            cmd.Parameters.AddWithValue("@Duration", txtduration.Text.ToString());
                            cmd.Parameters.AddWithValue("@Interest", Convert.ToDouble(txtinterest.Text.ToString()));
                            string strMessage = Convert.ToString(cmd.ExecuteScalar());
                            MessageBox.Show("Record Updated Successfully..");
                          

                            con.Close();



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
                            ClearFields();

                        }
                    }
                }
            }

            catch (Exception ex)
            {
                // MessageBox.Show(ex.InnerException);
               MessageBox.Show(ex.Message.ToString());
            }



        }
        public bool Validate()
        {
            if (string.IsNullOrEmpty(txtinstallmentDate.Text))
            {
                MessageBox.Show("Installment Date can Not be Empty..");
                txtinstallmentDate.Focus();
                return false;
            }

            else if (txtfullname.Text == null || txtfullname.Text == "")
            {
                MessageBox.Show("Full Name Can Not Be empty");
                txtfullname.Focus();
                return false;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtfullname.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("Name should be only characters");
                txtfullname.Focus();
                return false;
            }
            else if (txtmobileNo.Text == null || txtmobileNo.Text == "")
            {
                MessageBox.Show("Mobile No Can Not Be empty");
                txtmobileNo.Focus();
                return false;
            }
            else if (txtmobileNo.Text.Length != 10)
            {
                MessageBox.Show("Invalid Mobile Number");
                txtmobileNo.Focus();
                return false;
            }
            
           else if (txtcurrentAddress.Text == null || txtcurrentAddress.Text == "")
            {
                MessageBox.Show("Current Address Can Not Be empty");
                txtcurrentAddress.Focus();
                return false;
            }
           
           else if (txtPermanantAddress.Text == null || txtPermanantAddress.Text == "")
            {
                MessageBox.Show("Permanant Address Can Not Be empty");
                txtPermanantAddress.Focus();
                return false;
            }
          
            

            else if (cbPaymentmode.Text == "--Select--")
            {
                MessageBox.Show("Please Payment Mode");
                cbPaymentmode.Focus();
                return false;
            }
            else if (cbPaymentmode.Text == "CHEQUE" && txtchequeNo.Text == "")
            {
                MessageBox.Show("Please Enter Cheque No.");
                txtchequeNo.Focus();
                return false;
            }
            
            else if (string.IsNullOrEmpty(txtAmount.Text))
            {
                MessageBox.Show("Amount Can Not Be empty");
                txtAmount.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtduration.Text))
            {
                MessageBox.Show("Please Enter Duration");
                txtduration.Focus();
                return false;
                 
            }
            else if (txtduration.Text == "0")
            {
                MessageBox.Show("Please Enter valid duration");
                txtduration.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtinterest.Text))
            {
                MessageBox.Show("Please ENter Intrest.");
                txtinterest.Focus();
                return false;
            }
            else if (txtEmailId.Text != "")
            {
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
       @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
          @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(strRegex);
                if (re.IsMatch(txtEmailId.Text))
                    return (true);
                else
                    MessageBox.Show("Please Enter Poper Email ID");
                txtEmailId.Focus();
                return (false);

            }





            else
            {
                return true;
            }

        }
        private void loadGrid()
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))

                try
                {

                    #region


                    SqlCommand cmd = new SqlCommand("Usp_LoadPrivateLoanGrid", sqlCon);
                 
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    try
                    {

                        if (dt.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dt;
                            dataGridView1.ReadOnly = true;
                            dataGridView1.AllowUserToAddRows = false;
                            dataGridView1.AllowUserToDeleteRows = false;
                            dataGridView1.Refresh();
                            dataGridView1.Show();
                            dataGridView1.Columns["TransactionId"].Visible = false;
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


                }
                catch (Exception ex)
                {
                   MessageBox.Show(ex.Message.ToString());
                }
                finally
                {


                }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))

                try
                {

                    #region


                    SqlCommand cmd = new SqlCommand("Usp_SearchPrivateLoanDetails", sqlCon);
                    cmd.Parameters.AddWithValue("@CustomerName", txtcustomerName2.Text.ToString());
                  
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    try
                    {

                        if (dt.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dt;
                            dataGridView1.ReadOnly = true;
                            dataGridView1.Refresh();
                            dataGridView1.Show();
                            dataGridView1.Columns["TransactionId"].Visible = false;
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


                }
                catch (Exception ex)
                {
                   MessageBox.Show(ex.Message.ToString());
                }
                finally
                {


                }
        }

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

        public void deleteRecord()
        {

            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Usp_DeletePrivateLoanDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                int id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                cmd.Parameters.AddWithValue("@CustomerId", id);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Sucessfully..");
                loadGrid();

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

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txttransactionId.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["TransactionId"].Value);
                txtfullname.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Full Name"].Value);

                txtcurrentAddress.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Current Address"].Value);
                txtPermanantAddress.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Prmanant Address"].Value);
                txtEmailId.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Email ID"].Value);
                txtmobileNo.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Mobile No"].Value);

                txtinstallmentDate.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Date"].Value);
                cbPaymentmode.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Payment Mode"].Value);
                txtchequeNo.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Cheque No"].Value);
                txtAmount.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Amount"].Value);
                txtduration.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Duration"].Value);
                txtinterest.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Interest"].Value);
                tabControl1.SelectedIndex = 0;
                btnSave.Text = "Update";
            }
            else
            {
                MessageBox.Show("Please Select the record..");

            }

        }

        private void cbPaymentmode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPaymentmode.Text == "CHEQUE")
            {
                txtchequeNo.Enabled = true;

            }
            else {
                txtchequeNo.Enabled = false;
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtAmount.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtAmount.Text.Remove(txtAmount.Text.Length - 1);
                txtAmount.Text = "";
            }
        }

        private void txtinterest_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtinterest.Text, "[^0-9.]"))
            {
                MessageBox.Show("Please enter only numbers.(Without using % sign.)");
                txtinterest.Text.Remove(txtinterest.Text.Length - 1);
                txtinterest.Text = "";
            }
        }

        private void txtEmailId_TextChanged(object sender, EventArgs e)
        {
            
        }

        /*
         * Created By :- PriTesh D. Sortee
         * Created Date:- 16 Oct 2015
         * Purpose: Check whether enterd text is in numbers
         */
        #region--------------------------------txtduration_textChanged----------------------------
        private void txtduration_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtduration.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please Enter Only Numbers.");
                    txtduration.Text.Remove(txtduration.Text.Length - 1);
                    txtduration.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }
        #endregion
        /*
         * Created By :- PriTesh D. Sortee
         * Created Date:- 16 Oct 2015
         * Purpose: Check whether enterd text is in numbers
         */
        #region--------------------------------txtduration_textChanged----------------------------
        private void txtmobileNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtmobileNo.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please Enter Only Numbers.");
                    txtmobileNo.Text.Remove(txtmobileNo.Text.Length - 1);
                    txtmobileNo.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        /*
         * Created By :- PriTesh D. Sortee
         * Created Date:- 16 Oct 2015
         * Purpose: Clear Fiealds
         */
        #region------------------------------ClearFields-----------------------------------
        private void ClearFields()
        {
            txtinstallmentDate.Text = "";
            txtfullname.Text = "";
            txtcurrentAddress.Text = "";
            txtPermanantAddress.Text = "";
            txtEmailId.Text = "";
            txtmobileNo.Text = "";
            cbPaymentmode.Text = "--Select--";
            txtchequeNo.Text = "";
            txtAmount.Text = "";
            txtduration.Text = "";
            txtinterest.Text = "";
            btnSave.Text = "Save";
            getCustomerId();
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

    }
}
 