using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace RESTTests
{

    [TestClass]
    public class ClienteTest
    {

        [TestMethod]
        public void TestCrearCliente()
        {
            // Prueba de creación de alumno vía HTTP POST
            string postdata = "{\"Nombre\":\"Pedro\",\"ApePaterno\":\"Perez\",\"ApeMaterno\":\"Perez\",\"Celular\":\"9819283998\"}"; //JSON
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
            string clienteJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Cliente clienteCreado = js.Deserialize<Cliente>(clienteJson);
            Assert.AreEqual("Pedro", clienteCreado.Nombre);
            Assert.AreEqual("Perez", clienteCreado.ApePaterno);

            // Prueba de obtención de alumno vía HTTP GET
            HttpWebRequest req2 = (HttpWebRequest)WebRequest
                .Create("http://localhost:2744/Clientes.svc/Clientes/" + clienteCreado.Idcliente);
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string clienteJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Cliente clienteObtenido = js2.Deserialize<Cliente>(clienteJson2);
            Assert.AreEqual("Pedro", clienteObtenido.Nombre);
            Assert.AreEqual("Perez", clienteObtenido.ApePaterno);
        }

    }
}
