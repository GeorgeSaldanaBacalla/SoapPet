using RestServices.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICitas" in both code and config file together.
    [ServiceContract]
    public interface ICitas
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Citas", ResponseFormat = WebMessageFormat.Json)]
        Cita CrearCita(Cita citaACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Citas/{idcita}", ResponseFormat = WebMessageFormat.Json)]
        Cita ObtenerCita(string idcita);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Citas", ResponseFormat = WebMessageFormat.Json)]
        Cita ModificarCita(Cita citaAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Citas", ResponseFormat = WebMessageFormat.Json)]
        void EliminarCita(Cita citaAEliminar);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CitasDoctor/{iddoctor}", ResponseFormat = WebMessageFormat.Json)]
        List<Cita> ListarCitasPorDoctor(string iddoctor);
    }
}
