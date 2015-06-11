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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMascotas" in both code and config file together.
    [ServiceContract]
    public interface IMascotas
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Mascotas", ResponseFormat = WebMessageFormat.Json)]
        Mascota CrearMascota(Mascota MascotaACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Mascotas/{idmascota}", ResponseFormat = WebMessageFormat.Json)]
        Mascota ObtenerMascota(string idmascota);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Mascotas", ResponseFormat = WebMessageFormat.Json)]
        Mascota ModificarMascota(Mascota mascotaAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Mascotas", ResponseFormat = WebMessageFormat.Json)]
        void EliminarMascota(Mascota mascotaAEliminar);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "MascotasCliente/{idcliente}", ResponseFormat = WebMessageFormat.Json)]
        List<Mascota> ListarMascotasPorCliente(string idcliente);
    }
}
