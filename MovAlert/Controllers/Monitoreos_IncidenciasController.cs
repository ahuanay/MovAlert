using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovAlert.Controllers
{
    public class Monitoreos_IncidenciasController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Post()
        {

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MovAlertBDModel"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT IdMonitoreoIncidencia, IdEquipo, Incidencia, FechaHora FROM Monitoreos_Incidencias MI INNER JOIN Monitoreos M ON MI.IdMonitoreo = M.IdMonitoreo INNER JOIN Incidencias I ON MI.IdIncidencia = I.IdIncidencia", connection))
                {

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    var ListMonInc = reader.Cast<IDataRecord>()
                            .Select(x => new
                            {
                                IdMonitoreoIncidencia = (int)x["IdMonitoreoIncidencia"],
                                Equipo = (string)x["IdEquipo"],
                                Incidencia = (string)x["Incidencia"],
                                FechaHora = (DateTime)x["FechaHora"]
                            }).ToList();

                    return Json(new { ListMonInc = ListMonInc }, JsonRequestBehavior.AllowGet);

                }
            }
        }

    }
}
