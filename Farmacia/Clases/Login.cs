using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Farmacia
{
    public class Login 
    {
        ~Login()
        {

        }

        private static string usuario;
        private static string clave;
        private static string tipousuario;
        private static int idusuario;
        public string Usuario { get => usuario; set => usuario = value; }
        public string Clave { get => clave; set => clave = value; }
        public string Tipousuario { get => tipousuario; set => tipousuario = value; }
        public int Idusuario { get => idusuario; set => idusuario = value; }

        public string login()
        {

            //sql Adapter recibir
            //SqlComand Insertar
            

            SqlDataAdapter sda = new SqlDataAdapter("EXEC VerificarLogin'" + usuario + "','" + clave + "'", clsConexion.Conexion.LeerCadena());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            


            if (dt.Rows.Count > 0)
            {
                tipousuario = dt.Rows[0][0].ToString();
                return tipousuario;
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return "";
            }       
        }
    }
}
