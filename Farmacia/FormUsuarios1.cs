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
    public partial class FormUsuarios1 : Form
    {
        //Metodo que valida el Tipo de datos
        public Boolean IsNumeric(string valor)
        {
            int result;
            return int.TryParse(valor, out result);
        }
  
        public FormUsuarios1()
        {
            InitializeComponent();
        }
        ~FormUsuarios1()
        {

        }
        //Cierra el Form
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Hace una consulta a la base de datos para poder obtener el codigo atravez del Nombre
        public string ConsultaNombreEmpleado()
        {
            string Codigo;
            SqlCommand com = new SqlCommand("SELECT [PKIdEmpleado] FROM Empleados WHERE [NombreEmpleado] = '" + txtEmpleadoUsuarios.Text + "'", clsConexion.Conexion.LeerCadena());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Codigo = dt.Rows[0][0].ToString();
            return Codigo;
        }

            private void FormUsuarios1_Load(object sender, EventArgs e)
        {
            //Carga los Datos al iniciar el Form
            CargarDGVusuarios();
            comboBoxPerfil.DataSource = clsConsultas.Consultas.consultaGeneral("ConsultaGeneralPerfiles");
            comboBoxPerfil.DisplayMember = "Perfil";
            comboBoxPerfil.ValueMember = "Id";
            comboBoxPerfil.Text = "";
            btnModificarU.Enabled = false;
            btnEliminarU.Enabled = false;
        }
        //Metodo encargado de limpiar todos los textBox
        private void LimpiarUsuarios()
        {
            txtCodigoUsuarios.Text = "";
            txtContraUsuarios.Text = "";
            txtUsuarioU.Text = "";
            txtEmpleadoUsuarios.Text = "";
            comboBoxPerfil.Text = "";
            txtUsuarioU.Focus();
        }
        //Valida los campos
        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtUsuarioU.Text == "")
            {
                ok = false;
                errorProviderUsuarios.SetError(txtUsuarioU, "Error, Campo vacio");
            }
            if (txtContraUsuarios.Text == "")
            {
                ok = false;
                errorProviderUsuarios.SetError(txtContraUsuarios, "Error, Campo vacio");
            }
     
            return ok;
        }

        //Limpia los mensajes del error provaider
        private void BorrarMensaje()
        {
            errorProviderUsuarios.SetError(txtUsuarioU, "");
            errorProviderUsuarios.SetError(txtContraUsuarios, "");
        }
        //Carga los datos a un error provaider
        void CargarDGVusuarios()
        {
            dgvUsuarios.DataSource = clsConsultas.Consultas.consultaGeneral("ConsultaUsuarioGeneral");
        }
        
        private void btnRegistrarU_Click(object sender, EventArgs e)
        {
            try
            {
                //Valida
                if (txtUsuarioU.Text != "" && txtContraUsuarios.Text != "")
                {

                    if (IsNumeric(txtUsuarioU.Text) == false && IsNumeric(txtEmpleadoUsuarios.Text) == true)
                    {
                        SqlCommand com = new SqlCommand("InsertarUsuario", clsConexion.Conexion.LeerCadena());
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@User", txtUsuarioU.Text);
                        com.Parameters.AddWithValue("@Pass", txtContraUsuarios.Text);
                        com.Parameters.AddWithValue("@IdEmpleado",Convert.ToInt32( txtEmpleadoUsuarios.Text));
                        com.Parameters.AddWithValue("@IdPerfil", comboBoxPerfil.SelectedValue);
                        com.ExecuteNonQuery();
                        CargarDGVusuarios();
                        LimpiarUsuarios();
                        btnRegistrarU.Enabled = true;
                        clsConexion.Conexion.LeerCadena();
                    }
                    else
                    {
                        MessageBox.Show("Error, Inserte digitos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                else
                {
                    ValidarCampos();
                MessageBox.Show("Error, Llene todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuarioU.Focus();
            }
            }

            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
                //MessageBox.Show("Este Usuario Ya existe o El Codigo de empleado es incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //clsConexion.Conexion.LeerCadena();
            }
        }

        private void btnModificarU_Click(object sender, EventArgs e)
        {
            //se valida que haya seleccionado un usuario
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                clsConexion.Conexion.LeerCadena();
                string codigo = ConsultaNombreEmpleado();
                SqlCommand com = new SqlCommand("EditarUsuario", clsConexion.Conexion.LeerCadena());
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@IdUser",Convert.ToInt32( txtCodigoUsuarios.Text));
                com.Parameters.AddWithValue("@User", txtUsuarioU.Text);
                com.Parameters.AddWithValue("@IdEmpleado", codigo);
                com.Parameters.AddWithValue("@IdPerfil", comboBoxPerfil.SelectedValue);
                com.ExecuteNonQuery();
                CargarDGVusuarios();
                LimpiarUsuarios();
                btnRegistrarU.Enabled = true;
                clsConexion.Conexion.LeerCadena();
            }

            else
            {
                MessageBox.Show("Seleccione la fila a editar");
            }
        }

        private void btnEliminarU_Click(object sender, EventArgs e)
        {
            //se valida que se haya seleccionado un usuario para poder eliminar 
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Estas seguro de eliminar?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    clsConexion.Conexion.LeerCadena();
                    SqlCommand com = new SqlCommand("EliminarUsuario", clsConexion.Conexion.LeerCadena());
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Id", Convert.ToInt32(txtCodigoUsuarios.Text));               
                    com.ExecuteNonQuery();
                    //clsConsultas.Consultas.EliminarRegistro("EliminarUsuario", txtCodigoUsuarios.Text);
                    CargarDGVusuarios();
                    LimpiarUsuarios();
                    btnRegistrarU.Enabled = true;
                }
            }

            else
            {
                MessageBox.Show("Seleccione la fila a Eliminar");
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                //llena todos los texbox con los datos de datagridview
                txtEmpleadoUsuarios.Enabled = false;
                BorrarMensaje();
                btnRegistrarU.Enabled = false;
                txtCodigoUsuarios.Text = dgvUsuarios.SelectedCells[0].Value.ToString();
                txtUsuarioU.Text = dgvUsuarios.SelectedCells[1].Value.ToString();
                txtEmpleadoUsuarios.Text = dgvUsuarios.SelectedCells[2].Value.ToString();
                comboBoxPerfil.Text = dgvUsuarios.SelectedCells[3].Value.ToString();
            }

            else
            {
                btnRegistrarU.Enabled = true;
                LimpiarUsuarios();
                txtEmpleadoUsuarios.Enabled = true;
            }

            txtUsuarioU.Focus();
        }

        private void pbBuscarUsuario_Click(object sender, EventArgs e)
        {
            //busqueda por codigo
            
            if (rbBucarPorCodigoUsuarios.Checked == true)
            {
                if (IsNumeric(txtBuscarUsuario.Text) == true && txtBuscarUsuario.Text != "")
                {
                    dgvUsuarios.DataSource = clsConsultas.Consultas.consultaEspecifica("ConsultaUsuarioPorID", txtBuscarUsuario.Text.ToString());
                }

                else
                {
                    MessageBox.Show("Error, Campo vacio o con datos invalidos. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarDGVusuarios();
                }
            }

            if (rbBuscarPorNombreUsuarios.Checked == true)
            {
                //busqueda por usuario
                if (IsNumeric(txtBuscarUsuario.Text) == false && txtBuscarUsuario.Text != "")
                {
                    
                    dgvUsuarios.DataSource = clsConsultas.Consultas.consultaEspecifica("ConsultaPorUsuario", txtBuscarUsuario.Text);
                }
                else
                {
                    MessageBox.Show("Error,Ingrese datos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarDGVusuarios();
                }
            }
        }

        private void btnEliminarU_Click_1(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Estas seguro de eliminar?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    clsConexion.Conexion.LeerCadena();
                    SqlCommand com = new SqlCommand("EliminarUsuario", clsConexion.Conexion.LeerCadena());
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Id", Convert.ToInt32(txtCodigoUsuarios.Text));
                    com.ExecuteNonQuery();
                    //clsConsultas.Consultas.EliminarRegistro("EliminarUsuario", txtCodigoUsuarios.Text);
                    CargarDGVusuarios();
                    LimpiarUsuarios();
                    btnRegistrarU.Enabled = true;


                }
            }

            else
            {
                MessageBox.Show("Seleccione la fila a Eliminar");
            }
        }

        private void dgvUsuarios_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
           ;
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                txtEmpleadoUsuarios.Enabled = false;
                BorrarMensaje();
                btnRegistrarU.Enabled = false;
                txtCodigoUsuarios.Text = dgvUsuarios.SelectedCells[0].Value.ToString();
                txtUsuarioU.Text = dgvUsuarios.SelectedCells[1].Value.ToString();
                txtEmpleadoUsuarios.Text = dgvUsuarios.SelectedCells[2].Value.ToString();
                comboBoxPerfil.Text = dgvUsuarios.SelectedCells[3].Value.ToString();
                txtUsuarioU.Enabled = false;
            }
            else
            {
                btnRegistrarU.Enabled = true;
                LimpiarUsuarios();
                txtEmpleadoUsuarios.Enabled = true;
                txtUsuarioU.Enabled = true;
                btnModificarU.Enabled = true;
                btnEliminarU.Enabled = true;
            }

            txtUsuarioU.Focus();
        }

        private void btnModificarU_Click_1(object sender, EventArgs e)
        {
            try
            {
            //malidacion que ningun campo este vacio
                if (txtUsuarioU.Text != "" && txtEmpleadoUsuarios.Text != "" && comboBoxPerfil.Text != "")
                {
                    //en el que el tipo de dato sea el corrrecto
                    if (IsNumeric(txtUsuarioU.Text) == false)
                    {
                        if (dgvUsuarios.SelectedRows.Count > 0)
                        {
                            clsConexion.Conexion.LeerCadena();
                            string codigo = ConsultaNombreEmpleado();
                            SqlCommand com = new SqlCommand("EditarUsuario", clsConexion.Conexion.LeerCadena());
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.AddWithValue("@IdUser", Convert.ToInt32(txtCodigoUsuarios.Text));
                            com.Parameters.AddWithValue("@User", txtUsuarioU.Text);
                            com.Parameters.AddWithValue("@IdEmpleado", codigo);
                            com.Parameters.AddWithValue("@IdPerfil", comboBoxPerfil.SelectedValue);
                            com.ExecuteNonQuery();
                            CargarDGVusuarios();
                            LimpiarUsuarios();
                            btnRegistrarU.Enabled = true;
                            clsConexion.Conexion.LeerCadena();
                            MessageBox.Show("Usuario Actualizado");
                            txtEmpleadoUsuarios.Enabled = true;
                            txtUsuarioU.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Seleccione la fila a editar");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error, Inserte digitos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                else
                {
                    MessageBox.Show("Error, Llene todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuarioU.Focus();
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Este Usuario Ya existe o El Codigo de empleado es incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsConexion.Conexion.LeerCadena();
            }
        }

        private void pbBuscarUsuario_Click_1(object sender, EventArgs e)
        { //busqueda por codigo
            if (rbBucarPorCodigoUsuarios.Checked == true)
            {
                
                if (IsNumeric(txtBuscarUsuario.Text) == true && txtBuscarUsuario.Text != "")
                {
                    dgvUsuarios.DataSource = clsConsultas.Consultas.consultaEspecifica("ConsultaUsuarioPorID", txtBuscarUsuario.Text);
                }

                else
                {
                    MessageBox.Show("Error, Campo vacio o con datos invalidos. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarDGVusuarios();
                }
            }


            //busqueda por usuario
            if (rbBuscarPorNombreUsuarios.Checked == true)
            {
                if (IsNumeric(txtBuscarUsuario.Text) == false && txtBuscarUsuario.Text != "")
                {
                    SqlCommand com = new SqlCommand("exec dbo.ConsultaPorUsuario'" + txtBuscarUsuario.Text + "'", clsConexion.Conexion.LeerCadena());
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvUsuarios.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Error,Ingrese datos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarDGVusuarios();
                }
            }
        }

        private void txtUsuarioU_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtUsuarioU_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            ClassFunciones.clsFunciones.ValidaInicioEspacio(txtUsuarioU, e);
            
        }

        private void txtEmpleadoUsuarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validacion que solo permite ingresar carateres numericos en el Codigo
            ClassFunciones.clsFunciones.ValidaNumeros(e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtEmpleadoUsuarios_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
