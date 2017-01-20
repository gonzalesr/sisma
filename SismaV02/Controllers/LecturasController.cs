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
    public class LecturasController : Controller
    {
        private SISMAEntities db = new SISMAEntities();

        // GET: Lecturas
        public ActionResult Index()
        {
            var lectura = db.Lectura.Include(l => l.Medidor).Include(l => l.Periodo);
            return View(lectura.ToList());
        }

        // GET: Lecturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lectura lectura = db.Lectura.Find(id);
            if (lectura == null)
            {
                return HttpNotFound();
            }
            return View(lectura);
        }

        // GET: Lecturas/Create
        public ActionResult Create()
        {
            ViewBag.CodMedidor = new SelectList(db.Medidor, "CodMedidor", "NroSerie");
            ViewBag.CodPeriodo = new SelectList(db.Periodo, "CodPeriodo", "CodPeriodo");
            return View();
        }

        // POST: Lecturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodLectura,ValorLectura,Estado,Fecha,CodMedidor,CodPeriodo")] Lectura lectura)
        {
            if (ModelState.IsValid)
            {
                db.Lectura.Add(lectura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodMedidor = new SelectList(db.Medidor, "CodMedidor", "NroSerie", lectura.CodMedidor);
            ViewBag.CodPeriodo = new SelectList(db.Periodo, "CodPeriodo", "CodPeriodo", lectura.CodPeriodo);
            return View(lectura);
        }

        // GET: Lecturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lectura lectura = db.Lectura.Find(id);
            if (lectura == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodMedidor = new SelectList(db.Medidor, "CodMedidor", "NroSerie", lectura.CodMedidor);
            ViewBag.CodPeriodo = new SelectList(db.Periodo, "CodPeriodo", "CodPeriodo", lectura.CodPeriodo);
            return View(lectura);
        }

        // POST: Lecturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodLectura,ValorLectura,Estado,Fecha,CodMedidor,CodPeriodo")] Lectura lectura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lectura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodMedidor = new SelectList(db.Medidor, "CodMedidor", "NroSerie", lectura.CodMedidor);
            ViewBag.CodPeriodo = new SelectList(db.Periodo, "CodPeriodo", "CodPeriodo", lectura.CodPeriodo);
            return View(lectura);
        }

        // GET: Lecturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lectura lectura = db.Lectura.Find(id);
            if (lectura == null)
            {
                return HttpNotFound();
            }
            return View(lectura);
        }

        // POST: Lecturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lectura lectura = db.Lectura.Find(id);
            db.Lectura.Remove(lectura);
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
