using MascotaService.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MascotaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMascotas" in both code and config file together.
    [ServiceContract]
    public interface IMascotas
    {
        [OperationContract]
        [WebInvoke(Method="POST", UriTemplate="Mascotas", ResponseFormat=WebMessageFormat.Json )]
        Mascota CrearMascota(Mascota mascotaCrear);

       [OperationContract]
        [WebInvoke(Method="GET", UriTemplate ="Mascotas/{mascota}", ResponseFormat=WebMessageFormat.Json )]
        Mascota ObtenerMascota(string mascota);
        
       

        [OperationContract]
        [WebInvoke(Method="GET", UriTemplate="Mascotas/List/{idCliente}", ResponseFormat=WebMessageFormat.Json)]
        IList<Mascota> ListarMascota(string idCliente);
    }
}
