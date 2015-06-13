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
            Cliente clienteExistente = dao.Obtener(clienteACrear.Idcliente);
            if (clienteExistente != null)
            {
                throw new WebFaultException<string>("Código Cliente A Registrar Ya Existe.", HttpStatusCode.InternalServerError);
            }
            
            Cliente clienteExistenteXDni = dao.ObtenerXDni(clienteACrear.Dni);
                if (clienteExistenteXDni != null)
            {
                throw new WebFaultException<string>("Dni Cliente A Registrar Ya Existe.", HttpStatusCode.InternalServerError);
            }
            return dao.Crear(clienteACrear);
        }
                
        public Cliente ObtenerCliente(string codigo)
        {             
            Cliente clienteExistente = dao.Obtener(codigo);
            if (clienteExistente == null)
            {
                throw new WebFaultException<string>("Código Cliente No Encontrado.", HttpStatusCode.InternalServerError);
            }
            return dao.Obtener(codigo);
        }

      
        public Cliente ModificarCliente(Cliente clienteAModificar)
        {
            Cliente clienteExistente = dao.Obtener(clienteAModificar.Idcliente);
            if (clienteExistente == null)
            {
                throw new WebFaultException<string>("Código Cliente A Modificar No Existe.", HttpStatusCode.InternalServerError);
            }

            Cliente clienteExistenteXDni = dao.ObtenerXDni(clienteAModificar.Dni);
            if (clienteExistenteXDni != null)
            {
                if (clienteAModificar.Idcliente != clienteExistenteXDni.Idcliente)
                {
                    throw new WebFaultException<string>("Dni Cliente A Modificar Ya Existe.", HttpStatusCode.InternalServerError);
                }
            }
            return dao.Modificar(clienteAModificar);
        }
        
        public void EliminarCliente(Cliente clienteAEliminar)
        {
            Cliente clienteExistente = dao.Obtener(clienteAEliminar.Idcliente);
            if (clienteExistente == null)
            {
                throw new WebFaultException<string>("Código Cliente a Eliminar No Existe.", HttpStatusCode.InternalServerError);
            }

            dao.Eliminar(clienteAEliminar);
        }
                 
        public List<Cliente> ListarClientes()
        {
            return null;
        }
    }
}
