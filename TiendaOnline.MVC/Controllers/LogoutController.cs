using Newtonsoft.Json;
using TiendaOnline.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TiendaOnline.MVC.Controllers
{
    public class LogoutController : Controller
    {
        
        // GET: Login
        public ActionResult Index()
        {
            Session.Abandon();
            Response.Redirect("Login");
            return View();
        }
    }
}