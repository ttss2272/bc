using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAcessLayer;
using Entity;
using System.Data;
using System.Data.SqlClient;
namespace BusinessLayer
{
  public class BLAdduser
    {
      public DataTable AddUser(EntAdduser objentadduser)
      {
          DlAdduser  objdladduser = new DlAdduser();
         DataTable dt= objdladduser.AddUser(objentadduser);
         return dt;
      }

      public string UserRegistration(EntAdduser objentadduser)
      {
          DlAdduser objdladduser = new DlAdduser();
          string res = objdladduser.UserRegistration(objentadduser);
          return res;
      }
    }
}
