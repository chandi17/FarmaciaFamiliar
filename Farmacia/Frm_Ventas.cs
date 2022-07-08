using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Farmacia
{
    public partial class Frm_Ventas : Form
    {

        SqlConnection cn = new SqlConnection("Data Source = AGALEANO\\SQLEXPRESS; Initial Catalog = FarmaciaDesarrollo; Integrated Security = True");

        public Boolean IsNumeric(string valor)
        {
            int result;
            return int.TryParse(valor, out result);
        }

        public Frm_Ventas()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            CargarDGVproductos();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dgvDetalleProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        void CargarDGVproductos()
        {
            SqlCommand com = new SqlCommand("exec dbo.ConsultaProductoGeneral", cn);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvProductos.DataSource = dt;
        }

        void CargarDGVdetalleFactura()
        {
            SqlCommand com = new SqlCommand("exec dbo.ConsultaDetalleFactura", cn);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvDetalleFactura.DataSource = dt;
        }


        private void pbBuscarCli_Click(object sender, EventArgs e)
        {
            if (rbBucarPorCodigo.Checked == true)
            {
                if (IsNumeric(txtBuscarVentas.Text) == true && txtBuscarVentas.Text != "")
                {
                    SqlCommand com = new SqlCommand("exec dbo.ConsultaProductoPorID'" + txtBuscarVentas.Text + "'", cn);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvProductos.DataSource = dt;
                }

                else
                {
                    MessageBox.Show("Error, Campo vacio o con datos invalidos. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SqlCommand com = new SqlCommand("exec dbo.ConsultaProductoGeneral", cn);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvProductos.DataSource = dt;
                }
            }



            if (rbBuscarPorNombre.Checked == true)
            {
                if (IsNumeric(txtBuscarVentas.Text) == false && txtBuscarVentas.Text != "")
                {
                    SqlCommand com = new SqlCommand("exec dbo.ConsultaProductoPorNombre'" + txtBuscarVentas.Text + "'", cn);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvProductos.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Error,Ingrese datos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SqlCommand com = new SqlCommand("exec dbo.ConsultaProductoGeneral", cn);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvProductos.DataSource = dt;
                }
            }
        }

        private void btnBuscarCLiente_Click(object sender, EventArgs e)
        {
            
                if (IsNumeric(txtBuscarCLiente.Text) == true && txtBuscarCLiente.Text != "")
                {
                    SqlCommand com = new SqlCommand("exec dbo.ConsultaClientePorCodigo'" + txtBuscarCLiente.Text + "'", cn);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvProductos.DataSource = dt;
                }

                else
                {
                    MessageBox.Show("Error, Campo vacio o con datos invalidos. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SqlCommand com = new SqlCommand("exec dbo.ConsultaProductoGeneral", cn);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvProductos.DataSource = dt;
                }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
