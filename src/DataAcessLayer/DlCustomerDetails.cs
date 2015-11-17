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
   public class DlCustomerDetails
    {
       string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
       EntCustomerDetails objEntCustomerDetails = new EntCustomerDetails();
        public DataTable getCustomerId()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Usp_GetCustomerId", con);
            cmd.CommandType = CommandType.StoredProcedure;
           
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); 
            sqlDa.Fill(dt);
            return dt;
             
        }
        
        public string SaveCustomer(EntCustomerDetails objentcustomerDetails)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
           // SqlCommand cmd = new SqlCommand("Usp_SaveCustomerDetails", con); temp comment
            SqlCommand cmd = new SqlCommand("InsertCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@CustomerId", objentcustomerDetails.CustomerId);
                cmd.Parameters.AddWithValue("@CustomerName", objentcustomerDetails.Name);
                cmd.Parameters.AddWithValue("@MobileNo", objentcustomerDetails.MobileNumber);
                cmd.Parameters.AddWithValue("@AlterNameMobileNo", objentcustomerDetails.AlternateMobileNo);
                cmd.Parameters.AddWithValue("@Address", objentcustomerDetails.Address);
                cmd.Parameters.AddWithValue("@Reference", objentcustomerDetails.Reference);
                cmd.Parameters.AddWithValue("@Nominee", objentcustomerDetails.Nominee);
                cmd.Parameters.AddWithValue("@SMSRequire", objentcustomerDetails.RequiredSMSnotification);
                cmd.Parameters.AddWithValue("@BankName", objentcustomerDetails.BankName);
                cmd.Parameters.AddWithValue("@AccountNo", objentcustomerDetails.BankAccountNo);
                DateTime da = DateTime.Now;
                cmd.Parameters.AddWithValue("@Date",da);
                //string strMessage =Convert.ToString(cmd.ExecuteNonQuery());
                string strMessage = Convert.ToString(cmd.ExecuteScalar());
               // string strMessage = "Data Saved";
                con.Close();
                return strMessage;
            }
            catch (Exception ex)
            {
                throw ex;
               //MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        public string UpdateCustomer(EntCustomerDetails objentcustomerDetails)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            // SqlCommand cmd = new SqlCommand("Usp_SaveCustomerDetails", con); temp comment
            SqlCommand cmd = new SqlCommand("Usp_SaveCustomerDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@CustomerId", objentcustomerDetails.CustomerId);
                cmd.Parameters.AddWithValue("@CustomerName", objentcustomerDetails.Name);
                cmd.Parameters.AddWithValue("@MobileNo", objentcustomerDetails.MobileNumber);
                cmd.Parameters.AddWithValue("@AlterNameMobileNo", objentcustomerDetails.AlternateMobileNo);
                cmd.Parameters.AddWithValue("@Address", objentcustomerDetails.Address);
                cmd.Parameters.AddWithValue("@Reference", objentcustomerDetails.Reference);
                cmd.Parameters.AddWithValue("@Nominee", objentcustomerDetails.Nominee);
                cmd.Parameters.AddWithValue("@SMSRequire", objentcustomerDetails.RequiredSMSnotification);
                //cmd.Parameters.AddWithValue("@Identityproof", objentcustomerDetails.IdentityProof);
                cmd.Parameters.AddWithValue("@BankName", objentcustomerDetails.BankName);
                cmd.Parameters.AddWithValue("@AccountNo", objentcustomerDetails.BankAccountNo);
                //cmd.Parameters.AddWithValue("@CreditCardNo", objentcustomerDetails.CreditcardNo);
                DateTime da = DateTime.Now;
                cmd.Parameters.AddWithValue("@Date", da);
              
                string strMessage =Convert.ToString(cmd.ExecuteScalar());
                con.Close();
                return strMessage;
            }
            catch (Exception ex)
            {
                throw ex;
              // MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        
        
        }

        public DataTable getCustomernames()
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    #region
                    SqlDataAdapter da = new SqlDataAdapter("select CustomerId,Name  from Customer where IsDeleted = 0", sqlCon);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds.Tables[0];
                    #endregion
                }
                catch (Exception eo)
                {
                    throw eo;
                }
            }
        }

        public DataTable BindFullGrid()
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    #region
                    SqlDataAdapter da = new SqlDataAdapter("select CustomerId, ROW_NUMBER() over (ORDER BY CustomerId) AS Number,Name AS 'Name',MobileNumber AS 'Mobile No',AlternateMobileNo AS 'Alternate No',[Address] AS 'Address', Reference AS 'Reference', Nominee AS 'Nominee',BankName AS 'Bank Name',BankAccountNo As 'Bank Account No',CreatedDate AS 'Date',RequiredSMSnotification As 'Required Notification' from Customer where IsDeleted = 0 ", sqlCon);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds.Tables[0];
                    #endregion
                }
                catch (Exception eo)
                {
                    throw eo;
                }
            }
        }
       
        public DataTable SearchCustomer(EntCustomerDetails objent)
        {
            string msg = "Saved";
            SqlConnection con = new SqlConnection(ConnectionString); 
            con.Open(); 
            SqlCommand cmd = new SqlCommand("Usp_SearchCustomer", con); 
            cmd.CommandType = CommandType.StoredProcedure; 
            try
            { 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", objent.CustomerId);
                cmd.Parameters.AddWithValue("@CustomerName", objent.Name);
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                return dt; 
            } 
            catch (Exception ex)
            {
                throw ex; 
            } 
            finally
            { 
                cmd.Dispose(); 
                con.Close(); 
                con.Dispose(); 
            } 
        } 
        public int deleteRecord(EntCustomerDetails objent)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Usp_DeleteCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@CustomerId",objent.CustomerId);
               int result = cmd.ExecuteNonQuery();
               // string strMessage = "Data Saved"; 
                con.Close(); 
                return result; 
            } 
            catch (Exception ex)
            {
                throw ex;
             //  MessageBox.Show(ex.Message.ToString());
            } 
            finally
            { 
                cmd.Dispose(); 
                con.Close(); 
                con.Dispose(); 
            }
        }
    }
}
