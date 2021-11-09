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
        //conexion mi casa
        private SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Ferreteria;Data Source=DESKTOP-IV4HQSQ\\SQLEXPRESS");

        //Conexion del negocio
        //private SqlConnection conn = new SqlConnection("Password=sinergit;Persist Security Info=True;User ID=sa;Initial Catalog=Ferreteria;Data Source=192.168.1.113");

        public List<Entidades.Inventario> TenerInventarios(string buscar = null) 
        {
            List<Entidades.Inventario> inventarios = new List<Entidades.Inventario>();
            try
            {
                conn.Open();
                string querry = @"select id, codigo, nombre, descripcion, precio, cantidad, unidad, tipo_de_producto,comprado from inventario ";

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
                        Cantidad = double.Parse(reader["cantidad"].ToString()),
                        unidad = reader["unidad"].ToString(),
                        Tipo_de_producto = reader["tipo_de_producto"].ToString(),
                        comprado = decimal.Parse(reader["comprado"].ToString())
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
                string query = @" insert into inventario(codigo, tipo_de_producto, nombre, descripcion, comprado, precio, cantidad, unidad) 
                                                        values(@codigo,@tipo_de_producto,@nombre,@descripcion,@comprado,@precio,@cantidad,@unidad) ";

                SqlParameter codigo = new SqlParameter("@codigo",inventario.Codigo);
               /* firstName.ParameterName = "@FirstName";
                firstName.Value = contact.FirstName;
                firstName.DbType = System.Data.DbType.String;*/

                SqlParameter nombre = new SqlParameter("@nombre", inventario.Nombre);
                SqlParameter descripcion = new SqlParameter("@descripcion", inventario.descripcion);
                SqlParameter precio = new SqlParameter("@precio", inventario.Precio);
                SqlParameter cantidad = new SqlParameter("@cantidad", inventario.Cantidad);
                SqlParameter tipo_de_producto = new SqlParameter("@tipo_de_producto", inventario.Tipo_de_producto);
                SqlParameter comprado = new SqlParameter("@comprado", inventario.comprado);
                SqlParameter unidad = new SqlParameter("@unidad", inventario.unidad);


                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(codigo);
                command.Parameters.Add(nombre);
                command.Parameters.Add(descripcion);
                command.Parameters.Add(precio);
                command.Parameters.Add(cantidad);
                command.Parameters.Add(tipo_de_producto);
                command.Parameters.Add(comprado);
                command.Parameters.Add(unidad);

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
                                       cantidad = @cantidad,
                                       comprado = @comprado,
                                       unidad   = @unidad
                                       where id = @id";

                SqlParameter Id = new SqlParameter("@id", inventario.Id);
                SqlParameter codigo = new SqlParameter("@codigo", inventario.Codigo);
                SqlParameter nombre = new SqlParameter("@nombre", inventario.Nombre);
                SqlParameter descripcion = new SqlParameter("@descripcion", inventario.descripcion);
                SqlParameter precio = new SqlParameter("@precio", inventario.Precio);
                SqlParameter cantidad = new SqlParameter("@cantidad", inventario.Cantidad);
                SqlParameter comprado = new SqlParameter("@comprado", inventario.comprado);
                SqlParameter unidad = new SqlParameter("@unidad", inventario.unidad);

                SqlCommand command = new SqlCommand(querry, conn);
                command.Parameters.Add(Id);
                command.Parameters.Add(codigo);
                command.Parameters.Add(nombre);
                command.Parameters.Add(descripcion);
                command.Parameters.Add(precio);
                command.Parameters.Add(cantidad);
                command.Parameters.Add(comprado);
                command.Parameters.Add(unidad);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
        }

        public void AñadirInventario(Entidades.Inventario inventario)
        {
            try
            {
                conn.Open();
                String querry = @"update inventario 
                                  set  cantidad = cantidad + @cantidad
                                       where id = @id";

                SqlParameter cantidad = new SqlParameter("@cantidad", inventario.Cantidad);
                SqlParameter id = new SqlParameter("@id", inventario.Id);

                SqlCommand command = new SqlCommand(querry, conn);
                command.Parameters.Add(cantidad);
                command.Parameters.Add(id);

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

        public void AumentarExistenciaInventario(Entidades.Inventario inventario)
        {
            try
            {
                conn.Open();
                String querry = @"update inventario 
                                  set  cantidad = cantidad + @cantidad
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


        public void EliminarInventario(string codigo)
        {
            try
            {
                conn.Open();
                string query = @"DELETE FROM inventario WHERE codigo = @codigo";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(new SqlParameter("@codigo", codigo));

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
