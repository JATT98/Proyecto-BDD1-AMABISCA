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
    public class OrdenController : Controller
    {
        private AMABISCAEntities db = new AMABISCAEntities();

        // GET: Orden
        public ActionResult Index()
        {
            var oT_DESCRIPCION = db.OT_DESCRIPCION.Include(o => o.OT_IDENTIFICACION).Include(o => o.PT_DESCRIPCION);
            return View(oT_DESCRIPCION.ToList());
        }

        // GET: Orden/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OT_DESCRIPCION oT_DESCRIPCION = db.OT_DESCRIPCION.Find(id);
            if (oT_DESCRIPCION == null)
            {
                return HttpNotFound();
            }
            return View(oT_DESCRIPCION);
        }

        // GET: Orden/Create
        public ActionResult Create()
        {
            ViewBag.PRC_ORDEN = new SelectList(db.OT_IDENTIFICACION, "PC_ORDEN", "RC_ESTADO");
            ViewBag.PRC_PRODUCTO = new SelectList(db.PT_DESCRIPCION, "PC_PRODUCTO", "NOMBRE");
            return View();
        }

        // POST: Orden/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRC_ORDEN,PRC_PRODUCTO,CONDICION,CANTIDAD,PRECIO")] OT_DESCRIPCION oT_DESCRIPCION)
        {
            if (ModelState.IsValid)
            {
                db.OT_DESCRIPCION.Add(oT_DESCRIPCION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PRC_ORDEN = new SelectList(db.OT_IDENTIFICACION, "PC_ORDEN", "RC_ESTADO", oT_DESCRIPCION.PRC_ORDEN);
            ViewBag.PRC_PRODUCTO = new SelectList(db.PT_DESCRIPCION, "PC_PRODUCTO", "NOMBRE", oT_DESCRIPCION.PRC_PRODUCTO);
            return View(oT_DESCRIPCION);
        }

        // GET: Orden/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OT_DESCRIPCION oT_DESCRIPCION = db.OT_DESCRIPCION.Find(id);
            if (oT_DESCRIPCION == null)
            {
                return HttpNotFound();
            }
            ViewBag.PRC_ORDEN = new SelectList(db.OT_IDENTIFICACION, "PC_ORDEN", "RC_ESTADO", oT_DESCRIPCION.PRC_ORDEN);
            ViewBag.PRC_PRODUCTO = new SelectList(db.PT_DESCRIPCION, "PC_PRODUCTO", "NOMBRE", oT_DESCRIPCION.PRC_PRODUCTO);
            return View(oT_DESCRIPCION);
        }

        // POST: Orden/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRC_ORDEN,PRC_PRODUCTO,CONDICION,CANTIDAD,PRECIO")] OT_DESCRIPCION oT_DESCRIPCION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oT_DESCRIPCION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PRC_ORDEN = new SelectList(db.OT_IDENTIFICACION, "PC_ORDEN", "RC_ESTADO", oT_DESCRIPCION.PRC_ORDEN);
            ViewBag.PRC_PRODUCTO = new SelectList(db.PT_DESCRIPCION, "PC_PRODUCTO", "NOMBRE", oT_DESCRIPCION.PRC_PRODUCTO);
            return View(oT_DESCRIPCION);
        }

        // GET: Orden/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OT_DESCRIPCION oT_DESCRIPCION = db.OT_DESCRIPCION.Find(id);
            if (oT_DESCRIPCION == null)
            {
                return HttpNotFound();
            }
            return View(oT_DESCRIPCION);
        }

        // POST: Orden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OT_DESCRIPCION oT_DESCRIPCION = db.OT_DESCRIPCION.Find(id);
            db.OT_DESCRIPCION.Remove(oT_DESCRIPCION);
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
