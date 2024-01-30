using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoVehiculos.Clases
{
    public class Vehiculo
    {
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Cant_puertas { get; set; }
        public string Nombre_titular { get; set; }

    }
}