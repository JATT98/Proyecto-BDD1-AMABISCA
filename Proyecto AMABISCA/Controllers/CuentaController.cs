using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Proyecto_AMABISCA.Models;

namespace Proyecto_AMABISCA.Controllers
{
    public class CuentaController : Controller
    {
        private AMABISCAEntities db = new AMABISCAEntities();

        // GET: Cuenta
        public ActionResult Index()
        {
            var uT_CUENTA = db.UT_CUENTA.Include(u => u.UT_ROL).Include(u => u.UT_DESCRIPCION);
            return View(uT_CUENTA.ToList());
        }

        // GET: Cuenta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UT_CUENTA uT_CUENTA = db.UT_CUENTA.Find(id);
            if (uT_CUENTA == null)
            {
                return HttpNotFound();
            }
            return View(uT_CUENTA);
        }

        // GET: Cuenta/Create
        public ActionResult Create()
        {
            ViewBag.RC_ROL = new SelectList(db.UT_ROL, "PC_ROL", "NOMBRE");
            ViewBag.PC_CUENTA = new SelectList(db.UT_DESCRIPCION, "PRC_USUARIO", "NOMBRE");
            return View();
        }

        // POST: Cuenta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PC_CUENTA,NOMBRE,CLAVE,RC_ROL")] UT_CUENTA uT_CUENTA)
        {
            uT_CUENTA.CLAVE = PBKDF2(uT_CUENTA.CLAVE);
            if (ModelState.IsValid)
            {
                db.UT_CUENTA.Add(uT_CUENTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RC_ROL = new SelectList(db.UT_ROL, "PC_ROL", "NOMBRE", uT_CUENTA.RC_ROL);
            ViewBag.PC_CUENTA = new SelectList(db.UT_DESCRIPCION, "PRC_USUARIO", "NOMBRE", uT_CUENTA.PC_CUENTA);
            return View(uT_CUENTA);
        }

        // GET: Cuenta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UT_CUENTA uT_CUENTA = db.UT_CUENTA.Find(id);
            if (uT_CUENTA == null)
            {
                return HttpNotFound();
            }
            ViewBag.RC_ROL = new SelectList(db.UT_ROL, "PC_ROL", "NOMBRE", uT_CUENTA.RC_ROL);
            ViewBag.PC_CUENTA = new SelectList(db.UT_DESCRIPCION, "PRC_USUARIO", "NOMBRE", uT_CUENTA.PC_CUENTA);
            return View(uT_CUENTA);
        }

        // POST: Cuenta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PC_CUENTA,NOMBRE,CLAVE,RC_ROL")] UT_CUENTA uT_CUENTA)
        {
            uT_CUENTA.CLAVE = PBKDF2(uT_CUENTA.CLAVE);
            if (ModelState.IsValid)
            {
                db.Entry(uT_CUENTA).State = EntityState.Modified;
                db.SaveChanges();
                return View("Create", "Usuario");
            }
            ViewBag.RC_ROL = new SelectList(db.UT_ROL, "PC_ROL", "NOMBRE", uT_CUENTA.RC_ROL);
            ViewBag.PC_CUENTA = new SelectList(db.UT_DESCRIPCION, "PRC_USUARIO", "NOMBRE", uT_CUENTA.PC_CUENTA);
            return View(uT_CUENTA);
        }

        // GET: Cuenta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UT_CUENTA uT_CUENTA = db.UT_CUENTA.Find(id);
            if (uT_CUENTA == null)
            {
                return HttpNotFound();
            }
            return View(uT_CUENTA);
        }

        // POST: Cuenta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UT_CUENTA uT_CUENTA = db.UT_CUENTA.Find(id);
            db.UT_CUENTA.Remove(uT_CUENTA);
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

        public const string SALT = "AD387F0761B5E621C6E5EFDF95BF9CF1"; 
        public const int HASH_SIZE = 32; 
        private string PBKDF2(string s)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(s + SALT);
            SHA256Managed sha256hasgstring = new SHA256Managed();
            byte[] hash = sha256hasgstring.ComputeHash(bytes);

            return ByteArrayToHexString(hash);
        }
        public static string ByteArrayToHexString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}
