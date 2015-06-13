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
        {   //Prueba de creación de cliente vía HTTP GET
            try
            {   //Registrar un cliente...En el seguno intento genera mensaje código ya existe 
                string postdata = "{\"Idcliente\":\"1\",\"Nombre\":\"Juan1\",\"Ape_Paterno\":\"Perez\",\"Ape_Materno\":\"Mendez\",\"Telefono\":\"011234567\",\"Celular\":\"123456789\",\"Direccion\":\"Calle Alcanfores 125\",\"Correo\":\"prueba@hotmail.com\",\"Dni\":\"12345678\"}"; //JSON
                
                //Registrar un cliente...como el dni ya ha sido registrado muestra mensaje Dni ya existe             
                //string postdata = "{\"Idcliente\":\"2\",\"Nombre\":\"Juan1\",\"Ape_Paterno\":\"Perez\",\"Ape_Materno\":\"Mendez\",\"Telefono\":\"011234567\",\"Celular\":\"123456789\",\"Direccion\":\"Calle Alcanfores 125\",\"Correo\":\"prueba@hotmail.com\",\"Dni\":\"12345678\"}"; //JSON
                
                //Registrar otro cliente...como el dni y código diferente
                //string postdata = "{\"Idcliente\":\"2\",\"Nombre\":\"Juan1\",\"Ape_Paterno\":\"Perez\",\"Ape_Materno\":\"Mendez\",\"Telefono\":\"011234567\",\"Celular\":\"123456789\",\"Direccion\":\"Calle Alcanfores 125\",\"Correo\":\"prueba@hotmail.com\",\"Dni\":\"12345670\"}"; //JSON

                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest req = (HttpWebRequest)WebRequest
                    .Create("http://localhost:2100/Clientes.svc/Clientes");
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
                Assert.AreEqual("12345678", clienteCreado.Dni);
                Assert.AreEqual("Calle Alcanfores 125", clienteCreado.Direccion);
                Assert.AreEqual("prueba@hotmail.com", clienteCreado.Correo);
            }
            catch (WebException ex)
            {
                HttpStatusCode statusError = ((HttpWebResponse)ex.Response).StatusCode;
                string statusDescripcion = ((HttpWebResponse)ex.Response).StatusDescription;
                StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.Fail(mensaje);
            }
        }

        [TestMethod]
        public void TestObtenerCliente()
        {  //Prueba de Obtención de cliente vía HTTP GET                   
         try
            {   
                JavaScriptSerializer js = new JavaScriptSerializer();
                HttpWebRequest req2 = (HttpWebRequest)WebRequest
                   .Create("http://localhost:2100/Clientes.svc/Clientes/3"); //para validar codigo no existente
                //   .Create("http://localhost:2100/Clientes.svc/Clientes/1");   //Obtiene datos cliente registrado en test anterior(TestCrearCliente)
                
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
                Assert.AreEqual("12345678", clienteObtenido.Dni);
                Assert.AreEqual("Calle Alcanfores 125", clienteObtenido.Direccion);
                Assert.AreEqual("prueba@hotmail.com", clienteObtenido.Correo);
            }
            catch (WebException ex)
            {
             HttpStatusCode statusError = ((HttpWebResponse)ex.Response).StatusCode;
             string statusDescripcion = ((HttpWebResponse)ex.Response).StatusDescription;
             StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
             string error = reader.ReadToEnd();
             JavaScriptSerializer js = new JavaScriptSerializer();
             string mensaje = js.Deserialize<string>(error);
             Assert.Fail(mensaje);
            }
        }

        [TestMethod]
        public void TestModificarCliente()
        {   //Prueba de actualización de cliente vía HTTP PUT  
            try
            {   //para validar si el código de cliente a modificar existe  
                string postdata = "{\"Idcliente\":\"3\",\"Nombre\":\"Juan11\",\"Ape_Paterno\":\"Perez1\",\"Ape_Materno\":\"Mendez1\",\"Telefono\":\"011234567\",\"Celular\":\"123456789\",\"Direccion\":\"Calle Alcanfores 125\",\"Correo\":\"prueba@hotmail.com\",\"Dni\":\"12345678\"}"; //JSON

                //para validar si el dni de cliente a modificar existe en otro registro
                //string postdata = "{\"Idcliente\":\"1\",\"Nombre\":\"Juan11\",\"Ape_Paterno\":\"Perez1\",\"Ape_Materno\":\"Mendez1\",\"Telefono\":\"011234567\",\"Celular\":\"123456789\",\"Direccion\":\"Calle Alcanfores 125\",\"Correo\":\"prueba@hotmail.com\",\"Dni\":\"12345670\"}"; //JSON

                //para registrar datos modificados sin permitir duplicidad de dni de cliente -la evaluación tiene como excepción el existente 
                //string postdata = "{\"Idcliente\":\"1\",\"Nombre\":\"Juan11\",\"Ape_Paterno\":\"Perez1\",\"Ape_Materno\":\"Mendez1\",\"Telefono\":\"011234567\",\"Celular\":\"123456789\",\"Direccion\":\"Calle Alcanfores 125\",\"Correo\":\"prueba@hotmail.com\",\"Dni\":\"12345678\"}"; //JSON

                //para registrar datos modificados sin permitir duplicidad de dni de cliente
                //string postdata = "{\"Idcliente\":\"1\",\"Nombre\":\"Juan11\",\"Ape_Paterno\":\"Perez1\",\"Ape_Materno\":\"Mendez1\",\"Telefono\":\"011234567\",\"Celular\":\"123456789\",\"Direccion\":\"Calle Alcanfores 125\",\"Correo\":\"prueba@hotmail.com\",\"Dni\":\"12345677\"}"; //JSON
                
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:2100/Clientes.svc/Clientes");
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
                Assert.AreEqual("12345678", clienteModificado.Dni);
                Assert.AreEqual("Calle Alcanfores 125", clienteModificado.Direccion);
                Assert.AreEqual("prueba@hotmail.com", clienteModificado.Correo);

            }
            catch (WebException ex)
            {
                HttpStatusCode statusError = ((HttpWebResponse)ex.Response).StatusCode;
                string statusDescripcion = ((HttpWebResponse)ex.Response).StatusDescription;
                StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.Fail(mensaje);
            }
        }

        [TestMethod]
        public void TestEliminarCliente()
        {   // Prueba de eliminación de cliente vía HTTP DELETE
         try
          {
            string postdata = "{\"Idcliente\":\"3\"}"; //JSON      //-> Para Probar existencia del código a eliminar   
            //string postdata = "{\"Idcliente\":\"1\"}"; //JSON       //-> Para Probar eliminar un cliente codigo existente
           
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
         
            // Prueba de obtención de cliente eliminado vía HTTP GET
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
         catch (WebException ex)
          {
             HttpStatusCode statusError = ((HttpWebResponse)ex.Response).StatusCode;
             string statusDescripcion = ((HttpWebResponse)ex.Response).StatusDescription;
             StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
             string error = reader.ReadToEnd();
             JavaScriptSerializer js = new JavaScriptSerializer();
             string mensaje = js.Deserialize<string>(error);
             Assert.Fail(mensaje);
          }
        }
    }        
}
