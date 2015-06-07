using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace RestMascotas
{
    [TestClass]
    public class Mascota
    {
        [TestMethod]
        public void CRUDTest()
        {
            //Prueba de creación de alumno vía HTTP POST
            string postdata = "{\"idmascota\":\"3\",\"nombre\":\"canus\",\"raza\":\"doggy\",\"edad\":\"3\",\"peso\":\"2\",\"idcliente\":\"1\",\"ape_pat\":\"laos\",\"ape_mat\":\"barrantes\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:1194/Mascotas.svc/Mascotas");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string mascotaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Mascotas mascotaCreado = js.Deserialize<Mascotas>(mascotaJson);
            Assert.AreEqual("1", mascotaCreado.Codigo);

           
        }
    }
}
