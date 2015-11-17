using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;

namespace Global
{
    public class Class1
    {
         public SqlConnection GetConnection()
        {
          
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString);
            return conn;
        }
    }
    
     
}
