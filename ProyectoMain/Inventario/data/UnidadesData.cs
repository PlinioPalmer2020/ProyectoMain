using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace ProyectoMain.Inventario.data
{
    public class UnidadesData
    {
        private SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Ferreteria;Data Source=DESKTOP-1935SQ4\\SQLEXPRESS");

        public List<Entidades.Unidades> TenerUnidades()
        {
            List<Entidades.Unidades> Unidades = new List<Entidades.Unidades>();

            try
            {
                conn.Open();
                string querry = @"SELECT id, nombre, estado FROM unidades";

                SqlCommand command = new SqlCommand(querry,conn);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Unidades.Add(new Entidades.Unidades() 
                    {
                        id = int.Parse(reader["id"].ToString()),
                        nombre = reader["nombre"].ToString(),
                        estado = int.Parse(reader["estado"].ToString())
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

            return Unidades;
        }
    }
}
