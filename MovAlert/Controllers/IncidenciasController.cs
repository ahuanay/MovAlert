using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovAlert.Models;

namespace MovAlert.Controllers
{
    public class IncidenciasController : Controller
    {
        private MovAlertBDModel db = new MovAlertBDModel();

        // GET: Incidencias
        public ActionResult Index()
        {
            return View(db.Incidencias.ToList());
        }

        // GET: Incidencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidencias incidencias = db.Incidencias.Find(id);
            if (incidencias == null)
            {
                return HttpNotFound();
            }
            return View(incidencias);
        }

        // GET: Incidencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Incidencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdIncidencia,Incidencia")] Incidencias incidencias)
        {
            if (ModelState.IsValid)
            {
                db.Incidencias.Add(incidencias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(incidencias);
        }

        // GET: Incidencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidencias incidencias = db.Incidencias.Find(id);
            if (incidencias == null)
            {
                return HttpNotFound();
            }
            return View(incidencias);
        }

        // POST: Incidencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdIncidencia,Incidencia")] Incidencias incidencias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incidencias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(incidencias);
        }

        // GET: Incidencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidencias incidencias = db.Incidencias.Find(id);
            if (incidencias == null)
            {
                return HttpNotFound();
            }
            return View(incidencias);
        }

        // POST: Incidencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Incidencias incidencias = db.Incidencias.Find(id);
            db.Incidencias.Remove(incidencias);
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
