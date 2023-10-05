using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pudicc.Models
{
    public class Conexion
    {
        public static SqlConnection Conectar()
        {
            string conx = "DATA SOURCE = A; INITIAL CATALOG = PudiccBD; INTEGRATED SECURITY = YES;";
            //string conx = "SERVER = PudiccBD.mssql.somee.com; DATABASE = PudiccBD; USER ID = abcdefghij110_SQLLogin_1; PWD = ykwjcnxakg;";
            SqlConnection s = new SqlConnection(conx);
            return s;
        }
    }
}