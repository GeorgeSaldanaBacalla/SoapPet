﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using RestServices.Dominio;
using MySql.Data.MySqlClient;

namespace RestServices.Persistencia
{
    public class ClienteDAO
    {
        public Cliente Crear(Cliente clienteACrear)
        {
            Cliente ClienteCreado = null;
            long idcliente;
            string sql = "INSERT INTO cliente ( nombre, ape_paterno,ape_materno,telefono, celular,correo,direccion) " +
                         "VALUES ( @nombre, @ape_paterno, @ape_materno, @telefono, @celular, @correo, @direccion )";

            using (MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@nombre", clienteACrear.Nombre);
                    cmd.Parameters.AddWithValue("@ape_paterno", clienteACrear.ApePaterno);
                    cmd.Parameters.AddWithValue("@ape_materno", clienteACrear.ApeMaterno);
                    cmd.Parameters.AddWithValue("@telefono", clienteACrear.Telefono);
                    cmd.Parameters.AddWithValue("@celular", clienteACrear.Celular);
                    cmd.Parameters.AddWithValue("@correo", clienteACrear.Correo);
                    cmd.Parameters.AddWithValue("@direccion", clienteACrear.Direccion);

                    cmd.ExecuteNonQuery();
                    idcliente = cmd.LastInsertedId;
                }

            }

            ClienteCreado = Obtener(Convert.ToString(idcliente));
            return ClienteCreado;

        }
        public Cliente Obtener(string idcliente)
        {
            Cliente ClienteEncontrado = null;

            MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena);
            MySqlCommand cmd;
            MySqlDataReader reader = null;

            con.Open();

            try
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM cliente WHERE idcliente=@id";
                cmd.Parameters.AddWithValue("@id", idcliente);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ClienteEncontrado = new Cliente()
                    {
                        Idcliente = (reader["idcliente"] ?? "").ToString(),
                        Nombre = (reader["nombre"] ?? "").ToString(),
                        ApePaterno = (reader["ape_paterno"] ?? "").ToString(),
                        ApeMaterno = (reader["ape_materno"] ?? "").ToString(),
                        Telefono = (reader["telefono"] ?? "").ToString(),
                        Celular = (reader["celular"] ?? "").ToString(),
                        Correo = (reader["correo"] ?? "").ToString(),
                        Direccion = (reader["direccion"] ?? "").ToString()
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
            return ClienteEncontrado;
        }
        public Cliente Modificar(Cliente clienteAModificar)
        {
            string sql = "UPDATE cliente SET nombre=@nombre, ape_paterno=@ape_paterno,ape_materno=@ape_materno,telefono=@telefono, celular=@celular,correo=@correo,direccion=@direccion " +
                         "WHERE idcliente = @idcliente";

            using (MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@nombre", clienteAModificar.Nombre);
                    cmd.Parameters.AddWithValue("@ape_paterno", clienteAModificar.ApePaterno);
                    cmd.Parameters.AddWithValue("@ape_materno", clienteAModificar.ApeMaterno);
                    cmd.Parameters.AddWithValue("@telefono", clienteAModificar.Telefono);
                    cmd.Parameters.AddWithValue("@celular", clienteAModificar.Celular);
                    cmd.Parameters.AddWithValue("@correo", clienteAModificar.Correo);
                    cmd.Parameters.AddWithValue("@direccion", clienteAModificar.Direccion);
                    cmd.ExecuteNonQuery();
                }

            }
            return Obtener(clienteAModificar.Idcliente);
        }
        public void Eliminar(Cliente clienteAEliminar)
        {
            string sql = "DELETE FROM cliente WHERE idcliente = @idcliente";

            using (MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@idcliente", clienteAEliminar.Idcliente);
                    cmd.ExecuteNonQuery();
                }

            }
        }
        public List<Cliente> ListarTodos()
        {
            // TODO:
            return null;
        }
    }
}