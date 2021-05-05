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
    public class BajasController : Controller
    {
        private AMABISCAEntities db = new AMABISCAEntities();

        // GET: Bajas
        public ActionResult Index()
        {
            var bT_DESCRIPCION = db.BT_DESCRIPCION.Include(b => b.PT_DESCRIPCION).Include(b => b.BT_TIPO);
            return View(bT_DESCRIPCION.ToList());
        }

        // GET: Bajas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BT_DESCRIPCION bT_DESCRIPCION = db.BT_DESCRIPCION.Find(id);
            if (bT_DESCRIPCION == null)
            {
                return HttpNotFound();
            }
            return View(bT_DESCRIPCION);
        }

        // GET: Bajas/Create
        public ActionResult Create()
        {
            ViewBag.RC_PRODUCTO = new SelectList(db.PT_DESCRIPCION, "PC_PRODUCTO", "NOMBRE");
            ViewBag.RC_TIPO = new SelectList(db.BT_TIPO, "PC_TIPO", "NOMBRE");
            return View();
        }

        // POST: Bajas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PC_BAJA,CANTIDAD,PRECIO,DETALLE,F_CREACION,RC_PRODUCTO,RC_TIPO")] BT_DESCRIPCION bT_DESCRIPCION)
        {
            if (ModelState.IsValid)
            {
                db.BT_DESCRIPCION.Add(bT_DESCRIPCION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RC_PRODUCTO = new SelectList(db.PT_DESCRIPCION, "PC_PRODUCTO", "NOMBRE", bT_DESCRIPCION.RC_PRODUCTO);
            ViewBag.RC_TIPO = new SelectList(db.BT_TIPO, "PC_TIPO", "NOMBRE", bT_DESCRIPCION.RC_TIPO);
            return View(bT_DESCRIPCION);
        }

        // GET: Bajas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BT_DESCRIPCION bT_DESCRIPCION = db.BT_DESCRIPCION.Find(id);
            if (bT_DESCRIPCION == null)
            {
                return HttpNotFound();
            }
            ViewBag.RC_PRODUCTO = new SelectList(db.PT_DESCRIPCION, "PC_PRODUCTO", "NOMBRE", bT_DESCRIPCION.RC_PRODUCTO);
            ViewBag.RC_TIPO = new SelectList(db.BT_TIPO, "PC_TIPO", "NOMBRE", bT_DESCRIPCION.RC_TIPO);
            return View(bT_DESCRIPCION);
        }

        // POST: Bajas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PC_BAJA,CANTIDAD,PRECIO,DETALLE,F_CREACION,RC_PRODUCTO,RC_TIPO")] BT_DESCRIPCION bT_DESCRIPCION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bT_DESCRIPCION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RC_PRODUCTO = new SelectList(db.PT_DESCRIPCION, "PC_PRODUCTO", "NOMBRE", bT_DESCRIPCION.RC_PRODUCTO);
            ViewBag.RC_TIPO = new SelectList(db.BT_TIPO, "PC_TIPO", "NOMBRE", bT_DESCRIPCION.RC_TIPO);
            return View(bT_DESCRIPCION);
        }

        // GET: Bajas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BT_DESCRIPCION bT_DESCRIPCION = db.BT_DESCRIPCION.Find(id);
            if (bT_DESCRIPCION == null)
            {
                return HttpNotFound();
            }
            return View(bT_DESCRIPCION);
        }

        // POST: Bajas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BT_DESCRIPCION bT_DESCRIPCION = db.BT_DESCRIPCION.Find(id);
            db.BT_DESCRIPCION.Remove(bT_DESCRIPCION);
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
