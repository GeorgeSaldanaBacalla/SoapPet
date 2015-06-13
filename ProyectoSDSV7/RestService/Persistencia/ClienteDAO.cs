using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestService.Dominio;
using System.Data.SqlClient;
using RestService.Dominio;


namespace RestService.Persistencia
{
    public class ClienteDAO
    {
        public Cliente Crear(Cliente clienteACrear)
        {
            Cliente clienteCreado = null;
            string sql = "INSERT INTO cliente VALUES (@cod, @nom, @apep, @apem, @tel, @cel, @cor, @dir, @dni)";
            
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", clienteACrear.Idcliente));
                    com.Parameters.Add(new SqlParameter("@nom", clienteACrear.Nombre));
                    com.Parameters.Add(new SqlParameter("@apep", clienteACrear.Ape_Paterno));
                    com.Parameters.Add(new SqlParameter("@apem", clienteACrear.Ape_Materno));
                    com.Parameters.Add(new SqlParameter("@tel", clienteACrear.Telefono));
                    com.Parameters.Add(new SqlParameter("@cel", clienteACrear.Celular));
                    com.Parameters.Add(new SqlParameter("@cor", clienteACrear.Correo));
                    com.Parameters.Add(new SqlParameter("@dir", clienteACrear.Direccion));
                    com.Parameters.Add(new SqlParameter("@dni", clienteACrear.Dni));
                    com.ExecuteNonQuery();
                }
            }
            clienteCreado = Obtener(clienteACrear.Idcliente);
            return clienteCreado;
        }
        public Cliente Obtener(string idcliente)
        {
            Cliente clienteEncontrado = null;
            string sql = "SELECT * FROM cliente WHERE idcliente=@cod";
           
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", idcliente));                    
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            clienteEncontrado = new Cliente()
                            {
                                Idcliente = (string)resultado["idcliente"],
                                Nombre = (string)resultado["nombre"],
                                Ape_Paterno = (string)resultado["ape_paterno"],
                                Ape_Materno = (string)resultado["ape_materno"],
                                Telefono = (string)resultado["telefono"],
                                Celular = (string)resultado["celular"],
                                Direccion = (string)resultado["direccion"],
                                Correo = (string)resultado["correo"],
                                Dni = (string)resultado["dni"],
                            };
                        }
                    }
                }
            }
            return clienteEncontrado;
        }

        public Cliente ObtenerXDni(string dni)
        {
            Cliente clienteEncontrado = null;
            string sql = "SELECT * FROM cliente WHERE dni=@dni";

            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@dni", dni));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            clienteEncontrado = new Cliente()
                            {
                                Idcliente = (string)resultado["idcliente"],
                                Nombre = (string)resultado["nombre"],
                                Ape_Paterno = (string)resultado["ape_paterno"],
                                Ape_Materno = (string)resultado["ape_materno"],
                                Telefono = (string)resultado["telefono"],
                                Celular = (string)resultado["celular"],
                                Direccion = (string)resultado["direccion"],
                                Correo = (string)resultado["correo"],
                                Dni = (string)resultado["dni"],
                            };
                        }
                    }
                }
            }
            return clienteEncontrado;
        }


        public Cliente Modificar(Cliente clienteAModificar)
        {             
            Cliente clienteModificado = null;
           
            string sql = "UPDATE cliente SET nombre= @nom, ape_paterno=@apep, ape_materno=@apem, telefono=@tel, celular=@cel, correo=@cor, direccion=@dir, dni=@dni WHERE idcliente = @cod";
            
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", clienteAModificar.Idcliente));
                    com.Parameters.Add(new SqlParameter("@nom", clienteAModificar.Nombre));
                    com.Parameters.Add(new SqlParameter("@apep", clienteAModificar.Ape_Paterno));
                    com.Parameters.Add(new SqlParameter("@apem", clienteAModificar.Ape_Materno));
                    com.Parameters.Add(new SqlParameter("@tel", clienteAModificar.Telefono));
                    com.Parameters.Add(new SqlParameter("@cel", clienteAModificar.Celular));
                    com.Parameters.Add(new SqlParameter("@dir", clienteAModificar.Direccion));
                    com.Parameters.Add(new SqlParameter("@cor", clienteAModificar.Correo));
                    com.Parameters.Add(new SqlParameter("@dni", clienteAModificar.Dni));
                    com.ExecuteNonQuery();
                }
            }
            clienteModificado = Obtener(clienteAModificar.Idcliente);
            return clienteModificado;            
        }
        

        public void Eliminar(Cliente clienteAEliminar)
        {
            string sql = "DELETE cliente WHERE idcliente = @cod";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", clienteAEliminar.Idcliente));
                    com.ExecuteNonQuery();
                }
            }            
        }
        
        public List<Cliente> ListarTodos()
        {
            return null;
        }
    }
}



