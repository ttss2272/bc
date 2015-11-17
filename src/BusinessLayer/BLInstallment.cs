using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataAcessLayer;

namespace BusinessLayer
{
   public class BLInstallment
    {
        public string SaveInstallmentForGroupMembers(Entity.EntTransaction objentcustomerDetails)
        {
            DLInstallment objDLCustomerDetail = new DLInstallment();
            return objDLCustomerDetail.SaveInstallmentForGroupMembers(objentcustomerDetails);
        }
    }
}
