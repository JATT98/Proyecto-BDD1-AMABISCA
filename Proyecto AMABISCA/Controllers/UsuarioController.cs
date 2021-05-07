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
    public class UsuarioController : Controller
    {
        private AMABISCAEntities db = new AMABISCAEntities();

        // GET: Usuario
        public ActionResult Index()
        {
            var uT_DESCRIPCION = db.UT_DESCRIPCION.Include(u => u.UT_CUENTA);
            return View(uT_DESCRIPCION.ToList());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UT_DESCRIPCION uT_DESCRIPCION = db.UT_DESCRIPCION.Find(id);
            if (uT_DESCRIPCION == null)
            {
                return HttpNotFound();
            }
            return View(uT_DESCRIPCION);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.PRC_USUARIO = new SelectList(db.UT_CUENTA, "PC_CUENTA", "NOMBRE");
            return View();
        }

        // POST: Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRC_USUARIO,NOMBRE,APELLIDO,DNI,DIRECCION,TELEFONO,CORREO,F_NACIMIENTO,SEXO")] UT_DESCRIPCION uT_DESCRIPCION)
        {
            if (ModelState.IsValid)
            {
                db.UT_DESCRIPCION.Add(uT_DESCRIPCION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PRC_USUARIO = new SelectList(db.UT_CUENTA, "PC_CUENTA", "NOMBRE", uT_DESCRIPCION.PRC_USUARIO);
            return View(uT_DESCRIPCION);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UT_DESCRIPCION uT_DESCRIPCION = db.UT_DESCRIPCION.Find(id);
            if (uT_DESCRIPCION == null)
            {
                return HttpNotFound();
            }
            ViewBag.PRC_USUARIO = new SelectList(db.UT_CUENTA, "PC_CUENTA", "NOMBRE", uT_DESCRIPCION.PRC_USUARIO);
            return View(uT_DESCRIPCION);
        }

        // POST: Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRC_USUARIO,NOMBRE,APELLIDO,DNI,DIRECCION,TELEFONO,CORREO,F_NACIMIENTO,SEXO")] UT_DESCRIPCION uT_DESCRIPCION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uT_DESCRIPCION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PRC_USUARIO = new SelectList(db.UT_CUENTA, "PC_CUENTA", "NOMBRE", uT_DESCRIPCION.PRC_USUARIO);
            return View(uT_DESCRIPCION);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UT_DESCRIPCION uT_DESCRIPCION = db.UT_DESCRIPCION.Find(id);
            if (uT_DESCRIPCION == null)
            {
                return HttpNotFound();
            }
            return View(uT_DESCRIPCION);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UT_DESCRIPCION uT_DESCRIPCION = db.UT_DESCRIPCION.Find(id);
            db.UT_DESCRIPCION.Remove(uT_DESCRIPCION);
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
