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

    public partial class Clientes : Form
    {
        ~Clientes()
        {

        }
        public Clientes()
        {
            InitializeComponent();
        }
        public Boolean IsNumeric(string valor)
        {
            int result;
            return int.TryParse(valor, out result);
        }
        private void LimpiarClientes()
        {
            txtCodigoCliente.Text = "";
            txtApellidoCli.Text = "";
            txtNombreCli.Text = "";
            txtCorreoCli.Text = "";
            txtTelefonoCLi2.Text = "";
            txtDireccionCli.Text = "";
            txtRTNCLi2.Text = "";
            txtRTNCLi2.Focus();
        }
        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtNombreCli.Text == "")
            {
                ok = false;
                ErrorClientes.SetError(txtNombreCli, "Error, Campo vacio");
                txtNombreCli.Focus();
            }
            if (txtApellidoCli.Text == "")
            {
                ok = false;
                ErrorClientes.SetError(txtApellidoCli, "Error, Campo vacio");
                txtApellidoCli.Focus();
            }
            if (txtTelefonoCLi2.Text == "")
            {
                ok = false;
                ErrorClientes.SetError(txtTelefonoCLi2, "Error, Campo vacio");
                txtTelefonoCLi2.Focus();
            }
            if (txtCorreoCli.Text == "")
            {
                ok = false;
                ErrorClientes.SetError(txtCorreoCli, "Error, Campo vacio");
                txtCorreoCli.Focus();
            }
            if (txtDireccionCli.Text == "")
            {
                ok = false;
                ErrorClientes.SetError(txtDireccionCli, "Error, Campo vacio");
                txtDireccionCli.Focus();
            }
            if (txtRTNCLi2.Text == "")
            {
                ok = false;
                ErrorClientes.SetError(txtRTNCLi2, "Error, Campo vacio");
                txtRTNCLi2.Focus();
            }

            return ok;
        }
        private void BorrarMensaje()
        {
            ErrorClientes.SetError(txtNombreCli, "");
            ErrorClientes.SetError(txtApellidoCli, "");
            ErrorClientes.SetError(txtTelefonoCLi2, "");
            ErrorClientes.SetError(txtCorreoCli, "");
            ErrorClientes.SetError(txtDireccionCli, "");
            ErrorClientes.SetError(txtRTNCLi2, "");
        }
        public bool ComprobarFormatoEmail()
        {
            string EmailAComprobar = txtCorreoCli.Text;
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

        // Metodo encargado de Cargar el Dgv de Clientes
        void CargarDGVclientes()
        {
            dgvClientes.DataSource = clsConsultas.Consultas.consultaGeneral("ConsultaGeneralCLiente");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //Cierra el Formulario
            this.Close();
        }
        private void Clientes_Load(object sender, EventArgs e)
        {
            //Carga el DatagridView a la hora de abrir el formulario
            CargarDGVclientes();
            txtRTNCLi2.Focus();
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {//Botton Encargado de Registrar el cliente

            try
            {
                //Valida que nungun txt este Vacio
                if (txtNombreCli.Text != "" && txtRTNCLi2.Text != "" && txtApellidoCli.Text != "    -    -" ) 
                {
                    //Valida si los datos ingresados son de Tipo Numerico
                    if (IsNumeric(txtNombreCli.Text) == false && IsNumeric(txtApellidoCli.Text) == false && txtRTNCLi2.Text != "0000-0000-00000")
                    {
                        //Valida si ingreso el numero de telefono Completo
                        if (txtRTNCLi2.Text.Length == 15)
                        {
                            //Valida que el numero de telefono sea Valido y que pertenezca a una operadora local
                            if (txtTelefonoCLi2.Text.StartsWith("(+5O4)3") == true || txtTelefonoCLi2.Text.StartsWith("(+5O4)9") == true || txtTelefonoCLi2.Text.StartsWith("(+5O4)8") == true || txtTelefonoCLi2.Text.StartsWith("(+5O4)2") == true)
                            {
                                //Valida el formato del Email que lleve su respectivo @ y su Dominio
                                if (ComprobarFormatoEmail() && txtCorreoCli.Text != "")
                                {
                                    SqlCommand com = new SqlCommand("exec dbo.AgregarCliente'" + txtRTNCLi2.Text + "','" + txtNombreCli.Text + "','" + txtApellidoCli.Text + "','" + txtTelefonoCLi2.Text + "','" + txtCorreoCli.Text + "','" + txtDireccionCli.Text + "'", clsConexion.Conexion.LeerCadena());
                                    com.ExecuteNonQuery();

                                    MessageBox.Show("Los datos se agregaron exitosamente");
                                    CargarDGVclientes();
                                    LimpiarClientes();
                                    txtNombreCli.Focus();
                                    BorrarMensaje();
                                    txtRTNCLi2.Enabled = true;
                                }
                                else
                                {
                                    MessageBox.Show("Error, Ingrese un correo valido. Ejemplo: Hola@gmail.com", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtCorreoCli.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error, Numero de Telefono Invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtTelefonoCLi2.Focus();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Error, Numero de identidad Incompleto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtNombreCli.Focus();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Error, Inserte digitos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNombreCli.Focus();
                    }

                }
                else 
                {
                    ValidarCampos();
                    MessageBox.Show("Error, Llene todos los campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Este cliente ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsConexion.Conexion.LeerCadena();
            }
        }

        
        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Valida que haya seleccionado un producto
            if(dgvClientes.SelectedRows.Count > 0)
            {
                //Valida que haya ingresado todos los datos y que no este vacio ninguno
                if (txtNombreCli.Text != "" && txtRTNCLi2.Text != "" && txtApellidoCli.Text != "    -    -")
                {
                    //Valida si los datos ingresados son de Tipo Numerico
                    if (IsNumeric(txtNombreCli.Text) == false && IsNumeric(txtApellidoCli.Text) == false)
                    {
                        //Valida que sea Un numero Valido
                        if (txtTelefonoCLi2.Text.StartsWith("(+5O4)3") == true || txtTelefonoCLi2.Text.StartsWith("(+5O4)9") == true || txtTelefonoCLi2.Text.StartsWith("(+5O4)8") == true || txtTelefonoCLi2.Text.StartsWith("(+5O4)2") == true)
                        {
                            //Valida el Formato del Correo
                            if (ComprobarFormatoEmail() && txtCorreoCli.Text != "")
                            {
                                clsConexion.Conexion.LeerCadena();
                                SqlCommand com = new SqlCommand("exec dbo.EditarCliente'" + int.Parse(txtCodigoCliente.Text) + "','" + txtRTNCLi2.Text + "','" + txtNombreCli.Text + "','" + txtApellidoCli.Text + "','" + txtTelefonoCLi2.Text + "','" + txtCorreoCli.Text + "','" + txtDireccionCli.Text + "'", clsConexion.Conexion.LeerCadena());
                                com.ExecuteNonQuery();


                                MessageBox.Show("Los datos se modificaron exitosamente");
                                CargarDGVclientes();
                                LimpiarClientes();
                                txtNombreCli.Focus();
                                btnRegistrar.Enabled = true;
                                txtRTNCLi2.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Error, Ingrese el Dominio del Correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtCorreoCli.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error, Numero de télefono Inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCorreoCli.Focus();
                        }
                            
                    }
                    else
                    {
                        MessageBox.Show("Error, Inserte digitos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNombreCli.Focus();
                    }

                }
                else
                {
                    ValidarCampos();
                    MessageBox.Show("Error, Llene todos los campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            else
            {
                MessageBox.Show("Seleccione la fila a editar");
            } 
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Btn encargado de eliminar un Registro
            if(dgvClientes.SelectedRows.Count > 0)
            {
                //Condicion que pregunta si esta seguro de Eliminar
                if (MessageBox.Show("Estas seguro de eliminar?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    clsConsultas.Consultas.EliminarRegistro("EliminarCliente", txtCodigoCliente.Text);
                    MessageBox.Show("Los datos se eliminaron exitosamente");
                    CargarDGVclientes();
                    LimpiarClientes();
                    txtNombreCli.Focus();
                    btnRegistrar.Enabled = true;
                    txtRTNCLi2.Enabled = true;
                    txtRTNCLi2.Focus();
                }
            }
            else
            {
                MessageBox.Show("Seleccione la fila a Eliminar");
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //Boton Encargado de Buscar, Verifica si es una busqueda por nombre o una busqueda por codigo

                //Busqueda por Codigo
                if (rbBucarPorCodigo.Checked == true)
                {
                    if (IsNumeric(txtBuscarCli.Text) == true && txtBuscarCli.Text != "")
                    {
                        dgvClientes.DataSource = clsConsultas.Consultas.consultaEspecifica("ConsultaClientePorCodigo", txtBuscarCli.Text);
                    }

                    else
                    {
                        MessageBox.Show("Error, Campo vacio o con datos invalidos. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        CargarDGVclientes();
                    }
                }
                //Busqueda por Nombre
                if (rbBuscarPorNombre.Checked == true)
                {
                    if (IsNumeric(txtBuscarCli.Text) == false && txtBuscarCli.Text != "")
                    {
                        SqlCommand com = new SqlCommand("exec dbo.ConsultaClientePorNombre'" + txtBuscarCli.Text + "'", clsConexion.Conexion.LeerCadena());
                        SqlDataAdapter da = new SqlDataAdapter(com);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvClientes.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Error,Ingrese datos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        CargarDGVclientes();
                    }
                }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;

            //Llena todos los campos de los textbox con los datos del DGV para poder modificar
            if(dgvClientes.SelectedRows.Count > 0)
            {
                txtRTNCLi2.Enabled = false;
                BorrarMensaje();
                btnRegistrar.Enabled = false;
                txtCodigoCliente.Text = dgvClientes.SelectedCells[0].Value.ToString();
                txtRTNCLi2.Text = dgvClientes.SelectedCells[1].Value.ToString();
                txtNombreCli.Text = dgvClientes.SelectedCells[2].Value.ToString();
                txtApellidoCli.Text = dgvClientes.SelectedCells[3].Value.ToString();
                txtTelefonoCLi2.Text = dgvClientes.SelectedCells[4].Value.ToString();
                txtCorreoCli.Text = dgvClientes.SelectedCells[5].Value.ToString();
                txtDireccionCli.Text = dgvClientes.SelectedCells[6].Value.ToString();
            }

            else
            {
                btnRegistrar.Enabled = true;
                LimpiarClientes();
                txtRTNCLi2.Enabled = true;
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
            }
            txtNombreCli.Focus();
        }

        private void txtNombreCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassFunciones.clsFunciones.ValidaInicioEspacio(txtNombreCli, e);
            ClassFunciones.clsFunciones.ValidaCaracteres(e);
        }

        private void txtApellidoCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassFunciones.clsFunciones.ValidaInicioEspacio(txtApellidoCli, e);
            ClassFunciones.clsFunciones.ValidaCaracteres(e);
        }

        private void txtCorreoCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassFunciones.clsFunciones.ValidaInicioEspacio(txtCorreoCli, e);
        }

        private void txtDireccionCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassFunciones.clsFunciones.ValidaInicioEspacio(txtDireccionCli, e);
        }

        private void txtNombreCli_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRTNCLi2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32 && txtRTNCLi2.Text == "")
            {
                MessageBox.Show("El Campo no puede iniciar con un espacio", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                txtNombreCli.Focus();
                txtRTNCLi2.Focus();
                return;
            }
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo Se permiten numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
