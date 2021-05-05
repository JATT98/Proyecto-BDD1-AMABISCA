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
    public class RolesController : Controller
    {
        private AMABISCAEntities db = new AMABISCAEntities();

        // GET: Roles
        public ActionResult Index()
        {
            return View(db.UT_ROL.ToList());
        }

        // GET: Roles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UT_ROL uT_ROL = db.UT_ROL.Find(id);
            if (uT_ROL == null)
            {
                return HttpNotFound();
            }
            return View(uT_ROL);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PC_ROL,NOMBRE,PERMISO")] UT_ROL uT_ROL)
        {
            if (ModelState.IsValid)
            {
                db.UT_ROL.Add(uT_ROL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uT_ROL);
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UT_ROL uT_ROL = db.UT_ROL.Find(id);
            if (uT_ROL == null)
            {
                return HttpNotFound();
            }
            return View(uT_ROL);
        }

        // POST: Roles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PC_ROL,NOMBRE,PERMISO")] UT_ROL uT_ROL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uT_ROL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uT_ROL);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UT_ROL uT_ROL = db.UT_ROL.Find(id);
            if (uT_ROL == null)
            {
                return HttpNotFound();
            }
            return View(uT_ROL);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UT_ROL uT_ROL = db.UT_ROL.Find(id);
            db.UT_ROL.Remove(uT_ROL);
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
