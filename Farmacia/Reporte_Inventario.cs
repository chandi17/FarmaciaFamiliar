using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacia
{
    public partial class Reporte_Inventario : Form
    {
        public Reporte_Inventario()
        {
            InitializeComponent();
        }

        ~Reporte_Inventario()
        {

        }
        private void Reporte_Inventario_Load(object sender, EventArgs e)
        {
            
        }

        private void btnfiltrar_Click(object sender, EventArgs e)
        {
            string NombreProduco;
            NombreProduco = textBox1.Text;
            // TODO: esta línea de código carga datos en la tabla 'dataSetInventario.PA_reporteinv1' Puede moverla o quitarla según sea necesario.
            this.pA_reporteinv1TableAdapter.Fill(this.dataSetInventario.PA_reporteinv1, NombreProduco);

            this.reportViewer1.RefreshReport();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
