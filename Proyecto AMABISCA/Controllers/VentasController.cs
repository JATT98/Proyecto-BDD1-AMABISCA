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
    public class VentasController : Controller
    {

        private AMABISCAEntities db = new AMABISCAEntities();

        public ActionResult Index(string date1, string date2)
        {
            DateTime d1 = (date1 == null || date1 == "") ? DateTime.Now : DateTime.Parse(date1);
            DateTime d2 = (date2 == null || date2 == "") ? DateTime.Now.AddDays(1) : DateTime.Parse(date2);
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@FECHAMIN", d1),
                new SqlParameter("@FECHAMAX", d2)
            };

            var ventas = db.Database.SqlQuery<Venta>(@"P_VENTAS_PERIODO @FECHAMIN, @FECHAMAX",param).ToList();

            return View(ventas);
        }

        // GET: Ventas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ventas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ventas/Create
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

        // GET: Ventas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ventas/Edit/5
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

        // GET: Ventas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ventas/Delete/5
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


        public ActionResult Report(String date1, String date2)
        {
            DateTime d1 = (date1 == null || date1 == "") ? DateTime.Now : DateTime.Parse(date1);
            DateTime d2 = (date2 == null || date2 == "") ? DateTime.Now.AddDays(1) : DateTime.Parse(date2);
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@FECHAMIN", d1),
                new SqlParameter("@FECHAMAX", d2)
            };

            var ventas = db.Database.SqlQuery<ViewVentas>(@"P_VENTAS_PERIODO @FECHAMIN, @FECHAMAX", param).ToList();

            return View(ventas);
        }
        public ActionResult Print(String var1, String var2)
        {
            return new ActionAsPdf("Report", new { date1 = var1, date2 = var2 })
            { FileName = "Reporte_Ventas_"+var1+"-"+var2+".pdf" };
        }


    }
}
