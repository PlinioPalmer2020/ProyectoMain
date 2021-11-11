using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProyectoMain.Inventario.data
{
    public class RegistroData
    {
        // conexion de la laptop 
        //private SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Ferreteria;Data Source=DESKTOP-J8KTPBL\\SQLEXPRESS");

        //Negocio
        //private SqlConnection conn = new SqlConnection("Password=sinergit;Persist Security Info=True;User ID=sa;Initial Catalog=Ferreteria;Data Source=192.168.1.113");

        //conexion de mi casa
        private SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Ferreteria;Data Source=DESKTOP-IV4HQSQ\\SQLEXPRESS");
        public List<Entidades.Registro> TenerRegistro(string buscar = null)
        {
            List<Entidades.Registro> registros = new List<Entidades.Registro>();
            try
            {
                conn.Open();
                string querry = @"select id, codigo, tipo_de_producto, nombre, descripcion, precio, comprado, cantidad, unidad, fecha_entrada from registro_entrada ";

                // SqlCommand command = new SqlCommand(querry, conn);
                SqlCommand command = new SqlCommand();

                if (!string.IsNullOrEmpty(buscar))
                {
                    querry += @"WHERE codigo LIKE @buscar OR nombre LIKE @buscar OR descripcion LIKE @buscar OR tipo_de_producto LIKE @buscar";
                    command.Parameters.Add(new SqlParameter("@buscar", $"%{buscar}%"));
                }

                command.CommandText = querry;
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    registros.Add(new Entidades.Registro
                    {
                        id = int.Parse(reader["id"].ToString()),
                        codigo = reader["codigo"].ToString(),
                        tipo_de_producto = reader["tipo_de_producto"].ToString(),
                        nombre = reader["nombre"].ToString(),
                        descripcion = reader["descripcion"].ToString(),
                        precio = decimal.Parse(reader["precio"].ToString()),
                        comprado = decimal.Parse(reader["comprado"].ToString()),
                        cantidad = double.Parse(reader["cantidad"].ToString()),
                        unidad = reader["unidad"].ToString(),
                        fecha_entrada = DateTime.Parse( reader["fecha_entrada"].ToString()),
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

            return registros;
        }
    }
}
