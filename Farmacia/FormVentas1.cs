

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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;

namespace Farmacia
{
    public partial class FormVentas1 : Form
    {

        ~FormVentas1()
        {

        }
        //Declaración de las Variables
        bool Estado = false, SelecProducto = false;
        string codigoProducto, codigoCliente, nombreProducto, index, precio, NombreCliente;
        int cantidad;
        double Subtotal, ISV, Total, Descuento;
        public int contador = 0;
        string[,] ListaCompra = new string[200, 8];
        int Fila = 0;
        int Conteo;
        string CodigoModificarCantidad;


        // Metodos 
        public void ConsultarDetalleFact()
        {
            dgvDetalleFactura.DataSource = clsConsultas.Consultas.consultaEspecifica("ConsultaDetalleFactura", index);
        }
        public void VaciarDTGDetalle()
        {
            dgvDetalleFactura.DataSource = clsConsultas.Consultas.consultaGeneral("ConsultaDetalleVacio");
        }
        public void FinalizarVenta(string Codigo,string Subtotal,string ISV,string Total)
        {
            clsConexion.Conexion.LeerCadena();
            SqlCommand com = new SqlCommand("FinalizarVentas", clsConexion.Conexion.LeerCadena());
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Codigo", Convert.ToDouble(Codigo));
            com.Parameters.AddWithValue("@Subtotal", Convert.ToDouble(Subtotal));
            com.Parameters.AddWithValue("@ISV", Convert.ToDouble(ISV));
            com.Parameters.AddWithValue("@Total", Convert.ToDouble(Total));
            com.ExecuteNonQuery();
            CargarDGVproductos();
            clsConexion.Conexion.LeerCadena();
        }
        public void AgregarDetalleVenta(string indice)
        {
            clsConexion.Conexion.LeerCadena();
            SqlCommand com = new SqlCommand("AgregarDetalleVenta", clsConexion.Conexion.LeerCadena());
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@IdFactura", Convert.ToInt32(indice));
            com.Parameters.AddWithValue("@IdProducto", codigoProducto);
            com.Parameters.AddWithValue("@Cantidad", Convert.ToInt32 (txtCantidad.Text));
            com.Parameters.AddWithValue("@Precio", precio);
            com.ExecuteNonQuery();
            ConsultaSubtotal();
        }
        public void ConsultaSubtotal()
        {

            Subtotal = 0;
            for (int i = 0; i < dgvDetalleFactura.RowCount; i++)
            {
                Subtotal += int.Parse(dgvDetalleFactura.Rows[i].Cells[4].Value.ToString());
            }
            txtSubtotal.Text = Subtotal.ToString();
            txtTotalVentas.Text = (Subtotal * 1.15).ToString();
            txtISV.Text = Convert.ToString(Subtotal * 0.15);
        }
        public string ConsultaIndex()
        {
            clsConexion.Conexion.LeerCadena();
            string indice;
            SqlCommand com = new SqlCommand("exec dbo.Indice ", clsConexion.Conexion.LeerCadena());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            indice = dt.Rows[0][0].ToString();
            clsConexion.Conexion.LeerCadena();
            return indice;
        }
        public string ConsultaNombreCliente(int Codigo)
        {
            clsConexion.Conexion.LeerCadena();
            string indice;
            SqlCommand com = new SqlCommand("Select CONCAT(TRIM (NombreCliente),' ',TRIM(ApellidoCliente))  from Clientes WHERE PKIDcliente =" + Codigo, clsConexion.Conexion.LeerCadena());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            indice = dt.Rows[0][0].ToString();
            clsConexion.Conexion.LeerCadena();
            return indice;
        }
        public string ConsultaCodigoProducto(string NombreProducto)
        {
            clsConexion.Conexion.LeerCadena();
            string CodigoProducto;
            SqlCommand com = new SqlCommand("SELECT [IDProducto] FROM Productos WHERE[NombreProducto] = '" + NombreProducto + "'", clsConexion.Conexion.LeerCadena());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CodigoProducto = dt.Rows[0][0].ToString();
            clsConexion.Conexion.LeerCadena();
            return CodigoProducto;

        }
        public void ModificarDetalleProduc(string Codigo, string Cantidad, string NombreProducto)
        {
            string CodigoProducto = ConsultaCodigoProducto(NombreProducto);
            clsConexion.Conexion.LeerCadena();
            {
                SqlCommand com = new SqlCommand("ActualizarCantidadDetalle", clsConexion.Conexion.LeerCadena());
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Codigo", Convert.ToInt32(Codigo));
                com.Parameters.AddWithValue("@Cantidad", Convert.ToInt32(Cantidad));
                com.Parameters.AddWithValue("@Producto", Convert.ToInt32(CodigoProducto));
                com.ExecuteNonQuery();
                ConsultaSubtotal();
            }
            clsConexion.Conexion.LeerCadena();
        }
        public void EliminarDetalleProducto(string Codigo, string NombreProducto)
        {
            string CodigoProducto = ConsultaCodigoProducto(NombreProducto);
            clsConexion.Conexion.LeerCadena();
            {
                SqlCommand com = new SqlCommand("EliminarDetalleVenta", clsConexion.Conexion.LeerCadena());
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@IdFactura", Convert.ToInt32(Codigo));
                com.Parameters.AddWithValue("@IdProducto", Convert.ToInt32(CodigoProducto));
                com.ExecuteNonQuery();
            }
            clsConexion.Conexion.LeerCadena();
        }
        private void LimpiarFactura()
        {
            txtBuscarCliente.Text = "";
            txtNombreCliente.Text = "";
            txtSubtotal.Text = "";
            txtISV.Text = "";
            txtCantidad.Text = "";
            txtTotalVentas.Text = "";
        }
        public Boolean IsNumeric(string valor)
        {
            int result;
            return int.TryParse(valor, out result);
        }
        void CargarDGVproductos()
        {
            dgvProductos.DataSource = clsConsultas.Consultas.consultaGeneral("ConsultaProductoGeneral");
        }



