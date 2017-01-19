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
    public class CallesController : Controller
    {
        private SISMAEntities db = new SISMAEntities();

        // GET: Calles
        public ActionResult Index()
        {
            var calle = db.Calle.Include(c => c.Barrio);
            return View(calle.ToList());
        }

        // GET: Calles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calle calle = db.Calle.Find(id);
            if (calle == null)
            {
                return HttpNotFound();
            }
            return View(calle);
        }

        // GET: Calles/Create
        public ActionResult Create()
        {
            ViewBag.CodBarrio = new SelectList(db.Barrio, "CodBarrio", "NomBarrio");
            return View();
        }

        // POST: Calles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodCalle,CodBarrio,NomCalle")] Calle calle)
        {
            if (ModelState.IsValid)
            {
                db.Calle.Add(calle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodBarrio = new SelectList(db.Barrio, "CodBarrio", "NomBarrio", calle.CodBarrio);
            return View(calle);
        }

        // GET: Calles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calle calle = db.Calle.Find(id);
            if (calle == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodBarrio = new SelectList(db.Barrio, "CodBarrio", "NomBarrio", calle.CodBarrio);
            return View(calle);
        }

        // POST: Calles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodCalle,CodBarrio,NomCalle")] Calle calle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodBarrio = new SelectList(db.Barrio, "CodBarrio", "NomBarrio", calle.CodBarrio);
            return View(calle);
        }

        // GET: Calles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calle calle = db.Calle.Find(id);
            if (calle == null)
            {
                return HttpNotFound();
            }
            return View(calle);
        }

        // POST: Calles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calle calle = db.Calle.Find(id);
            db.Calle.Remove(calle);
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
