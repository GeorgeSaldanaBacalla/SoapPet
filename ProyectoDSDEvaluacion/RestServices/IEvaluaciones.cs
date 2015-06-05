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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEvaluaciones" in both code and config file together.
    [ServiceContract]
    public interface IEvaluaciones
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Evaluaciones", ResponseFormat = WebMessageFormat.Json)]
        Evaluacion CrearEvaluacion(Evaluacion EvaluacionACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Evaluaciones/{idevaluacion}", ResponseFormat = WebMessageFormat.Json)]
        Evaluacion ObtenerEvaluacion(string idevaluacion);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Evaluaciones", ResponseFormat = WebMessageFormat.Json)]
        Evaluacion ModificarEvaluacion(Evaluacion evaluacionAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Evaluaciones", ResponseFormat = WebMessageFormat.Json)]
        void EliminarEvaluacion(Evaluacion evaluacionAEliminar);

        [OperationContract]
        // TODO:
        List<Evaluacion> ListarEvaluaciones();
    }
}
