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
    public class CobrosServiciosController : Controller
    {
        private SISMAEntities db = new SISMAEntities();

        // GET: CobrosServicios
        public ActionResult Index()
        {
            var cobroServicio = db.CobroServicio.Include(c => c.Contrato).Include(c => c.Lectura).Include(c => c.Usuario);
            return View(cobroServicio.ToList());
        }

        // GET: CobrosServicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CobroServicio cobroServicio = db.CobroServicio.Find(id);
            if (cobroServicio == null)
            {
                return HttpNotFound();
            }
            return View(cobroServicio);
        }

        // GET: CobrosServicios/Create
        public ActionResult Create()
        {
            ViewBag.codContrato = new SelectList(db.Contrato, "CodContrato", "CodFijo");
            ViewBag.CodLectura = new SelectList(db.Lectura, "CodLectura", "CodLectura");
            ViewBag.CodUsuario = new SelectList(db.Usuario, "CodUsuario", "NomUsuario");
            return View();
        }

        // POST: CobrosServicios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodCobro,MontoTotal,Fecha,Glosa,CodUsuario,codContrato,CodLectura")] CobroServicio cobroServicio)
        {
            if (ModelState.IsValid)
            {
                db.CobroServicio.Add(cobroServicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codContrato = new SelectList(db.Contrato, "CodContrato", "CodFijo", cobroServicio.codContrato);
            ViewBag.CodLectura = new SelectList(db.Lectura, "CodLectura", "CodLectura", cobroServicio.CodLectura);
            ViewBag.CodUsuario = new SelectList(db.Usuario, "CodUsuario", "NomUsuario", cobroServicio.CodUsuario);
            return View(cobroServicio);
        }

        // GET: CobrosServicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CobroServicio cobroServicio = db.CobroServicio.Find(id);
            if (cobroServicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.codContrato = new SelectList(db.Contrato, "CodContrato", "CodFijo", cobroServicio.codContrato);
            ViewBag.CodLectura = new SelectList(db.Lectura, "CodLectura", "CodLectura", cobroServicio.CodLectura);
            ViewBag.CodUsuario = new SelectList(db.Usuario, "CodUsuario", "NomUsuario", cobroServicio.CodUsuario);
            return View(cobroServicio);
        }

        // POST: CobrosServicios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodCobro,MontoTotal,Fecha,Glosa,CodUsuario,codContrato,CodLectura")] CobroServicio cobroServicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cobroServicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codContrato = new SelectList(db.Contrato, "CodContrato", "CodFijo", cobroServicio.codContrato);
            ViewBag.CodLectura = new SelectList(db.Lectura, "CodLectura", "CodLectura", cobroServicio.CodLectura);
            ViewBag.CodUsuario = new SelectList(db.Usuario, "CodUsuario", "NomUsuario", cobroServicio.CodUsuario);
            return View(cobroServicio);
        }

        // GET: CobrosServicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CobroServicio cobroServicio = db.CobroServicio.Find(id);
            if (cobroServicio == null)
            {
                return HttpNotFound();
            }
            return View(cobroServicio);
        }

        // POST: CobrosServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CobroServicio cobroServicio = db.CobroServicio.Find(id);
            db.CobroServicio.Remove(cobroServicio);
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
