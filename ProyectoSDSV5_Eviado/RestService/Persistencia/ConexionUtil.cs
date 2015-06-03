using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestService.Persistencia
{
    public class ConexionUtil
    {
        public static string Cadena
        {
            get
            {
                //return "Data Source=(local);Initial Catalog=BD_Alumnos;Integrated Security=SSPI;";
                //Conexion en mi laptop
                //return "Data Source=.\\SQLEXPRESS;Initial Catalog=BD_Alumnos;Integrated Security=SSPI;";
                return "Data Source=.\\SQLEXPRESS;Initial Catalog=Soapet;Integrated Security=SSPI;";
            }
        }
    }
}
