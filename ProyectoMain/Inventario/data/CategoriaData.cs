using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProyectoMain.Inventario.data
{
    public class CategoriaData
    {
        // conexion de la laptop 
        //private SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Ferreteria;Data Source=DESKTOP-J8KTPBL\\SQLEXPRESS");

        //conexion mi casa
        private SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Ferreteria;Data Source=DESKTOP-IV4HQSQ\\SQLEXPRESS");

        //Conexion del negocio
        //private SqlConnection conn = new SqlConnection("Password=sinergit;Persist Security Info=True;User ID=sa;Initial Catalog=Ferreteria;Data Source=192.168.1.113");

        public List<Entidades.Categoria> TenerCategoria(string buscar = null)
        {
            List<Entidades.Categoria>  categorias = new List<Entidades.Categoria>();
            try
            {
                conn.Open();
                string querry = @"Select id_categoria, familia_categoria, nombre_categoria, estado_categoria from categoria ";

                // SqlCommand command = new SqlCommand(querry, conn);
                SqlCommand command = new SqlCommand();

                if (!string.IsNullOrEmpty(buscar))
                {
                    querry += @"WHERE id_categoria LIKE @buscar OR familia_categoria LIKE @buscar OR nombre_categoria LIKE @buscar OR estado_categoria LIKE @buscar";
                    command.Parameters.Add(new SqlParameter("@buscar", $"%{buscar}%"));
                }

                command.CommandText = querry;
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    categorias.Add(new Entidades.Categoria
                    {
                        id_categoria = int.Parse(reader["id_categoria"].ToString()),
                        familia_categoria = reader["familia_categoria"].ToString(),
                        nombre_categoria = reader["nombre_categoria"].ToString(),
                        estado_categoria = int.Parse(reader["estado_categoria"].ToString())

                    });
                }



            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return categorias;
        }

    }
}
