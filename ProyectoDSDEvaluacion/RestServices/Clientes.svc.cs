﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RestServices.Dominio;
using RestServices.Persistencia;
using System.ServiceModel.Web;
using System.Net;

namespace RestServices
{
    public class Clientes : IClientes
    {
        private ClienteDAO dao = new ClienteDAO();

        public Cliente CrearCliente(Cliente clienteACrear)
        {
            return dao.Crear(clienteACrear);
        }

        public Cliente ObtenerCliente(string idcliente)
        {
            return dao.Obtener(idcliente);
        }

        public Cliente ModificarCliente(Cliente clienteAModificar)
        {
            // TODO:
            return dao.Modificar(clienteAModificar);
        }

        public void EliminarCliente(Cliente clienteAEliminar)
        {
            // TODO:
            dao.Eliminar(clienteAEliminar);
        }

        public List<Cliente> ListarClientes()
        {
            // TODO:
            throw new NotImplementedException();
        }
    }
}