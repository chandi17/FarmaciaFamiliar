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
    public partial class MostrarReporteVentas : Form
    {
        public MostrarReporteVentas()
        {
            InitializeComponent();
        }
        public DateTime Fecha {get; set;}
        private void MostrarReporteVentas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'Datasetprincipal.ReporteVentas' Puede moverla o quitarla según sea necesario.
            this.ReporteVentasTableAdapter.Fill(this.Datasetprincipal.ReporteVentas, Fecha);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
