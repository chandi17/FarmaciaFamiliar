using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace clsConexion
{
     public static class Conexion
    {

        public static SqlConnection LeerCadena()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["unica"].ConnectionString);
            if(cn.State == ConnectionState.Open)
            {
                cn.Close();

            }
            else
            {
                cn.Open();
            }
            return cn;
        }
     }
}
