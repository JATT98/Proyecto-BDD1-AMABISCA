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
    public class PT_TIPO_UNIDADController : Controller
    {
        private AMABISCAEntities db = new AMABISCAEntities();

        // GET: PT_TIPO_UNIDAD
        public ActionResult Index()
        {
            return View(db.PT_TIPO_UNIDAD.ToList());
        }

        // GET: PT_TIPO_UNIDAD/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PT_TIPO_UNIDAD pT_TIPO_UNIDAD = db.PT_TIPO_UNIDAD.Find(id);
            if (pT_TIPO_UNIDAD == null)
            {
                return HttpNotFound();
            }
            return View(pT_TIPO_UNIDAD);
        }

        // GET: PT_TIPO_UNIDAD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PT_TIPO_UNIDAD/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PC_TIPO_UNIDAD,NOMBRE")] PT_TIPO_UNIDAD pT_TIPO_UNIDAD)
        {
            if (ModelState.IsValid)
            {
                db.PT_TIPO_UNIDAD.Add(pT_TIPO_UNIDAD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pT_TIPO_UNIDAD);
        }

        // GET: PT_TIPO_UNIDAD/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PT_TIPO_UNIDAD pT_TIPO_UNIDAD = db.PT_TIPO_UNIDAD.Find(id);
            if (pT_TIPO_UNIDAD == null)
            {
                return HttpNotFound();
            }
            return View(pT_TIPO_UNIDAD);
        }

        // POST: PT_TIPO_UNIDAD/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PC_TIPO_UNIDAD,NOMBRE")] PT_TIPO_UNIDAD pT_TIPO_UNIDAD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pT_TIPO_UNIDAD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pT_TIPO_UNIDAD);
        }

        // GET: PT_TIPO_UNIDAD/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PT_TIPO_UNIDAD pT_TIPO_UNIDAD = db.PT_TIPO_UNIDAD.Find(id);
            if (pT_TIPO_UNIDAD == null)
            {
                return HttpNotFound();
            }
            return View(pT_TIPO_UNIDAD);
        }

        // POST: PT_TIPO_UNIDAD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PT_TIPO_UNIDAD pT_TIPO_UNIDAD = db.PT_TIPO_UNIDAD.Find(id);
            db.PT_TIPO_UNIDAD.Remove(pT_TIPO_UNIDAD);
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
