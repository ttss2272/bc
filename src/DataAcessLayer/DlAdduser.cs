using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAcessLayer;
using Entity;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
namespace DataAcessLayer
{
   public  class DlAdduser
    {
       string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

        public DataTable AddUser(EntAdduser objentadduser)
        {
            // string strMessage = "Login";
            SqlConnection con = new SqlConnection(ConnectionString); 
            con.Open();  
            DataTable dt=null;
            SqlCommand cmd = new SqlCommand("Usp_AddNewUsers", con); 
            cmd.CommandType = CommandType.StoredProcedure; 
            try
            {  
                cmd.Parameters.AddWithValue("@UserId", objentadduser.LoginUserName);
                cmd.Parameters.AddWithValue("@Paswored",objentadduser.Password);
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                dt= new DataTable();
                sqlDa.Fill(dt); 
            } 
            catch (Exception ex)
            { 
               //MessageBox.Show(ex.Message.ToString()); 
            } 
            finally
            { 
                cmd.Dispose(); 
                con.Close(); 
                con.Dispose(); 
            }
            return dt;   
        }

        public string UserRegistration(EntAdduser objentadduser)
        {
             string strMessage = "Add User";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open(); 
            SqlCommand cmd = new SqlCommand("Usp_UserRegistration", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
                cmd.Parameters.AddWithValue("@UserType", objentadduser.LoginType);
                cmd.Parameters.AddWithValue("@UserId", objentadduser.LoginUserName);
                cmd.Parameters.AddWithValue("@Paswored", objentadduser.Password);
                strMessage=cmd.ExecuteNonQuery().ToString(); 
            
                //MessageBox.Show(ex.Message.ToString()); 
            
            
                cmd.Dispose();
                con.Close();
                con.Dispose();
            
            return strMessage;   
        }
    }
}
