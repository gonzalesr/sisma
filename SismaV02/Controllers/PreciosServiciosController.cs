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
    public class PreciosServiciosController : Controller
    {
        private SISMAEntities db = new SISMAEntities();

        // GET: PreciosServicios
        public ActionResult Index()
        {
            var precioServicio = db.PrecioServicio.Include(p => p.CatServicio).Include(p => p.Servicio);
            return View(precioServicio.ToList());
        }

        // GET: PreciosServicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecioServicio precioServicio = db.PrecioServicio.Find(id);
            if (precioServicio == null)
            {
                return HttpNotFound();
            }
            return View(precioServicio);
        }

        // GET: PreciosServicios/Create
        public ActionResult Create()
        {
            ViewBag.CodCategoria = new SelectList(db.CatServicio, "CodCategoria", "NomCategoria");
            ViewBag.CodServicio = new SelectList(db.Servicio, "CodServicio", "Descripcion");
            return View();
        }

        // POST: PreciosServicios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodCategoria,CodServicio,PrecioUnit")] PrecioServicio precioServicio)
        {
            if (ModelState.IsValid)
            {
                db.PrecioServicio.Add(precioServicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodCategoria = new SelectList(db.CatServicio, "CodCategoria", "NomCategoria", precioServicio.CodCategoria);
            ViewBag.CodServicio = new SelectList(db.Servicio, "CodServicio", "Descripcion", precioServicio.CodServicio);
            return View(precioServicio);
        }

        // GET: PreciosServicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecioServicio precioServicio = db.PrecioServicio.Find(id);
            if (precioServicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodCategoria = new SelectList(db.CatServicio, "CodCategoria", "NomCategoria", precioServicio.CodCategoria);
            ViewBag.CodServicio = new SelectList(db.Servicio, "CodServicio", "Descripcion", precioServicio.CodServicio);
            return View(precioServicio);
        }

        // POST: PreciosServicios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodCategoria,CodServicio,PrecioUnit")] PrecioServicio precioServicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(precioServicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodCategoria = new SelectList(db.CatServicio, "CodCategoria", "NomCategoria", precioServicio.CodCategoria);
            ViewBag.CodServicio = new SelectList(db.Servicio, "CodServicio", "Descripcion", precioServicio.CodServicio);
            return View(precioServicio);
        }

        // GET: PreciosServicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecioServicio precioServicio = db.PrecioServicio.Find(id);
            if (precioServicio == null)
            {
                return HttpNotFound();
            }
            return View(precioServicio);
        }

        // POST: PreciosServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrecioServicio precioServicio = db.PrecioServicio.Find(id);
            db.PrecioServicio.Remove(precioServicio);
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
