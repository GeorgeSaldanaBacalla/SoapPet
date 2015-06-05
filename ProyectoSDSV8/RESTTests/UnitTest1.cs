using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace RESTTests
{
    [TestClass]
    public class ClientesTest
    {
        [TestMethod]
        public void TestCrearCliente()
        {
            //Prueba de creación de cliente vía HTTP GET
            //string postdata = "{\"Codigo\":\"2\",\"Nombre\":\"Juan2\"}"; //JSON
            //string postdata = "{\"Codigo\":\"4\",\"Nombre\":\"Juan4\"}"; //JSON
            //string postdata = "{\"Codigo\":\"1\",\"Nombre\":\"Juan1\"}"; //JSON
            //string postdata = "{\"Idcliente\":\"1\",\"Nombre\":\"Juan1\",\"Ape_Paterno\":\"Perez\"}"; //JSON
            //string postdata = "{\"Idcliente\":\"1\",\"Nombre\":\"Juan1\",\"Ape_Paterno\":\"Perez\",\"Ape_Materno\":\"Mendez\"}"; //JSON
            string postdata = "{\"Idcliente\":\"1\",\"Nombre\":\"Juan1\",\"Ape_Paterno\":\"Perez\",\"Ape_Materno\":\"Mendez\",\"Telefono\":\"011234567\",\"Celular\":\"123456789\",\"Direccion\":\"Calle Alcanfores 125\",\"Correo\":\"prueba@hotmail.com\"}"; //JSON
            
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:2100/Clientes.svc/Clientes");
                //.Create("http://localhost:2100/Clientes.svc/Alumnos");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string clienteJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Cliente clienteCreado = js.Deserialize<Cliente>(clienteJson);
            Assert.AreEqual("1", clienteCreado.Idcliente);
            Assert.AreEqual("Juan1", clienteCreado.Nombre);
            Assert.AreEqual("Perez", clienteCreado.Ape_Paterno);
            Assert.AreEqual("Mendez", clienteCreado.Ape_Materno);
            Assert.AreEqual("011234567", clienteCreado.Telefono);
            Assert.AreEqual("123456789", clienteCreado.Celular);
            Assert.AreEqual("Calle Alcanfores 125", clienteCreado.Direccion);
            Assert.AreEqual("prueba@hotmail.com", clienteCreado.Correo);
        }
        [TestMethod]
        public void TestObtenerCliente()
        {
            //Prueba de Obtención de alumno vía HTTP POST         
            JavaScriptSerializer js = new JavaScriptSerializer();
            HttpWebRequest req2 = (HttpWebRequest)WebRequest
                .Create("http://localhost:2100/Clientes.svc/Clientes/1");
            //.Create("http://localhost:2100/Clientes.svc/Clientes/4");
            //.Create("http://localhost:2100/Clientes.svc/Alumnos/6"); 
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string clienteJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Cliente clienteObtenido = js.Deserialize<Cliente>(clienteJson2);
            Assert.AreEqual("1", clienteObtenido.Idcliente);
            Assert.AreEqual("Juan1", clienteObtenido.Nombre);
            Assert.AreEqual("Perez", clienteObtenido.Ape_Paterno);
            Assert.AreEqual("Mendez", clienteObtenido.Ape_Materno);
            Assert.AreEqual("011234567", clienteObtenido.Telefono);
            Assert.AreEqual("123456789", clienteObtenido.Celular);
            Assert.AreEqual("Calle Alcanfores 125", clienteObtenido.Direccion);
            Assert.AreEqual("prueba@hotmail.com", clienteObtenido.Correo);
        }
        [TestMethod]
        public void TestModificarCliente()
        {   //Prueba de actualización de alumno vía HTTP PUT  
            //string postdata = "{\"Codigo\":\"4\",\"Nombre\":\"Juan444\"}"; //JSON
            //string postdata = "{\"Idcliente\":\"4\",\"Nombre\":\"Juan444\"}"; //JSON
            //string postdata = "{\"Idcliente\":\"1\",\"Nombre\":\"Juan11\"}"; //JSON
            //string postdata = "{\"Idcliente\":\"1\",\"Nombre\":\"Juan111\",\"Ape_Paterno\":\"Perez1\",\"Ape_Materno\":\"Mendez1\"}"; //JSON
            string postdata = "{\"Idcliente\":\"1\",\"Nombre\":\"Juan11\",\"Ape_Paterno\":\"Perez1\",\"Ape_Materno\":\"Mendez1\",\"Telefono\":\"011234567\",\"Celular\":\"123456789\",\"Direccion\":\"Calle Alcanfores 125\",\"Correo\":\"prueba@hotmail.com\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:2100/Clientes.svc/Clientes");
            //.Create("http://localhost:2100/Clientes.svc/Alumnos");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string clienteJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Cliente clienteModificado = js.Deserialize<Cliente>(clienteJson);
            Assert.AreEqual("1", clienteModificado.Idcliente);
            Assert.AreEqual("Juan11", clienteModificado.Nombre);
            Assert.AreEqual("Perez1", clienteModificado.Ape_Paterno);
            Assert.AreEqual("Mendez1", clienteModificado.Ape_Materno);
            Assert.AreEqual("011234567", clienteModificado.Telefono);
            Assert.AreEqual("123456789", clienteModificado.Celular);
            Assert.AreEqual("Calle Alcanfores 125", clienteModificado.Direccion);
            Assert.AreEqual("prueba@hotmail.com", clienteModificado.Correo);
         }

        [TestMethod]
        public void TestEliminarCliente()
        {
            // Prueba de eliminación de cliente vía HTTP DELETE
            //string postdata = "{\"Codigo\":\"4\",\"Nombre\":\"Juan444\"}"; //JSON
            //string postdata = "{\"Idcliente\":\"4\",\"Nombre\":\"Juan444\"}"; //JSON 
            //string postdata = "{\"Idcliente\":\"1\",\"Nombre\":\"Juan11\"}"; //JSON 
            //string postdata = "{\"Idcliente\":\"1\",\"Nombre\":\"Juan111\",\"Ape_Paterno\":\"Perez1\",\"Ape_Materno\":\"Mendez1\"}"; //JSON         
            string postdata = "{\"Idcliente\":\"1\"}"; //JSON 
           
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:2100/Clientes.svc/Clientes");
            req.Method = "DELETE";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string clienteJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
         
            // Prueba de obtención de cliente vía HTTP GET
            HttpWebRequest req2 = (HttpWebRequest)WebRequest                
                .Create("http://localhost:2100/Clientes.svc/Clientes/1");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string clienteJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Cliente clienteObtenido = js2.Deserialize<Cliente>(clienteJson2);
            Assert.IsNull(clienteObtenido);
        }
    }
        
}
