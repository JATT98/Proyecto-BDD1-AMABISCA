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
    public class SolicitadosController : Controller
    {
        // GET: Solicitados
        private AMABISCAEntities db = new AMABISCAEntities();

        public ActionResult Index(String LIMITE)
        {
            int x = (LIMITE == null || LIMITE == "") ? 1 : Int32.Parse(LIMITE);
            var solicitados = db.Database.SqlQuery<Prroducto>(
                @"P_PRODUCTOS_SOLICITADOS @LIMITE", new SqlParameter("@LIMITE", x)).ToList();

            return View(solicitados);
        }

        // GET: Solicitados/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Solicitados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Solicitados/Create
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

        // GET: Solicitados/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Solicitados/Edit/5
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

        // GET: Solicitados/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Solicitados/Delete/5
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
            var solicitados = db.Database.SqlQuery<ViewProductos>(
                @"P_PRODUCTOS_SOLICITADOS @LIMITE", new SqlParameter("@LIMITE", x)).ToList();

            return View(solicitados);
        }
        public ActionResult Print(String var)
        {
            return new ActionAsPdf("Report", new { LIMITE = var })
            { FileName = "Reporte_Productos.pdf" };
        }
    }
}
