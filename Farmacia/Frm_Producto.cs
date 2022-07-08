using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Farmacia
{
    public partial class Frm_Producto : Form 
    {
        ~Frm_Producto()
        {

        }
        
        public Frm_Producto()
        {
            InitializeComponent();
        }
        int index;
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }
        //valida el tipo de dato
        public Boolean IsNumeric(string valor)
        {
            int result;
            return int.TryParse(valor, out result);
        }
        //metodo encargado en limpiar texbox del formulario
        public void Limpiar()
        {
            txtCodigoProducto.Clear();
            txtNombre.Clear();
            txtcantidad.Clear();
            txtPrecio.Clear();
            cbCategoria.Text = "";
            CbLab.Text = "";
            CbUsos.Text = "";
            CbProveedor.Text = "";

        
        }

        private bool ValidarCampos()
        {
            bool ok = true;
            if(txtNombre.Text == "")
            {
                ok = false;
                errorProviderProductos.SetError(txtNombre, "Error, Campo vacio");
            }
            if (txtPrecio.Text == "")
            {
                ok = false;
                errorProviderProductos.SetError(txtPrecio, "Error, Campo vacio");
            }
            if (txtcantidad.Text == "")
            {
                ok = false;
                errorProviderProductos.SetError(txtcantidad, "Error, Campo vacio");
            }
            if (CbLab.Text == "")
            {
                ok = false;
                errorProviderProductos.SetError(CbLab, "Error, Campo vacio");
            }
            if (CbProveedor.Text == "")
            {
                ok = false;
                errorProviderProductos.SetError(CbProveedor, "Error, Campo vacio");
            }
            if (cbCategoria.Text == "")
            {
                ok = false;
                errorProviderProductos.SetError(cbCategoria, "Error, Campo vacio");
            }
            if (CbUsos.Text == "")
            {
                ok = false;
                errorProviderProductos.SetError(CbUsos, "Error, Campo vacio");
            }
            return ok;

        }

        private void BorrarMensaje()
        {
            errorProviderProductos.SetError(txtNombre, "");
            errorProviderProductos.SetError(txtPrecio, "");
            errorProviderProductos.SetError(txtcantidad, "");
            errorProviderProductos.SetError(CbLab, "");
            errorProviderProductos.SetError(CbProveedor, "");
            errorProviderProductos.SetError(cbCategoria, "");
            errorProviderProductos.SetError(CbUsos, "");
        }


        public string ConsultaLaboratorio()
        {
            //consulta el laboratorio para llenar el combobox
            string Codigo;
            SqlCommand com = new SqlCommand(" select IdLaboratorio from Labororios Where NombreLaboratorio = '" + CbLab.Text + "'", clsConexion.Conexion.LeerCadena());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Codigo = dt.Rows[0][0].ToString();
            return Codigo;
        }
        //consulta el proveedor para llenar el combobox
        public string ConsultaProveedor()
        {
            string Codigo;
            SqlCommand com = new SqlCommand(" select PKIdProveedor from Proveedores where NombreProveedor = '" + CbProveedor.Text + "'", clsConexion.Conexion.LeerCadena());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Codigo = dt.Rows[0][0].ToString();
            return Codigo;
        }
        //consulta el categoria para llenar el combobox
        public string ConsultaCategoriaP()
        {
            string Codigo;
            SqlCommand com = new SqlCommand(" select IdCategoriaProducto from CategoriaProducto where NombreCategoria =  '" + cbCategoria.Text + "'", clsConexion.Conexion.LeerCadena());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Codigo = dt.Rows[0][0].ToString();
            return Codigo;
        }
        //consulta el usos para llenar el combobox
        public string ConsultaUsos()
        {
            string Codigo;
            SqlCommand com = new SqlCommand(" Select PKIdUsos From Usos where Descripcion =  '" + CbUsos.Text + "'", clsConexion.Conexion.LeerCadena());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Codigo = dt.Rows[0][0].ToString();
            return Codigo;
        }
        //llena los producto en el data gridview
        void CargarDGProductos()
        {
            dgvProducto.DataSource = clsConsultas.Consultas.consultaGeneral("ConsultaProductoGeneral2");
        }
        private void Ventas_Load(object sender, EventArgs e)
        {
            CargarDGProductos();
            CbLab.DataSource = clsConsultas.Consultas.consultaGeneral("ConsultaLaboratorioGeneral");
            CbLab.DisplayMember = "Nombre";
            CbLab.ValueMember = "ID";
            CbLab.Text = "";
            
            CbProveedor.DataSource = clsConsultas.Consultas.consultaGeneral("ConsultaGeneralProveedor");
            CbProveedor.DisplayMember = "Nombre";
            CbProveedor.ValueMember = "Proveedor";
            CbProveedor.Text = "";


            cbCategoria.DataSource = clsConsultas.Consultas.consultaGeneral("ConsultaCategoriaProductoGeneral");
            cbCategoria.DisplayMember = "Nombre";
            cbCategoria.ValueMember = "ID";
            cbCategoria.Text = "";

            CbUsos.DataSource = clsConsultas.Consultas.consultaGeneral("ConsultaGeneralUsos");
            CbUsos.DisplayMember = "Descripción";
            CbUsos.ValueMember = "ID";
            CbUsos.Text = "";
           
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {//valida que el campo no este vacio
                if (txtNombre.Text == "")
                {
                    ValidarCampos();
                    MessageBox.Show("Por favor, llenes todos los campos");


                }

                else if (txtcantidad.Text == "")
                {
                    ValidarCampos();
                    MessageBox.Show("Por favor, llenes todos los campos");
                }

                else
                {
                    MessageBox.Show("Entre");
                    ClProducto produc = new ClProducto();
                    int cantidad, usos, proveedor, categoria, laboratorio;
                    float precio;
                    bool float1 = float.TryParse(txtPrecio.Text, out precio);
                    bool int1 = int.TryParse(txtcantidad.Text, out cantidad);
                    usos = (int)CbUsos.SelectedValue;
                    proveedor = (int)CbProveedor.SelectedValue;
                    categoria = (int)cbCategoria.SelectedValue;
                    laboratorio = (int)CbLab.SelectedValue;
                    BorrarMensaje();

                    //validar que el campo no este vacio
                    if (txtNombre.Text != string.Empty && txtPrecio.Text != string.Empty && txtcantidad.Text != string.Empty && CbUsos.Text != "" && cbCategoria.Text != "" && CbLab.Text != "" && CbProveedor.Text != "")
                    {//validar si el  tipo es numerico
                        if (IsNumeric(txtNombre.Text) == false)
                        {
                            
                            //valida que los tipos de datos sean enteros y flotantes
                            if (int1 && float1)
                            {//valida que cantidad sea mayor que 0
                                if (Convert.ToInt32(txtcantidad.Text) < 0)
                                {
                                    MessageBox.Show("Error, no se permite una cantidad negativa ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtcantidad.Focus();
                                }
                                else if(Convert.ToInt32(txtPrecio.Text) < 0)
                                {
                                    MessageBox.Show("Error, no se permite un precio negativo ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtPrecio.Focus();
                                }
                                else
                                {
                                    produc.Nombre = txtNombre.Text;
                                    produc.Precio = precio; 
                                    produc.Cantidad = cantidad;
                                    produc.Idusos = usos;
                                    produc.Idproveedor = proveedor;
                                    produc.Idlaboratorio = laboratorio;
                                    produc.Idcategria = categoria;

                                    produc.agregarProducto();
                                    Limpiar();
                                    produc.cargarDatos(dgvProducto);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error, Inserte digitos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Error, Inserte Caracteres Validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }


                    }
                    /*else
                    {
                        //MessageBox.Show("No puede dejar campos vacíos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }*/
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Este producto ya existe, Modifique la cantidad!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            ClProducto produc = new ClProducto();
            produc.eliminarProducto(dgvProducto,Convert.ToString(index));
            produc.cargarDatos(dgvProducto);
            Limpiar();
            btnRegistrar.Enabled = true;
        }

        private void dgvProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombre.Text = dgvProducto.CurrentRow.Cells[1].Value.ToString();
            txtPrecio.Text = dgvProducto.CurrentRow.Cells[2].Value.ToString();
            txtcantidad.Text = dgvProducto.CurrentRow.Cells[3].Value.ToString();
            CbLab.SelectedItem = dgvProducto.CurrentRow.Cells[4].Value.ToString();
            CbProveedor.SelectedItem = dgvProducto.CurrentRow.Cells[5].Value.ToString();
            CbUsos.SelectedItem = dgvProducto.CurrentRow.Cells[6].Value.ToString();
            cbCategoria.SelectedItem = dgvProducto.CurrentRow.Cells[7].Value.ToString();
        }

        private void pbBuscarUsos_Click(object sender, EventArgs e)
        {
            //buscar  por codigo
            if (rbBucarPorCodigo.Checked == true)
            {
                if (IsNumeric(txtBuscar.Text) == true && txtBuscar.Text != "")
                {
                    dgvProducto.DataSource = clsConsultas.Consultas.consultaEspecifica("ConsultaProductoPorID", txtBuscar.Text.ToString());
                }

                else
                {
                    MessageBox.Show("Error, Campo vacio o con datos invalidos. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarDGProductos();
                }
            }
            //buscar por nombre
            if (rbBuscarPorNombre.Checked == true)
            {
                if (IsNumeric(txtBuscar.Text) == false && txtBuscar.Text != "")
                {
                    dgvProducto.DataSource = clsConsultas.Consultas.consultaEspecifica("ConsultaProductoPorNombre", txtBuscar.Text);
                }
                else
                {
                    MessageBox.Show("Error,Ingrese datos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarDGProductos();
                }
            }
        }
        //llena todos los texbox con los datos del datagridview
        private void dgvProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnRegistrar.Enabled = false;   
            txtCodigoProducto.Text = dgvProducto.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvProducto.CurrentRow.Cells[1].Value.ToString();
            txtPrecio.Text = dgvProducto.CurrentRow.Cells[2].Value.ToString();
            txtcantidad.Text = dgvProducto.CurrentRow.Cells[3].Value.ToString();
            CbLab.Text = dgvProducto.CurrentRow.Cells[4].Value.ToString();
            CbProveedor.Text = dgvProducto.CurrentRow.Cells[5].Value.ToString();
            CbUsos.Text = dgvProducto.CurrentRow.Cells[6].Value.ToString();
            cbCategoria.Text = dgvProducto.CurrentRow.Cells[7].Value.ToString();
        }
       
        private void btnModificar_Click(object sender, EventArgs e)
        {
            int cantidad;
            bool int1 = int.TryParse(txtcantidad.Text, out cantidad);
            //valida que los campos esten llenos
            if (txtNombre.Text != string.Empty && txtPrecio.Text != string.Empty && txtcantidad.Text != string.Empty && CbUsos.Text != "" && cbCategoria.Text != "" && CbLab.Text != "" && CbProveedor.Text != "")
            {//valida que los numeros sean enteros 
                if (dgvProducto.SelectedRows.Count > 0)
                {
                    if (int1)
                    {
                        if (Convert.ToInt32(txtcantidad.Text) < 0)
                        {
                            MessageBox.Show("Error, no se permite una cantidad negativa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtcantidad.Focus();
                        }
                        else if (Convert.ToInt32(txtPrecio.Text) < 0)
                        {
                            MessageBox.Show("Error, no se permite un precio negativo ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPrecio.Focus();
                        }
                        else
                        {
                            string Lab, Proveedor, CategoriaP, Usos;
                            Lab = ConsultaLaboratorio();
                            Proveedor = ConsultaProveedor();
                            CategoriaP = ConsultaCategoriaP();
                            Usos = ConsultaUsos();
                            SqlCommand com = new SqlCommand("EditarProducto", clsConexion.Conexion.LeerCadena());
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.AddWithValue("@IDProducto", Convert.ToInt32(txtCodigoProducto.Text));
                            com.Parameters.AddWithValue("@NombreProducto", txtNombre.Text);
                            com.Parameters.AddWithValue("@Precio", txtPrecio.Text);
                            com.Parameters.AddWithValue("@Cantidad", txtcantidad.Text);
                            com.Parameters.AddWithValue("@IdLaboratorio", Convert.ToInt32(Lab));
                            com.Parameters.AddWithValue("@IdProveedor", Convert.ToInt32(Proveedor));
                            com.Parameters.AddWithValue("@IdCategoria", Convert.ToInt32(CategoriaP));
                            com.Parameters.AddWithValue("@IdUsos", Convert.ToInt32(Usos));
                            com.ExecuteNonQuery();
                            MessageBox.Show("El producto se ha modificado exitosamente!");
                            CargarDGProductos();

                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("Error,Ingrese datos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtcantidad.Text = "";
                        txtcantidad.Focus();
                    }
                }

            }
            else
            {
                MessageBox.Show("Error,Ingrese todos los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvProducto_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void dgvProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Limpiar();
            btnRegistrar.Enabled = true;   
        }

        private void txtcantidad_KeyUp(object sender, KeyEventArgs e)
        {
            ClassFunciones.clsFunciones.ValidarCampoEntero(txtcantidad.Text);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validacion que solo permite ingresar carateres numericos en el telefono
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Error! ingrese un numero", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassFunciones.clsFunciones.ValidaInicioEspacio(txtNombre,e);
        }

        private void txtcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassFunciones.clsFunciones.ValidaNumeros(e);
        }
    }
    
}
