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
        public string Idcliente { get; set; }        
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Ape_Paterno { get; set; }
        [DataMember]
        public string Ape_Materno { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Celular { get; set; }
        [DataMember]
        public string Correo { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Dni { get; set; }
    }
}