using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Farmacia
{
    class cls_EMPLEADOS
    {/*
        private CLASE_CONEXION_BD Con = new CLASE_CONEXION_BD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader LeerFilas;

        public DataTable Empleados()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Con.AbrirConexion();
            Comando.CommandText = "Listar_Empleados";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Con.CerrarConexion();
            return Tabla;
        }

        public DataTable Perfiles()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Con.AbrirConexion();
            Comando.CommandText = "Listar_perfiles";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Con.CerrarConexion();
            return Tabla;
        }*/
    }
}
