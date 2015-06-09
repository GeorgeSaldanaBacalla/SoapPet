﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using RestServices.Dominio;
using MySql.Data.MySqlClient;

namespace RestServices.Persistencia
{
    public class MascotaDAO
    {
        public Mascota Crear(Mascota mascotaACrear)
        {
            Mascota MascotaCreado = null;
            long idmascota;
            string sql = "INSERT INTO mascota Values ( @nombre, @ape_pat, @ape_mat, @raza, @edad, @peso)";

            using (MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@nombre", mascotaACrear.Nombre);
                    cmd.Parameters.AddWithValue("@ape_pat", mascotaACrear.Ape_Pat);
                    cmd.Parameters.AddWithValue("@ape_mat", mascotaACrear.Ape_Mat);
                    cmd.Parameters.AddWithValue("@raza", mascotaACrear.Raza);
                    cmd.Parameters.AddWithValue("@edad", mascotaACrear.Edad);
                    cmd.Parameters.AddWithValue("@peso", mascotaACrear.Peso);

                    cmd.ExecuteNonQuery();
                    idmascota = cmd.LastInsertedId;
                }

            }

            MascotaCreado = Obtener(Convert.ToString( idmascota ));

            return MascotaCreado;

        }
        public Mascota Obtener(string idmascota)
        {
            Mascota MascotaEncontrado = null;

            MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena);
            MySqlCommand cmd;
            MySqlDataReader reader = null;

            con.Open();

            try
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM mascota WHERE idmascota=@id";
                cmd.Parameters.AddWithValue("@id", idmascota);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    MascotaEncontrado = new Mascota()
                    {
                        Idmascota = (reader["idmascota"] ?? "").ToString(),
                        Nombre = (reader["nombre"] ?? "").ToString(),
                        Ape_Pat = (reader["ape_paterno"] ?? "").ToString(),
                        Ape_Mat = (reader["ape_materno"] ?? "").ToString(),
                        Raza = (reader["raza"] ?? "").ToString(),
                        Edad = (reader["edad"] ?? "").ToString(),
                        Peso = (reader["peso"] ?? "").ToString(),
                        
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
            return MascotaEncontrado;
        }
        public Mascota Modificar(Mascota mascotaAModificar)
        {
            string sql = "UPDATE mascota SET nombre=@nombre, ape_paterno=@ape_paterno,ape_materno=@ape_materno,telefono=@telefono, celular=@celular,correo=@correo,direccion=@direccion " +
                         "WHERE idmascota = @idmascota";

            using (MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@nombre", mascotaAModificar.Nombre);
                    cmd.Parameters.AddWithValue("@ape_pat", mascotaAModificar.Ape_Pat);
                    cmd.Parameters.AddWithValue("@ape_mat", mascotaAModificar.Ape_Mat);
                    cmd.Parameters.AddWithValue("@raza", mascotaAModificar.Raza);
                    cmd.Parameters.AddWithValue("@edad", mascotaAModificar.Edad);
                    cmd.Parameters.AddWithValue("@peso", mascotaAModificar.Peso);
                    cmd.ExecuteNonQuery();
                }

            }
            return Obtener(mascotaAModificar.Idmascota);
        }
        public void Eliminar(Mascota mascotaAEliminar)
        {
            string sql = "DELETE FROM mascota WHERE idmascota = @idmascota";

            using (MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@idmascota", mascotaAEliminar.Idmascota);
                    cmd.ExecuteNonQuery();
                }

            }
        }
        public List<Mascota> ListarTodos()
        {
            // TODO:
            return null;
        }
    }
}