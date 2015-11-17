using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entity;
using BusinessLayer;
using Entity;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
namespace LoanApplication
{
    
    public partial class AddUser : Form
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
       
        public AddUser()
        { 
            InitializeComponent();
            ddlLogintype.Text = "--Select--";
        }
        private void btnCreateuser_Click(object sender, EventArgs e)
        {
            string Output = string.Empty;
            if (Validate())
            {
                if (btnCreateuser.Text == "Save")
                {
                    if (ddlLogintype.Text == "--Select--")
                    {
                        MessageBox.Show("Please Select Login Type");
                    }
                    else
                    {
                        EntAdduser objentadduser = new EntAdduser();
                        objentadduser.LoginType = ddlLogintype.SelectedItem.ToString();
                        objentadduser.LoginUserName = txtyuserId.Text;
                        objentadduser.Password = txtpassword.Text;
                        BLAdduser objbladduser = new BLAdduser();
                        Output = objbladduser.UserRegistration(objentadduser);
                        MessageBox.Show("New User Added Successfully..");
                        txtpassword.Text = "";
                        txtyuserId.Text = "";
                        ddlLogintype.Text = "--Select--";
                        loadcustomerGrid();
                    } 
                }
                else
                {
                    SqlConnection con = new SqlConnection(ConnectionString); 
                    con.Open(); 
                    SqlCommand cmd = new SqlCommand("Usp_UpdateUser", con); 
                    cmd.CommandType = CommandType.StoredProcedure; 
                    try
                    {
                        cmd.Parameters.AddWithValue("@UserType",ddlLogintype.Text.ToString());
                        cmd.Parameters.AddWithValue("@UserName", txtyuserId.Text.ToString());
                        cmd.Parameters.AddWithValue("@Password", txtpassword.Text.ToString());
                        txtyuserId.Enabled = false;
                        string strMessage = Convert.ToString(cmd.ExecuteScalar());
                        MessageBox.Show("Record Updated Successfully..");
                        loadcustomerGrid();
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
                    }
                
                }
            }
            else
            {
               // MessageBox.Show("Internal error occure");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool Validate()
        {
            if (ddlLogintype.Text == "")
            {
                MessageBox.Show("Please select login type");
                return false;
            }
            else if (string.IsNullOrEmpty(txtyuserId.Text))
            {
                MessageBox.Show("User Id  Can Not be Empty..");
                return false;
            }
            else if (txtyuserId.Text.Length < 6)
            {
                MessageBox.Show("User Id should be above than 6 characctor");
                return false;
            }
            else if (string.IsNullOrEmpty(txtpassword.Text))
            {
                MessageBox.Show("Password Can Not be Empty..");
                return false;
            }
            else if (txtpassword.Text.Length < 6)
            {
                MessageBox.Show("Password should be above than 6 characctor");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnupdate_Click(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
        }
        private void txtcustid_TextChanged(object sender, EventArgs e)
        {
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
        }
        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (rbselectAll.Checked == true)
                {
                    rbselectAll.Checked = false;
                    // cbuserType.Enabled = false;
                    loadcustomerGrid();
                }
                else
                {
                    if (cbuserType.Text == "--Select--")
                    {
                        MessageBox.Show("Please Select User Type");
                    }
                    else
                    {
                        serchUserIdandPassword();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void serchUserIdandPassword()
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    #region
                    SqlCommand cmd = new SqlCommand("Usp_SearchUsersByUserType", sqlCon);
                    cmd.Parameters.AddWithValue("@Usertype", cbuserType.Text.ToString());
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                        dataGridView1.Refresh();
                        dataGridView1.AllowUserToAddRows = false;
                        dataGridView1.Show();
                    }
                    else
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.Hide();
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
           
        }
        private void loadcustomerGrid()
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    #region
                    SqlCommand cmd = new SqlCommand("Usp_SearchAllUsers", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                  
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[0].HeaderCell.Value = "User Id";
                        dataGridView1.Columns[1].HeaderCell.Value = "Password";
                        dataGridView1.Columns[2].HeaderCell.Value = "User Type";
                        dataGridView1.Refresh();
                        dataGridView1.AllowUserToAddRows = false;
                        dataGridView1.Show();
                        rbselectAll.Checked = false;
                        cbuserType.Enabled = true;
                    }
                    else
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.Hide();
                    }
                    #endregion
                }
                catch (Exception ex )
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void btnupdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    ddlLogintype.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[2].Value);
                    txtyuserId.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value);
                    txtpassword.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[1].Value);
                    txtyuserId.Enabled = false;
                    btnCreateuser.Text = "Update";
                    btnupdate.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Please Select the record..");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Enternal Error Occured");
            }
        }
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You Want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                deleteRecord();
                loadcustomerGrid();
              
            }
            else
            {
            }
        }
        public void deleteRecord()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Usp_DeleteUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
               string id = dataGridView1.SelectedCells[0].Value.ToString();
                cmd.Parameters.AddWithValue("@UserId", id);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("User Deleted Sucessfully..");
                loadcustomerGrid();
            }
            catch (Exception ex )
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
        private void rbselectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbselectAll.Checked == true)
            {
                cbuserType.Enabled = false;
                loadcustomerGrid();
            }
            else
            {
              
            }
        }
    }
}
