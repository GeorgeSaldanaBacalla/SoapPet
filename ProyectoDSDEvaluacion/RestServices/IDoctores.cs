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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDoctores" in both code and config file together.
    [ServiceContract]
    public interface IDoctores
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Doctores", ResponseFormat = WebMessageFormat.Json)]
        Doctor CrearDoctor(Doctor doctorACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Doctores/{iddoctor}", ResponseFormat = WebMessageFormat.Json)]
        Doctor ObtenerDoctor(string iddoctor);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Doctores", ResponseFormat = WebMessageFormat.Json)]
        Doctor ModificarDoctor(Doctor doctorAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Doctores", ResponseFormat = WebMessageFormat.Json)]
        void EliminarDoctor(Doctor doctorAEliminar);

        [OperationContract]
        // TODO:
        List<Doctor> ListarDoctores();
    }
}
