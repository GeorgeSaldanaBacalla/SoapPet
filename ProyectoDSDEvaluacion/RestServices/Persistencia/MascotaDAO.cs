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
            string sql = "INSERT INTO mascota (idcliente,nombre,ape_paterno,ape_materno,raza,edad,peso) values ( @idcliente,@nombre, @ape_pat, @ape_mat, @raza, @edad, @peso)";

            using (MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@idcliente", mascotaACrear.Idcliente);
                    cmd.Parameters.AddWithValue("@nombre", mascotaACrear.Nombre);
                    cmd.Parameters.AddWithValue("@ape_pat", mascotaACrear.ApePaterno);
                    cmd.Parameters.AddWithValue("@ape_mat", mascotaACrear.ApeMaterno);
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
                        Idcliente = (reader["idcliente"] ?? "").ToString(),
                        Nombre = (reader["nombre"] ?? "").ToString(),
                        ApePaterno = (reader["ape_paterno"] ?? "").ToString(),
                        ApeMaterno = (reader["ape_materno"] ?? "").ToString(),
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
            string sql = "UPDATE mascota SET idcliente=@idcliente, nombre=@nombre, ape_paterno=@ape_paterno, ape_materno=@ape_materno, raza=@raza, edad=@edad, peso=@peso " +
                         "WHERE idmascota = @idmascota";

            using (MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@idmascota", mascotaAModificar.Idmascota);
                    cmd.Parameters.AddWithValue("@idcliente", mascotaAModificar.Idcliente);
                    cmd.Parameters.AddWithValue("@nombre", mascotaAModificar.Nombre);
                    cmd.Parameters.AddWithValue("@ape_paterno", mascotaAModificar.ApePaterno);
                    cmd.Parameters.AddWithValue("@ape_materno", mascotaAModificar.ApeMaterno);
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
        public List<Mascota> ListarMascotasPorCliente(string idcliente)
        {

            List<Mascota> listaMascotas = new List<Mascota>();

            MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena);
            MySqlCommand cmd;
            MySqlDataReader reader = null;

            con.Open();

            try
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM mascota where idcliente=@idcliente";
                cmd.Parameters.AddWithValue("@idcliente", idcliente);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Mascota mascotaEncontrado = new Mascota()
                    {
                        Idmascota = (reader["idmascota"] ?? "").ToString(),
                        Idcliente = (reader["idcliente"] ?? "").ToString(),
                        Nombre = (reader["nombre"] ?? "").ToString(),
                        ApePaterno = (reader["ape_paterno"] ?? "").ToString(),
                        ApeMaterno = (reader["ape_materno"] ?? "").ToString(),
                        Raza = (reader["raza"] ?? "").ToString(),
                        Edad = (reader["edad"] ?? "").ToString(),
                        Peso = (reader["peso"] ?? "").ToString(),
                    };
                    listaMascotas.Add(mascotaEncontrado);
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
            return listaMascotas;
        }
    }
}