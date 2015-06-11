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
using System.IO;
using System.Web.Script.Serialization;

namespace RestServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Atenciones" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Atenciones.svc or Atenciones.svc.cs at the Solution Explorer and start debugging.
    public class Atenciones : IAtenciones
    {
        public Cita ObtenerCita(string idcita)
        {
            // Prueba de obtención de alumno vía HTTP GET
            HttpWebRequest req1 = (HttpWebRequest)WebRequest
                .Create("http://localhost:2744/Citas.svc/Citas/" + idcita);
            req1.Method = "GET";
            HttpWebResponse res1 = (HttpWebResponse)req1.GetResponse();
            StreamReader reader1 = new StreamReader(res1.GetResponseStream());
            string citaJson1 = reader1.ReadToEnd();
            JavaScriptSerializer js1 = new JavaScriptSerializer();
            Cita citaObtenido = js1.Deserialize<Cita>(citaJson1);

            return citaObtenido;
        }
        public Cita CrearCita(Cita citaACrear)
        {
            string postdata = "{\"Idmascota\":\"" + citaACrear.Idmascota + "\","+
                               "\"Iddoctor\":\"" + citaACrear.Iddoctor + "\"," +
                               "\"FechaInicio\":\"" + citaACrear.FechaInicio + "\","+
                               "\"FechaFin\":\"" + citaACrear.FechaFin + "\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:2744/Citas.svc/Citas");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string citaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Cita citaCreado = js.Deserialize<Cita>(citaJson);
            return citaCreado;
        }
        public List<Cita> ListarCitasPorDoctor(string iddoctor)
        {
            // Prueba de obtención de alumno vía HTTP GET
            HttpWebRequest req1 = (HttpWebRequest)WebRequest
                .Create("http://localhost:2744/Citas.svc/CitasDoctor/" + iddoctor);
            req1.Method = "GET";
            HttpWebResponse res1 = (HttpWebResponse)req1.GetResponse();
            StreamReader reader1 = new StreamReader(res1.GetResponseStream());
            string citaJson1 = reader1.ReadToEnd();
            JavaScriptSerializer js1 = new JavaScriptSerializer();
            List<Cita> citaObtenido = js1.Deserialize<List<Cita>>(citaJson1);

            return citaObtenido;
        }
        /* SERVICIO CLIENTES */
        public Cliente ObtenerCliente(string idcliente)
        {
            // Prueba de obtención de alumno vía HTTP GET
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:2744/Clientes.svc/Clientes/" + idcliente );
            req.Method = "GET";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string ojbJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Cliente objObtenido = js.Deserialize<Cliente>(ojbJson);

            return objObtenido;
        }
        public Cliente CrearCliente(Cliente clienteACrear)
        {
            string postdata = "{\"Nombre\":\"" + clienteACrear.Nombre + "\"," +
                               "\"ApePaterno\":\"" + clienteACrear.ApePaterno + "\"," +
                               "\"ApeMaterno\":\"" + clienteACrear.ApeMaterno + "\"," +
                               "\"Telefono\":\"" + clienteACrear.Telefono + "\"," +
                               "\"Celular\":\"" + clienteACrear.Celular + "\"," +
                               "\"Correo\":\"" + clienteACrear.Correo + "\"," +
                               "\"Direccion\":\"" + clienteACrear.Direccion + "\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:2744/Clientes.svc/Clientes");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string cJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Cliente oCreado = js.Deserialize<Cliente>(cJson);
            return oCreado;
        }
        public Cliente ModificarCliente(Cliente clienteACrear)
        {
            string postdata = "{\"Idcliente\":\"" + clienteACrear.Idcliente + "\"," +
                               "\"Nombre\":\"" + clienteACrear.Nombre + "\"," +
                               "\"ApePaterno\":\"" + clienteACrear.ApePaterno + "\"," +
                               "\"ApeMaterno\":\"" + clienteACrear.ApeMaterno + "\"," +
                               "\"Telefono\":\"" + clienteACrear.Telefono + "\"," +
                               "\"Celular\":\"" + clienteACrear.Celular + "\"," +
                               "\"Correo\":\"" + clienteACrear.Correo + "\"," +
                               "\"Direccion\":\"" + clienteACrear.Direccion + "\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:2744/Clientes.svc/Clientes");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string cJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Cliente oCreado = js.Deserialize<Cliente>(cJson);
            return oCreado;
        }

        public void EliminarCliente(Cliente clienteAEliminar)
        {

            string postdata = "{\"Idcliente\":\"" + clienteAEliminar.Idcliente+ "\"}"; //JSON 

            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:2744/Clientes.svc/Clientes");
            req.Method = "DELETE";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
        }


        /*  SERVICIO MASCOTAS   */


        public Mascota ObtenerMascota(string idmascota)
        {
            // Prueba de obtención de alumno vía HTTP GET
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:2744/Mascotas.svc/Mascotas/" + idmascota);
            req.Method = "GET";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string ojbJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Mascota objObtenido = js.Deserialize<Mascota>(ojbJson);

            return objObtenido;
        }
        public Mascota CrearMascota(Mascota mascotaACrear)
        {
            string postdata = "{\"Idcliente\":\"" + mascotaACrear.Idcliente + "\"," +
                               "\"Nombre\":\"" + mascotaACrear.Nombre + "\"," +
                               "\"ApePaterno\":\"" + mascotaACrear.ApePaterno + "\"," +
                               "\"ApeMaterno\":\"" + mascotaACrear.ApeMaterno + "\"," +
                               "\"Raza\":\"" + mascotaACrear.Raza + "\"," +
                               "\"Edad\":\"" + mascotaACrear.Edad + "\"," +
                               "\"Peso\":\"" + mascotaACrear.Peso + "\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:2744/Mascotas.svc/Mascotas");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string cJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Mascota oCreado = js.Deserialize<Mascota>(cJson);
            return oCreado;
        }
        public Mascota ModificarMascota(Mascota mascotaAModificar)
        {
            string postdata = "{\"Idmascota\":\"" + mascotaAModificar.Idmascota + "\"," +
                               "\"Idcliente\":\"" + mascotaAModificar.Idcliente + "\"," +
                               "\"Nombre\":\"" + mascotaAModificar.Nombre + "\"," +
                               "\"ApePaterno\":\"" + mascotaAModificar.ApePaterno + "\"," +
                               "\"ApeMaterno\":\"" + mascotaAModificar.ApeMaterno + "\"," +
                               "\"Raza\":\"" + mascotaAModificar.Raza + "\"," +
                               "\"Edad\":\"" + mascotaAModificar.Edad + "\"," +
                               "\"Peso\":\"" + mascotaAModificar.Peso + "\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:2744/Mascotas.svc/Mascotas");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string cJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Mascota oCreado = js.Deserialize<Mascota>(cJson);
            return oCreado;
        }

        public void EliminarMascota(Mascota mascotaAEliminar)
        {

            string postdata = "{\"Idcliente\":\"" + mascotaAEliminar.Idmascota + "\"}"; //JSON 

            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:2744/Mascotas.svc/Mascotas");
            req.Method = "DELETE";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
        }
        public List<Mascota> ListarMascotasPorCliente(string idcliente)
        {
            // Prueba de obtención de alumno vía HTTP GET
            HttpWebRequest req1 = (HttpWebRequest)WebRequest
                .Create("http://localhost:2744/Mascotas.svc/MascotasCliente/" + idcliente);
            req1.Method = "GET";
            HttpWebResponse res1 = (HttpWebResponse)req1.GetResponse();
            StreamReader reader1 = new StreamReader(res1.GetResponseStream());
            string citaJson1 = reader1.ReadToEnd();
            JavaScriptSerializer js1 = new JavaScriptSerializer();
            List<Mascota> citaObtenido = js1.Deserialize<List<Mascota>>(citaJson1);

            return citaObtenido;
        }
    }
}
