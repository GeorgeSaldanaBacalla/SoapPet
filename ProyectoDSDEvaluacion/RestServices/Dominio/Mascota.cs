using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RestServices.Dominio
{
    public class Mascota
    {
        [DataMember]
        public string Idmascota { get; set; }
        [DataMember]
        public string Idcliente { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string ApePaterno { get; set; }
        [DataMember]
        public string ApeMaterno { get; set; }
        [DataMember]
        public string Raza { get; set; }
        [DataMember]
        public string Edad { get; set; }
        [DataMember]
        public string Peso { get; set; }

    }
}

