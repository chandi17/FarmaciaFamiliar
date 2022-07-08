using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Farmacia
{
    internal class ClaseUsuarios
    {

        SqlConnection cn = new SqlConnection("Data Source = AGALEANO\\SQLEXPRESS; Initial Catalog = FarmaciaDesarrollo; Integrated Security = True");

        SqlDataAdapter sda;
        SqlCommand cmd;
        DataTable dt;


        public DataTable cargarComboboxUsuario()
        {
            sda = new SqlDataAdapter("ConsultaGeneralPerfiles", cn);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

    }
}
