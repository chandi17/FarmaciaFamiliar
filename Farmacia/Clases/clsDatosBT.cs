using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBT
{
    //Variables Necesarias para el detalle de la Venta
    public static class clsDetallesVenta
    {
        public static int idDetalleventa { get; set; }
        public static int idProdcutofk { get; set; }
        public static float Cantidad { get; set; }
        public static float CostoDetalle { get; set; }
        public static int IdVentafk { get; set; }
    }

    //Variables Necesarias para el Producto
    public static class clsProducto
    {
        public static int idProducto { get; set; }
        public static string NombreProducto { get; set; }
        public static float Precio { get; set; }

    }
    //Variables Necesarias para la Venta
    public static class clsVenta
    {

        public static int IdVenta { get; set; }
        public static float Costo { get; set; }
        public static string Fecha { get; set; }

    }
    //Variables Necesarias el dorm Home y para el nombre del empleado en la Factura
    public static class clsHome
    {
        public static string Fecha { get; set; }
        public static string NombreEmpleado { get; set; }
    }

}
