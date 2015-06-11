﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using RestServices.Dominio;
using MySql.Data.MySqlClient;

namespace RestServices.Persistencia
{
    public class CitaDAO
    {
        public Cita Crear(Cita citaACrear)
        {
            Cita CitaCreado = null;
            long idcita;
            string sql = "INSERT INTO cita ( idmascota, iddoctor, fecha_inicio, fecha_fin) " +
                         "values ( @idmascota, @iddoctor, @fecha_inicio, @fecha_fin) ";

            using (MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@idmascota", citaACrear.Idmascota);
                    cmd.Parameters.AddWithValue("@iddoctor", citaACrear.Iddoctor);
                    cmd.Parameters.AddWithValue("@fecha_inicio", citaACrear.FechaInicio);
                    cmd.Parameters.AddWithValue("@fecha_fin", citaACrear.FechaFin);

                    cmd.ExecuteNonQuery();
                    idcita = cmd.LastInsertedId;
                }

            }

            CitaCreado = Obtener(Convert.ToString( idcita ));

            return CitaCreado;

        }
        public Cita Obtener(string idcita)
        {
            Cita CitaEncontrado = null;

            MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena);
            MySqlCommand cmd;
            MySqlDataReader reader = null;

            con.Open();

            try
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM cita WHERE idcita=@id";
                cmd.Parameters.AddWithValue("@id", idcita);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    CitaEncontrado = new Cita()
                    {
                        Idcita = (reader["idcita"] ?? "").ToString(),
                        Idmascota = (reader["idmascota"] ?? "").ToString(),
                        Iddoctor = (reader["iddoctor"] ?? "").ToString(),
                        FechaInicio = Convert.ToDateTime((reader["fecha_inicio"] ?? "")).ToString("yyyy-MM-dd HH:mm:ss"),
                        FechaFin = Convert.ToDateTime((reader["fecha_fin"] ?? "")).ToString("yyyy-MM-dd HH:mm:ss")
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
            return CitaEncontrado;
        }
        public Cita Modificar(Cita citaAModificar)
        {
            string sql = "UPDATE cita SET idmascota=@idmascota, iddoctor=@iddoctor, fecha_inicio=@fecha_inicio, fecha_fin=@fecha_fin " +
                         "WHERE idcita = @idcita";

            using (MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@idcita", citaAModificar.Idcita);
                    cmd.Parameters.AddWithValue("@idmascota", citaAModificar.Idmascota);
                    cmd.Parameters.AddWithValue("@iddoctor", citaAModificar.Iddoctor);
                    cmd.Parameters.AddWithValue("@fecha_inicio", citaAModificar.FechaInicio);
                    cmd.Parameters.AddWithValue("@fecha_fin", citaAModificar.FechaFin);
                    cmd.ExecuteNonQuery();
                }

            }
            return Obtener(citaAModificar.Idcita);
        }
        public void Eliminar(Cita citaAEliminar)
        {
            string sql = "DELETE FROM cita WHERE idcita = @idcita";

            using (MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@idcita", citaAEliminar.Idcita);
                    cmd.ExecuteNonQuery();
                }

            }
        }
        public List<Cita> ListarCitasPorDoctor(string iddoctor)
        {

            List<Cita> listaCitas = new List<Cita>();

            MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena);
            MySqlCommand cmd;
            MySqlDataReader reader = null;

            con.Open();

            try
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM cita where iddoctor=@iddoctor";
                cmd.Parameters.AddWithValue("@iddoctor", iddoctor);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cita citaEncontrado = new Cita()
                    {
                        Idcita = (reader["idcita"] ?? "").ToString(),
                        Idmascota = (reader["idmascota"] ?? "").ToString(),
                        Iddoctor = (reader["iddoctor"] ?? "").ToString(),
                        FechaInicio = (reader["fecha_inicio"] ?? "").ToString(),
                        FechaFin = (reader["fecha_fin"] ?? "").ToString()
                    };
                    listaCitas.Add(citaEncontrado);
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
            return listaCitas;
        }
    }
}