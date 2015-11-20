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
using System.Text.RegularExpressions;
namespace LoanApplication
{
    public partial class CustomerDetails : Form
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        public CustomerDetails()
        {
            InitializeComponent();
            EntCustomerDetails objentcustomerDetails = new EntCustomerDetails();
            getCustomerId();
            FillCustomerNames();
            bindGrid();
        
        }
        public void FillCustomerNames()
        {
            try
            {
                DataTable dt = new DataTable();
                BLCustomerDetails objBL = new BLCustomerDetails();
                dt = objBL.getCustomerNames();
                if (dt.Rows.Count > 0)
                {
                    cbCustomerName.DataSource = dt;
                    cbCustomerName.DisplayMember = "Name";
                    cbCustomerName.ValueMember = "CustomerId";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString());

            }
        }
        public void getCustomerId()
        {
            BLCustomerDetails obblcustomerDetails = new BLCustomerDetails();
            DataTable dt = obblcustomerDetails.getCustomerId();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                        {
                            int a = 1;
                            txtcustomerId.Text = Convert.ToString(a);
                        }
                        else
                        {
                            txtcustomerId.Text = dt.Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {
                    if (btnSave.Text == "Save")
                    {
                        string result = "";
                        string Output = string.Empty;
                        EntCustomerDetails objentcustomerDetails = new EntCustomerDetails();
                        objentcustomerDetails.CustomerId = Convert.ToInt32(txtcustomerId.Text);
                        objentcustomerDetails.Name = txtcustomername.Text;
                        objentcustomerDetails.MobileNumber = txtmobileNo.Text;
                        objentcustomerDetails.AlternateMobileNo = txtAlternatemobileNo.Text;
                        objentcustomerDetails.Address = txtAddress.Text;
                        objentcustomerDetails.Reference = txtreference.Text;
                        objentcustomerDetails.Nominee = txtnominee.Text;
                        objentcustomerDetails.CreatedDate = DateTime.Now;
                        objentcustomerDetails.CreatedDate = Convert.ToDateTime(txtdate.Text);
                        if (cknotification.Checked == true)
                        {
                            result = "yes";
                        }
                        else
                        {
                            result = "No";
                        }
                        objentcustomerDetails.RequiredSMSnotification = result;
                        objentcustomerDetails.BankName = txtbankName.Text;
                        objentcustomerDetails.BankAccountNo = txtbankAccount.Text;
                        BLCustomerDetails objblcustomerdetails = new BLCustomerDetails();
                        Output = objblcustomerdetails.SaveCustomer(objentcustomerDetails);
                        if (Output == "This record already exists!")
                        {
                            MessageBox.Show(Output);
                        }
                        else
                        {
                            MessageBox.Show("Customer Added Sucessfully..");
                        }
                        // ClearFields();
                        ClearFields();
                        getCustomerId();
                        bindGrid();
                        FillCustomerNames();
                    }
                    else
                    {
                        string result = "";
                        string Output = string.Empty;
                        EntCustomerDetails objentcustomerDetails = new EntCustomerDetails();
                        objentcustomerDetails.CustomerId = Convert.ToInt32(txtcustomerId.Text);
                        objentcustomerDetails.Name = txtcustomername.Text;
                        objentcustomerDetails.MobileNumber = txtmobileNo.Text;
                        objentcustomerDetails.AlternateMobileNo = txtAlternatemobileNo.Text;
                        objentcustomerDetails.Address = txtAddress.Text;
                        objentcustomerDetails.Reference = txtreference.Text;
                        objentcustomerDetails.Nominee = txtnominee.Text;
                        //objentcustomerDetails.CreatedDate = DateTime.Now;
                        objentcustomerDetails.CreatedDate = Convert.ToDateTime(txtdate.Text);
                        if (cknotification.Checked == true)
                        {
                            result = "yes";
                        }
                        else
                        {
                            result = "No";
                        }
                        objentcustomerDetails.RequiredSMSnotification = result;
                        objentcustomerDetails.BankName = txtbankName.Text;
                        objentcustomerDetails.BankAccountNo = txtbankAccount.Text;
                        BLCustomerDetails objblcustomerdetails = new BLCustomerDetails();
                        Output = objblcustomerdetails.UpdateCustomer(objentcustomerDetails);
                        if (Output == "This record already exists!")
                        {
                            MessageBox.Show(Output);
                        }
                        else
                        {
                            MessageBox.Show("Customer Updated Sucessfully!!! ");
 
                        }
                        btnSave.Text = "Save";
                        ClearFields();
                        getCustomerId();
                        bindGrid();
                        FillCustomerNames();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public void ClearFields()
        {
            txtcustomername.Text = "";
            txtmobileNo.Text = "";
            txtAlternatemobileNo.Text = "";
            txtAddress.Text = "";
            txtnominee.Text = "";
            txtreference.Text = "";
            txtdate.Text = "";
            txtbankAccount.Text = "";
            txtbankName.Text = "";
            cknotification.Checked = false;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
                        
            if ((txtcustomername.Text != "") || (txtmobileNo.Text != "") || (txtAddress.Text != "") || (txtnominee.Text != "") || (txtreference.Text != "") || (txtdate.Text != "") || (txtbankAccount.Text != "") || (txtbankName.Text != ""))
            {
                DialogResult result = MessageBox.Show("Record Is not Saved Do you Want To Save!", "Want to Save Record", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveCutomerDetails();
                }
                else
                {
                    btnSave.Text = "Save";
                    ClearFields();
                    getCustomerId();
                }
            }
            
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void bindGrid()
        {
            try
            {
                DataTable dt = new DataTable();
                BLCustomerDetails objBL = new BLCustomerDetails();
                dt = objBL.BindFullGrid();
                if (dt.Rows.Count != 0)
                {

                    dataGridView1.DataSource = dt;
                    //dataGridView1.Columns[-1].HeaderCell.Value = "Row Number";
                    dataGridView1.Columns[0].HeaderCell.Value = "Sr.No";
                    dataGridView1.Columns[0].Visible = false;
                    
                    
                    dataGridView1.ReadOnly = true;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.Refresh();
                    dataGridView1.Show();
                }
                else
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchCustomer();
        }
        private void searchCustomer()
        {
            try
            {
                DataTable dt = new DataTable();
                BLCustomerDetails objBL = new BLCustomerDetails();
                EntCustomerDetails objent = new EntCustomerDetails();
                
                
                    objent.CustomerId = Convert.ToInt32(cbCustomerName.SelectedValue);
                    objent.Name = cbCustomerName.Text;
                    dt = objBL.searchCustomer(objent);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                        
                        dataGridView1.Columns["CustomerId"].Visible = false;
                        //dataGridView1.Columns[1].HeaderCell.Value = "Sr.No";
                        
                        dataGridView1.Refresh();
                        dataGridView1.Show();
                    }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do You Want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.OK))
                {
                    deleteRecord();
                    FillCustomerNames();
                }
                else
                {
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Internal Error Occured");
            }

        }
        public void deleteRecord()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Usp_DeleteCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                int id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                cmd.Parameters.AddWithValue("@CustomerId", id);
                string result = Convert.ToString(cmd.ExecuteScalar());
               if (result == "This Customer Already in Group,So you cannot delete this Customer!")
               {
                   MessageBox.Show("This Customer Already in Group,So you cannot delete this Customer!", "Cannot Delete", MessageBoxButtons.OKCancel);
               }
               else
               {
                   con.Close();
                   MessageBox.Show("Record Deleted Sucessfully..");
               }
                bindGrid();

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
            updateCustomer();
        }
        private void updateCustomer()
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    txtcustomerId.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["CustomerId"].Value);
                    txtcustomername.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Name"].Value);
                    txtmobileNo.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Mobile No"].Value);
                    txtAlternatemobileNo.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Alternate No"].Value);
                    txtAddress.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Address"].Value);
                    txtreference.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Reference"].Value);
                    txtnominee.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Nominee"].Value);
                    txtbankName.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Bank Name"].Value);
                    txtbankAccount.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Bank Account No"].Value);
                    txtdate.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Date"].Value);
                    string reqnoti = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Required Notification"].Value);
                    if (reqnoti != "Yes")
                        cknotification.Checked = true;
                    else
                        cknotification.Checked = false ;
                    tabControl1.SelectedIndex = 0;
                    btnSave.Text = "Update";
                }
                else
                {
                    MessageBox.Show("Please Select the record..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void txtcustid_TextChanged(object sender, EventArgs e)
        {
        }
        public bool Validate()
        {

            if (string.IsNullOrEmpty(txtcustomername.Text))
            {
                MessageBox.Show("Customer Name Can Not be Empty..");
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtcustomername.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("Customer Name should be only characters");
                //txtcustomername.Text.Remove(txtcustomername.Text.Length - 1);
                txtcustomername.Text = "";
                txtcustomername.Focus();
                return false;
            }
            
            else if (string.IsNullOrEmpty(txtmobileNo.Text))
            {
                MessageBox.Show("Mobile Number Can Not be Empty..");
                return false;
            }
            else if (txtmobileNo.Text.Length != 10)
            {
                MessageBox.Show("Invalid Mobile Number");
                txtmobileNo.Focus();
                return false;
            }
            else if (txtAlternatemobileNo.Text.Length != 0 && txtAlternatemobileNo.Text.Length != 10)
            {
                
                    MessageBox.Show("Invalid AlternetMobile Number");
                    txtAlternatemobileNo.Focus();
                    return false;

                }
            
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Address Can Not be Empty..");
                return false;
            }
            if (txtbankName.Text != "")
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtbankName.Text, "^[a-zA-Z]"))
                {
                    MessageBox.Show("Bank Name should be only characters");
                    //txtcustomername.Text.Remove(txtcustomername.Text.Length - 1);
                    txtbankName.Text = "";
                    txtbankName.Focus();
                    return false;
                }
            }
            //else if (txtbankName.Text != "" && txtbankAccount.Text == "")
            //{

