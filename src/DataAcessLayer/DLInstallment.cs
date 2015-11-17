using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entity;
using System.Configuration;



namespace DataAcessLayer
{
   public class DLInstallment
    {
       string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        public string SaveInstallmentForGroupMembers(Entity.EntTransaction objentcustomerDetails)
        {
            SqlConnection con = new SqlConnection(ConnectionString); 
            con.Open();
            SqlCommand cmd = new SqlCommand("Usp_SaveGroupInstallment", con); 
            cmd.CommandType = CommandType.StoredProcedure; 
            try
            {
                cmd.Parameters.AddWithValue("@InstallmentId", objentcustomerDetails.InstallmentId);
                cmd.Parameters.AddWithValue("@TotalAmount", objentcustomerDetails.Amount);
                cmd.Parameters.AddWithValue("@DurationInMonths", objentcustomerDetails.Month);
                cmd.Parameters.AddWithValue("@InstallmentAmount", objentcustomerDetails.amountofmonth);
                cmd.Parameters.AddWithValue("@GroupName", objentcustomerDetails.GroupName);
                cmd.Parameters.AddWithValue("@MemberName", objentcustomerDetails.MemberList);
                cmd.Parameters.AddWithValue("@ActualAmount", objentcustomerDetails.ActualAmountforBCCustomer);
                cmd.Parameters.AddWithValue("@ActualInstallment", objentcustomerDetails.ActualInstallment);
                cmd.Parameters.AddWithValue("@CustomerId", objentcustomerDetails.CustomerId);
                cmd.Parameters.AddWithValue("@GroupId", objentcustomerDetails.GroupId);
                cmd.Parameters.AddWithValue("@InstallmentStatus", objentcustomerDetails.InstallmentStatus);
                cmd.Parameters.AddWithValue("@TransactionId", objentcustomerDetails.TransactionId);
                cmd.ExecuteNonQuery();
                string strMessage = "Data Saved";
                con.Close();
                return strMessage;
            }

            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
            string msg = "saved";
            return msg;
        }

       
    }
}
