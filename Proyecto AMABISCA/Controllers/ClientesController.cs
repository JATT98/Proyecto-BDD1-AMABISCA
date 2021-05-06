using Proyecto_AMABISCA.Models;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_AMABISCA.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        private AMABISCAEntities db = new AMABISCAEntities();

        // GET: Clientes
        public ActionResult Index(string LIMITE)
        {

            int x = (LIMITE == null || LIMITE == "") ? 1 : Int32.Parse(LIMITE);
            var clientes = db.Database.SqlQuery<Cliente>(
                @"P_CLIENTES_RECURRENTES @LIMITE", new SqlParameter("@LIMITE", x)).ToList();


            return View(clientes);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
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

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Clientes/Edit/5
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

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Clientes/Delete/5
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
        public ActionResult Report(String LIMITE)
        {
            int x = (LIMITE == null || LIMITE == "") ? 1 : Int32.Parse(LIMITE);
            var clientes = db.Database.SqlQuery<ViewClientes>(
                @"P_CLIENTES_RECURRENTES @LIMITE", new SqlParameter("@LIMITE", x)).ToList();

            return View(clientes);
        }
        public ActionResult Print(String var)
        {
            return new ActionAsPdf("Report", new { LIMITE = var })
            { FileName = "Reporte_Mayores_Compras.pdf"};
        }
    }
}
