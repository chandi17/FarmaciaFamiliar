using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace clsConsultas
{
    public static class Consultas
    {
        static SqlDataAdapter sda;
        static SqlCommand cmd;
        static DataTable dt;
        public static DataTable consultaGeneral(string Consulta)
        {
            sda = new SqlDataAdapter(Consulta, clsConexion.Conexion.LeerCadena());
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static DataTable consultaEspecifica(string Consulta,string nombre)
        {
            SqlCommand com = new SqlCommand(Consulta + " " + nombre, clsConexion.Conexion.LeerCadena());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static void EliminarRegistro(string Consulta, string nombre)
        {
            


            SqlCommand com = new SqlCommand(Consulta, clsConexion.Conexion.LeerCadena());
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", nombre);
            com.ExecuteNonQuery();
            

        }
    }
}
