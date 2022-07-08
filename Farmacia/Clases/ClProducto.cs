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
    class ClProducto
    {
        ~ClProducto()
        {

        }

        private static String nombre;
        private static float precio;
        private static int cantidad;
        private static int idlaboratorio;
        private static int idproveedor;
        private static int idcategria;
        private static int idusos;

        public float Precio { get => precio; set => precio = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public  int Idlaboratorio { get => idlaboratorio; set => idlaboratorio = value; }
        public  int Idproveedor { get => idproveedor; set => idproveedor = value; }
        public int Idcategria { get => idcategria; set => idcategria = value; }
        public  int Idusos { get => idusos; set => idusos = value; }

        SqlDataAdapter sda;
        SqlCommand cmd;
        DataTable dt;
        //Metodo encargado de Cargar los datos en el DataGridView
        public void cargarDatos(DataGridView dgvProducto)
        {
            try
            {
                


                sda = new SqlDataAdapter("EXEC ConsultaProductoGeneral2",clsConexion.Conexion.LeerCadena());
                dt = new DataTable();
                sda.Fill(dt);
                dgvProducto.DataSource = dt;
                clsConexion.Conexion.LeerCadena();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR " + ex);
            }
        }
        public void agregarProducto()
        {
            //metodo encargado en agregar un producto en la base de datos
            clsConexion.Conexion.LeerCadena();
            SqlCommand cmd = new SqlCommand("InsertarUnProducto", clsConexion.Conexion.LeerCadena());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NombreProducto", nombre);
            cmd.Parameters.AddWithValue("@Precio", precio);
            cmd.Parameters.AddWithValue("@Cantidad", cantidad);
            cmd.Parameters.AddWithValue("@EstadoProducto", true);
            cmd.Parameters.AddWithValue("@IdLaboratorio", idlaboratorio);
            cmd.Parameters.AddWithValue("@IdCategoria", idcategria);
            cmd.Parameters.AddWithValue("@IdProveedor", idproveedor);   
            cmd.Parameters.AddWithValue("@IdUsos", idusos);
            cmd.ExecuteNonQuery();
            clsConexion.Conexion.LeerCadena();
            MessageBox.Show("El Producto se ha insertado Satisfactoriamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
       
        //metodo encrgado a cambiar el estado del producto a imnabilidatado 
        ///
        public void eliminarProducto(DataGridView dgvProducto, String index)
        {
            
            index = dgvProducto.CurrentRow.Cells[0].Value.ToString();

            DialogResult x = MessageBox.Show("¿Está seguro de que desea eliminar este Producto?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            try
            {
                if (x == DialogResult.Yes)
                {
                    clsConexion.Conexion.LeerCadena();
                    cmd = new SqlCommand("EliminarProducto", clsConexion.Conexion.LeerCadena());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id ",int.Parse(index));
                    cmd.ExecuteNonQuery();
                    

                    MessageBox.Show("El Producto ha sido eliminado exitosamente", "Exito", MessageBoxButtons.OK);
                    cargarDatos(dgvProducto);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error " + e);
            }
        }
    }
    
}
