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
    public class Citas : ICitas
    {
        private CitaDAO dao = new CitaDAO();

        public Cita CrearCita(Cita citaACrear)
        {
            /*Cita nuevaCita = dao.Crear(citaACrear);

            string postdata = "{\"Idmascota\":\""+citaACrear.Idmascota+"\",\"Idcita\":\""+nuevaCita.Idcita+"\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:2744/Historias.svc/Historias");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string clienteJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Cliente clienteCreado = js.Deserialize<Cliente>(clienteJson);
            Assert.AreEqual("Pedro", clienteCreado.Nombre);
            Assert.AreEqual("Perez", clienteCreado.ApePaterno);*/

            return dao.Crear(citaACrear);
        }

        public Cita ObtenerCita(string idcita)
        {
            return dao.Obtener(idcita);
        }

        public Cita ModificarCita(Cita citaAModificar)
        {
            // TODO:
            return dao.Modificar(citaAModificar);
        }

        public void EliminarCita(Cita citaAEliminar)
        {
            // TODO:
            dao.Eliminar(citaAEliminar);
        }

        public List<Cita> ListarCitasPorDoctor(string iddoctor)
        {
            return dao.ListarCitasPorDoctor(iddoctor);
        }
    }
}