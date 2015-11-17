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
namespace BusinessLayer
{
    public  class BLlogin
    {
       
        public string InsertUserDetails(EntLogin objentlogin)
        {
            string strMessage = "Data Saved";
            DlLogin objdllogin = new DlLogin();
            try
            {
                return objdllogin.InsertUserInformation(objentlogin);//pass entity object

            }

            catch (Exception ex)
            {

              // MessageBox.Show(ex.Message.ToString());

            }

            finally
            {

                objdllogin = null;
               

            }
            return strMessage;
        }

        public SqlDataReader checklogin(string username, string password, string usertType)
        {

            DlLogin oblldlogin = new DlLogin();
            try
            {
                SqlDataReader dr = oblldlogin.checklogin(username, password, usertType);
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
