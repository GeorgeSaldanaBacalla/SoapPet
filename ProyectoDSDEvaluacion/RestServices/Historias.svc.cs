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
    public class Historias : IHistorias
    {
        private HistoriaDAO dao = new HistoriaDAO();

        public Historia CrearHistoria(Historia historiaACrear)
        {
            return dao.Crear(historiaACrear);
        }

        public Historia ObtenerHistoria(string idhistoria)
        {
            return dao.Obtener(idhistoria);
        }

        public Historia ModificarHistoria(Historia historiaAModificar)
        {
            // TODO:
            return dao.Modificar(historiaAModificar);
        }

        public void EliminarHistoria(Historia historiaAEliminar)
        {
            // TODO:
            dao.Eliminar(historiaAEliminar);
        }

        public List<Historia> ListarHistorias()
        {
            // TODO:
            throw new NotImplementedException();
        }
    }
}