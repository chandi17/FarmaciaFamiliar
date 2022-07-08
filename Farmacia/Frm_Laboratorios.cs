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
    public partial class Frm_Laboratorios : Form
    {
        //meotod encargado de validar el tipo de dato
        ~Frm_Laboratorios()
        {

        }
        public Boolean IsNumeric(string valor)
        {
            int result;
            return int.TryParse(valor, out result);
        }

        public Frm_Laboratorios()

        {
            InitializeComponent();
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            CargarDGVlaboratorios();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //limpia todos los tex del formulario
        private void LimpiarLaboratorios()
        {
            txtCodigoLab.Text = "";
            txtNombreLab.Text = "";
        }

        private bool ValidarCampos()
        {
            //validacion de los campos no esten vacios 
            bool ok = true;
            if (txtNombreLab.Text == "")
            {
                ok = false;
                errorProviderLaboratorios.SetError(txtNombreLab, "Error, Campo vacio");
            }

            return ok;
        }


        private void BorrarMensaje()
        {
            //eliminar el mensaje del errorprovider
            errorProviderLaboratorios.SetError(txtNombreLab, "");
        }

        void CargarDGVlaboratorios()
        {//llena el datagridview de los datos del laboratorio
            dgvLaboratorios.DataSource = clsConsultas.Consultas.consultaGeneral("ConsultaLaboratorioGeneral");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //boton encargado de agregar un nuevo laboratorio
            clsConexion.Conexion.LeerCadena();

            try
            {
                //validar que no este vacio
                if (txtNombreLab.Text != "")
                {
                    if (IsNumeric(txtNombreLab.Text) == false)
                    {
                        SqlCommand com = new SqlCommand("exec dbo.InsertarLaboratorio'" + txtNombreLab.Text + "'", clsConexion.Conexion.LeerCadena());
                        com.ExecuteNonQuery();
                        MessageBox.Show("Los datos se agregaron exitosamente");
                        CargarDGVlaboratorios();
                        LimpiarLaboratorios();
                        txtNombreLab.Focus();
                        BorrarMensaje();
                    }
                    else
                    {
                        MessageBox.Show("Error, Inserte digitos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNombreLab.Clear();
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
                MessageBox.Show("Este laboratorio ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           clsConexion.Conexion.LeerCadena();

        }

        private void pbBuscarCli_Click(object sender, EventArgs e)
        {//buscar por nombre 
            if (rbBucarPorCodigoLab.Checked == true)
            {

                if (IsNumeric(txtBuscarLab.Text) == true && txtBuscarLab.Text != "")
                {
                    dgvLaboratorios.DataSource = clsConsultas.Consultas.consultaEspecifica("ConsultaLaboratorioPorID", txtBuscarLab.Text);
                }

                else
                {
                    MessageBox.Show("Error, Campo vacio o con datos invalidos. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarDGVlaboratorios();
                }
            }


            //buscar por usuario
            if (rbBuscarPorNombreLab.Checked == true)
            {
                if (IsNumeric(txtBuscarLab.Text) == false && txtBuscarLab.Text != "")
                {
                    SqlCommand com = new SqlCommand("exec dbo.ConsultaLaboratorioPorNombre'" + txtBuscarLab.Text + "'", clsConexion.Conexion.LeerCadena());
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvLaboratorios.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Error,Ingrese datos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarDGVlaboratorios();
                }
            }
        }

        private void btnModificarLab_Click(object sender, EventArgs e)
        {
            if (dgvLaboratorios.SelectedRows.Count > 0)
            {
                clsConexion.Conexion.LeerCadena();
                SqlCommand com = new SqlCommand("exec dbo.EditarLaboratorio'" + int.Parse(txtCodigoLab.Text) + "','" + txtNombreLab.Text + "'", clsConexion.Conexion.LeerCadena());
                com.ExecuteNonQuery();
                clsConexion.Conexion.LeerCadena();
                MessageBox.Show("Los datos se modificaron exitosamente");
                CargarDGVlaboratorios();
                LimpiarLaboratorios();
                txtNombreLab.Focus();
                btnRegistrarLab.Enabled = true;
            }
            else
            {
                MessageBox.Show("Seleccione la fila a editar");
            }
        }

        private void btnEliminarLab_Click(object sender, EventArgs e)
        {
            if (dgvLaboratorios.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Estas seguro de eliminar?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    clsConsultas.Consultas.EliminarRegistro("EliminarLaboratorio", txtCodigoLab.Text);
                    MessageBox.Show("Los datos se eliminaron exitosamente");
                    CargarDGVlaboratorios();
                    LimpiarLaboratorios();
                    txtNombreLab.Focus();
                    btnRegistrarLab.Enabled = true;
                }
            }

            else
            {
                MessageBox.Show("Seleccione la fila a Eliminar");
            }
        }

        private void dgvLaboratorios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLaboratorios.SelectedRows.Count > 0)
            {
                BorrarMensaje();
                btnRegistrarLab.Enabled = false;
                txtCodigoLab.Text = dgvLaboratorios.SelectedCells[0].Value.ToString();
                txtNombreLab.Text = dgvLaboratorios.SelectedCells[1].Value.ToString();
            }

            else
            {
                btnRegistrarLab.Enabled = true;
                LimpiarLaboratorios();
            }

            txtNombreLab.Focus();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombreLab_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassFunciones.clsFunciones.ValidaInicioEspacio(txtNombreLab, e);

        }
    }
}