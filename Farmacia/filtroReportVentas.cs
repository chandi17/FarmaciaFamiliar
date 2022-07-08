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
    public partial class filtroReportVentas : Form
    {
        public filtroReportVentas()
        {
            InitializeComponent();
        }
        ~filtroReportVentas()
        {

        }

        public DateTime Fecha1 { get; set; }
        public DateTime Fecha2 { get; set; }

        private void filtroReportVentas_Load(object sender, EventArgs e)
        {

 
        }

        private void dtpfecha1_ValueChanged(object sender, EventArgs e)
        {

        }
        
        private void ValidarFecha()
        {
        
            if (dtpfecha1.Value.Date > dtpfecha2.Value.Date)
            {
               MessageBox.Show("La primera fecha debe ser menor que la segunda ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }

        }
        
        

        private void btnfiltrar_Click(object sender, EventArgs e)
        {
            Fecha1 = dtpfecha1.Value;
            Fecha2 = dtpfecha2.Value;

           ValidarFecha();


            // TODO: esta línea de código carga datos en la tabla 'dataSetReporteVenta.reportventas' Puede moverla o quitarla según sea necesario.
            this.reportventasTableAdapter.Fill(this.dataSetReporteVenta.reportventas, Fecha1, Fecha2);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            dtpfecha1.MinDate = new DateTime(2020, 1, 1);
            dtpfecha1.MaxDate = DateTime.Today;

            dtpfecha2.MinDate = new DateTime(2020, 1, 1);
            dtpfecha2.MaxDate = DateTime.Today;

        }
    }
}
