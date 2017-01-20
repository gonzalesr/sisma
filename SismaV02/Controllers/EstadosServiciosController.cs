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
    public class EstadosServiciosController : Controller
    {
        private SISMAEntities db = new SISMAEntities();

        // GET: EstadosServicios
        public ActionResult Index()
        {
            var estadoServicio = db.EstadoServicio.Include(e => e.Contrato);
            return View(estadoServicio.ToList());
        }

        // GET: EstadosServicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoServicio estadoServicio = db.EstadoServicio.Find(id);
            if (estadoServicio == null)
            {
                return HttpNotFound();
            }
            return View(estadoServicio);
        }

        // GET: EstadosServicios/Create
        public ActionResult Create()
        {
            ViewBag.CodContrato = new SelectList(db.Contrato, "CodContrato", "CodFijo");
            return View();
        }

        // POST: EstadosServicios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodEstado,Fecha,Estado,CodContrato")] EstadoServicio estadoServicio)
        {
            if (ModelState.IsValid)
            {
                db.EstadoServicio.Add(estadoServicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodContrato = new SelectList(db.Contrato, "CodContrato", "CodFijo", estadoServicio.CodContrato);
            return View(estadoServicio);
        }

        // GET: EstadosServicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoServicio estadoServicio = db.EstadoServicio.Find(id);
            if (estadoServicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodContrato = new SelectList(db.Contrato, "CodContrato", "CodFijo", estadoServicio.CodContrato);
            return View(estadoServicio);
        }

        // POST: EstadosServicios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodEstado,Fecha,Estado,CodContrato")] EstadoServicio estadoServicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoServicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodContrato = new SelectList(db.Contrato, "CodContrato", "CodFijo", estadoServicio.CodContrato);
            return View(estadoServicio);
        }

        // GET: EstadosServicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoServicio estadoServicio = db.EstadoServicio.Find(id);
            if (estadoServicio == null)
            {
                return HttpNotFound();
            }
            return View(estadoServicio);
        }

        // POST: EstadosServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoServicio estadoServicio = db.EstadoServicio.Find(id);
            db.EstadoServicio.Remove(estadoServicio);
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
