using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MascotaService.Dominio;
using MascotaService.Persistencia;

namespace MascotaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Mascotas" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Mascotas.svc or Mascotas.svc.cs at the Solution Explorer and start debugging.
    public class Mascotas : IMascotas
    {

        private MascotaDAO dao = new MascotaDAO();
        public Mascota CrearMascota(Mascota mascotaCrear)
        {
            return dao.Crear(mascotaCrear);
        }

        public Mascota ObtenerMascota(string mascota)
        {
            return dao.Obtener(mascota);
        }
        
        public IList<Mascota> ListarMascota(string idCliente)
        {
            return dao.ObtenerPorIdCliente(idCliente);
        }
    }
}
