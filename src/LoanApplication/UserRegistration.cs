using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entity;
using System.Data;
using System.Data.SqlClient;
using BusinessLayer;
using System.Configuration;

namespace LoanApplication
{
    public partial class UserRegistration : Form
    {
        public UserRegistration()
        {
            InitializeComponent();
        }
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
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
                        if (Output == "1")
                        {
                            MessageBox.Show("New User Added Successfully..");
                        }
                        else
                        {
                            MessageBox.Show("User Name Already Exists...");
                        }
                        txtpassword.Text = "";
                        txtyuserId.Text = "";
                        ddlLogintype.Text = "--Select--"; 
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
                        cmd.Parameters.AddWithValue("@UserType", ddlLogintype.Text.ToString());
                        cmd.Parameters.AddWithValue("@UserName", txtyuserId.Text.ToString());
                        cmd.Parameters.AddWithValue("@Password", txtpassword.Text.ToString());
                        txtyuserId.Enabled = false;
                        string strMessage = Convert.ToString(cmd.ExecuteScalar());
                        MessageBox.Show("Record Updated Successfully..");
                        //loadcustomerGrid();
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

        private void UserRegistration_Load(object sender, EventArgs e)
        {
            ddlLogintype.Text = "--Select--";
        }
    }
}
