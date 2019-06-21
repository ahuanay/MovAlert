using MovAlert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovAlert.Controllers
{
    public class AvatarController : Controller
    {
        private MovAlertBDModel db = new MovAlertBDModel();

        public ActionResult convertirImagen(string IdEmpleado)
        {
            var Avatar = db.Empleados.Where(x => x.IdEmpleado == IdEmpleado).FirstOrDefault();

            return File(Avatar.Avatar, "image/jpeg");
        }
    }
}