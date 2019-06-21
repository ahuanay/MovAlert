using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovAlert.Models;

namespace MovAlert.Controllers
{
    public class LoginController : Controller
    {
        private MovAlertBDModel db = new MovAlertBDModel();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autherize(MovAlert.Models.Empleados emp)
        {
            var user = db.Empleados.Where(x => x.UserName == emp.UserName && x.UserPass == emp.UserPass).FirstOrDefault();
            if (user == null)
                return View("Index");
            else
            {
                Session["IdEmpleado"] = user.IdEmpleado;
                Session["Avatar"] = user.Avatar;
                Session["Nombre"] = user.Apellido + " " + user.Nombre;
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}