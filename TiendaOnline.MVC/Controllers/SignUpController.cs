using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TiendaOnline.MVC.Models;

namespace TiendaOnline.MVC.Controllers
{
    public class SignUpController : Controller
    {
        string baseurl = "https://sistranapi.azurewebsites.net/";

        // GET: SignUp
        public ActionResult Index()
        {
            return View();
        }


        // POST: SignUp/Create
        [HttpPost]
        public async Task<ActionResult> Create(SignUp entidad)
        {

            if (!entidad.passwordconfirm.Equals(entidad.usuario.clave)) 
            {
                ViewBag.Message = "La contraseñas no coinciden.";
                return View("Index");
            }
            else 
            {
                entidad.registro.Correo = entidad.usuario.codigo;
                entidad.usuario.rol = "Cliente";
                List<Registro> registro = new List<Registro>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseurl);

                    var myContent = JsonConvert.SerializeObject(entidad.registro);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var postTask = client.PostAsync("api/Registro/Insert", byteContent).Result;

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage res = await client.GetAsync("api/Registro/GetAll");

                        if (res.IsSuccessStatusCode)
                        {
                            var auxRes = res.Content.ReadAsStringAsync().Result;

                            registro = JsonConvert.DeserializeObject<List<Registro>>(auxRes);
                            var id_registro = (from x in registro
                                        where entidad.registro.Correo.Equals(x.Correo)
                                        select x).FirstOrDefault();
                            int codigoRegistro = id_registro.Id_registro;

                            entidad.usuario.Id_registro = codigoRegistro;
                            myContent = JsonConvert.SerializeObject(entidad.usuario);
                            buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                            byteContent = new ByteArrayContent(buffer);
                            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                            postTask = client.PostAsync("api/Usuario/Insert", byteContent).Result;

                            result = postTask;
                            if (result.IsSuccessStatusCode)
                            {
                                client.DefaultRequestHeaders.Clear();
                                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                res = await client.GetAsync("api/Usuario/GetAll");

                                if (res.IsSuccessStatusCode)
                                {
                                    auxRes = res.Content.ReadAsStringAsync().Result;

                                    List<Usuario> usuario = JsonConvert.DeserializeObject<List<Usuario>>(auxRes);
                                    var id_usuario = (from x in usuario
                                                       where entidad.usuario.codigo.Equals(x.codigo) & entidad.usuario.clave.Equals(x.clave)
                                                       select x).FirstOrDefault();
                                    Session["userId"]= id_usuario.Id_usuario;
                                    Session["rol"]= id_usuario.rol;
                                    Session["username"] = id_registro.Nombres + " " + id_registro.Apellidos;

                                }
                                return RedirectToAction("Index","Home");
                            }
                        }


                    }
                }
            ModelState.AddModelError(string.Empty, "Server Error, Please contact administrator");
                return View();
            }
        }
    }
}
