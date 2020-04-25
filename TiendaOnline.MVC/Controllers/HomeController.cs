using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TiendaOnline.MVC.Models;

namespace TiendaOnline.MVC.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {

            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://sistranapi.azurewebsites.net/api/Categorias/GetAll");
            var CategoriasList = JsonConvert.DeserializeObject<List<Categoria>>(json);
            List<Categoria> categorialist = JsonConvert.DeserializeObject<List<Categoria>>(json);
            Session["categorias"] = categorialist;

            return View(categorialist);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}