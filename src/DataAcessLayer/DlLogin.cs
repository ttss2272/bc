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
    
  public class DlLogin
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

        public string InsertUserInformation(EntLogin objentlogin)
        {
            string msg = "Saved";
            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();

            SqlCommand cmd = new SqlCommand("GetLoginDetails", con);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {

                cmd.Parameters.AddWithValue("@LoginuserId",objentlogin.LoginuserId);
                cmd.Parameters.AddWithValue("@LoginTypeId",objentlogin.LoginTypeId);
                cmd.Parameters.AddWithValue("@LoginUserName", objentlogin.LoginUserName);
                cmd.Parameters.AddWithValue("@Password", objentlogin.Password);
                cmd.ExecuteNonQuery();
                string strMessage = "User registred";

                con.Close();

                return strMessage;

            }

            catch (Exception ex)
            {

              // MessageBox.Show(ex.Message.ToString());

            }

            finally
            {

                cmd.Dispose();

                con.Close();

                con.Dispose();

            }
            return msg;
        }

        public SqlDataReader checklogin(string username, string password, string usertType)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("checklogin", con);
            SqlParameter param = new SqlParameter("@Username", username);
            SqlParameter param1 = new SqlParameter("@Password", password);
            SqlParameter param2 = new SqlParameter("@LoginType", usertType);
          
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.String;
            param1.Direction = ParameterDirection.Input;
            param1.DbType = DbType.String;

            param2.Direction = ParameterDirection.Input;
            param2.DbType = DbType.String;

            cmd.Parameters.Add(param);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }
    }
}
