using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RestServices.Dominio
{
    [DataContract]
    public class Evaluacion
    {
        [DataMember]
        public Int32 Idevaluacion { get; set; }
        [DataMember]
        public string Fecha { get; set; }
        [DataMember]
        public string Pregunta { get; set; }
        [DataMember]
        public string Respuesta { get; set; }
        [DataMember]
        public Int32 Idcita { get; set; }
    }
}