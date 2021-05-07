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
    public class FacturaController : Controller
    {
        private AMABISCAEntities db = new AMABISCAEntities();

        // GET: Factura
        public ActionResult Index()
        {
            var oT_IDENTIFICACION = db.OT_IDENTIFICACION.Include(o => o.OT_ENVIO).Include(o => o.OT_ESTADO).Include(o => o.UT_CUENTA).Include(o => o.UT_CUENTA1);
            return View(oT_IDENTIFICACION.ToList());
        }

        // GET: Factura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OT_IDENTIFICACION oT_IDENTIFICACION = db.OT_IDENTIFICACION.Find(id);
            if (oT_IDENTIFICACION == null)
            {
                return HttpNotFound();
            }
            return View(oT_IDENTIFICACION);
        }

        // GET: Factura/Create
        public ActionResult Create()
        {
            ViewBag.RC_ENVIO = new SelectList(db.OT_ENVIO, "PC_ENVIO", "NOMBRE");
            ViewBag.RC_ESTADO = new SelectList(db.OT_ESTADO, "PC_ESTADO", "NOMBRE");
            ViewBag.RC_CLIENTE = new SelectList(db.UT_CUENTA, "PC_CUENTA", "NOMBRE");
            ViewBag.RC_EMISOR = new SelectList(db.UT_CUENTA, "PC_CUENTA", "NOMBRE");
            return View();
        }

        // POST: Factura/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PC_ORDEN,F_EMISION,RC_CLIENTE,RC_EMISOR,RC_ESTADO,RC_ENVIO")] OT_IDENTIFICACION oT_IDENTIFICACION)
        {
            if (ModelState.IsValid)
            {
                db.OT_IDENTIFICACION.Add(oT_IDENTIFICACION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RC_ENVIO = new SelectList(db.OT_ENVIO, "PC_ENVIO", "NOMBRE", oT_IDENTIFICACION.RC_ENVIO);
            ViewBag.RC_ESTADO = new SelectList(db.OT_ESTADO, "PC_ESTADO", "NOMBRE", oT_IDENTIFICACION.RC_ESTADO);
            ViewBag.RC_CLIENTE = new SelectList(db.UT_CUENTA, "PC_CUENTA", "NOMBRE", oT_IDENTIFICACION.RC_CLIENTE);
            ViewBag.RC_EMISOR = new SelectList(db.UT_CUENTA, "PC_CUENTA", "NOMBRE", oT_IDENTIFICACION.RC_EMISOR);
            return View(oT_IDENTIFICACION);
        }

        // GET: Factura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OT_IDENTIFICACION oT_IDENTIFICACION = db.OT_IDENTIFICACION.Find(id);
            if (oT_IDENTIFICACION == null)
            {
                return HttpNotFound();
            }
            ViewBag.RC_ENVIO = new SelectList(db.OT_ENVIO, "PC_ENVIO", "NOMBRE", oT_IDENTIFICACION.RC_ENVIO);
            ViewBag.RC_ESTADO = new SelectList(db.OT_ESTADO, "PC_ESTADO", "NOMBRE", oT_IDENTIFICACION.RC_ESTADO);
            ViewBag.RC_CLIENTE = new SelectList(db.UT_CUENTA, "PC_CUENTA", "NOMBRE", oT_IDENTIFICACION.RC_CLIENTE);
            ViewBag.RC_EMISOR = new SelectList(db.UT_CUENTA, "PC_CUENTA", "NOMBRE", oT_IDENTIFICACION.RC_EMISOR);
            return View(oT_IDENTIFICACION);
        }

        // POST: Factura/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PC_ORDEN,F_EMISION,RC_CLIENTE,RC_EMISOR,RC_ESTADO,RC_ENVIO")] OT_IDENTIFICACION oT_IDENTIFICACION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oT_IDENTIFICACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RC_ENVIO = new SelectList(db.OT_ENVIO, "PC_ENVIO", "NOMBRE", oT_IDENTIFICACION.RC_ENVIO);
            ViewBag.RC_ESTADO = new SelectList(db.OT_ESTADO, "PC_ESTADO", "NOMBRE", oT_IDENTIFICACION.RC_ESTADO);
            ViewBag.RC_CLIENTE = new SelectList(db.UT_CUENTA, "PC_CUENTA", "NOMBRE", oT_IDENTIFICACION.RC_CLIENTE);
            ViewBag.RC_EMISOR = new SelectList(db.UT_CUENTA, "PC_CUENTA", "NOMBRE", oT_IDENTIFICACION.RC_EMISOR);
            return View(oT_IDENTIFICACION);
        }

        // GET: Factura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OT_IDENTIFICACION oT_IDENTIFICACION = db.OT_IDENTIFICACION.Find(id);
            if (oT_IDENTIFICACION == null)
            {
                return HttpNotFound();
            }
            return View(oT_IDENTIFICACION);
        }

        // POST: Factura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OT_IDENTIFICACION oT_IDENTIFICACION = db.OT_IDENTIFICACION.Find(id);
            db.OT_IDENTIFICACION.Remove(oT_IDENTIFICACION);
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
