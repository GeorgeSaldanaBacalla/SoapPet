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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHistorias" in both code and config file together.
    [ServiceContract]
    public interface IHistorias
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Historias", ResponseFormat = WebMessageFormat.Json)]
        Historia CrearHistoria(Historia historiaACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Historias/{idhistoria}", ResponseFormat = WebMessageFormat.Json)]
        Historia ObtenerHistoria(string idhistoria);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Historias", ResponseFormat = WebMessageFormat.Json)]
        Historia ModificarHistoria(Historia historiaAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Historias", ResponseFormat = WebMessageFormat.Json)]
        void EliminarHistoria(Historia historiaAEliminar);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "HistoriasMascota/{idmascota}", ResponseFormat = WebMessageFormat.Json)]
        List<Historia> ListarHistoriasPorMascota(string idmascota);
    }
}
