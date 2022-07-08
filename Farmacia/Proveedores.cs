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
using System.Text.RegularExpressions;

namespace Farmacia
{
    public partial class Proveedores : Form
    {


        public Boolean IsNumeric(string valor)
        {
            int result;
            return int.TryParse(valor, out result);
        }
        public bool ComprobarFormatoEmail()
        {
            string EmailAComprobar = txtCorreoProveedor.Text;
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(EmailAComprobar, sFormato))
            {
                if (Regex.Replace(EmailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        public Proveedores()
        {
            InitializeComponent();
        }
        ~Proveedores()
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            CargarDGVProveedores();
        }

        void CargarDGVProveedores()
        {
            dgvProveedores.DataSource = clsConsultas.Consultas.consultaGeneral("ConsultaGeneralProveedor");
        }

        private void LimpiarProveedores()
        {
            txtNombreProveedor.Text = "";
            txtTelefonoProveedor.Text = "";
            txtCorreoProveedor.Text = "";
            txtDireccionProveedor.Text = "";
            txtRTNProveedor2.Text = "";
            txtCodigoProveedor.Text = "";
            txtRTNProveedor2.Focus();
        }

        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtNombreProveedor.Text == "")
            {
                ok = false;
                errorProveedor.SetError(txtNombreProveedor, "Error, Campo vacio");
            }
            if (txtTelefonoProveedor.Text == "")
            {
                ok = false;
                errorProveedor.SetError(txtTelefonoProveedor, "Error, Campo vacio");
            }
            if (txtCorreoProveedor.Text == "")
            {
                ok = false;
                errorProveedor.SetError(txtCorreoProveedor, "Error, Campo vacio");
            }
            if (txtDireccionProveedor.Text == "")
            {
                ok = false;
                errorProveedor.SetError(txtDireccionProveedor, "Error, Campo vacio");
            }
            if (txtRTNProveedor2.Text == "")
            {
                ok = false;
                errorProveedor.SetError(txtRTNProveedor2, "Error, Campo vacio");
            }

            return ok;
        }

        private void BorrarMensaje()
        {
            errorProveedor.SetError(txtNombreProveedor, "");
            errorProveedor.SetError(txtTelefonoProveedor, "");
            errorProveedor.SetError(txtCorreoProveedor, "");
            errorProveedor.SetError(txtDireccionProveedor, "");
            errorProveedor.SetError(txtRTNProveedor2, "");
        }

