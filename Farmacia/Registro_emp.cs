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
    public partial class Registro_emp : Form
    {
        public Registro_emp()
        {
            InitializeComponent();
        }
        ~Registro_emp()
        {
            System.Diagnostics.Trace.WriteLine("Se destruyo el Form Empleado");
        }

        public Boolean IsNumeric(string valor)
        {
            int result;
            return int.TryParse(valor, out result);
        }
        public bool ComprobarFormatoEmail()
        {
            string EmailAComprobar = txtCorreoEmpleado.Text;
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


        int EstadoCivil = 0;

     

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Registro_emp_Load(object sender, EventArgs e)
        {
            CargarDGVEmpleados();

            dtpFechaNacimientoEmp.MinDate = new DateTime(1935, 1, 1);
            dtpFechaNacimientoEmp.MaxDate = DateTime.Today;

        }


        private void LimpiarClientes()
        {
            txtNombreEmpleado.Text = "";
            txtApellidoEmpleado.Text = "";
            txtTelefonoEmpleado.Text = "";
            txtCorreoEmpleado.Text = "";
            txtRTNEmpleado.Text = "";
            rbSolteroEmpleado.Checked = true;
            rbCasadoEmpleado.Checked = false;
            rbDivorciadoLEmpleado.Checked = false;
            txtCodigoEmpleado.Text = "";
            txtRTNEmpleado.Focus();
        }

        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtNombreEmpleado.Text == "")
            {
                ok = false;
                errorProviderEmpleados.SetError(txtNombreEmpleado, "Error, Campo vacio");
            }
            if (txtApellidoEmpleado.Text == "")
            {
                ok = false;
                errorProviderEmpleados.SetError(txtApellidoEmpleado, "Error, Campo vacio");
            }
            if (txtTelefonoEmpleado.Text == "")
            {
                ok = false;
                errorProviderEmpleados.SetError(txtTelefonoEmpleado, "Error, Campo vacio");
            }
            if (txtCorreoEmpleado.Text == "")
            {
                ok = false;
                errorProviderEmpleados.SetError(txtCorreoEmpleado, "Error, Campo vacio");
            }
            if (txtRTNEmpleado.Text == "")
            {
                ok = false;
                errorProviderEmpleados.SetError(txtRTNEmpleado, "Error, Campo vacio");
            }
            return ok;
        }


        private void BorrarMensaje()
        {
            errorProviderEmpleados.SetError(txtNombreEmpleado, "");
            errorProviderEmpleados.SetError(txtApellidoEmpleado, "");
            errorProviderEmpleados.SetError(txtTelefonoEmpleado, "");
            errorProviderEmpleados.SetError(txtCorreoEmpleado, "");
            errorProviderEmpleados.SetError(txtRTNEmpleado, "");
        }

        void CargarDGVEmpleados()
        {
            dgvEmpleados.DataSource = clsConsultas.Consultas.consultaGeneral("ConsultaGeneralEmpleado");
        }

        private void btnRegistrarEmpleado_Click(object sender, EventArgs e)
        {
 
           try
           {
                if (txtNombreEmpleado.Text != "" && txtRTNEmpleado.Text != "    -    -" && txtApellidoEmpleado.Text !="")
                {
                    if (IsNumeric(txtNombreEmpleado.Text) == false && IsNumeric(txtApellidoEmpleado.Text) == false && txtRTNEmpleado.Text != "0000-0000-00000" )
                    {
                        if (txtTelefonoEmpleado.Text.StartsWith("(+5O4)3") == true || txtTelefonoEmpleado.Text.StartsWith("(+5O4)9") == true || txtTelefonoEmpleado.Text.StartsWith("(+5O4)8") == true || txtTelefonoEmpleado.Text.StartsWith("(+5O4)2") == true)
                        {
                            if (ComprobarFormatoEmail() && txtCorreoEmpleado.Text != "")
                            {
                                if (rbSolteroEmpleado.Checked == true)
                                {
                                    EstadoCivil = 1;
                                }

                                if (rbCasadoEmpleado.Checked == true)
                                {
                                    EstadoCivil = 2;
                                }

                                if (rbDivorciadoLEmpleado.Checked == true)
                                {
                                    EstadoCivil = 3;
                                }

                                SqlCommand com = new SqlCommand("AgregarEmpleado", clsConexion.Conexion.LeerCadena());
                                com.CommandType = CommandType.StoredProcedure;
                                com.Parameters.AddWithValue("@Identidad", txtRTNEmpleado.Text);
                                com.Parameters.AddWithValue("@Nombre", txtNombreEmpleado.Text);
                                com.Parameters.AddWithValue("@Apellido", txtApellidoEmpleado.Text);
                                com.Parameters.AddWithValue("@Telefono", Convert.ToString(txtTelefonoEmpleado.Text));
                                com.Parameters.AddWithValue("@Correo", txtCorreoEmpleado.Text);
                                com.Parameters.AddWithValue("@IdCategoria", EstadoCivil);
                                com.Parameters.AddWithValue("@FechaNacimiento", DateTime.Parse(dtpFechaNacimientoEmp.Text));
                                com.ExecuteNonQuery();
                                MessageBox.Show("Empleado Ingresado con Exito!");
                                CargarDGVEmpleados();

                                LimpiarClientes();
                                txtNombreEmpleado.Focus();
                                BorrarMensaje();
                                txtRTNEmpleado.Enabled = true;
                                rbSolteroEmpleado.Enabled = true;

                            }
                            else
                            {
                                MessageBox.Show("Error, Ingrese el Dominio del Correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtCorreoEmpleado.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error, Numero de teléfono inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtTelefonoEmpleado.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error, Inserte digitos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNombreEmpleado.Focus();
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
                MessageBox.Show("Este empleado ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            clsConexion.Conexion.LeerCadena();
        }

        private void btnModificarEmpleado_Click(object sender, EventArgs e)
        {

            if (txtNombreEmpleado.Text != "" && txtRTNEmpleado.Text != "    -    -" && txtApellidoEmpleado.Text !="" )
            {
                if (IsNumeric(txtNombreEmpleado.Text) == false && IsNumeric(txtApellidoEmpleado.Text) == false)
                {
                    if (txtRTNEmpleado.Text.Length == 15)
                    {
                        if (txtTelefonoEmpleado.Text.StartsWith("(+5O4)3") == true || txtTelefonoEmpleado.Text.StartsWith("(+5O4)9") == true || txtTelefonoEmpleado.Text.StartsWith("(+5O4)8") == true || txtTelefonoEmpleado.Text.StartsWith("(+5O4)2") == true)
                        {
                            if (ComprobarFormatoEmail() && txtCorreoEmpleado.Text != "")
                            {
                                if (dgvEmpleados.SelectedRows.Count > 0)
                                {
                                    if (rbSolteroEmpleado.Checked == true)
                                    {
                                        EstadoCivil = 1;
                                    }

                                    if (rbCasadoEmpleado.Checked == true)
                                    {
                                        EstadoCivil = 2;
                                    }

                                    if (rbDivorciadoLEmpleado.Checked == true)
                                    {
                                        EstadoCivil = 3;
                                    }

                                    SqlCommand com = new SqlCommand("EditarEmpleado", clsConexion.Conexion.LeerCadena());
                                    com.CommandType = CommandType.StoredProcedure;
                                    com.Parameters.AddWithValue("@Id", txtCodigoEmpleado.Text);
                                    com.Parameters.AddWithValue("@Identidad", txtRTNEmpleado.Text);
                                    com.Parameters.AddWithValue("@Nombre", txtNombreEmpleado.Text);
                                    com.Parameters.AddWithValue("@Apellido", txtApellidoEmpleado.Text);
                                    com.Parameters.AddWithValue("@Telefono", txtTelefonoEmpleado.Text);
                                    com.Parameters.AddWithValue("@Correo", txtCorreoEmpleado.Text);
                                    com.Parameters.AddWithValue("@IdCategoria", EstadoCivil);
                                    com.Parameters.AddWithValue("@FechaNacimiento", DateTime.Parse(dtpFechaNacimientoEmp.Text));
                                    com.ExecuteNonQuery();
                                    MessageBox.Show("Los Datos se Modificados Exitosamente!");
                                    CargarDGVEmpleados();
                                    LimpiarClientes();
                                    txtNombreEmpleado.Focus();
                                    btnRegistrarEmpleado.Enabled = true;
                                    txtRTNEmpleado.Enabled = true;
                                }

                                else
                                {
                                    MessageBox.Show("Seleccione la fila a editar");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error, Ingrese el Dominio del Correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtCorreoEmpleado.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error, Numero de Teléfono Inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCorreoEmpleado.Focus();
                        }
                    }

                    else
                    {
                        MessageBox.Show("Error, Inserte digitos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNombreEmpleado.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Error, Numero de telefono Incompleto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRTNEmpleado.Focus();
                }
            }
            else
            {
                ValidarCampos();
                MessageBox.Show("Error, Llene todos los campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Estas seguro de eliminar?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    clsConsultas.Consultas.EliminarRegistro("EliminarEmpleado", txtCodigoEmpleado.Text);
                    MessageBox.Show("Los datos se eliminaron exitosamente");
                    CargarDGVEmpleados();
                    LimpiarClientes();
                    txtNombreEmpleado.Focus();
                    btnRegistrarEmpleado.Enabled = true;
                    txtRTNEmpleado.Enabled = true;
                }
            }

            else
            {
                MessageBox.Show("Seleccione la fila a Eliminar");
            }            
        }

        private void btnBuscaEmpleados_Click(object sender, EventArgs e)
        {
            if (rbBucarPorCodigoEmp.Checked == true)
            {
                if (IsNumeric(txtBuscarEmpleado.Text) == true && txtBuscarEmpleado.Text != "")
                {
                    dgvEmpleados.DataSource = clsConsultas.Consultas.consultaEspecifica("ConsultaEmpleadoPorCodigo", txtBuscarEmpleado.Text);
                }

                else
                {
                    MessageBox.Show("Error, Campo vacio o con datos invalidos. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarDGVEmpleados();
                }
            }



            if (rbBuscarPorNombreEmp.Checked == true)
            {
                if (IsNumeric(txtBuscarEmpleado.Text) == false && txtBuscarEmpleado.Text != "")
                {
                    //dgvEmpleados.DataSource = clsConsultas.Consultas.consultaEspecifica("ConsultaEmpleadoPorNombre", txtBuscarEmpleado.Text);

                    SqlCommand com = new SqlCommand("exec dbo.ConsultaEmpleadoPorNombre'" + (txtBuscarEmpleado.Text) + "'", clsConexion.Conexion.LeerCadena());
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvEmpleados.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Error,Ingrese datos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                    CargarDGVEmpleados();
                }
            }
        }

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string EstadoC;

            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                txtRTNEmpleado.Enabled = false;
                rbSolteroEmpleado.Checked = true;
                BorrarMensaje();
                btnRegistrarEmpleado.Enabled = false;
                txtCodigoEmpleado.Text = dgvEmpleados.SelectedCells[0].Value.ToString();
                txtRTNEmpleado.Text = dgvEmpleados.SelectedCells[1].Value.ToString();
                txtNombreEmpleado.Text = dgvEmpleados.SelectedCells[2].Value.ToString();
                txtApellidoEmpleado.Text = dgvEmpleados.SelectedCells[3].Value.ToString();
                txtTelefonoEmpleado.Text = dgvEmpleados.SelectedCells[4].Value.ToString();
                txtCorreoEmpleado.Text = dgvEmpleados.SelectedCells[5].Value.ToString();
                EstadoC = dgvEmpleados.SelectedCells[6].Value.ToString();
                dtpFechaNacimientoEmp.Text = dgvEmpleados.SelectedCells[7].Value.ToString();

                if(EstadoC == "Soltero")
                {
                    rbSolteroEmpleado.Checked = true;
                }

                if (EstadoC == "Casado")
                {
                    rbCasadoEmpleado.Checked = true;
                }

                if (EstadoC == "Divorciado")
                {
                    rbDivorciadoLEmpleado.Checked = true;
                }
            }

            else
            {
                btnRegistrarEmpleado.Enabled = true;
                LimpiarClientes();
                txtRTNEmpleado.Enabled = true;
                rbSolteroEmpleado.Enabled = true;
            }

            txtNombreEmpleado.Focus();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            this.Close();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNombreEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32 && txtNombreEmpleado.Text == "")
            {
                MessageBox.Show("El nombre del empleado no puede iniciar con un espacio", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtApellidoEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32 && txtNombreEmpleado.Text == "")
            {
                MessageBox.Show("El Apellido del empleado no puede iniciar con un espacio", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void txtCorreoEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32 && txtNombreEmpleado.Text == "")
            {
                MessageBox.Show("El Correo del empleado no puede iniciar con un espacio", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
