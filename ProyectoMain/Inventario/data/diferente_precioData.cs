using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMain.Inventario.data
{
    public class diferente_precioData
    {
        // conexion de la laptop 
        //private SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Ferreteria;Data Source=DESKTOP-J8KTPBL\\SQLEXPRESS");

        //conexion mi casa
        private SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Ferreteria;Data Source=DESKTOP-IV4HQSQ\\SQLEXPRESS");

        //Conexion del negocio
        //private SqlConnection conn = new SqlConnection("Password=sinergit;Persist Security Info=True;User ID=sa;Initial Catalog=Ferreteria;Data Source=192.168.1.113");

        public void InsentarDiferente_precio(Entidades.Diferente_precio diferente_Precio)
        {
            try
            {
                conn.Open();
                string query = @" Insert into diferente_precio(codigo_producto_diferente, unidad_diferente, precio) values(@codigo_producto_diferente,@unidad_diferente,@precio) ";

                SqlParameter codigo_producto_diferente = new SqlParameter("@codigo_producto_diferente", diferente_Precio.codigo_producto_diferente);
                SqlParameter unidad_diferente = new SqlParameter("@unidad_diferente", diferente_Precio.unidad_diferente);
                SqlParameter precio = new SqlParameter("@precio", diferente_Precio.precio);



                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(codigo_producto_diferente);
                command.Parameters.Add(unidad_diferente);
                command.Parameters.Add(precio);


                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Entidades.Diferente_precio> TenerDiferente_precio(string buscar = null)
        {
            List<Entidades.Diferente_precio>  diferentes_precios = new List<Entidades.Diferente_precio>();
            try
            {
                conn.Open();
                string querry = @"Select id_diferente, codigo_producto_diferente, unidad_diferente, precio from diferente_precio  ";

                SqlCommand command = new SqlCommand();

                if (!string.IsNullOrEmpty(buscar))
                {
                    querry += @"WHERE id_diferente LIKE @buscar OR codigo_producto_diferente LIKE @buscar OR unidad_diferente LIKE @buscar ";
                    command.Parameters.Add(new SqlParameter("@buscar", $"%{buscar}%"));
                }

                command.CommandText = querry;
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    diferentes_precios.Add(new Entidades.Diferente_precio
                    {
                        id_diferente = int.Parse(reader["id_diferente"].ToString()),
                        codigo_producto_diferente = reader["codigo_producto_diferente"].ToString(),
                        unidad_diferente = reader["unidad_diferente"].ToString(),
                        precio = decimal.Parse(reader["precio"].ToString())

                    });
                }



            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return diferentes_precios;
        }

        public void ModificarDiferente_precio(Entidades.Diferente_precio diferente_Precio)
        {
            try
            {
                conn.Open();
                String querry = @"update diferente_precio 
                                  set codigo_producto_diferente = @codigo_producto_diferente, 
                                  unidad_diferente = @unidad_diferente, 
                                  precio = @precio 
                                  Where id_diferente = @id_diferente";

                SqlParameter @id_diferente = new SqlParameter("@id_diferente", diferente_Precio.id_diferente);
                SqlParameter codigo_producto_diferente = new SqlParameter("@codigo_producto_diferente", diferente_Precio.codigo_producto_diferente);
                SqlParameter unidad_diferente = new SqlParameter("@unidad_diferente", diferente_Precio.unidad_diferente);
                SqlParameter precio = new SqlParameter("@precio", diferente_Precio.precio);


                SqlCommand command = new SqlCommand(querry, conn);
                command.Parameters.Add(@id_diferente);
                command.Parameters.Add(codigo_producto_diferente);
                command.Parameters.Add(unidad_diferente);
                command.Parameters.Add(precio);


                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
        }

    }
}
