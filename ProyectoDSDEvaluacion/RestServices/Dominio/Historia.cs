using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RestServices.Dominio
{
    [DataContract]
    public class Historia
    {
        [DataMember]
        public string Idhistoria { get; set; }
        [DataMember]
        public string Idmascota { get; set; }
        [DataMember]
        public string Idcita { get; set; }
        [DataMember]
        public string Diagnostico { get; set; }
        [DataMember]
        public string Tratamiento { get; set; }
    }
}