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
    public class EvaluacionTest
    {

        [TestMethod]
        public void TestCrearEvaluacion()
        {
            // Prueba de creación de alumno vía HTTP POST
            string postdata = "{\"Fecha\":\"2015-05-05 15:00:00\",\"Pregunta\":\"Califique el trato del doctor\",\"Respuesta\":\"Bueno\",\"Idcita\":\"100\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:2744/Evaluaciones.svc/Evaluaciones");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string evaluacionJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Evaluacion evaluacionCreado = js.Deserialize<Evaluacion>(evaluacionJson);
            Assert.AreEqual("Califique el trato del doctor", evaluacionCreado.Pregunta);
            Assert.AreEqual("Bueno", evaluacionCreado.Respuesta);

            // Prueba de obtención de alumno vía HTTP GET
            HttpWebRequest req2 = (HttpWebRequest)WebRequest
                .Create("http://localhost:2744/Evaluaciones.svc/Evaluaciones/" + evaluacionCreado.Idevaluacion);
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string alumnoJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Evaluacion alumnoObtenido = js2.Deserialize<Evaluacion>(alumnoJson2);
            Assert.AreEqual("Califique el trato del doctor", evaluacionCreado.Pregunta);
            Assert.AreEqual("Bueno", evaluacionCreado.Respuesta);
        }

        [TestMethod]

        public void TestEliminarCliente()
        {
            string postdata = "{\"Idevaluacion\":\"1\"}"; //JSON 

            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:2744/Evaluaciones.svc/Evaluaciones");
            req.Method = "DELETE";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);

            /*HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string clienteJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();*/

            // Prueba de obtención de cliente vía HTTP GET
            HttpWebRequest req2 = (HttpWebRequest)WebRequest
                .Create("http://localhost:2744/Evaluaciones.svc/Evaluaciones/1");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string EvaluacionJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Evaluacion evaluacionObtenido = js2.Deserialize<Evaluacion>(EvaluacionJson2);
            Assert.IsNull(evaluacionObtenido);
        }
        [TestMethod]
        public void TestModificarAlumno()
        {
            // Prueba de creación de alumno vía HTTP POST
            string postdata = "{\"Idevaluacion\":\"2\",\"Fecha\":\"2015-05-05 15:00:00\",\"Pregunta\":\"Califique la atencion\",\"Respuesta\":\"Bueno\",\"Idcita\":\"100\",}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:2744/Evaluaciones.svc/Evaluaciones");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string evaluacionJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Evaluacion evaluacionCreado = js.Deserialize<Evaluacion>(evaluacionJson);
            Assert.AreEqual("Califique la atencion", evaluacionCreado.Pregunta);
            Assert.AreEqual("Bueno", evaluacionCreado.Respuesta);

            // Prueba de obtención de alumno vía HTTP GET
            HttpWebRequest req2 = (HttpWebRequest)WebRequest
                .Create("http://localhost:2744/Evaluaciones.svc/Evaluaciones/2");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string evaluacionJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Evaluacion evaluacionObtenido = js2.Deserialize<Evaluacion>(evaluacionJson2);
            Assert.AreEqual("Califique la atencion", evaluacionObtenido.Pregunta);
            Assert.AreEqual("Bueno", evaluacionObtenido.Respuesta);
        }
    }
}
