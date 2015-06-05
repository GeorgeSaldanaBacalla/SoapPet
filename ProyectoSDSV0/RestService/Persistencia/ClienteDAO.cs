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
            //string sql = "INSERT INTO t_alumno VALUES (@cod, @nom)";
            string sql = "INSERT INTO cliente VALUES (@cod, @nom)";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", clienteACrear.Codigo));
                    com.Parameters.Add(new SqlParameter("@nom", clienteACrear.Nombre));
                    com.ExecuteNonQuery();
                }
            }
            clienteCreado = Obtener(clienteACrear.Codigo);
            return clienteCreado;
        }
        public Cliente Obtener(string codigo)
        {
            Cliente clienteEncontrado = null;
            //string sql = "SELECT * FROM t_alumno WHERE codigo=@cod";
            string sql = "SELECT * FROM cliente WHERE codigo=@cod";
            //string sql = "SELECT * FROM cliente WHERE idcliente=@cod";
           
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", codigo));                    
                    //com.Parameters.Add(new SqlParameter("@cod", idcliente));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            clienteEncontrado = new Cliente()
                            {
                                Codigo = (string)resultado["codigo"],
                                //Codigo = (string)resultado["idcliente"],
                                Nombre = (string)resultado["nombre"]
                            };
                        }
                    }
                }
            }
            return clienteEncontrado;
        }
        public Cliente Modificar(Cliente clienteAModificar)
        { 
            // TODO:
            return null;
        }
        public void Eliminar(Cliente clienteAEliminar)
        {
            // TODO:
            
        }
        public List<Cliente> ListarTodos()
        {
            return null;
        }
    }
}



