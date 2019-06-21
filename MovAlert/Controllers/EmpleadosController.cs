using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovAlert.Models;

namespace MovAlert.Controllers
{
    public class EmpleadosController : Controller
    {
        private MovAlertBDModel db = new MovAlertBDModel();

        // GET: Empleados
        public ActionResult Index()
        {
            return View(db.Empleados.ToList());
        }

        public ActionResult convertirImagen(string IdEmpleado)
        {
            var Avatar = db.Empleados.Where(x => x.IdEmpleado == IdEmpleado).FirstOrDefault();

            return File(Avatar.Avatar, "image/jpeg");
        }

        // GET: Empleados/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // GET: Empleados/Create
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "IdEmpleado,Apellido,Nombre,Telefono,Email,UserName,UserPass")] Empleados empleados, HttpPostedFileBase Avatar)
        {
            if (Avatar != null && Avatar.ContentLength > 0)
            {
                byte[] imagenData = null;
                using (var binaryReader = new BinaryReader(Avatar.InputStream))
                {
                    imagenData = binaryReader.ReadBytes(Avatar.ContentLength);
                }
                empleados.Avatar = imagenData;
            }

            if (ModelState.IsValid)
            {
                db.Empleados.Add(empleados);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Login");
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEmpleado,Apellido,Nombre,Telefono,Email,UserName,UserPass")] Empleados empleados, HttpPostedFileBase Avatar)
        {
            if (Avatar != null && Avatar.ContentLength > 0)
            {
                byte[] imagenData = null;
                using (var binaryReader = new BinaryReader(Avatar.InputStream))
                {
                    imagenData = binaryReader.ReadBytes(Avatar.ContentLength);
                }
                empleados.Avatar = imagenData;
            }

            if (ModelState.IsValid)
            {
                db.Empleados.Add(empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleados);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEmpleado,Apellido,Nombre,Telefono,Email,UserName,UserPass")] Empleados empleados, HttpPostedFileBase Avatar)
        {
            if (Avatar != null && Avatar.ContentLength > 0)
            {
                byte[] imagenData = null;
                using (var binaryReader = new BinaryReader(Avatar.InputStream))
                {
                    imagenData = binaryReader.ReadBytes(Avatar.ContentLength);
                }
                empleados.Avatar = imagenData;
            }

            if (ModelState.IsValid)
            {
                db.Entry(empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleados);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Empleados empleados = db.Empleados.Find(id);
            db.Empleados.Remove(empleados);
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
