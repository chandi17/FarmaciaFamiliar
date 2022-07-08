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
    public class ClLaboratorios 
    {
        private static int codigo;
        private static string Nombre;

        public  int Codigo { get => codigo; set => codigo = value; }
        public  string Nombre1 { get => Nombre; set => Nombre = value; }

        SqlDataAdapter sda;
        SqlCommand cmd;
        DataTable dt;

        ~ClLaboratorios()
        {

        }
        public void ConsultaGeneralLaboratorios(DataGridView dgvLaboratorio)
        {
            try
            {
                clsConexion.Conexion.LeerCadena();
                sda = new SqlDataAdapter("EXEC ConsultaLaboratorioGeneral ", clsConexion.Conexion.LeerCadena());
                dt = new DataTable();
                sda.Fill(dt);
                dgvLaboratorio.DataSource = dt;
                clsConexion.Conexion.LeerCadena();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error " + e);
            }
        }
        public void ConsultaLaboratoriosCodigo(DataGridView dgvLaboratorio, int codigo)
        {
            try
            {
                clsConexion.Conexion.LeerCadena();
                sda = new SqlDataAdapter("EXEC ConsultaLaboratorioPorID " + codigo, clsConexion.Conexion.LeerCadena());
                dt = new DataTable();
                sda.Fill(dt);
                dgvLaboratorio.DataSource = dt;
                clsConexion.Conexion.LeerCadena();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error " + e);
            }
        }

        public void ConsultaLaboratoriosNombre(DataGridView dgvLaboratorio, string nombre)
        {
            try
            {
                clsConexion.Conexion.LeerCadena();
                SqlDataAdapter sda = new SqlDataAdapter("EXEC ConsultaLaboratorioPorNombre " + nombre, clsConexion.Conexion.LeerCadena());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvLaboratorio.DataSource = dt;
                clsConexion.Conexion.LeerCadena();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error " + e);
            }
        }
        public void AgregarLaboratorio(DataGridView dgvLaboratorio, string nombre)
        {
            try
            {
                clsConexion.Conexion.LeerCadena();
                cmd = new SqlCommand("EXEC InsertarLaboratorio '" + nombre + "'", clsConexion.Conexion.LeerCadena());
                cmd.ExecuteNonQuery();
                clsConexion.Conexion.LeerCadena();
                MessageBox.Show("Laboratorio agregado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConsultaGeneralLaboratorios(dgvLaboratorio);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error " + e);
            }
        }

        public DataTable actualizarDatos(DataGridView dgvEditorial, int codigo)
        {
            string idEditorial = dgvEditorial.CurrentRow.Cells[0].Value.ToString();
            try
            {
                clsConexion.Conexion.LeerCadena();
                sda = new SqlDataAdapter("EXEC InsertarLaboratorio '" + codigo + "'", clsConexion.Conexion.LeerCadena());
                dt = new DataTable();
                sda.Fill(dt);
                


                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error " + e);
                return dt;
            }
        }




    }
}
