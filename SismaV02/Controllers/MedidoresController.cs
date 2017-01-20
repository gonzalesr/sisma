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
    public class MedidoresController : Controller
    {
        private SISMAEntities db = new SISMAEntities();

        // GET: Medidores
        public ActionResult Index()
        {
            return View(db.Medidor.ToList());
        }

        // GET: Medidores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medidor medidor = db.Medidor.Find(id);
            if (medidor == null)
            {
                return HttpNotFound();
            }
            return View(medidor);
        }

        // GET: Medidores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medidores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodMedidor,NroSerie,Marca,Modelo")] Medidor medidor)
        {
            if (ModelState.IsValid)
            {
                db.Medidor.Add(medidor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medidor);
        }

        // GET: Medidores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medidor medidor = db.Medidor.Find(id);
            if (medidor == null)
            {
                return HttpNotFound();
            }
            return View(medidor);
        }

        // POST: Medidores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodMedidor,NroSerie,Marca,Modelo")] Medidor medidor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medidor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medidor);
        }

        // GET: Medidores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medidor medidor = db.Medidor.Find(id);
            if (medidor == null)
            {
                return HttpNotFound();
            }
            return View(medidor);
        }

        // POST: Medidores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medidor medidor = db.Medidor.Find(id);
            db.Medidor.Remove(medidor);
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
