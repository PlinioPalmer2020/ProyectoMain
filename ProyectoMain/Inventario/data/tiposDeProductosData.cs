using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMain.Inventario.data
{
    public class tiposDeProductosData
    {
        private SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Ferreteria;Data Source=DESKTOP-1935SQ4\\SQLEXPRESS"); 

        public List<Entidades.tiposDeProductos> TenerTiposDeProductos()
        {
            List<Entidades.tiposDeProductos> tiposDeProductos = new List<Entidades.tiposDeProductos>();

            try
            {
                conn.Open();
                string querry = @"select id, nombre, estado from tiposDeProductos";

                SqlCommand command = new SqlCommand(querry,conn);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    tiposDeProductos.Add(new Entidades.tiposDeProductos() 
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

            return tiposDeProductos;
        }
    }
}
