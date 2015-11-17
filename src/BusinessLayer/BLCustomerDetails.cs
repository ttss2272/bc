using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using DataAcessLayer;
using System.Data.SqlClient;
using System.Data;
namespace BusinessLayer
{
    public class BLCustomerDetails
    {

        public DataTable getCustomerId()
        {
            DlCustomerDetails objDLCustomerDetails = new DlCustomerDetails();
            DataTable dt = objDLCustomerDetails.getCustomerId();
            return dt;
        }

        public string SaveCustomer(EntCustomerDetails objentcustomerDetails)
        {
            string msg = "Saved";
            try
            {
                DlCustomerDetails objDLCustomerDetail = new DlCustomerDetails();
                return objDLCustomerDetail.SaveCustomer(objentcustomerDetails);
            }
            catch (Exception ex)
            {

               //MessageBox.Show(ex.Message.ToString());

            }

            finally
            {

                // objDLCustomerDetail = null;

            }
            return msg;

        }

        public DataTable getCustomerNames()
        {

            DlCustomerDetails objDAL = new DlCustomerDetails();
            return objDAL.getCustomernames();
        }


        public DataTable BindFullGrid()
        {

            DlCustomerDetails objDAL = new DlCustomerDetails();
            return objDAL.BindFullGrid();
        }



        public DataTable searchCustomer(EntCustomerDetails objent)
        {
            DlCustomerDetails objDAL = new DlCustomerDetails();
            return objDAL.SearchCustomer(objent);
        }

        public string UpdateCustomer(EntCustomerDetails objentcustomerDetails)
        {
            try
            {
                DlCustomerDetails objDLCustomerDetail = new DlCustomerDetails();
                return objDLCustomerDetail.UpdateCustomer(objentcustomerDetails);
            }
            catch (Exception ex)
            {

                throw ex;
               //MessageBox.Show(ex.Message.ToString());

            }

            finally
            {

                // objDLCustomerDetail = null;

            }
        }
    }
}
        
//public int  deleteRecord(EntCustomerDetails objent)
//{
//     DlCustomerDetails objdlcustomer = new DlCustomerDetails();
//    return objdlcustomer.deleteRecord(objent);
//}
    
