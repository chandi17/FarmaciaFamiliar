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
    public partial class Frm_CategoriaProducto : Form
    {
        ~Frm_CategoriaProducto()
        {

        }

        public Boolean IsNumeric(string valor)
        {
            int result;
            return int.TryParse(valor, out result);
        }


        public Frm_CategoriaProducto()
        {
            InitializeComponent();
        }
        private void Ventas_Load(object sender, EventArgs e)
        {

            CargarDGVCategoriaProducto();
            btnModificarCP.Enabled = false;
            btnEliminarCP.Enabled = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void CargarDGVCategoriaProducto()
        {
            dgvCategoriaProducto.DataSource = clsConsultas.Consultas.consultaGeneral("ConsultaCategoriaProductoGeneral");
        }

        private void LimpiarCategoriaProducto()
        {
            txtCategoriaProducto.Text = "";
            txtCodigoCategoriaP.Text = "";
        }

        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtCategoriaProducto.Text == "")
            {
                ok = false;
                errorCategoriaProducto.SetError(txtCategoriaProducto, "Error, Campo vacio");
            }
            return ok;
        }

        private void BorrarMensaje()
        {
            errorCategoriaProducto.SetError(txtCategoriaProducto, "");
        }

        private void btnRegistrarCP_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCategoriaProducto.Text != "")
                {
                    if (IsNumeric(txtCategoriaProducto.Text) == false)
                    {
                        SqlCommand com = new SqlCommand("exec dbo.InsertarCategoriaProducto'" + txtCategoriaProducto.Text + "'", clsConexion.Conexion.LeerCadena());
                        com.ExecuteNonQuery();
                        MessageBox.Show("Los datos se agregaron exitosamente");
                        CargarDGVCategoriaProducto();
                        LimpiarCategoriaProducto();
                        txtCategoriaProducto.Focus();
                        BorrarMensaje();
                    }
                    else
                    {
                        MessageBox.Show("Error, Inserte digitos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }

                else
                {
                    ValidarCampos();
                    MessageBox.Show("Por favor, llene todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Esta categoria ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            clsConexion.Conexion.LeerCadena();

        }

        private void btnModificarCP_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCategoriaProducto.Text != "")
                {
                    if (IsNumeric(txtCategoriaProducto.Text) == false)
                    {
                        if (dgvCategoriaProducto.SelectedRows.Count > 0)
                        {
                            clsConexion.Conexion.LeerCadena();
                            SqlCommand com = new SqlCommand("exec dbo.EditarCategoriaProducto'" + int.Parse(txtCodigoCategoriaP.Text) + "','" + txtCategoriaProducto.Text + "'", clsConexion.Conexion.LeerCadena());
                            com.ExecuteNonQuery();
                            clsConexion.Conexion.LeerCadena();
                            MessageBox.Show("Los datos se modificaron exitosamente");
                            CargarDGVCategoriaProducto();
                            LimpiarCategoriaProducto();
                            txtCategoriaProducto.Focus();
                            btnRegistrarCP.Enabled = true;
                            txtCodigoCategoriaP.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Seleccione la fila a editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error, Inserte digitos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    ValidarCampos();
                    MessageBox.Show("Por favor, llene todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Esta categoria ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}
    private void btnEliminarCP_Click(object sender, EventArgs e)
        {
            if (dgvCategoriaProducto.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Estas seguro de eliminar?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    clsConsultas.Consultas.EliminarRegistro("EliminarCategoriaProducto", txtCodigoCategoriaP.Text);
                    MessageBox.Show("Los datos se eliminaron exitosamente");
                    CargarDGVCategoriaProducto();
                    LimpiarCategoriaProducto();
                    txtCategoriaProducto.Focus();
                    btnRegistrarCP.Enabled = true;
                }
            }

            else
            {
                MessageBox.Show("Seleccione la fila a Eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (rbBucarPorCodigoCP.Checked == true)
            {
                if (IsNumeric(txtBuscarProducto.Text) == true && txtBuscarProducto.Text != "")
                {
                    dgvCategoriaProducto.DataSource = clsConsultas.Consultas.consultaEspecifica("ConsultaCategoriaProductoPorID", txtBuscarProducto.Text);
                }

                else
                {
                    MessageBox.Show("Error, Campo vacio o con datos invalidos. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarDGVCategoriaProducto();
                }
            }

            /*if (rbBuscarPorNombreCP.Checked == true)
            {
                if (IsNumeric(txtBuscarProducto.Text) == false && txtBuscarProducto.Text != "")
                {
                    dgvCategoriaProducto.DataSource = clsConsultas.Consultas.consultaEspecifica("ConsultaCategoriaProductoPorNombre", txtBuscarProducto.Text);
                }
                else
                {
                    MessageBox.Show("Error,Ingrese datos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarDGVCategoriaProducto();
                }
            }*/

            if (rbBuscarPorNombreCP.Checked == true)
            {
                if (IsNumeric(txtBuscarProducto.Text) == false && txtBuscarProducto.Text != "")
                {
                    SqlCommand com = new SqlCommand("exec dbo.ConsultaCategoriaProductoPorNombre'" + txtBuscarProducto.Text + "'", clsConexion.Conexion.LeerCadena());
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCategoriaProducto.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Error,Ingrese datos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarDGVCategoriaProducto();
                }
            }
        }

        private void dgvCategoriaProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategoriaProducto.SelectedRows.Count > 0)
            {
                btnModificarCP.Enabled = true;
                btnEliminarCP.Enabled = true;
                btnRegistrarCP.Enabled = false;
                txtCodigoCategoriaP.Text = dgvCategoriaProducto.SelectedCells[0].Value.ToString();
                txtCategoriaProducto.Text = dgvCategoriaProducto.SelectedCells[1].Value.ToString();
            }

            else
            {
                btnRegistrarCP.Enabled = true;
                LimpiarCategoriaProducto();
                btnModificarCP.Enabled = false;
                btnEliminarCP.Enabled =false;
            }

            txtCategoriaProducto.Focus();
        }

        private void txtCategoriaProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassFunciones.clsFunciones.ValidaInicioEspacio(txtCategoriaProducto, e);
        }
    }
}
