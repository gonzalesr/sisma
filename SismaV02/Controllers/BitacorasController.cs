using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SismaV02.Models;

namespace SismaV02.Controllers
{
    public class BitacorasController : Controller
    {
        private SISMAEntities db = new SISMAEntities();

        // GET: Bitacoras
        public ActionResult Index()
        {
            var bitacora = db.Bitacora.Include(b => b.Transaccion).Include(b => b.Usuario);
            return View(bitacora.ToList());
        }

        // GET: Bitacoras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitacora bitacora = db.Bitacora.Find(id);
            if (bitacora == null)
            {
                return HttpNotFound();
            }
            return View(bitacora);
        }

        // GET: Bitacoras/Create
        public ActionResult Create()
        {
            ViewBag.CodTransac = new SelectList(db.Transaccion, "CodTransac", "DesTransac");
            ViewBag.CodUsuario = new SelectList(db.Usuario, "CodUsuario", "NomUsuario");
            return View();
        }

        // POST: Bitacoras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodBitac,FechaBitac,Hora,Tabla,Registro,CodTransac,CodUsuario")] Bitacora bitacora)
        {
            if (ModelState.IsValid)
            {
                db.Bitacora.Add(bitacora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodTransac = new SelectList(db.Transaccion, "CodTransac", "DesTransac", bitacora.CodTransac);
            ViewBag.CodUsuario = new SelectList(db.Usuario, "CodUsuario", "NomUsuario", bitacora.CodUsuario);
            return View(bitacora);
        }

        // GET: Bitacoras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitacora bitacora = db.Bitacora.Find(id);
            if (bitacora == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodTransac = new SelectList(db.Transaccion, "CodTransac", "DesTransac", bitacora.CodTransac);
            ViewBag.CodUsuario = new SelectList(db.Usuario, "CodUsuario", "NomUsuario", bitacora.CodUsuario);
            return View(bitacora);
        }

        // POST: Bitacoras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodBitac,FechaBitac,Hora,Tabla,Registro,CodTransac,CodUsuario")] Bitacora bitacora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bitacora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodTransac = new SelectList(db.Transaccion, "CodTransac", "DesTransac", bitacora.CodTransac);
            ViewBag.CodUsuario = new SelectList(db.Usuario, "CodUsuario", "NomUsuario", bitacora.CodUsuario);
            return View(bitacora);
        }

        // GET: Bitacoras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitacora bitacora = db.Bitacora.Find(id);
            if (bitacora == null)
            {
                return HttpNotFound();
            }
            return View(bitacora);
        }

        // POST: Bitacoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bitacora bitacora = db.Bitacora.Find(id);
            db.Bitacora.Remove(bitacora);
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