            //    MessageBox.Show("Please enter Bank Account Number");
            //    txtbankName.Focus();
            //    return false;

            //}
             if (txtnominee.Text != "")
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtnominee.Text, "^[a-zA-Z]"))
                {
                    MessageBox.Show("Nominee Name should be only characters");
                    //txtcustomername.Text.Remove(txtcustomername.Text.Length - 1);
                    txtnominee.Text = "";
                    txtnominee.Focus();
                    return false;
                }
                return true;   

            }
            else
            {
                return true;
            }
        }

        #region-----------------------------all Keydown Events----------------------------------
        private void txtcustomername_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtmobileNo.Select();
            }
        }
        private void txtmobileNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtAlternatemobileNo.Select();
            }
        }
        private void txtAlternatemobileNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtAddress.Select();
            }
        }
        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtreference.Select();
            }
        }
        private void txtreference_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtnominee.Select();
            }
        }
        private void txtnominee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtdate.Select();
            }
        }
        private void txtdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtnominee.Select();
            }
        }
        private void cknotification_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //cbidentityproof.Select();
            }
        }
        private void cbidentityproof_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtbankName.Select();
            }
        }
        private void txtbankName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtbankAccount.Select();
            }
        }
        private void txtbankAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //txtCreditCardNo.Select();
            }
        }
        private void txtCreditCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnSave.Select();
            }
        }
        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

            }
        }
        #endregion

        private void cbselectall_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbselectall.Checked == true)
                {
                    bindGrid();
                    cbCustomerName.Enabled = false;
                    btnSearch.Enabled = false;
                }
                else
                {
                    cbCustomerName.Enabled = true;
                    btnSearch.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        #region-------------------txtmobileNo_TextChanged-------------------
        private void txtmobileNo_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtmobileNo.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only 10 digit Mobile numbers.");
                txtmobileNo.Text.Remove(txtmobileNo.Text.Length - 1);
                txtmobileNo.Text = "";
            }
        }
        #endregion

        #region------------------txtAlternatemobileNo_TextChanged------------
        private void txtAlternatemobileNo_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtAlternatemobileNo.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtAlternatemobileNo.Text.Remove(txtmobileNo.Text.Length - 1);
                txtAlternatemobileNo.Text = "";
            }
        }
        #endregion


        #region-----------------------------Save Customer Details-----------------------------------------
        private void SaveCutomerDetails()
        {
            if (Validate())
            {
                if (btnSave.Text == "Save")
                {
                    string result = "";
                    string Output = string.Empty;
                    EntCustomerDetails objentcustomerDetails = new EntCustomerDetails();
                    objentcustomerDetails.CustomerId = Convert.ToInt32(txtcustomerId.Text);
                    objentcustomerDetails.Name = txtcustomername.Text;
                    objentcustomerDetails.MobileNumber = txtmobileNo.Text;
                    objentcustomerDetails.AlternateMobileNo = txtAlternatemobileNo.Text;
                    objentcustomerDetails.Address = txtAddress.Text;
                    objentcustomerDetails.Reference = txtreference.Text;
                    objentcustomerDetails.Nominee = txtnominee.Text;
                    objentcustomerDetails.CreatedDate = DateTime.Now;
                    objentcustomerDetails.CreatedDate = Convert.ToDateTime(txtdate.Text);
                    if (cknotification.Checked == true)
                    {
                        result = "yes";
                    }
                    else
                    {
                        result = "No";
                    }
                    objentcustomerDetails.RequiredSMSnotification = result;
                    objentcustomerDetails.BankName = txtbankName.Text;
                    objentcustomerDetails.BankAccountNo = txtbankAccount.Text;
                    BLCustomerDetails objblcustomerdetails = new BLCustomerDetails();
                    Output = objblcustomerdetails.SaveCustomer(objentcustomerDetails);
                    if (Output == "This record already exists!")
                    {
                        MessageBox.Show(Output);
                    }
                    else
                    {
                        MessageBox.Show("Customer Added Sucessfully..");
                    }
                    // ClearFields();
                    ClearFields();
                    getCustomerId();
                    bindGrid();
                    FillCustomerNames();
                }
                else
                {
                    string result = "";
                    string Output = string.Empty;
                    EntCustomerDetails objentcustomerDetails = new EntCustomerDetails();
                    objentcustomerDetails.CustomerId = Convert.ToInt32(txtcustomerId.Text);
                    objentcustomerDetails.Name = txtcustomername.Text;
                    objentcustomerDetails.MobileNumber = txtmobileNo.Text;
                    objentcustomerDetails.AlternateMobileNo = txtAlternatemobileNo.Text;
                    objentcustomerDetails.Address = txtAddress.Text;
                    objentcustomerDetails.Reference = txtreference.Text;
                    objentcustomerDetails.Nominee = txtnominee.Text;
                    //objentcustomerDetails.CreatedDate = DateTime.Now;
                    objentcustomerDetails.CreatedDate = Convert.ToDateTime(txtdate.Text);
                    if (cknotification.Checked == true)
                    {
                        result = "yes";
                    }
                    else
                    {
                        result = "No";
                    }
                    objentcustomerDetails.RequiredSMSnotification = result;
                    objentcustomerDetails.BankName = txtbankName.Text;
                    objentcustomerDetails.BankAccountNo = txtbankAccount.Text;
                    BLCustomerDetails objblcustomerdetails = new BLCustomerDetails();
                    Output = objblcustomerdetails.UpdateCustomer(objentcustomerDetails);
                    if (Output == "This record already exists!")
                    {
                        MessageBox.Show(Output);
                    }
                    else
                    {
                        MessageBox.Show("Customer Updated Sucessfully!!! ");

                    }
                    btnSave.Text = "Save";
                    ClearFields();
                    getCustomerId();
                    bindGrid();
                    FillCustomerNames();
                }
            }
 
        }
        #endregion
    }
}
