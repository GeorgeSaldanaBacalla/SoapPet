using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MascotaService.Dominio
{
    [DataContract]
    public class Mascota
    {
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string  Ape_Pat{ get; set; }
        [DataMember]
        public string Ape_Mat { get; set; }
        [DataMember]
        public string Raza { get; set; }
        [DataMember]
        public int Edad { get; set; }
        [DataMember]
        public double Peso { get; set; }

    }
}