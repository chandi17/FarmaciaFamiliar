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
    public partial class reporteventa : Form
    {
        public reporteventa()
        {
            InitializeComponent();
        }

        private void btnverreporteventas_Click(object sender, EventArgs e)
        {
            MostrarReporteVentas Mostrar = new MostrarReporteVentas();
            Mostrar.Fecha = dtreporteventas.Value;
            Mostrar.ShowDialog();
        }
    }
}
