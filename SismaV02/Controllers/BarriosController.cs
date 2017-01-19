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
    public class BarriosController : Controller
    {
        private SISMAEntities db = new SISMAEntities();

        // GET: Barrios
        public ActionResult Index()
        {
            return View(db.Barrio.ToList());
        }

        // GET: Barrios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrio barrio = db.Barrio.Find(id);
            if (barrio == null)
            {
                return HttpNotFound();
            }
            return View(barrio);
        }

        // GET: Barrios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Barrios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodBarrio,NomBarrio")] Barrio barrio)
        {
            if (ModelState.IsValid)
            {
                db.Barrio.Add(barrio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(barrio);
        }

        // GET: Barrios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrio barrio = db.Barrio.Find(id);
            if (barrio == null)
            {
                return HttpNotFound();
            }
            return View(barrio);
        }

        // POST: Barrios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodBarrio,NomBarrio")] Barrio barrio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(barrio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(barrio);
        }

        // GET: Barrios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrio barrio = db.Barrio.Find(id);
            if (barrio == null)
            {
                return HttpNotFound();
            }
            return View(barrio);
        }

        // POST: Barrios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Barrio barrio = db.Barrio.Find(id);
            db.Barrio.Remove(barrio);
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
