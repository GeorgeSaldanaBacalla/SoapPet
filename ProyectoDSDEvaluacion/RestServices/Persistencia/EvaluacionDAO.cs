using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using RestServices.Dominio;
using MySql.Data.MySqlClient;

namespace RestServices.Persistencia
{
    public class EvaluacionDAO
    {
        public Evaluacion Crear(Evaluacion evaluacionACrear)
        {
            Evaluacion EvaluacionCreado = null;
            long idevaluacion;
            string sql = "INSERT INTO evaluacion (fecha, pregunta, respuesta, idcita) VALUES ( @fecha,@pregunta,@respuesta,@idcita)";

            using (MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Prepare();
                    //we will bound a value to the placeholder
                    cmd.Parameters.AddWithValue("@fecha", evaluacionACrear.Fecha);
                    cmd.Parameters.AddWithValue("@pregunta", evaluacionACrear.Pregunta);
                    cmd.Parameters.AddWithValue("@respuesta", evaluacionACrear.Respuesta);
                    cmd.Parameters.AddWithValue("@idcita", evaluacionACrear.Idcita);

                    cmd.ExecuteNonQuery();
                    idevaluacion = cmd.LastInsertedId;
                }

            }

            EvaluacionCreado = Obtener(Convert.ToString(idevaluacion));
            return EvaluacionCreado;

        }
        public Evaluacion Obtener(string idevaluacion)
        {
            Evaluacion EvaluacionEncontrado = null;

            MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena);
            MySqlCommand cmd;
            MySqlDataReader reader = null;

            con.Open();

            try
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM evaluacion WHERE idevaluacion=@id";
                cmd.Parameters.AddWithValue("@id", idevaluacion);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    DateTime fec = (DateTime)reader["fecha"];
                    EvaluacionEncontrado = new Evaluacion()
                    {
                        Idevaluacion = (string)reader["idevaluacion"],
                        Fecha = fec.ToString("yyyy-MM-dd HH:mm:ss"),
                        Pregunta = (string)reader["pregunta"],
                        Respuesta = (string)reader["respuesta"],
                        Idcita = (string)reader["idcita"]
                    };
                }
            }
            catch (MySqlException err)
            {
                Console.WriteLine("Error: " + err.ToString());
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (con != null)
                {
                    con.Close(); //close the connection
                }
            }
            return EvaluacionEncontrado;
        }
        public Evaluacion Modificar(Evaluacion evaluacionAModificar)
        {
            string sql = "UPDATE evaluacion SET fecha='@fecha', pregunta=@pregunta, respuesta=@respuesta, idcita=@idcita WHERE idevaluacion = @idevaluacion";

            using (MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@idevaluacion", evaluacionAModificar.Idevaluacion);
                    cmd.Parameters.AddWithValue("@fecha", evaluacionAModificar.Fecha);
                    cmd.Parameters.AddWithValue("@pregunta", evaluacionAModificar.Pregunta);
                    cmd.Parameters.AddWithValue("@respuesta", evaluacionAModificar.Respuesta);
                    cmd.Parameters.AddWithValue("@idcita", evaluacionAModificar.Idcita);

                    cmd.ExecuteNonQuery();
                }

            }
            return Obtener(evaluacionAModificar.Idevaluacion);
        }
        public void Eliminar(Evaluacion evaluacionAEliminar)
        {
            string sql = "DELETE FROM evaluacion WHERE idevaluacion = @idevaluacion";

            using (MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Prepare();
                    //we will bound a value to the placeholder
                    cmd.Parameters.AddWithValue("@idevaluacion", evaluacionAEliminar.Idevaluacion);
                    cmd.ExecuteNonQuery();
                }

            }
        }
        public List<Evaluacion> ListarTodos()
        {
            // TODO:
            return null;
        }
    }
}