        private void btnRegistrarProveedores_Click(object sender, EventArgs e)
        {
            

            try
            {
                if (txtNombreProveedor.Text != "" && txtRTNProveedor2.Text != "    -    -")
                {
                    if (IsNumeric(txtNombreProveedor.Text) == false && txtRTNProveedor2.Text != "0000-0000-00000")
                    {
                        if (txtTelefonoProveedor.Text.StartsWith("(+5O4)3") == true || txtTelefonoProveedor.Text.StartsWith("(+5O4)9") == true || txtTelefonoProveedor.Text.StartsWith("(+5O4)8") == true || txtTelefonoProveedor.Text.StartsWith("(+5O4)2") == true)
                        {
                            if (ComprobarFormatoEmail() && txtCorreoProveedor.Text != "")
                            {
                                SqlCommand com = new SqlCommand("exec dbo.AgregarProveedor'" + txtNombreProveedor.Text + "','" + txtTelefonoProveedor.Text + "','" + txtCorreoProveedor.Text + "','" + txtDireccionProveedor.Text + "','" + txtRTNProveedor2.Text + "'", clsConexion.Conexion.LeerCadena());
                                com.ExecuteNonQuery();
                                MessageBox.Show("Los datos se agregaron exitosamente");
                                CargarDGVProveedores();
                                LimpiarProveedores();
                                txtNombreProveedor.Focus();
                                BorrarMensaje();
                                txtRTNProveedor2.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Error, Ingrese el Dominio del Correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtCorreoProveedor.Focus();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Error, Numero de télefono Inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtTelefonoProveedor.Focus();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Error, Inserte digitos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRTNProveedor2.Clear();
                    }
                    }
                else
                {
                    ValidarCampos();
                    MessageBox.Show("Por favor, llene todos los campos");
                }
            }

            catch (Exception error)
            {
                MessageBox.Show("Este Proveedor ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            clsConexion.Conexion.LeerCadena();

        }

        private void btnModificarProveedores_Click(object sender, EventArgs e)
        {
            try
            {


                if (txtNombreProveedor.Text != "" && txtRTNProveedor2.Text != "    -    -")
                {
                    if (IsNumeric(txtNombreProveedor.Text) == false)
                    {
                        if (txtRTNProveedor2.Text.Length == 15)
                        {
                            if (txtTelefonoProveedor.Text.StartsWith("(+5O4)3") == true || txtTelefonoProveedor.Text.StartsWith("(+5O4)9") == true || txtTelefonoProveedor.Text.StartsWith("(+5O4)8") == true || txtTelefonoProveedor.Text.StartsWith("(+5O4)2") == true)
                            {
                                if (ComprobarFormatoEmail() && txtCorreoProveedor.Text != "")
                                {
                                    if (dgvProveedores.SelectedRows.Count > 0)
                                    {
                                        clsConexion.Conexion.LeerCadena();
                                        SqlCommand com = new SqlCommand("exec dbo.EditarProveedor'" + int.Parse(txtCodigoProveedor.Text) + "','" + txtNombreProveedor.Text + "','" + txtTelefonoProveedor.Text + "','" + txtCorreoProveedor.Text + "','" + txtDireccionProveedor.Text + "','" + txtRTNProveedor2.Text + "'", clsConexion.Conexion.LeerCadena());
                                        com.ExecuteNonQuery();
                                        clsConexion.Conexion.LeerCadena();
                                        MessageBox.Show("Los datos se modificaron exitosamente");
                                        CargarDGVProveedores();
                                        LimpiarProveedores();
                                        txtNombreProveedor.Focus();
                                        btnRegistrarProveedores.Enabled = true;
                                        txtRTNProveedor2.Enabled = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Seleccione la fila a editar");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Error, Ingrese el Dominio del Correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtCorreoProveedor.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error, Numero de télefono Inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtTelefonoProveedor.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error, Inserte digitos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtRTNProveedor2.Focus();
                        }
                    }

                    else
                    {
                        MessageBox.Show("Error, Inserte digitos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNombreProveedor.Focus();
                    }
                }
                else
                {
                    ValidarCampos();
                    MessageBox.Show("Error, Llene todos los campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Este Proveedor ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnEliminarProveedores_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Estas seguro de eliminar?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    clsConsultas.Consultas.EliminarRegistro("EliminarProveedor", txtCodigoProveedor.Text);
                    MessageBox.Show("Los datos se eliminaron exitosamente");
                    CargarDGVProveedores();
                    LimpiarProveedores();
                    txtNombreProveedor.Focus();
                    btnRegistrarProveedores.Enabled = true;
                    txtRTNProveedor2.Enabled = true;
                }
            }

            else
            {
                MessageBox.Show("Seleccione la fila a Eliminar");
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (rbBucarPorCodigoPro.Checked == true)
            {
                if (IsNumeric(txtBuscarProveedor.Text) == true && txtBuscarProveedor.Text != "")
                {

                    dgvProveedores.DataSource = clsConsultas.Consultas.consultaEspecifica("ConsultaProveedorPorCodigo", txtBuscarProveedor.Text);

                }

                else
                {
                    MessageBox.Show("Error, Campo vacio o con datos invalidos. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarDGVProveedores();
                }
            }



            /*if (rbBuscarPorNombrePro.Checked == true)
            {
                if (IsNumeric(txtBuscarProveedor.Text) == false && txtBuscarProveedor.Text != "")
                {
                    dgvProveedores.DataSource = clsConsultas.Consultas.consultaEspecifica("ConsultaProveedorPorNombre", txtBuscarProveedor.Text);
                }
                else
                {
                    MessageBox.Show("Error,Ingrese datos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarDGVProveedores();
                }
            }*/

            if (rbBuscarPorNombrePro.Checked == true)
            {
                if (IsNumeric(txtBuscarProveedor.Text) == false && txtBuscarProveedor.Text != "")
                {
                    SqlCommand com = new SqlCommand("exec dbo.ConsultaProveedorPorNombre'" + txtBuscarProveedor.Text + "'", clsConexion.Conexion.LeerCadena());
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvProveedores.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Error,Ingrese datos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarDGVProveedores();
                }
            }
        }

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                txtRTNProveedor2.Enabled = false;
                btnRegistrarProveedores.Enabled = false;
                txtCodigoProveedor.Text = dgvProveedores.SelectedCells[0].Value.ToString();
                txtNombreProveedor.Text = dgvProveedores.SelectedCells[1].Value.ToString();
                txtTelefonoProveedor.Text = dgvProveedores.SelectedCells[2].Value.ToString();
                txtCorreoProveedor.Text = dgvProveedores.SelectedCells[3].Value.ToString();
                txtDireccionProveedor.Text = dgvProveedores.SelectedCells[4].Value.ToString();
                txtRTNProveedor2.Text = dgvProveedores.SelectedCells[5].Value.ToString();
            }

            else
            {
                btnRegistrarProveedores.Enabled = true;
                LimpiarProveedores();
                txtRTNProveedor2.Enabled = true;
            }

            txtNombreProveedor.Focus();
        }

        public static bool ComprobarFormatoEmail(string EmailAComprobar)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(EmailAComprobar, sFormato))
            {
                if (Regex.Replace(EmailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void txtNombreProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassFunciones.clsFunciones.ValidaInicioEspacio(txtNombreProveedor, e);
            ClassFunciones.clsFunciones.ValidaCaracteres(e);
        }

        private void txtCorreoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassFunciones.clsFunciones.ValidaInicioEspacio(txtCorreoProveedor, e);
        }

        private void txtDireccionProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassFunciones.clsFunciones.ValidaInicioEspacio(txtDireccionProveedor, e);
        }
    }
}
