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
    public class Mascotas : IMascotas
    {
        private MascotaDAO dao = new MascotaDAO();

        public Mascota CrearMascota(Mascota mascotaACrear)
        {
            return dao.Crear(mascotaACrear);
        }

        public Mascota ObtenerMascota(string idmascota)
        {
            return dao.Obtener(idmascota);
        }

        public Mascota ModificarMascota(Mascota mascotaAModificar)
        {
            // TODO:
            return dao.Modificar(mascotaAModificar);
        }

        public void EliminarMascota(Mascota mascotaAEliminar)
        {
            // TODO:
            dao.Eliminar(mascotaAEliminar);
        }

        public List<Mascota> ListarMascotas()
        {
            // TODO:
            throw new NotImplementedException();
        }
    }
}