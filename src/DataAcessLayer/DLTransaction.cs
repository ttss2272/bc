using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Entity;
namespace DataAcessLayer
{
   public class DLTransaction
    {
       string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
     
        public string SaveCustomer(Entity.EntTransaction objentcustomerDetails)
        {
            string strMessage=null;
            SqlConnection con = new SqlConnection(ConnectionString); 
            con.Open();  
            SqlCommand cmd = new SqlCommand("Usp_SaveTransaction", con); 
            cmd.CommandType = CommandType.StoredProcedure; 
            try
            {
                cmd.Parameters.AddWithValue("@TransactionId", objentcustomerDetails.TransactionId);
                cmd.Parameters.AddWithValue("@Amount", objentcustomerDetails.Amount);
                cmd.Parameters.AddWithValue("@Month", objentcustomerDetails.Month);
                cmd.Parameters.AddWithValue("@Member", objentcustomerDetails.Member);
                cmd.Parameters.AddWithValue("@amountofmonth", objentcustomerDetails.amountofmonth);
                cmd.Parameters.AddWithValue("@Percentage", objentcustomerDetails.Percentage);
                cmd.Parameters.AddWithValue("@RemainingMonths", objentcustomerDetails.RemainingMonths);
                cmd.Parameters.AddWithValue("@GroupName", objentcustomerDetails.GroupName);
                cmd.Parameters.AddWithValue("@MemberList", objentcustomerDetails.MemberList);
                cmd.Parameters.AddWithValue("@OffcetPrice", objentcustomerDetails.OffcetPrice);
                cmd.Parameters.AddWithValue("@Loss", objentcustomerDetails.Loss);
                cmd.Parameters.AddWithValue("@ActualAmountforBCCustomer", objentcustomerDetails.ActualAmountforBCCustomer);
                cmd.Parameters.AddWithValue("@Drawa", objentcustomerDetails.Drawa);
                cmd.Parameters.AddWithValue("@ActualInstallment", objentcustomerDetails.ActualInstallment);
                cmd.Parameters.AddWithValue("@BcRecriverMember", objentcustomerDetails.BcRecriverMember);
              //  DateTime da = DateTime.Now;
                cmd.Parameters.AddWithValue("@BcDate",objentcustomerDetails.BcDate);
                cmd.Parameters.AddWithValue("@DueDate", objentcustomerDetails.DueDate);
                cmd.Parameters.AddWithValue("@Installment", objentcustomerDetails.Installment);
                cmd.Parameters.AddWithValue("@CustomerId",objentcustomerDetails.CustomerId);
                cmd.Parameters.AddWithValue("@GroupId", objentcustomerDetails.GroupId);

                cmd.Parameters.AddWithValue("@Drawa1Name",objentcustomerDetails.Drawa1Name );
                cmd.Parameters.AddWithValue("@Drawa2Name", objentcustomerDetails.Drawa2Name);
                cmd.Parameters.AddWithValue("@Drawa2Amount", objentcustomerDetails.Drawa2Amount);
                cmd.Parameters.AddWithValue("@RunerUpName", objentcustomerDetails.RunnerUpName);
                cmd.Parameters.AddWithValue("@RunerUpAmount", objentcustomerDetails.RunnerUpAmount);

                strMessage = cmd.ExecuteNonQuery().ToString();
                 //= "Data Saved";


                con.Close(); 
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
            return strMessage;
            //string msg = "saved";
            //return msg;
        }
        public DataTable getCustomerId()
        {
            SqlConnection con = new SqlConnection(ConnectionString); 
            con.Open(); 
            SqlCommand cmd = new SqlCommand("Usp_getTransactionId", con); 
            cmd.CommandType = CommandType.StoredProcedure; 
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDa.Fill(dt);
            return dt; 
        }
        public DataTable BindFullGrid()
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    #region
                    SqlCommand cmd = new SqlCommand("Usp_BindGrid",sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
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

        public DataTable searchData(EntTransaction objentransaction)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            try 
            
            {
                #region

                SqlCommand cmd = new SqlCommand("Usp_SearchDatabydate", sqlCon);
                cmd.Parameters.AddWithValue("@FromDate", objentransaction.FromDate);
                cmd.Parameters.AddWithValue("@ToDate", objentransaction.ToDate);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
               
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
                #endregion 
                

            }
            catch(Exception ex)
            {
                throw ex;
              // MessageBox.Show(ex.Message.ToString());
            }
             finally
                {
                }
        }

        public int deleteRecord(EntTransaction objent)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Usp_DeleteTransaction", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            { 
                cmd.Parameters.AddWithValue("@TransactionId", objent.TransactionId);
                int result = cmd.ExecuteNonQuery();
                return result;
                con.Close();
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

        public DataTable FetchTransaction(int TransactionId)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    #region
                    SqlCommand cmd = new SqlCommand("Usp_FetchTransaction", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransactionId",TransactionId);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
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



        public string AddPayment(EntTransaction objentcustomerDetails)
        {
            try
            {
            string strMessage = null;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Usp_SavePaymentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TransactionID", objentcustomerDetails.TransactionId);
            cmd.Parameters.AddWithValue("@GroupID", objentcustomerDetails.GroupId);
            cmd.Parameters.AddWithValue("@BCReceiverID", objentcustomerDetails.BcRecriverMember);
            cmd.Parameters.AddWithValue("@DeuDate", objentcustomerDetails.DueDate);
            cmd.Parameters.AddWithValue("@DebitAmount", objentcustomerDetails.Amount);
            cmd.Parameters.AddWithValue("@CreditAmount", objentcustomerDetails.ActualAmountforBCCustomer);
            strMessage = cmd.ExecuteNonQuery().ToString();
            return strMessage;
            }
            catch (Exception eo)
            {
                throw eo;
            }
            
        }

        //public DataSet getData(int GroupID)
        //{
        //    try
        //    {
        //        SqlConnection con = new SqlConnection(ConnectionString);
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("Usp_GetGroupIDforPayment", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@GroupID", GroupID);
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataSet ds = new DataSet();
        //        da.Fill(ds);
        //        con.Close();
        //        return ds;
        //    }
        //    catch (Exception eo)
        //    {
        //        throw eo;
        //    }
        //}
        public DataTable GetEndDate(int GroupID)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {


                SqlCommand cmd = new SqlCommand("Usp_CheckTranscationDate", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@GroupId", GroupID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
 
        }
       }
}
