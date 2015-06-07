using MascotaService.Dominio;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MascotaService.Persistencia
{

    public class MascotaDAO {

        public Mascota Crear(Mascota mascotaCrear) {
            Mascota mascotaCreado = null;
            string sql = "INSERT INTO mascota Values (@codigo, @nombre, @ape_pat, @ape_mat, @raza, @edad, @peso)";
            using (MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena)) {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(sql, con)) {
                    com.Parameters.Add(new MySqlParameter("@codigo", mascotaCrear.Codigo));
                    com.Parameters.Add(new MySqlParameter("@nombre", mascotaCrear.Nombre));
                    com.Parameters.Add(new MySqlParameter("@ape_pat", mascotaCrear.Ape_Pat));
                    com.Parameters.Add(new MySqlParameter("@ape_mat", mascotaCrear.Ape_Mat));
                    com.Parameters.Add(new MySqlParameter("@raza", mascotaCrear.Raza));
                    com.Parameters.Add(new MySqlParameter("@edad", mascotaCrear.Edad));
                    com.Parameters.Add(new MySqlParameter("@peso", mascotaCrear.Peso));
                    com.ExecuteNonQuery();
                }
            }
            mascotaCreado = Obtener(Convert.ToString( mascotaCrear.Codigo).ToString().Trim());
            return mascotaCreado;
        }

        public Mascota Obtener(string Codigo) {
            Mascota mascotaEncontrado = null;
            string sql = "SELECT * from mascota where idmascota= @codigo";
            using (MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena)) {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(sql, con)) {
                    com.Parameters.Add(new MySqlParameter("@codigo", Codigo));
                    using (MySqlDataReader resultado = com.ExecuteReader()) {
                        if (resultado.Read())
                        {
                            mascotaEncontrado = new Mascota()
                            {
                                Codigo = (int)resultado["idmascota"],
                                Nombre = (string)resultado["nombre"],
                                Ape_Pat = (string)resultado["ape_pat"],
                                Ape_Mat = (string)resultado["ape_mat"],
                                Raza = (string)resultado["raza"],
                                Edad = (int)resultado["edad"],
                                Peso = (double)resultado["peso"]
                            };
                        }
                    }
                }
            }
            return mascotaEncontrado;
        }

        public List<Mascota> ObtenerPorIdCliente(string idCliente)
        {
            List<Mascota> mascotaEncontrado = null;
            string sql = "SELECT * from mascota where idcliente= @idCliente";
            using (MySqlConnection con = new MySqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(sql, con))
                {
                    com.Parameters.Add(new MySqlParameter("@idCliente", idCliente));
                    using (MySqlDataReader resultado = com.ExecuteReader())
                    {
                        mascotaEncontrado = new List<Mascota>();
                        while (resultado.Read())
                        {
                            Mascota mascota = new Mascota();
                                              
                                
                                mascota.Codigo = (int)resultado["idmascota"];
                                mascota.Nombre = (string)resultado["nombre"];
                                mascota.Ape_Pat = (string)resultado["ape_pat"];
                                mascota.Ape_Mat = (string)resultado["ape_mat"];
                                mascota.Raza = (string)resultado["raza"];
                                mascota.Edad = (int)resultado["edad"];
                                mascota.Peso = (double)resultado["peso"];
                                mascotaEncontrado.Add(mascota);
                            
                        }
                    }
                }
            }
            return mascotaEncontrado;
        }
    }
        
}
