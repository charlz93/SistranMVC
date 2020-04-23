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
    public class RegistrosController : Controller
    {
        // GET: Registros
        string baseurl = "https://sistranapi.azurewebsites.net/";
        public async Task<ActionResult> Index()
        {
            List<Registro> aux = new List<Registro>();
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Registros/GetAll");

                if (res.IsSuccessStatusCode)
                {
                    var auxRes = res.Content.ReadAsStringAsync().Result;

                    aux = JsonConvert.DeserializeObject<List<Registro>>(auxRes);
                }
            }
            return View(aux);
        }

        // GET: Registros/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Registros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registros/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Registros/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Registros/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Registros/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Registros/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
