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
    public class AltasController : Controller
    {
        private AMABISCAEntities db = new AMABISCAEntities();

        // GET: Altas
        public ActionResult Index(string SearchValue)
        {
            var aT_DESCRIPCION = db.AT_DESCRIPCION.Include(a => a.PT_DESCRIPCION).Include(a => a.AT_PROVEEDOR);
            return View(aT_DESCRIPCION.Where(x => x.PT_DESCRIPCION.NOMBRE.Contains(SearchValue)||SearchValue == null).ToList());
        }

        // GET: Altas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AT_DESCRIPCION aT_DESCRIPCION = db.AT_DESCRIPCION.Find(id);
            if (aT_DESCRIPCION == null)
            {
                return HttpNotFound();
            }
            return View(aT_DESCRIPCION);
        }

        // GET: Altas/Create
        public ActionResult Create()
        {
            ViewBag.RC_PRODUCTO = new SelectList(db.PT_DESCRIPCION, "PC_PRODUCTO", "NOMBRE");
            ViewBag.RC_PROVEEDOR = new SelectList(db.AT_PROVEEDOR, "PC_PROVEEDOR", "RAZON_SOCIAL");
            return View();
        }

        // POST: Altas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PC_ALTA,CANTIDAD,PRECIO,F_CREACION,RC_PRODUCTO,RC_PROVEEDOR")] AT_DESCRIPCION aT_DESCRIPCION)
        {
            if (ModelState.IsValid)
            {
                db.AT_DESCRIPCION.Add(aT_DESCRIPCION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RC_PRODUCTO = new SelectList(db.PT_DESCRIPCION, "PC_PRODUCTO", "NOMBRE", aT_DESCRIPCION.RC_PRODUCTO);
            ViewBag.RC_PROVEEDOR = new SelectList(db.AT_PROVEEDOR, "PC_PROVEEDOR", "RAZON_SOCIAL", aT_DESCRIPCION.RC_PROVEEDOR);
            return View(aT_DESCRIPCION);
        }

        // GET: Altas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AT_DESCRIPCION aT_DESCRIPCION = db.AT_DESCRIPCION.Find(id);
            if (aT_DESCRIPCION == null)
            {
                return HttpNotFound();
            }
            ViewBag.RC_PRODUCTO = new SelectList(db.PT_DESCRIPCION, "PC_PRODUCTO", "NOMBRE", aT_DESCRIPCION.RC_PRODUCTO);
            ViewBag.RC_PROVEEDOR = new SelectList(db.AT_PROVEEDOR, "PC_PROVEEDOR", "RAZON_SOCIAL", aT_DESCRIPCION.RC_PROVEEDOR);
            return View(aT_DESCRIPCION);
        }

        // POST: Altas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PC_ALTA,CANTIDAD,PRECIO,F_CREACION,RC_PRODUCTO,RC_PROVEEDOR")] AT_DESCRIPCION aT_DESCRIPCION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aT_DESCRIPCION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RC_PRODUCTO = new SelectList(db.PT_DESCRIPCION, "PC_PRODUCTO", "NOMBRE", aT_DESCRIPCION.RC_PRODUCTO);
            ViewBag.RC_PROVEEDOR = new SelectList(db.AT_PROVEEDOR, "PC_PROVEEDOR", "RAZON_SOCIAL", aT_DESCRIPCION.RC_PROVEEDOR);
            return View(aT_DESCRIPCION);
        }

        // GET: Altas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AT_DESCRIPCION aT_DESCRIPCION = db.AT_DESCRIPCION.Find(id);
            if (aT_DESCRIPCION == null)
            {
                return HttpNotFound();
            }
            return View(aT_DESCRIPCION);
        }

        // POST: Altas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AT_DESCRIPCION aT_DESCRIPCION = db.AT_DESCRIPCION.Find(id);
            db.AT_DESCRIPCION.Remove(aT_DESCRIPCION);
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
