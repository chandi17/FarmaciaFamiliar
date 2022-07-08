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
        //Elmer
        //public static SqlConnection cn = new SqlConnection("Data Source = DESKTOP-2B3TCMC; Initial Catalog = FarmaciaDesarrollo; Integrated Security = True");
        //Asdrubal
        //public static SqlConnection cn = new SqlConnection("Data Source = AGALEANO; Initial Catalog = FarmaciaDesarrollo; Integrated Security = True");


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

        /*public static void abrircn()
        {
            try
            {
                cn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al conectar a base de datos " + e);
            }
        }
        public static void close()
        {
            cn.Close();
        }*/


     }
}
