﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace proyectoVehiculos.Clases
{
    public class Conexion
    {
        public static string cn = ConfigurationManager.ConnectionStrings["connectionDB"].ToString();
    }
}