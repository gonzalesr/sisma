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
    public class PrivilegiosController : Controller
    {
        private SISMAEntities db = new SISMAEntities();

        // GET: Privilegios
        public ActionResult Index()
        {
            return View(db.Privilegio.ToList());
        }

        // GET: Privilegios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Privilegio privilegio = db.Privilegio.Find(id);
            if (privilegio == null)
            {
                return HttpNotFound();
            }
            return View(privilegio);
        }

        // GET: Privilegios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Privilegios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodPrivil,DesPriv")] Privilegio privilegio)
        {
            if (ModelState.IsValid)
            {
                db.Privilegio.Add(privilegio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(privilegio);
        }

        // GET: Privilegios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Privilegio privilegio = db.Privilegio.Find(id);
            if (privilegio == null)
            {
                return HttpNotFound();
            }
            return View(privilegio);
        }

        // POST: Privilegios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodPrivil,DesPriv")] Privilegio privilegio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(privilegio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(privilegio);
        }

        // GET: Privilegios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Privilegio privilegio = db.Privilegio.Find(id);
            if (privilegio == null)
            {
                return HttpNotFound();
            }
            return View(privilegio);
        }

        // POST: Privilegios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Privilegio privilegio = db.Privilegio.Find(id);
            db.Privilegio.Remove(privilegio);
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
