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
    public class AT_PROVEEDORController : Controller
    {
        private AMABISCAEntities db = new AMABISCAEntities();

        // GET: AT_PROVEEDOR
        public ActionResult Index()
        {
            return View(db.AT_PROVEEDOR.ToList());
        }

        // GET: AT_PROVEEDOR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AT_PROVEEDOR aT_PROVEEDOR = db.AT_PROVEEDOR.Find(id);
            if (aT_PROVEEDOR == null)
            {
                return HttpNotFound();
            }
            return View(aT_PROVEEDOR);
        }

        // GET: AT_PROVEEDOR/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AT_PROVEEDOR/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PC_PROVEEDOR,RAZON_SOCIAL,DIRECCION,TELEFONO")] AT_PROVEEDOR aT_PROVEEDOR)
        {
            if (ModelState.IsValid)
            {
                db.AT_PROVEEDOR.Add(aT_PROVEEDOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aT_PROVEEDOR);
        }

        // GET: AT_PROVEEDOR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AT_PROVEEDOR aT_PROVEEDOR = db.AT_PROVEEDOR.Find(id);
            if (aT_PROVEEDOR == null)
            {
                return HttpNotFound();
            }
            return View(aT_PROVEEDOR);
        }

        // POST: AT_PROVEEDOR/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PC_PROVEEDOR,RAZON_SOCIAL,DIRECCION,TELEFONO")] AT_PROVEEDOR aT_PROVEEDOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aT_PROVEEDOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aT_PROVEEDOR);
        }

        // GET: AT_PROVEEDOR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AT_PROVEEDOR aT_PROVEEDOR = db.AT_PROVEEDOR.Find(id);
            if (aT_PROVEEDOR == null)
            {
                return HttpNotFound();
            }
            return View(aT_PROVEEDOR);
        }

        // POST: AT_PROVEEDOR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AT_PROVEEDOR aT_PROVEEDOR = db.AT_PROVEEDOR.Find(id);
            db.AT_PROVEEDOR.Remove(aT_PROVEEDOR);
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
