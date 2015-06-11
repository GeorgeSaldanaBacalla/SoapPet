using RestServices.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAtenciones" in both code and config file together.
    [ServiceContract]
    public interface IAtenciones
    {
        /*************  SERVICIO CITAS   *************/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Citas/{idcita}", ResponseFormat = WebMessageFormat.Json)]
        Cita ObtenerCita(string idcita);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Citas", ResponseFormat = WebMessageFormat.Json)]
        Cita CrearCita(Cita citaACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CitasDoctor/{iddoctor}", ResponseFormat = WebMessageFormat.Json)]
        List<Cita> ListarCitasPorDoctor(string iddoctor);


        /***********  SERVICIO CLIENTES   *************/

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Clientes", ResponseFormat = WebMessageFormat.Json)]
        Cliente CrearCliente(Cliente ClienteACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Clientes/{idcliente}", ResponseFormat = WebMessageFormat.Json)]
        Cliente ObtenerCliente(string idcliente);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Clientes", ResponseFormat = WebMessageFormat.Json)]
        Cliente ModificarCliente(Cliente clienteAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Clientes", ResponseFormat = WebMessageFormat.Json)]
        void EliminarCliente(Cliente clienteAEliminar);

        /***********  SERVICIO MASCOTAS   *************/
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Mascotas", ResponseFormat = WebMessageFormat.Json)]
        Mascota CrearMascota(Mascota MascotaACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Mascotas/{idmascota}", ResponseFormat = WebMessageFormat.Json)]
        Mascota ObtenerMascota(string idmascota);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Mascotas", ResponseFormat = WebMessageFormat.Json)]
        Mascota ModificarMascota(Mascota mascotaAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Mascotas", ResponseFormat = WebMessageFormat.Json)]
        void EliminarMascota(Mascota mascotaAEliminar);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "MascotasCliente/{idcliente}", ResponseFormat = WebMessageFormat.Json)]
        List<Mascota> ListarMascotasPorCliente(string idcliente);
    }
}
