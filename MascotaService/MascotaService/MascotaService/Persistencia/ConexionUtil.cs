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
                return "Server=localhost; DataBase= soapet; Uid=root; Pwd=mysql;";
            }
        }
    }
}