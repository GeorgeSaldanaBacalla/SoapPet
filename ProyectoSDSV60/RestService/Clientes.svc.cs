using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RestService.Dominio;
using RestService.Persistencia;
using System.ServiceModel.Web;
using System.Net;
using RestService;

namespace RestService
{
    public class Clientes : IClientes
    {
        private ClienteDAO dao = new ClienteDAO();

        public Cliente CrearCliente(Cliente clienteACrear)
        {
            return dao.Crear(clienteACrear);
        }

        public Cliente ObtenerCliente(string codigo)
        {
            return dao.Obtener(codigo);
        }

        public Cliente ModificarCliente(Cliente clienteAModificar)
        {
           //return null;
            return dao.Modificar(clienteAModificar);
        
        }               
//        public void EliminarCliente(string codigo)
//        {
            //TODO:
//        }
        public void EliminarCliente(Cliente clienteAEliminar)
        {
            dao.Eliminar(clienteAEliminar);
        }
         
        public List<Cliente> ListarClientes()
        {
            //TODO:
            return null;
        }
    }
}
