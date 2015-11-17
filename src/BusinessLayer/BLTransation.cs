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
  public  class BLTransation
    { 
        public string SaveCustomer(Entity.EntTransaction objentcustomerDetails)
        {
            try
            {
                DLTransaction objDLCustomerDetail = new DLTransaction();
                return objDLCustomerDetail.SaveCustomer(objentcustomerDetails);
            }
            catch (Exception ex)
            {
                throw ex; 
            } 
            finally
            { 
                // objDLCustomerDetail = null; 
            }
        } 
        public DataTable getCustomerId()
        { 
            DLTransaction objDLCustomerDetails = new DLTransaction();
            DataTable dt = objDLCustomerDetails.getCustomerId();
            return dt;
        }
        public DataTable BindFullGrid()
        { 
            DLTransaction objDAL = new DLTransaction();
            return objDAL.BindFullGrid();
        }
        public DataTable searchData(EntTransaction objentransaction)
        {
            DLTransaction objdltransaction = new DLTransaction();
            DataTable dt = objdltransaction.searchData(objentransaction);
            return dt; 
        }

        public int delertRecord(EntTransaction objent)
        {
            DLTransaction objdl = new DLTransaction();
           int result = objdl.deleteRecord(objent);
           return result;
        } 
        public DataTable FetchTransaction(int TransactionId)
        {
            DLTransaction objDAL = new DLTransaction();
            return objDAL.FetchTransaction(TransactionId);
        }



        //public string AddPayment(EntTransaction objentcustomerDetails)
        //{
        //    DLTransaction objDLCustomerDetail = new DLTransaction();
        //    return objDLCustomerDetail.AddPayment(objentcustomerDetails);
        //}

        //public DataSet getData(int GroupID)
        //{
        //    DLTransaction objDLCustomerDetail = new DLTransaction();
        //    return objDLCustomerDetail.getData(GroupID);
        //}
        public DataTable GetEndDate(int GroupID)
        {
            DLTransaction objDAL = new DLTransaction();
            DataTable dt = objDAL.GetEndDate(GroupID);
            return dt;
        }

    }
}
