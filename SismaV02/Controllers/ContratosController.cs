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
    public class ContratosController : Controller
    {
        private SISMAEntities db = new SISMAEntities();

        // GET: Contratos
        public ActionResult Index()
        {
            var contrato = db.Contrato.Include(c => c.Calle).Include(c => c.CatServicio).Include(c => c.Medidor).Include(c => c.Socio).Include(c => c.Usuario);
            return View(contrato.ToList());
        }

        // GET: Contratos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // GET: Contratos/Create
        public ActionResult Create()
        {
            ViewBag.CodCalle = new SelectList(db.Calle, "CodCalle", "NomCalle");
            ViewBag.CodCategoria = new SelectList(db.CatServicio, "CodCategoria", "NomCategoria");
            ViewBag.CodMedidor = new SelectList(db.Medidor, "CodMedidor", "NroSerie");
            ViewBag.CodSocio = new SelectList(db.Socio, "CodSocio", "NomSocio");
            ViewBag.CodUsuario = new SelectList(db.Usuario, "CodUsuario", "NomUsuario");
            return View();
        }

        // POST: Contratos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodContrato,CodFijo,FechaInicio,DireccionNro,NroDpto,Observacion,CodMedidor,CodCalle,CodCategoria,CodUsuario,CodSocio")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Contrato.Add(contrato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodCalle = new SelectList(db.Calle, "CodCalle", "NomCalle", contrato.CodCalle);
            ViewBag.CodCategoria = new SelectList(db.CatServicio, "CodCategoria", "NomCategoria", contrato.CodCategoria);
            ViewBag.CodMedidor = new SelectList(db.Medidor, "CodMedidor", "NroSerie", contrato.CodMedidor);
            ViewBag.CodSocio = new SelectList(db.Socio, "CodSocio", "NomSocio", contrato.CodSocio);
            ViewBag.CodUsuario = new SelectList(db.Usuario, "CodUsuario", "NomUsuario", contrato.CodUsuario);
            return View(contrato);
        }

        // GET: Contratos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodCalle = new SelectList(db.Calle, "CodCalle", "NomCalle", contrato.CodCalle);
            ViewBag.CodCategoria = new SelectList(db.CatServicio, "CodCategoria", "NomCategoria", contrato.CodCategoria);
            ViewBag.CodMedidor = new SelectList(db.Medidor, "CodMedidor", "NroSerie", contrato.CodMedidor);
            ViewBag.CodSocio = new SelectList(db.Socio, "CodSocio", "NomSocio", contrato.CodSocio);
            ViewBag.CodUsuario = new SelectList(db.Usuario, "CodUsuario", "NomUsuario", contrato.CodUsuario);
            return View(contrato);
        }

        // POST: Contratos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodContrato,CodFijo,FechaInicio,DireccionNro,NroDpto,Observacion,CodMedidor,CodCalle,CodCategoria,CodUsuario,CodSocio")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contrato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodCalle = new SelectList(db.Calle, "CodCalle", "NomCalle", contrato.CodCalle);
            ViewBag.CodCategoria = new SelectList(db.CatServicio, "CodCategoria", "NomCategoria", contrato.CodCategoria);
            ViewBag.CodMedidor = new SelectList(db.Medidor, "CodMedidor", "NroSerie", contrato.CodMedidor);
            ViewBag.CodSocio = new SelectList(db.Socio, "CodSocio", "NomSocio", contrato.CodSocio);
            ViewBag.CodUsuario = new SelectList(db.Usuario, "CodUsuario", "NomUsuario", contrato.CodUsuario);
            return View(contrato);
        }

        // GET: Contratos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // POST: Contratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contrato contrato = db.Contrato.Find(id);
            db.Contrato.Remove(contrato);
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
