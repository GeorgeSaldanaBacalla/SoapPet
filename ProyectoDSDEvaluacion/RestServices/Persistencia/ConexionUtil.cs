﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestServices.Persistencia
{
    public class ConexionUtil
    {
        public static string Cadena
        {
            get
            {
                return "server=localhost;database=soapet;userid=root;password=s3rv3r;";
            }
        }
    }
}