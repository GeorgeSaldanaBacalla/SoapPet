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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IClientes" in both code and config file together.
    [ServiceContract]
    public interface IClientes
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Clientes", ResponseFormat = WebMessageFormat.Json)]
        Cliente CrearCliente(Cliente ClienteACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Clientes/{idcliente}", ResponseFormat = WebMessageFormat.Json)]
        Cliente ObtenerCliente(string idcliente);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Clientes", ResponseFormat = WebMessageFormat.Json)]
        Cliente ModificarCliente(Cliente clienteAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Clientes", ResponseFormat = WebMessageFormat.Json)]
        void EliminarCliente(Cliente clienteAEliminar);

        [OperationContract]
        // TODO:
        List<Cliente> ListarClientes();
    }
}
