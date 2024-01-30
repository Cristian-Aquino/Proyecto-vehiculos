using proyectoVehiculos.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace proyectoVehiculos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult AltaVehiculo()
        {

            return View();
        }

        public ActionResult ListaVehiculos()
        {

            return View();
        }

        [HttpGet]
        public JsonResult ListadoVehiculos()
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>();

            vehiculos = new CTA_vehiculo().Listado();

            return Json(new { data = vehiculos}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost] 
        public JsonResult GuardarVehiculo(Vehiculo vehiculo)
        {

            object resultado;

            resultado = new CTA_vehiculo().guardarVehiculo(vehiculo.Patente, vehiculo.Marca, vehiculo.Modelo, vehiculo.Cant_puertas, vehiculo.Nombre_titular);

            return Json(new { resultado = resultado }, JsonRequestBehavior.AllowGet);
        }


    }
}