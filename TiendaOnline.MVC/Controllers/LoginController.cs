using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using TiendaOnline.MVC.Models;

namespace TiendaOnline.MVC.Controllers
{
    public class LoginController : Controller
    {
        string baseurl = "https://sistranapi.azurewebsites.net/";
        // GET: Login
        public ActionResult Index()
        {
            return View(new Usuario());
        }
        [HttpPost]
        public async Task<ActionResult> Autorizar(Usuario usuario)
        {
            Usuario autorizado = new Usuario();
            List<Usuario> aux = new List<Usuario>();
            Registro auxr = new Registro();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Usuario/GetAll");

                if (res.IsSuccessStatusCode)
                {
                    var auxRes = res.Content.ReadAsStringAsync().Result;

                    aux = JsonConvert.DeserializeObject<List<Usuario>>(auxRes);
                    var user = (from x in aux
                                where x.codigo.Equals(usuario.codigo) & x.clave.Equals(usuario.clave)
                                select x).FirstOrDefault();

                    if (user != null)
                    {
                        Session["userId"] = user.Id_usuario;
                        Session["rol"] = user.rol;

                        res = await client.GetAsync("api/Registro/GetOneById/5?id="+user.Id_registro);
                        auxRes = res.Content.ReadAsStringAsync().Result;
                        auxr = JsonConvert.DeserializeObject<Registro>(auxRes);

                        Session["username"] = auxr.Nombres+" "+auxr.Apellidos;

                        return RedirectToAction("Index","Home");

                    }
                    else
                    {
                        ViewBag.Message = "Correo o contraseña invalido.";
                        return View("Index");
                    }

                }
                else 
                {
                    ViewBag.Message = "Error de conexion.";
                    return View("Index");
                }
              
            }
           
            
        }
    }
}