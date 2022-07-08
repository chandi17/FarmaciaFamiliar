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
    public partial class Perfiles : Form
    {

        public Boolean IsNumeric(string valor)
        {
            int result;
            return int.TryParse(valor, out result);
        }


        public Perfiles()
        {
            InitializeComponent();
        }
        ~Perfiles()
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            clsConexion.Conexion.LeerCadena();
            this.Close();
        }

        private void Perfiles_Load(object sender, EventArgs e)
        {
            CargarDGVperfiles();
        }


        private void LimpiarPerfiles()
        {
            txtCodigoPerfiles.Text = "";
            txtNombrePerfil.Text = "";
        }

        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtNombrePerfil.Text == "")
            {
                ok = false;
                errorProviderPerfiles.SetError(txtNombrePerfil, "Error, Campo vacio");
            }

            return ok;
        }


        private void BorrarMensaje()
        {
            errorProviderPerfiles.SetError(txtNombrePerfil, "");
        }

        void CargarDGVperfiles()
        {
            dgvPerfiles.DataSource = clsConsultas.Consultas.consultaGeneral("ConsultaGeneralPerfiles");
        }

        private void btnRegistrarPerfiles_Click(object sender, EventArgs e)
        {
            clsConexion.Conexion.LeerCadena();

            try
            {
                if (txtNombrePerfil.Text != "")
                {
                    if (IsNumeric(txtNombrePerfil.Text) == false)
                    {
                        SqlCommand com = new SqlCommand("exec dbo.AgregarPerfiles'" + txtNombrePerfil.Text + "'", clsConexion.Conexion.LeerCadena());
                        com.ExecuteNonQuery();
                        MessageBox.Show("Los datos se agregaron exitosamente");
                        CargarDGVperfiles();
                        LimpiarPerfiles();
                        txtNombrePerfil.Focus();
                        BorrarMensaje();
                    }
                    else
                    {
                        MessageBox.Show("Error, Inserte digitos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNombrePerfil.Clear();
                    }
                }
                else
                {
                    ValidarCampos();
                    MessageBox.Show("Por favor, llene todos los campos");
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Este perfil ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            clsConexion.Conexion.LeerCadena();
        }

        private void btnModificarPerfiles_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombrePerfil.Text != "")
                {
                    if (IsNumeric(txtNombrePerfil.Text) == false)
                    {

                        if (dgvPerfiles.SelectedRows.Count > 0)
                        {
                        clsConexion.Conexion.LeerCadena();
                        SqlCommand com = new SqlCommand("exec dbo.EditarPerfiles'" + int.Parse(txtCodigoPerfiles.Text) + "','" + txtNombrePerfil.Text + "'", clsConexion.Conexion.LeerCadena());
                        com.ExecuteNonQuery();

                        MessageBox.Show("Los datos se modificaron exitosamente");
                        CargarDGVperfiles();
                        LimpiarPerfiles();
                        txtNombrePerfil.Focus();
                        btnRegistrarPerfiles.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Error, Inserte digitos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtNombrePerfil.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione la fila a editar");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Este perfil ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarPerfiles_Click(object sender, EventArgs e)
        {
            if (dgvPerfiles.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Estas seguro de eliminar?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    clsConsultas.Consultas.EliminarRegistro("EliminarPerfiles", txtCodigoPerfiles.Text);
                    MessageBox.Show("Los datos se eliminaron exitosamente");
                    CargarDGVperfiles();
                    LimpiarPerfiles();
                    txtNombrePerfil.Focus();
                    btnRegistrarPerfiles.Enabled = true;
                }
            }

            else
            {
                MessageBox.Show("Seleccione la fila a Eliminar");
            }
        }

        private void pbBuscarCli_Click(object sender, EventArgs e)
        {
            if (rbBucarPorCodigoPerfil.Checked == true)
            {
                if (IsNumeric(txtBuscarPerfil.Text) == true && txtBuscarPerfil.Text != "")
                {
                    dgvPerfiles.DataSource = clsConsultas.Consultas.consultaEspecifica("ConsultaPerfilPorCodigo", txtBuscarPerfil.Text);
                }

                else
                {
                    MessageBox.Show("Error, Campo vacio o con datos invalidos. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarDGVperfiles();
                }
            }



            /*if (rbBuscarPorNombrePerfil.Checked == true)
            {
                if (IsNumeric(txtBuscarPerfil.Text) == false && txtBuscarPerfil.Text != "")
                {
                    dgvPerfiles.DataSource = clsConsultas.Consultas.consultaEspecifica("ConsultaPerfilesPorNombre", txtBuscarPerfil.Text);
                }
                else
                {
                    MessageBox.Show("Error,Ingrese datos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarDGVperfiles();
                }
            }*/

            if (rbBuscarPorNombrePerfil.Checked == true)
            {
                if (IsNumeric(txtBuscarPerfil.Text) == false && txtBuscarPerfil.Text != "")
                {
                    SqlCommand com = new SqlCommand("exec dbo.ConsultaPerfilesPorNombre'" + txtBuscarPerfil.Text + "'", clsConexion.Conexion.LeerCadena());
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPerfiles.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Error,Ingrese datos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarDGVperfiles();
                }
            }
        }

        private void dgvPerfiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPerfiles.SelectedRows.Count > 0)
            {
                BorrarMensaje();
                btnRegistrarPerfiles.Enabled = false;
                txtCodigoPerfiles.Text = dgvPerfiles.SelectedCells[0].Value.ToString();
                txtNombrePerfil.Text = dgvPerfiles.SelectedCells[1].Value.ToString();
            }

            else
            {
                btnRegistrarPerfiles.Enabled = true;
                LimpiarPerfiles();
            }

            txtNombrePerfil.Focus();
        }

        private void txtNombrePerfil_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassFunciones.clsFunciones.ValidaInicioEspacio(txtNombrePerfil, e);
        }
    }
}
