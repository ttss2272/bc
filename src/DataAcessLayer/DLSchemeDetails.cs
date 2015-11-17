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
    public class DLSchemeDetails
    {
        /*
-- ==================================================================================================================
-- Author:		Raj
-- Create date: 10-06-2015
-- Description:	Pass scheme dtails
-- Updated By :
-- Updated Date:
-- ==================================================================================================================  
*/

        string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

        public string InsertUserInformation(EntSchemeDetails objBELUserDetails)
        {

            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();

            SqlCommand cmd = new SqlCommand("Usp_SaveSchemeDetails", con);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                
                cmd.Parameters.AddWithValue("@BCId", objBELUserDetails.BCId);
                cmd.Parameters.AddWithValue("@BCName", objBELUserDetails.BCName);
                cmd.Parameters.AddWithValue("@StartDate", objBELUserDetails.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", objBELUserDetails.EndDate);
                cmd.Parameters.AddWithValue("@Amount", objBELUserDetails.Amount);
                cmd.Parameters.AddWithValue("@Duration", objBELUserDetails.Duration);
                cmd.Parameters.AddWithValue("@InstallmentDate", objBELUserDetails.InstallmentDate);
                cmd.ExecuteNonQuery();
                string strMessage = "Data Saved";

                con.Close();

                return strMessage;

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

        }
        public DataTable GetSchemeNames()
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    #region 
                    SqlDataAdapter da = new SqlDataAdapter("select BCName  from BCSchemeDetails", sqlCon);
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
                    SqlDataAdapter da = new SqlDataAdapter("select * from BCSchemeDetails", sqlCon);
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

        //public DataTable GetSearchResult(string schemename)
        //{
        //    string scheme = schemename;
        //    using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
        //    {
        //        try
        //        {
        //            //#region
        //            //SqlDataAdapter da = new SqlDataAdapter("select * from BCSchemeDetails where BCName =  ", sqlCon);
        //            //DataSet ds = new DataSet();
        //            //da.Fill(ds);
        //            //return ds.Tables[0];
        //            //#endregion
        //        }
        //        catch (Exception eo)
        //        {
        //            throw eo;
        //        }
        //    }
        //}
    }
}

