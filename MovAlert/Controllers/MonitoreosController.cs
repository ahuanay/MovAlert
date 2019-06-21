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
    public class MonitoreosController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Get()
        {

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MovAlertBDModel"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT IdMonitoreo, IdEquipo, Conectividad, Peligro FROM Monitoreos", connection))
                {

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    var ListMon = reader.Cast<IDataRecord>()
                            .Select(x => new
                            {
                                IdMonitoreo = (int)x["IdMonitoreo"],
                                IdEquipo = (string)x["IdEquipo"],
                                Conectividad = (Boolean)x["Conectividad"],
                                Peligro = (Boolean)x["Peligro"]
                            }).ToList();

                    return Json(new { ListMon = ListMon }, JsonRequestBehavior.AllowGet);

                }
            }
        }
    }
}
