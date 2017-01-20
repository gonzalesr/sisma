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
    public class CategoriasServiciosController : Controller
    {
        private SISMAEntities db = new SISMAEntities();

        // GET: CategoriasServicios
        public ActionResult Index()
        {
            return View(db.CatServicio.ToList());
        }

        // GET: CategoriasServicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatServicio catServicio = db.CatServicio.Find(id);
            if (catServicio == null)
            {
                return HttpNotFound();
            }
            return View(catServicio);
        }

        // GET: CategoriasServicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriasServicios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodCategoria,NomCategoria")] CatServicio catServicio)
        {
            if (ModelState.IsValid)
            {
                db.CatServicio.Add(catServicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(catServicio);
        }

        // GET: CategoriasServicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatServicio catServicio = db.CatServicio.Find(id);
            if (catServicio == null)
            {
                return HttpNotFound();
            }
            return View(catServicio);
        }

        // POST: CategoriasServicios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodCategoria,NomCategoria")] CatServicio catServicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catServicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catServicio);
        }

        // GET: CategoriasServicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatServicio catServicio = db.CatServicio.Find(id);
            if (catServicio == null)
            {
                return HttpNotFound();
            }
            return View(catServicio);
        }

        // POST: CategoriasServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CatServicio catServicio = db.CatServicio.Find(id);
            db.CatServicio.Remove(catServicio);
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
