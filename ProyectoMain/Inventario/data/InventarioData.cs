using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoMain.Inventario.data
{
    public class InventarioData
    {
        private SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Ferreteria;Data Source=DESKTOP-IV4HQSQ\\SQLEXPRESS");

        public List<Entidades.Inventario> TenerInventarios(string buscar = null) 
        {
            List<Entidades.Inventario> inventarios = new List<Entidades.Inventario>();
            try
            {
                conn.Open();
                string querry = @"select id, codigo, nombre, descripcion, precio, cantidad from inventario ";

                // SqlCommand command = new SqlCommand(querry, conn);
                SqlCommand command = new SqlCommand();

                if (!string.IsNullOrEmpty(buscar))
                {
                    querry += @"WHERE codigo LIKE @buscar OR nombre LIKE @buscar OR descripcion LIKE @buscar";
                    command.Parameters.Add(new SqlParameter("@buscar", $"%{buscar}%"));
                }

                command.CommandText = querry;
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    inventarios.Add(new Entidades.Inventario
                    {
                        Id = int.Parse(reader["id"].ToString()),
                        Codigo = reader["codigo"].ToString(),
                        Nombre = reader["nombre"].ToString(),
                        descripcion = reader["descripcion"].ToString(),
                        Precio = decimal.Parse(reader["precio"].ToString()),
                        Cantidad = int.Parse(reader["cantidad"].ToString())
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

            return inventarios;
        }
        public void InsentarInventario(Entidades.Inventario inventario)
        {
            try
            {
                conn.Open();
                string query = @" insert into inventario(codigo, nombre, descripcion, precio, cantidad) 
                                                        values(@codigo,@nombre,@descripcion,@precio,@cantidad) ";

                SqlParameter codigo = new SqlParameter("@codigo",inventario.Codigo);
               /* firstName.ParameterName = "@FirstName";
                firstName.Value = contact.FirstName;
                firstName.DbType = System.Data.DbType.String;*/

                SqlParameter nombre = new SqlParameter("@nombre", inventario.Nombre);
                SqlParameter descripcion = new SqlParameter("@descripcion", inventario.descripcion);
                SqlParameter precio = new SqlParameter("@precio", inventario.Precio);
                SqlParameter cantidad = new SqlParameter("@cantidad", inventario.Cantidad);

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(codigo);
                command.Parameters.Add(nombre);
                command.Parameters.Add(descripcion);
                command.Parameters.Add(precio);
                command.Parameters.Add(cantidad);

                command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public void ModificarInventario(Entidades.Inventario inventario)
        {
            try
            {
                conn.Open();
                String querry = @"update inventario 
                                  set  codigo = @codigo, 
                                       nombre = @nombre, 
                                       descripcion  = @descripcion,
                                       precio = @precio,
                                       cantidad = @cantidad
                                       where id = @id";

                SqlParameter Id = new SqlParameter("@id", inventario.Id);
                SqlParameter codigo = new SqlParameter("@codigo", inventario.Codigo);
                SqlParameter nombre = new SqlParameter("@nombre", inventario.Nombre);
                SqlParameter descripcion = new SqlParameter("@descripcion", inventario.descripcion);
                SqlParameter precio = new SqlParameter("@precio", inventario.Precio);
                SqlParameter cantidad = new SqlParameter("@cantidad", inventario.Cantidad);

                SqlCommand command = new SqlCommand(querry, conn);
                command.Parameters.Add(Id);
                command.Parameters.Add(codigo);
                command.Parameters.Add(nombre);
                command.Parameters.Add(descripcion);
                command.Parameters.Add(precio);
                command.Parameters.Add(cantidad);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
        }


        public void ReducirExistenciaInventario(Entidades.Inventario inventario)
        {
            try
            {
                conn.Open();
                String querry = @"update inventario 
                                  set  cantidad = cantidad - @cantidad
                                       where codigo = @codigo";


                SqlParameter codigo = new SqlParameter("@codigo", inventario.Codigo);
                SqlParameter cantidad = new SqlParameter("@cantidad", inventario.Cantidad);

                SqlCommand command = new SqlCommand(querry, conn);
                command.Parameters.Add(codigo);
                command.Parameters.Add(cantidad);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
        }
    }

}
