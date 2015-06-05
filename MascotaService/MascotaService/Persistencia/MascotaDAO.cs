using MascotaService.Dominio;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Data.SqlClient;

namespace MascotaService.Persistencia
{

    public class MascotaDAO {

        public Mascota Crear(Mascota mascotaCrear) {
            Mascota mascotaCreado = null;
            string sql = "INSERT INTO mascota Values (@codigo, @nombre, @ape_pat, @ape_mat, @raza, @edad, @peso)";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena)) {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con)) {
                    com.Parameters.Add(new SqlParameter("@codigo", mascotaCrear.Codigo));
                    com.Parameters.Add(new SqlParameter("@nombre", mascotaCrear.Nombre));
                    com.Parameters.Add(new SqlParameter("@ape_pat", mascotaCrear.Ape_Pat));
                    com.Parameters.Add(new SqlParameter("@ape_mat", mascotaCrear.Ape_Mat));
                    com.Parameters.Add(new SqlParameter("@raza", mascotaCrear.Raza));
                    com.Parameters.Add(new SqlParameter("@edad", mascotaCrear.Edad));
                    com.Parameters.Add(new SqlParameter("@peso", mascotaCrear.Peso));
                    com.ExecuteNonQuery();
                }
            }
            mascotaCreado = Obtener(mascotaCrear.Codigo);
            return mascotaCreado;
        }

        public Mascota Obtener(string Codigo) {
            Mascota mascotaEncontrado = null;
            string sql = "SELECT * from mascota where idmascota= @codigo";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena)) {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con)) {
                    com.Parameters.Add(new SqlParameter("@codigo", Codigo));
                    using (SqlDataReader resultado = com.ExecuteReader()) {
                        if (resultado.Read())
                        {
                            mascotaEncontrado = new Mascota()
                            {
                                Codigo = (string)resultado["idmascota"],
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

        public Mascota Modificar(Mascota mascotaModificar) {
            Mascota mascotaModificado = null;
            string sql = "Update  mascota set nombre = @nombre, set ape_pat = @ape_pat, set ape_mat = @ape_mat, set raza = @raza, set edad = @edad, set peso = @peso where idmascota = @codigo";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@codigo", mascotaModificado.Codigo));
                    com.Parameters.Add(new SqlParameter("@nombre", mascotaModificado.Nombre));
                    com.Parameters.Add(new SqlParameter("@ape_pat", mascotaModificado.Ape_Pat));
                    com.Parameters.Add(new SqlParameter("@ape_mat", mascotaModificado.Ape_Mat));
                    com.Parameters.Add(new SqlParameter("@raza", mascotaModificado.Raza));
                    com.Parameters.Add(new SqlParameter("@edad", mascotaModificado.Edad));
                    com.Parameters.Add(new SqlParameter("@peso", mascotaModificado.Peso));
                    com.ExecuteNonQuery();
                }
            }
            mascotaModificado = Obtener(mascotaModificado.Codigo);
            return mascotaModificado;
        }
        public void Eliminar(Mascota mascotaEliminar) {
            Mascota mascotaEliminado = null;
            string sql = "Delete  mascota where idmascota = @codigo";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@codigo", mascotaEliminado.Codigo));
                    com.ExecuteNonQuery();
                }
            }
            //mascotaEliminado = Obtener(mascotaEliminado.Codigo);
            //return mascotaEliminado;
        }

        public List<Mascota> ListarTodos() {
            return null;
        }
    }
        
}
