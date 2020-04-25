using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiendaOnline.MVC.Controllers
{
    public class Productos_ClienteController : Controller
    {
        // GET: Productos_Cliente
        public ActionResult Index()
        {
            return View();
        }

        // GET: Productos_Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Productos_Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos_Cliente/Create
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

        // GET: Productos_Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Productos_Cliente/Edit/5
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

        // GET: Productos_Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Productos_Cliente/Delete/5
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
