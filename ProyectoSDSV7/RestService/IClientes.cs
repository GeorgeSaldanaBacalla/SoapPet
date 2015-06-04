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
        [WebInvoke(Method = "PUT", UriTemplate = "Clientes", ResponseFormat = WebMessageFormat.Json)]
//      [WebInvoke(Method = "PUT", UriTemplate = "Directores", ResponseFormat = WebMessageFormat.Json)]
        Cliente ModificarCliente(Cliente clienteAModificar);

        [OperationContract]        
        [WebInvoke(Method = "DELETE", UriTemplate = "Clientes", ResponseFormat = WebMessageFormat.Json)]
//      [WebInvoke(Method = "DELETE", UriTemplate = "Directores", ResponseFormat = WebMessageFormat.Json)
//      void EliminarDirector(Director directorAEliminar);
        void EliminarCliente(Cliente clienteAEliminar);
        
        [OperationContract]
        //TODO:
        List<Cliente> ListarClientes();        
    }
}
