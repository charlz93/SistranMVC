using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnline.MVC.Models
{
    public class Factura_lin
    {
        public int Id_factura_lin { get; set; }
        public Nullable<int> Id_producto { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<decimal> Impuesto { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public int Id_Factura_Cab { get; set; }
        public System.DateTime Fecha_insert { get; set; }

        //public virtual Factura_cab Factura_cab { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
