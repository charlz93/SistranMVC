using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaOnline.MVC.Models
{
    public class SignUp
    {
        public Registro registro { get; set; }
        public Usuario usuario { get; set; }
        //[Compare("usuario.clave", ErrorMessage = "Error")]
        public string passwordconfirm { get; set; }
    }
}