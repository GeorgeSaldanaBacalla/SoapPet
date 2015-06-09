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
        public string Nombre { get; set; }
        [DataMember]
        public string Ape_Pat { get; set; }
        [DataMember]
        public string Ape_Mat { get; set; }
        [DataMember]
        public string Raza { get; set; }
        [DataMember]
        public string Edad { get; set; }
        [DataMember]
        public string Peso { get; set; }

    }
}

