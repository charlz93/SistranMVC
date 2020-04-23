using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnline.MVC.Models
{
    public class Factura_cab
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Factura_cab()
        {
            this.Factura_lin = new HashSet<Factura_lin>();
        }

        public int Id_factura_cab { get; set; }
        public Nullable<int> Id_usuario { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<int> Id_estado { get; set; }
        public Nullable<decimal> Total_imp { get; set; }
        public Nullable<int> Procesado { get; set; }
        public System.DateTime Fecha_Fac { get; set; }

       // public virtual Estado Estado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Factura_lin> Factura_lin { get; set; }
       // public virtual Usuario Usuario { get; set; }
    }
}
