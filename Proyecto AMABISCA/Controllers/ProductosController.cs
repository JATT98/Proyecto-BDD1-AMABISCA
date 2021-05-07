using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Proyecto_AMABISCA.Models;

namespace Proyecto_AMABISCA.Controllers
{
    public class ProductosController : Controller
    {
        private AMABISCAEntities db = new AMABISCAEntities();

        // GET: Productos
        public ActionResult Index()
        {
            var pT_DESCRIPCION = db.PT_DESCRIPCION.Include(p => p.PT_UNIDAD);
            return View(pT_DESCRIPCION.ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PT_DESCRIPCION pT_DESCRIPCION = db.PT_DESCRIPCION.Find(id);
            if (pT_DESCRIPCION == null)
            {
                return HttpNotFound();
            }
            return View(pT_DESCRIPCION);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.RC_UNIDAD = new SelectList(db.PT_UNIDAD, "PC_UNIDAD", "NOMBRE");
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PC_PRODUCTO,NOMBRE,PRECIO,DESCRIPCION,IMAGEN,CANTIDAD,RC_UNIDAD")] PT_DESCRIPCION pT_DESCRIPCION)
        {
            HttpPostedFileBase FileBase = Request.Files[0];
            //HttpFileCollectionBase collectionBase = Request.Files;
            WebImage image = new WebImage(FileBase.InputStream);
            pT_DESCRIPCION.IMAGEN = image.GetBytes();

            if (ModelState.IsValid)
            {
                db.PT_DESCRIPCION.Add(pT_DESCRIPCION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RC_UNIDAD = new SelectList(db.PT_UNIDAD, "PC_UNIDAD", "NOMBRE", pT_DESCRIPCION.RC_UNIDAD);
            return View(pT_DESCRIPCION);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PT_DESCRIPCION pT_DESCRIPCION = db.PT_DESCRIPCION.Find(id);
            if (pT_DESCRIPCION == null)
            {
                return HttpNotFound();
            }
            ViewBag.RC_UNIDAD = new SelectList(db.PT_UNIDAD, "PC_UNIDAD", "NOMBRE", pT_DESCRIPCION.RC_UNIDAD);
            return View(pT_DESCRIPCION);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PC_PRODUCTO,NOMBRE,PRECIO,DESCRIPCION,IMAGEN,CANTIDAD,RC_UNIDAD")] PT_DESCRIPCION pT_DESCRIPCION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pT_DESCRIPCION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RC_UNIDAD = new SelectList(db.PT_UNIDAD, "PC_UNIDAD", "NOMBRE", pT_DESCRIPCION.RC_UNIDAD);
            return View(pT_DESCRIPCION);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PT_DESCRIPCION pT_DESCRIPCION = db.PT_DESCRIPCION.Find(id);
            if (pT_DESCRIPCION == null)
            {
                return HttpNotFound();
            }
            return View(pT_DESCRIPCION);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PT_DESCRIPCION pT_DESCRIPCION = db.PT_DESCRIPCION.Find(id);
            db.PT_DESCRIPCION.Remove(pT_DESCRIPCION);
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


        public ActionResult getImage(int id)
        {
            PT_DESCRIPCION productosK = db.PT_DESCRIPCION.Find(id);
            byte[] byteImage = productosK.IMAGEN;
            MemoryStream memoryStream = new MemoryStream(byteImage);
            Image image = Image.FromStream(memoryStream);

            memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Png);
            memoryStream.Position = 0;

            return File(memoryStream, "image/png");
        }
    }
}
