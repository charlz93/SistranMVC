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
    public class EstadosController : Controller
    {
        // GET: Estados
         string baseurl = "https://sistranapi.azurewebsites.net/";
        public async Task<ActionResult> Index()
        {
            List<Estado> aux = new List<Estado>();
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Estado/GetAll");

                if (res.IsSuccessStatusCode)
                {
                    var auxRes = res.Content.ReadAsStringAsync().Result;

                    aux = JsonConvert.DeserializeObject<List<Estado>>(auxRes);
                }
            }
            return View(aux);
        }

        // GET: Estados/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Estados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estados/Create
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

        // GET: Estados/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Estados/Edit/5
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

        // GET: Estados/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Estados/Delete/5
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
