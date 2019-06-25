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
    public class RequisitoriadosController : Controller
    {
        private MovAlertBDModel db = new MovAlertBDModel();

        // GET: Requisitoriados
        public ActionResult Index()
        {
            return View(db.Requisitoriados.ToList());
        }

        // GET: Requisitoriados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Requisitoriados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRequisitoriado,Estado")] Requisitoriados requisitoriados, HttpPostedFileBase Imagen)
        {
            if (Imagen != null && Imagen.ContentLength > 0)
            {
                string archivo = Imagen.FileName;
                string urlBase = "/Img/";
                string url = urlBase + archivo;

                Imagen.SaveAs(Server.MapPath(url));

                requisitoriados.UrlImg = url;
            }

            if (ModelState.IsValid)
            {
                db.Requisitoriados.Add(requisitoriados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(requisitoriados);
        }

        // GET: Requisitoriados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisitoriados requisitoriados = db.Requisitoriados.Find(id);
            if (requisitoriados == null)
            {
                return HttpNotFound();
            }
            return View(requisitoriados);
        }

        // POST: Requisitoriados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRequisitoriado,UrlImg,Estado")] Requisitoriados requisitoriados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requisitoriados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(requisitoriados);
        }

        // GET: Requisitoriados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisitoriados requisitoriados = db.Requisitoriados.Find(id);
            if (requisitoriados == null)
            {
                return HttpNotFound();
            }
            return View(requisitoriados);
        }

        // POST: Requisitoriados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Requisitoriados requisitoriados = db.Requisitoriados.Find(id);
            db.Requisitoriados.Remove(requisitoriados);
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
