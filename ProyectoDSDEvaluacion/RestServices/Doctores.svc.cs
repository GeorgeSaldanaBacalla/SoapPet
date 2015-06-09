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
    public class Doctores : IDoctores
    {
        private DoctorDAO dao = new DoctorDAO();

        public Doctor CrearDoctor(Doctor doctorACrear)
        {
            return dao.Crear(doctorACrear);
        }

        public Doctor ObtenerDoctor(string iddoctor)
        {
            return dao.Obtener(iddoctor);
        }

        public Doctor ModificarDoctor(Doctor doctorAModificar)
        {
            // TODO:
            return dao.Modificar(doctorAModificar);
        }

        public void EliminarDoctor(Doctor doctorAEliminar)
        {
            // TODO:
            dao.Eliminar(doctorAEliminar);
        }

        public List<Doctor> ListarDoctores()
        {
            // TODO:
            throw new NotImplementedException();
        }
    }
}