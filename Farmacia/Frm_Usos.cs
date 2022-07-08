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
    public partial class Frm_Usos : Form
    {
        ~Frm_Usos()
        {

        }
        public Boolean IsNumeric(string valor)
        {
            int result;
            return int.TryParse(valor, out result);
        }

        public Frm_Usos()
        {
            InitializeComponent();
        }

        private void LimpiarUsos()
        {
            txtCodigoUsos.Text = "";
            txtDescripcionUsos.Text = "";
        }

        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtDescripcionUsos.Text == "")
            {
                ok = false;
                errorProviderUsos.SetError(txtDescripcionUsos, "Error, Campo vacio");
            }

            return ok;
        }


        private void BorrarMensaje()
        {
            errorProviderUsos.SetError(txtDescripcionUsos, "");
        }

        void CargarDGVusos()
        {
            dgvUsos.DataSource = clsConsultas.Consultas.consultaGeneral("ConsultaGeneralUsos");
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            CargarDGVusos();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrarUsos_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtDescripcionUsos.Text != "")
                {
                    if (IsNumeric(txtDescripcionUsos.Text) == false)
                    {
                        SqlCommand com = new SqlCommand("exec dbo.AgregarUsos'" + txtDescripcionUsos.Text + "'", clsConexion.Conexion.LeerCadena());
                        com.ExecuteNonQuery();
                        clsConexion.Conexion.LeerCadena();
                        MessageBox.Show("Los datos se agregaron exitosamente");
                        CargarDGVusos();
                        LimpiarUsos();
                        txtDescripcionUsos.Focus();
                        BorrarMensaje();
                    }
                    else
                    {
                        MessageBox.Show("Error, Inserte digitos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDescripcionUsos.Clear();
                    }
                }
                else
                {
                    ValidarCampos();
                    MessageBox.Show("Por favor, llene todos los campos"); 
                }
            }
                catch (Exception)
            {
                MessageBox.Show("Este Uso ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


}
        private void btnModificarUsos_Click(object sender, EventArgs e)
        {

            try
            {
                if (IsNumeric(txtDescripcionUsos.Text) == false)
                {
                    if (txtDescripcionUsos.Text != "")
                    {
                    if (dgvUsos.SelectedRows.Count > 0)
                    {
                        clsConexion.Conexion.LeerCadena();
                        SqlCommand com = new SqlCommand("exec dbo.EditarUsos'" + int.Parse(txtCodigoUsos.Text) + "','" + txtDescripcionUsos.Text + "'", clsConexion.Conexion.LeerCadena());
                        com.ExecuteNonQuery();
                        MessageBox.Show("Los datos se modificaron exitosamente");
                        CargarDGVusos();
                        LimpiarUsos();
                        txtDescripcionUsos.Focus();
                        btnRegistrarUsos.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Seleccione la fila a editar");
                    }
                    }
                    else
                    {
                        MessageBox.Show("Error, Inserte digitos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDescripcionUsos.Clear();
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
                MessageBox.Show("Este Uso ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
        }

        private void btnEliminarUsos_Click(object sender, EventArgs e)
        {
            if (dgvUsos.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Estas seguro de eliminar?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    clsConsultas.Consultas.EliminarRegistro("EliminarUsos", txtCodigoUsos.Text);
                    MessageBox.Show("Los datos se eliminaron exitosamente");
                    CargarDGVusos();
                    LimpiarUsos();
                    txtDescripcionUsos.Focus();
                    btnRegistrarUsos.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Seleccione la fila a Eliminar");
            }
        }

        private void pbBuscarCli_Click(object sender, EventArgs e)
        {
            if (rbBucarPorCodigoUsos.Checked == true)
            {
                if (IsNumeric(txtBuscarUsos.Text) == true && txtBuscarUsos.Text != "")
                {
                    dgvUsos.DataSource = clsConsultas.Consultas.consultaEspecifica("ConsultaUsosPorCodigo ", txtBuscarUsos.Text);
                }

                else
                {
                    MessageBox.Show("Error, Campo vacio o con datos invalidos. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarDGVusos();
                }
            }
            if (rbBuscarPorNombreUsos.Checked == true)
            {
                if (IsNumeric(txtBuscarUsos.Text) == false && txtBuscarUsos.Text != "")
                {
                    SqlCommand com = new SqlCommand("exec dbo.ConsultaUsosPorNombre'" + txtBuscarUsos.Text + "'", clsConexion.Conexion.LeerCadena());
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvUsos.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Error,Ingrese datos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarDGVusos();
                }
            }
        }

        private void dgvUsos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsos.SelectedRows.Count > 0)
            {
                BorrarMensaje();
                btnRegistrarUsos.Enabled = false;
                txtCodigoUsos.Text = dgvUsos.SelectedCells[0].Value.ToString();
                txtDescripcionUsos.Text = dgvUsos.SelectedCells[1].Value.ToString();
            }

            else
            {
                btnRegistrarUsos.Enabled = true;
                LimpiarUsos();
            }

            txtDescripcionUsos.Focus();
        }

        private void txtDescripcionUsos_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassFunciones.clsFunciones.ValidaInicioEspacio(txtDescripcionUsos, e);
        }
    }
}
