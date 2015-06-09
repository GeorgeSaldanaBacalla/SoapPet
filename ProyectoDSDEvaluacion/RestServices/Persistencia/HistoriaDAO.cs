﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using RestServices.Dominio;
using MySql.Data.MySqlClient;

namespace RestServices.Persistencia
{
    public class HistoriaDAO
    {
        public Historia Crear(Historia historiaACrear)
        {
            Historia HistoriaCreado = null;
            long idhistoria;
            string sql = "INSERT INTO historia ( idmascota,idcita,diagnostico, tratamiento) " +
                         "VALUES ( @idmascota, @idcita, @diagnostico, @tratamiento )";

            using (MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@idmascota", historiaACrear.Idmascota);
                    cmd.Parameters.AddWithValue("@idcita", historiaACrear.Idcita);
                    cmd.Parameters.AddWithValue("@diagnostico", historiaACrear.Diagnostico);
                    cmd.Parameters.AddWithValue("@tratamiento", historiaACrear.Tratamiento);

                    cmd.ExecuteNonQuery();
                    idhistoria = cmd.LastInsertedId;
                }

            }

            HistoriaCreado = Obtener(Convert.ToString(idhistoria));
            return HistoriaCreado;

        }
        public Historia Obtener(string idhistoria)
        {
            Historia HistoriaEncontrado = null;

            MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena);
            MySqlCommand cmd;
            MySqlDataReader reader = null;

            con.Open();

            try
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM historia WHERE idhistoria=@id";
                cmd.Parameters.AddWithValue("@id", idhistoria);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    HistoriaEncontrado = new Historia()
                    {
                        Idhistoria = (reader["idhistoria"] ?? "").ToString(),
                        Idmascota = (reader["idmascota"] ?? "").ToString(),
                        Idcita = (reader["idcita"] ?? "").ToString(),
                        Diagnostico = (reader["diagnostico"] ?? "").ToString(),
                        Tratamiento = (reader["tratamiento"] ?? "").ToString()
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
            return HistoriaEncontrado;
        }
        public Historia Modificar(Historia historiaAModificar)
        {
            string sql = "UPDATE historia SET idmascota=@idmascota, idcita=@idcita,diagnostico=@diagnostico,tratamiento=@tratamiento " +
                         "WHERE idhistoria = @idhistoria";

            using (MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@idmascota", historiaAModificar.Idmascota);
                    cmd.Parameters.AddWithValue("@idcita", historiaAModificar.Idcita);
                    cmd.Parameters.AddWithValue("@diagnostico", historiaAModificar.Diagnostico);
                    cmd.Parameters.AddWithValue("@tratamiento", historiaAModificar.Tratamiento);
                    cmd.ExecuteNonQuery();
                }

            }
            return Obtener(historiaAModificar.Idhistoria);
        }
        public void Eliminar(Historia historiaAEliminar)
        {
            string sql = "DELETE FROM historia WHERE idhistoria = @idhistoria";

            using (MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@idhistoria", historiaAEliminar.Idhistoria);
                    cmd.ExecuteNonQuery();
                }

            }
        }
        public List<Historia> ListarTodos()
        {
            // TODO:
            return null;
        }
    }
}