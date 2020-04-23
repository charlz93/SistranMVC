using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnline.MVC.Models
{
    public class Categoria
    {

        public int Id_categoria { get; set; }
        public string Nombre_categoria { get; set; }
        //public virtual ICollection<Producto> Productos { get; set; }
    }
}
