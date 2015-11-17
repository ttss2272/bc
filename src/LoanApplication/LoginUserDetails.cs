using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLayer;
using Entity;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
namespace LoanApplication
{
    public partial class LoginUserDetails : Form
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        public LoginUserDetails()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string username = txtyuserId.Text;
            string password = txtpassword.Text;
            string usertType = ddlLogintype.SelectedItem.ToString();
            BLlogin objbllogin = new BLlogin();
            SqlDataReader drLogin = objbllogin.checklogin(username, password, usertType);
            if (drLogin.HasRows == true)
            {
                drLogin.Read();
                string type = drLogin["LoginType"].ToString();
                int LoginId = int.Parse(drLogin["LoginuserId"].ToString());
                HomeMDI objhomemdi = new HomeMDI();
                objhomemdi.Show();
                drLogin.Close();
            }
            else
            {
                MessageBox.Show("Incorrect UserId or Password");
                LoginUserDetails objloginuserdetails = new LoginUserDetails();
                objloginuserdetails.Show();
            }
        }
    }
}
