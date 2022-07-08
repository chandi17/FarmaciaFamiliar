 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Farmacia
{
    class ClCategoriaProducto 
    {

        private static String nombre;

        public string Nombre { get => nombre; set => nombre = value; }


        SqlDataAdapter sda;
        SqlCommand cmd;
        DataTable dt;
        public void cargarDatos(DataGridView dgvCategoriaProducto)
        {
            try
            {
                


                sda = new SqlDataAdapter("EXEC ConsultaCategoriaProductoGeneral", clsConexion.Conexion.LeerCadena());
                dt = new DataTable();
                sda.Fill(dt);
                dgvCategoriaProducto.DataSource = dt;
                clsConexion.Conexion.LeerCadena();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR " + ex);
            }
        }
        public void agregarCategoriaProducto()
        {
            clsConexion.Conexion.LeerCadena();
            SqlCommand cmd = new SqlCommand("InsertarCategoriaProducto", clsConexion.Conexion.LeerCadena());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NombreCategoria", nombre);
            cmd.ExecuteNonQuery();
            clsConexion.Conexion.LeerCadena();
            MessageBox.Show("La Categoria se ha insertado Satisfactoriamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void eliminarCategoriaProducto(DataGridView dgvCategoriaProducto, String index)
        {
            index = dgvCategoriaProducto.CurrentRow.Cells[0].Value.ToString();

            DialogResult x = MessageBox.Show("¿Está seguro de que desea eliminar esta Categoria?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            try
            {
                if (x == DialogResult.Yes)
                {
                    clsConexion.Conexion.LeerCadena();
                    cmd = new SqlCommand("EliminarCategoriaProducto", clsConexion.Conexion.LeerCadena());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", int.Parse(index));
                    cmd.ExecuteNonQuery();
                    

                    MessageBox.Show("La Categoria ha sido eliminada exitosamente", "Exito", MessageBoxButtons.OK);
                    cargarDatos(dgvCategoriaProducto);
                }
            }
            catch (Exception e)
            {
               MessageBox.Show("Error " + e);
                MessageBox.Show("Hola " + e);
            }
        }
    }
}
