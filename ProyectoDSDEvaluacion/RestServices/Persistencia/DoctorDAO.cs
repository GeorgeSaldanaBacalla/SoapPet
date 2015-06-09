﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using RestServices.Dominio;
using MySql.Data.MySqlClient;

namespace RestServices.Persistencia
{
    public class DoctorDAO
    {
        public Doctor Crear(Doctor doctorACrear)
        {
            Doctor doctorCreado = null;
            long iddoctor;
            string sql = "INSERT INTO doctor ( nombre, ape_paterno,ape_materno,correo,telefono, celular) " +
                         "VALUES ( @nombre, @ape_paterno, @ape_materno, @correo, @telefono, @celular )";

            using (MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@nombre", doctorACrear.Nombre);
                    cmd.Parameters.AddWithValue("@ape_paterno", doctorACrear.ApePaterno);
                    cmd.Parameters.AddWithValue("@ape_materno", doctorACrear.ApeMaterno);
                    cmd.Parameters.AddWithValue("@correo", doctorACrear.Correo);
                    cmd.Parameters.AddWithValue("@telefono", doctorACrear.Telefono);
                    cmd.Parameters.AddWithValue("@celular", doctorACrear.Celular);

                    cmd.ExecuteNonQuery();
                    iddoctor = cmd.LastInsertedId;
                }

            }

            doctorCreado = Obtener(Convert.ToString(iddoctor));
            return doctorCreado;

        }
        public Doctor Obtener(string iddoctor)
        {
            Doctor doctorEncontrado = null;

            MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena);
            MySqlCommand cmd;
            MySqlDataReader reader = null;

            con.Open();

            try
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM doctor WHERE iddoctor=@id";
                cmd.Parameters.AddWithValue("@id", iddoctor);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    doctorEncontrado = new Doctor()
                    {
                        Iddoctor = (reader["iddoctor"] ?? "").ToString(),
                        Nombre = (reader["nombre"] ?? "").ToString(),
                        ApePaterno = (reader["ape_paterno"] ?? "").ToString(),
                        ApeMaterno = (reader["ape_materno"] ?? "").ToString(),
                        Correo = (reader["correo"] ?? "").ToString(),
                        Telefono = (reader["telefono"] ?? "").ToString(),
                        Celular = (reader["celular"] ?? "").ToString(),
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
            return doctorEncontrado;
        }
        public Doctor Modificar(Doctor doctorAModificar)
        {
            string sql = "UPDATE doctor SET nombre=@nombre, ape_paterno=@ape_paterno,ape_materno=@ape_materno,correo=@correo,telefono=@telefono, celular=@celular " +
                         "WHERE iddoctor = @iddoctor";

            using (MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@nombre", doctorAModificar.Nombre);
                    cmd.Parameters.AddWithValue("@ape_paterno", doctorAModificar.ApePaterno);
                    cmd.Parameters.AddWithValue("@ape_materno", doctorAModificar.ApeMaterno);
                    cmd.Parameters.AddWithValue("@correo", doctorAModificar.Correo);
                    cmd.Parameters.AddWithValue("@telefono", doctorAModificar.Telefono);
                    cmd.Parameters.AddWithValue("@celular", doctorAModificar.Celular);
                    cmd.ExecuteNonQuery();
                }

            }
            return Obtener(doctorAModificar.Iddoctor);
        }
        public void Eliminar(Doctor doctorAEliminar)
        {
            string sql = "DELETE FROM doctor WHERE iddoctor = @iddoctor";

            using (MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@iddoctor", doctorAEliminar.Iddoctor);
                    cmd.ExecuteNonQuery();
                }

            }
        }
        public List<Doctor> ListarTodos()
        {
            // TODO:
            return null;
        }
    }
}