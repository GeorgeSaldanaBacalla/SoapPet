using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RestServices.Dominio
{
    [DataContract]
    public class Cita
    {
        [DataMember]
        public string Idcita { get; set; }
        [DataMember]
        public string Idmascota { get; set; }
        [DataMember]
        public string Iddoctor { get; set; }
        [DataMember]
        public string FechaInicio { get; set; }
        [DataMember]
        public string FechaFin { get; set; }

    }
}