using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAcessLayer;
using Entity;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
namespace BusinessLayer
{
    /*
-- =================================================================================================
-- Author:		Raj
-- Create date: 10-06-2015
-- Description:	Pass scheme dtails
-- Updated By :
-- Updated Date:
-- =================================================================================================  
*/
    public class BLSchemeDetails
    {
        public string InsertUserDetails(EntSchemeDetails objUserDetails)//passed entity object
        {

          
            DLSchemeDetails objdlschemedetails = new DLSchemeDetails();//create DAL object

            try
            {
                return objdlschemedetails.InsertUserInformation(objUserDetails);//pass entity object
               // return string = "saved";
               
            }

            catch (Exception ex)
            {

              // MessageBox.Show(ex.Message.ToString());

            }

            finally
            {

                objdlschemedetails = null;

            }

        }

        public DataTable GetSchemeNames()
          {
            DLSchemeDetails objDAL = new DLSchemeDetails();
            return objDAL.GetSchemeNames();
           }

        public DataTable BindFullGrid()
        {
            DLSchemeDetails objDAL = new DLSchemeDetails();
            return objDAL.BindFullGrid();
        }

        public DataTable GetSearchResult { get; set; }

        //public DataTable GetSearchResult(string schemename)
        //{
        //    //DLSchemeDetails objDAL = new DLSchemeDetails();
        //    //return objDAL.GetSearchResult(string schemename);
        //}
    } 
}
