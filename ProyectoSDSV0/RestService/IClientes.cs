using RestService.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestService
{
    [ServiceContract]
    public interface IClientes
    {
        [OperationContract]
        //[WebInvoke(Method="POST", UriTemplate="Alumnos", ResponseFormat=WebMessageFormat.Json)]        
        [WebInvoke(Method = "POST", UriTemplate = "Clientes", ResponseFormat = WebMessageFormat.Json)]        
        Cliente CrearCliente(Cliente clienteACrear);

        [OperationContract]
        //[WebInvoke(Method="GET",UriTemplate="Alumnos/{codigo}", ResponseFormat=WebMessageFormat.Json)]
        [WebInvoke(Method = "GET", UriTemplate = "Clientes/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        //[WebInvoke(Method = "GET", UriTemplate = "Clientes/{idcliente}", ResponseFormat = WebMessageFormat.Json)]
        Cliente ObtenerCliente(string codigo);

        [OperationContract]
        //TODO:
        Cliente ModificarCliente(Cliente clienteAModificar);

        [OperationContract]
        //TODO:
        void EliminarCliente(string codigo);

        [OperationContract]
        //TODO:
        List<Cliente> ListarClientes();        
    }
}
