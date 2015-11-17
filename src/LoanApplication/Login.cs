using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entity;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;

namespace LoanApplication
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void btnCreateuser_Click(object sender, EventArgs e)
        {
            string Output = string.Empty;
            try
            {
                EntAdduser objentadduser = new EntAdduser();
                objentadduser.LoginUserName = txtUserName.Text;
                objentadduser.Password = txtpassword.Text;
                BLAdduser objbladduser = new BLAdduser();
                DataTable dt = objbladduser.AddUser(objentadduser);
                HomeMDI objmdi = new HomeMDI();
                BLlogin objlogin = new BLlogin();
                string Expirydate = null;
                if (dt.Rows.Count > 0)
                {
                    Expirydate = dt.Rows[0]["ExpiryDate"].ToString();
                    DateTime currentdate = DateTime.Now;
                    DateTime expirydate = Convert.ToDateTime(Expirydate);
                    if (currentdate == expirydate)
                    {
                        MessageBox.Show("Your Application Is Going to Expire Today..!!! Please Contact your Support");
                        this.Visible = false;
                        objmdi.Show();
                    }
                    else if (currentdate > expirydate)
                    {
                        MessageBox.Show("Sorry...Your Application Is Expired....!!! Please Contact your Support");
                        objmdi.Close();
                    }
                    else
                    {
                        MessageBox.Show("Welcome...To Loan Application!!!!");
                        this.Visible = false;

                        HomeMDI objHomeMdi = new HomeMDI();
                        Login loginPage = new Login();
                        if (objHomeMdi.ShowDialog() == DialogResult.OK)
                        {
                            Application.Run(new HomeMDI());
                            
                        }
                        else
                        {
                            Application.Exit();
                        }

                        
                        InitializeComponent();
                    }
                    txtpassword.Text = "";
                    txtUserName.Text = "";
                }
                else
                {
                    MessageBox.Show("Username Or Password Not Match");
                    txtpassword.Text = "";
                    txtUserName.Text = "";
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
