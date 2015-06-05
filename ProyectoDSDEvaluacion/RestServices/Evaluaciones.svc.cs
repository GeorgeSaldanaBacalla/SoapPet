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
    public class Evaluaciones : IEvaluaciones
    {
        private EvaluacionDAO dao = new EvaluacionDAO();

        public Evaluacion CrearEvaluacion(Evaluacion evaluacionACrear)
        {
            return dao.Crear(evaluacionACrear);
        }

        public Evaluacion ObtenerEvaluacion(string idevaluacion)
        {
            return dao.Obtener(Convert.ToInt32(idevaluacion));
        }

        public Evaluacion ModificarEvaluacion(Evaluacion evaluacionAModificar)
        {
            // TODO:
            return dao.Modificar(evaluacionAModificar);
        }

        public void EliminarEvaluacion(Evaluacion evaluacionAEliminar)
        {
            // TODO:
            dao.Eliminar(evaluacionAEliminar);
        }

        public List<Evaluacion> ListarEvaluaciones()
        {
            // TODO:
            throw new NotImplementedException();
        }
    }
}