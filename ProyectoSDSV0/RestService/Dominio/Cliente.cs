using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RestService.Dominio
{
    [DataContract]
    public class Cliente
    {
        [DataMember]
        public string Codigo { get; set; }        
        [DataMember]
        public string Nombre { get; set; }
    }
}