        public FormVentas1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbBuscarProductos_Click(object sender, EventArgs e)
        {

            if (rbBuscarPorNombre.Checked == true)
            {
                if (IsNumeric(txtBuscarVentas.Text) == false && txtBuscarVentas.Text != "")
                {
                    {
                        SqlCommand com = new SqlCommand("exec dbo.ConsultaProductoPorNombre'" + txtBuscarVentas.Text + "'", clsConexion.Conexion.LeerCadena());
                        SqlDataAdapter da = new SqlDataAdapter(com);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvProductos.DataSource = dt;
                    }

                }
                else
                {
                    MessageBox.Show("Error,Ingrese datos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarDGVproductos();
                }
            }
            if (rbBucarPorCodigo.Checked == true)
            {
                if (IsNumeric(txtBuscarVentas.Text) == true && txtBuscarVentas.Text != "")
                {
                    dgvProductos.DataSource = clsConsultas.Consultas.consultaEspecifica("ConsultaProductoPorID", txtBuscarVentas.Text);
                }

                else
                {
                    MessageBox.Show("Error, Campo vacio o con datos invalidos. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarDGVproductos();
                }
            }


        }
        private void btnQuitarProduc_Click(object sender, EventArgs e)
        {
            MessageBox.Show(index);
            MessageBox.Show(nombreProducto);
            if (dgvDetalleFactura.SelectedCells.Count > 0)
            {
                MessageBox.Show("Entre");
                EliminarDetalleProducto(index, nombreProducto);
                NombreCliente = "";
                ConsultarDetalleFact();
                ConsultaSubtotal();
            }

            else
            {
                MessageBox.Show("Error, Seleccione el producto a eliminar ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {

            try
            {

                if (txtBuscarCliente.Text != "")
                {

                    codigoCliente = txtBuscarCliente.Text.ToString();
                    int temporal = Convert.ToInt32(codigoCliente);
                    NombreCliente = ConsultaNombreCliente(temporal);
                    txtNombreCliente.Text = NombreCliente;
                }

                else
                {
                    txtNombreCliente.Text = "";
                }


            }

            catch (Exception)
            {
                MessageBox.Show("No existe este cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBuscarCliente.Text = "";
                txtNombreCliente.Text = "";
                clsConexion.Conexion.LeerCadena();
                txtBuscarCliente.Focus();
            }
        }

        private void txtBuscarCliente_KeyPress(object sender, KeyPressEventArgs e)
        {

            ClassFunciones.clsFunciones.ValidaNumeros(e);

        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {

            ClassFunciones.clsFunciones.ValidaNumeros(e);

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                if (Convert.ToInt32(txtCantidad.Text) > 0)
                    {
                        try
                        {
                            clsConexion.Conexion.LeerCadena();
                            nombreProducto = dgvDetalleFactura.CurrentRow.Cells[1].Value.ToString();
                            ModificarDetalleProduc(CodigoModificarCantidad, txtCantidad.Text , nombreProducto);
                            ConsultarDetalleFact();
                            ConsultaSubtotal();
                            btnActualizar.Visible = false;
                            txtCantidad.Text = "";  
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("Error, No se que pasa ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            clsConexion.Conexion.LeerCadena();
                        }
                }
                else
                {
                    MessageBox.Show("Error, La cantidad no puede ser 0 ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCantidad.Focus();
                }
            }
            else
            {
                MessageBox.Show("Error, Ingrese la Cantidad del producto ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
            }
        }

        private void dgvProductos_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (txtBuscarCliente.Text != "")
            {
                codigoCliente = txtBuscarCliente.Text;
                codigoProducto = dgvProductos.CurrentRow.Cells[0].Value.ToString();
                precio = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                Estado = true;
                MessageBox.Show("Producto Seleccionado");
                txtCantidad.Focus();
                SelecProducto = true;
            }
            else
            {
                MessageBox.Show("Error, Inserte él código del Cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuscarCliente.Focus();
            }
        }

        private void dgvDetalleFactura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalleFactura.SelectedRows.Count > 0)
            {
                index = ConsultaIndex();
                nombreProducto = txtCantidad.Text = dgvDetalleFactura.CurrentRow.Cells[1].Value.ToString();
                MessageBox.Show("Producto Seleccionado ");
                MessageBox.Show(index);
                MessageBox.Show(nombreProducto);

            }
            else if (e.ColumnIndex == 3)
            {
                MessageBox.Show("Ingrese la nueva Cantidad");
                txtCantidad.Text = dgvDetalleFactura.CurrentRow.Cells[3].Value.ToString();
                CodigoModificarCantidad = dgvDetalleFactura.CurrentRow.Cells[0].Value.ToString();
                btnActualizar.Visible = true;
            }
            else
            {
                btnActualizar.Visible = false;
                txtCantidad.Text = "";
                CodigoModificarCantidad = "";
            }
        }
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {

            ClassFunciones.clsFunciones.ValidaNumeros(e);

            if (e.KeyChar == (char)13)
            {
                btnAgregar.PerformClick();
            }

        }
        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtDevolucion.Text = (float.Parse(txtEfectivo.Text) - float.Parse(txtTotalVentas.Text)).ToString();
            }
            catch
            {
                txtDevolucion.Text = 0.ToString();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
        }

        private void btnImprimirFactura_Click(object sender, EventArgs e)
        {
            Conteo = dgvDetalleFactura.RowCount; // se cuenta los productos y se utilisa el conteo como limite del for

            if (txtEfectivo.Text != "")
            {
                if(Convert.ToDouble(txtEfectivo.Text) > Convert.ToDouble(txtTotalVentas.Text))
                {
                    if (Conteo != 0)
                    {
                        ClassFunciones.clsFunciones.CreaTicket Ticket1 = new ClassFunciones.clsFunciones.CreaTicket();

                        Ticket1.TextoCentro("Farmacia Familiar "); //imprime una linea de descripcion
                        Ticket1.TextoCentro("********************************************************************************");

                        Ticket1.TextoIzquierda("Dirc: Barrio San Antonio");
                        Ticket1.TextoIzquierda("Tel:33122949 ");
                        Ticket1.TextoIzquierda("RTN: 0501-2001-10666");
                        Ticket1.TextoIzquierda("");
                        Ticket1.TextoCentro("Factura de Venta"); //imprime una linea de descripcion
                        Ticket1.TextoIzquierda("No Fac:" + index);
                        Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        Ticket1.TextoIzquierda("Le Atendio: " + txtVendedor.Text);
                        Ticket1.TextoIzquierda("");
                        ClassFunciones.clsFunciones.CreaTicket.LineasGuion();//-------------------------

                        ClassFunciones.clsFunciones.CreaTicket.EncabezadoVenta();
                        ClassFunciones.clsFunciones.CreaTicket.LineasGuion();
                        //Detalle de la factura
                        foreach (DataGridViewRow r in dgvDetalleFactura.Rows)
                        {

                            // Articulo                     //Precio                                    cantidad                            Subtotal
                            Ticket1.AgregaArticulo(r.Cells[1].Value.ToString(), (r.Cells[2].Value.ToString()), (r.Cells[3].Value.ToString()), (r.Cells[4].Value.ToString())); //imprime una linea de descripcion
                        }


                        ClassFunciones.clsFunciones.CreaTicket.LineasGuion();
                        Ticket1.AgregaTotales("Sub-Total", Convert.ToString(txtSubtotal.Text)); // imprime linea con Subtotal
                        Ticket1.AgregaTotales("ISV", (txtISV.Text)); // imprime linea con ITBis total
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Total", (txtTotalVentas.Text)); // imprime linea con total
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Efectivo Entregado:", (txtEfectivo.Text));
                        Ticket1.AgregaTotales("Efectivo Devuelto:", (txtDevolucion.Text));


                        // Ticket1.LineasTotales(); // imprime linea 

                        Ticket1.TextoIzquierda(" ");

                        Ticket1.TextoCentro("********************************************************************************");
                        Ticket1.TextoCentro("*                           Gracias por preferirnos                            *");
                        Ticket1.TextoCentro("********************************************************************************");
                        Ticket1.TextoIzquierda(" ");
                        //Falta el combo BOX para las impresoras
                        Ticket1.ImprimirTiket("Microsoft Print to PDF"); //Imprimir

                        Fila = 0;
                        while (dgvDetalleFactura.RowCount > 0)//limpia el dgv
                        { dgvDetalleFactura.Rows.Remove(dgvDetalleFactura.CurrentRow); }
                        //LBLIDnuevaFACTURA.Text = ClaseFunciones.ClsFunciones.IDNUEVAFACTURA().ToString();


                        string subTotal1, ISV1, TotalVents1;
                        subTotal1 = txtSubtotal.Text;
                        ISV1 = txtISV.Text;
                        TotalVents1 = txtTotalVentas.Text;

                        LimpiarFactura();
                        VaciarDTGDetalle();
                        txtBuscarCliente.Focus();
                        MessageBox.Show("Gracias por preferirnos");
                        contador = 0;
                        FinalizarVenta(index,subTotal1, ISV1, TotalVents1);
                        VaciarDTGDetalle();
                        ConsultaSubtotal();
                        LimpiarFactura();
                        index = "";
                    }
                }
                else
                {
                    MessageBox.Show("Error, El monto debe ser mayor que el Total", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEfectivo.Focus();
                }
            }
            else
            {
                MessageBox.Show("Error, Ingrese el Efectivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEfectivo.Focus();
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {

            if (txtBuscarCliente.Text != "")
            {
                if (SelecProducto == true)
                {
                    if (txtCantidad.Text != "")
                    {
                    if (Convert.ToInt32(txtCantidad.Text) > 0)
                        {
                            try
                            {
                                cantidad = Convert.ToInt32(txtCantidad.Text);

                                if (Estado != false)
                                {
                                    clsConexion.Conexion.LeerCadena();
                                    if (contador == 0)
                                    {
                                        SqlCommand com = new SqlCommand("AgregarFactura", clsConexion.Conexion.LeerCadena());
                                        com.CommandType = CommandType.StoredProcedure;
                                        com.Parameters.AddWithValue("@IdEmpleado", 1);
                                        com.Parameters.AddWithValue("@IdCliente", codigoCliente);
                                        com.Parameters.AddWithValue("@Descuento", 0);
                                        com.Parameters.AddWithValue("@DescuenPorcentaje", 0);
                                        com.Parameters.AddWithValue("@Subtotal", 0);
                                        com.Parameters.AddWithValue("@ISV", 0);
                                        com.Parameters.AddWithValue("@Total", 0);
                                        com.ExecuteNonQuery();
                                        contador++;
                                        btnImprimirFactura.Enabled = true;
                                        btnQuitarProduc.Enabled = true;

                                    }
                                }
                                index = ConsultaIndex();
                                AgregarDetalleVenta(index);
                                ConsultarDetalleFact();
                                ConsultaSubtotal();
                                    
                                Conteo++;
                                txtCantidad.Text = "";
                                SelecProducto = false;
                            }
                            catch (Exception error)
                            {
                                //MessageBox.Show(error.ToString());
                                MessageBox.Show("Error, Ya se ingreso el Producto ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                clsConexion.Conexion.LeerCadena();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Error, La cantidad no puede ser 0 ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCantidad.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error, Ingrese la Cantidad del producto ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCantidad.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Error, Seleccione el Producto ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else 
            {
                MessageBox.Show("Error, Ingrese el ID del cliente ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuscarCliente.Focus();
            }

        }
        private void FormVentas1_Load(object sender, EventArgs e)
        {
            CargarDGVproductos();
            VaciarDTGDetalle();
            txtBuscarCliente.Focus();
            btnQuitarProduc.Enabled = false;
            btnImprimirFactura.Enabled = false;
            lblHora.Text = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();
            txtVendedor.Text = ClassBT.clsHome.NombreEmpleado;



        }
        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtBuscarCliente.Text != "")
            {
                codigoCliente = txtBuscarCliente.Text;
                codigoProducto = dgvProductos.CurrentRow.Cells[0].Value.ToString();
                precio = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                Estado = true;
                MessageBox.Show("Producto Seleccionado");
                txtCantidad.Focus();
                SelecProducto = true;
            }
            else
            {
                MessageBox.Show("Error, Inserte él código del Cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuscarCliente.Focus();
            }
        }
    }
}