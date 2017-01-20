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
    public class DetallesCobrosController : Controller
    {
        private SISMAEntities db = new SISMAEntities();

        // GET: DetallesCobros
        public ActionResult Index()
        {
            var detalleCobro = db.DetalleCobro.Include(d => d.CobroServicio).Include(d => d.Servicio);
            return View(detalleCobro.ToList());
        }

        // GET: DetallesCobros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCobro detalleCobro = db.DetalleCobro.Find(id);
            if (detalleCobro == null)
            {
                return HttpNotFound();
            }
            return View(detalleCobro);
        }

        // GET: DetallesCobros/Create
        public ActionResult Create()
        {
            ViewBag.CodCobro = new SelectList(db.CobroServicio, "CodCobro", "Glosa");
            ViewBag.CodServicio = new SelectList(db.Servicio, "CodServicio", "Descripcion");
            return View();
        }

        // POST: DetallesCobros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodCobro,CodServicio,Cantidad,Monto")] DetalleCobro detalleCobro)
        {
            if (ModelState.IsValid)
            {
                db.DetalleCobro.Add(detalleCobro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodCobro = new SelectList(db.CobroServicio, "CodCobro", "Glosa", detalleCobro.CodCobro);
            ViewBag.CodServicio = new SelectList(db.Servicio, "CodServicio", "Descripcion", detalleCobro.CodServicio);
            return View(detalleCobro);
        }

        // GET: DetallesCobros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCobro detalleCobro = db.DetalleCobro.Find(id);
            if (detalleCobro == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodCobro = new SelectList(db.CobroServicio, "CodCobro", "Glosa", detalleCobro.CodCobro);
            ViewBag.CodServicio = new SelectList(db.Servicio, "CodServicio", "Descripcion", detalleCobro.CodServicio);
            return View(detalleCobro);
        }

        // POST: DetallesCobros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodCobro,CodServicio,Cantidad,Monto")] DetalleCobro detalleCobro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleCobro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodCobro = new SelectList(db.CobroServicio, "CodCobro", "Glosa", detalleCobro.CodCobro);
            ViewBag.CodServicio = new SelectList(db.Servicio, "CodServicio", "Descripcion", detalleCobro.CodServicio);
            return View(detalleCobro);
        }

        // GET: DetallesCobros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCobro detalleCobro = db.DetalleCobro.Find(id);
            if (detalleCobro == null)
            {
                return HttpNotFound();
            }
            return View(detalleCobro);
        }

        // POST: DetallesCobros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleCobro detalleCobro = db.DetalleCobro.Find(id);
            db.DetalleCobro.Remove(detalleCobro);
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
