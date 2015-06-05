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
        public void CRUDTest1()
        {
            //Prueba de creación de cliente vía HTTP GET
            //string postdata = "{\"Codigo\":\"2\",\"Nombre\":\"Juan2\"}"; //JSON
            string postdata = "{\"Codigo\":\"4\",\"Nombre\":\"Juan4\"}"; //JSON
            
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
            Assert.AreEqual("4", clienteCreado.Codigo);
            Assert.AreEqual("Juan4", clienteCreado.Nombre);

        }
        [TestMethod]
        public void CRUDTest2()
        {
            //Prueba de Obtención de alumno vía HTTP POST         
            JavaScriptSerializer js = new JavaScriptSerializer();
            HttpWebRequest req2 = (HttpWebRequest)WebRequest
                .Create("http://localhost:2100/Clientes.svc/Clientes/4");
            //.Create("http://localhost:2100/Clientes.svc/Alumnos/6"); 
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string clienteJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Cliente clienteObtenido = js.Deserialize<Cliente>(clienteJson2);
            Assert.AreEqual("4", clienteObtenido.Codigo);
            Assert.AreEqual("Juan", clienteObtenido.Nombre);

        }
        [TestMethod]
        public void CRUDTest3()
        {   //Prueba de actualización de alumno vía HTTP PUT  
            string postdata = "{\"Codigo\":\"6\",\"Nombre\":\"Juan66\"}"; //JSON
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
            Cliente clienteCreado = js.Deserialize<Cliente>(clienteJson);
            Assert.AreEqual("6", clienteCreado.Codigo);
            Assert.AreEqual("Juan6", clienteCreado.Nombre);      
         }

        

        [TestMethod]
        public void CRUDTest0()
        {
            //Prueba de creación de alumno vía HTTP POST
            string postdata = "{\"Codigo\":\"6\",\"Nombre\":\"Juan6\"}"; //JSON
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
            string alumnoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Cliente alumnoCreado = js.Deserialize<Cliente>(alumnoJson);
            Assert.AreEqual("6", alumnoCreado.Codigo);
            Assert.AreEqual("Juan6", alumnoCreado.Nombre);

            //Prueba de Obtención de alumno vía HTTP GET        

            HttpWebRequest req2 = (HttpWebRequest)WebRequest
                .Create("http://localhost:2100/Clientes.svc/Clientes/6");
            //.Create("http://localhost:2100/Clientes.svc/Alumnos/6");

            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string alumnoJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Cliente alumnoObtenido = js.Deserialize<Cliente>(alumnoJson2);
            Assert.AreEqual("6", alumnoObtenido.Codigo);
            Assert.AreEqual("Juan", alumnoObtenido.Nombre);
        }
    }
}
