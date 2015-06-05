using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MascotaService.Persistencia
{
    public class ConexionUtil
    {
        public static string Cadena {
            get {
                return "Server=LocalHost; DataBase= SOAPET; Uid=root; Pwd=root;";
            }
        }
    }
}