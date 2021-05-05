using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto_AMABISCA.Models;

namespace Proyecto_AMABISCA.Controllers
{
    public class UnidadesController : Controller
    {
        private AMABISCAEntities db = new AMABISCAEntities();

        // GET: Unidades
        public ActionResult Index()
        {
            var pT_UNIDAD = db.PT_UNIDAD.Include(p => p.PT_TIPO_UNIDAD);
            return View(pT_UNIDAD.ToList());
        }

        // GET: Unidades/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PT_UNIDAD pT_UNIDAD = db.PT_UNIDAD.Find(id);
            if (pT_UNIDAD == null)
            {
                return HttpNotFound();
            }
            return View(pT_UNIDAD);
        }

        // GET: Unidades/Create
        public ActionResult Create()
        {
            ViewBag.RC_TIPO_UNIDAD = new SelectList(db.PT_TIPO_UNIDAD, "PC_TIPO_UNIDAD", "NOMBRE");
            return View();
        }

        // POST: Unidades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PC_UNIDAD,NOMBRE,RC_TIPO_UNIDAD")] PT_UNIDAD pT_UNIDAD)
        {
            if (ModelState.IsValid)
            {
                db.PT_UNIDAD.Add(pT_UNIDAD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RC_TIPO_UNIDAD = new SelectList(db.PT_TIPO_UNIDAD, "PC_TIPO_UNIDAD", "NOMBRE", pT_UNIDAD.RC_TIPO_UNIDAD);
            return View(pT_UNIDAD);
        }

        // GET: Unidades/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PT_UNIDAD pT_UNIDAD = db.PT_UNIDAD.Find(id);
            if (pT_UNIDAD == null)
            {
                return HttpNotFound();
            }
            ViewBag.RC_TIPO_UNIDAD = new SelectList(db.PT_TIPO_UNIDAD, "PC_TIPO_UNIDAD", "NOMBRE", pT_UNIDAD.RC_TIPO_UNIDAD);
            return View(pT_UNIDAD);
        }

        // POST: Unidades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PC_UNIDAD,NOMBRE,RC_TIPO_UNIDAD")] PT_UNIDAD pT_UNIDAD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pT_UNIDAD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RC_TIPO_UNIDAD = new SelectList(db.PT_TIPO_UNIDAD, "PC_TIPO_UNIDAD", "NOMBRE", pT_UNIDAD.RC_TIPO_UNIDAD);
            return View(pT_UNIDAD);
        }

        // GET: Unidades/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PT_UNIDAD pT_UNIDAD = db.PT_UNIDAD.Find(id);
            if (pT_UNIDAD == null)
            {
                return HttpNotFound();
            }
            return View(pT_UNIDAD);
        }

        // POST: Unidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PT_UNIDAD pT_UNIDAD = db.PT_UNIDAD.Find(id);
            db.PT_UNIDAD.Remove(pT_UNIDAD);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
