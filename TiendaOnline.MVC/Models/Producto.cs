using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnline.MVC.Models
{
    public class Producto
    {
        public int Id_producto { get; set; }
        public Nullable<int> cantidad { get; set; }
        public string Nombre_producto { get; set; }
        public Nullable<int> Id_categoria { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<int> Id_promo { get; set; }
        public string Imagen { get; set; }
        public Nullable<int> Id_estado { get; set; }
        public string Descripcion { get; set; }

        //public virtual Categoria Categoria { get; set; }
        //public virtual Estado Estado { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]     
        //public virtual Promociones Promociones { get; set; }
    }
}
