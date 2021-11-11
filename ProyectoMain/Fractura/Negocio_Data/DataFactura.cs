using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ProyectoMain.Fractura.Negocio_Data
{
    public class DataFactura
    {
        // conexion de la laptop 
        //private SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Ferreteria;Data Source=DESKTOP-J8KTPBL\\SQLEXPRESS");

        //conexion mi casa
        private SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Ferreteria;Data Source=DESKTOP-IV4HQSQ\\SQLEXPRESS");

        //Conexion del negocio
        //private SqlConnection conn = new SqlConnection("Password=sinergit;Persist Security Info=True;User ID=sa;Initial Catalog=Ferreteria;Data Source=192.168.1.113");

        //private SqlConnection conn = new SqlConnection("Password=sinergit;Persist Security Info=True;User ID=sa;Initial Catalog=Ferreteria;Data Source=192.168.1.113");

        public void InsentarFactura(Entidades.Factura factura)
        {
            try
            {
                conn.Open();
                string query = @" insert into facturas(Codigofactura, NameCliente, Cedula, Codigo, Tipo_De_Producto, Producto, Descripción, Precio, Cantidad, unidad, PrecioTotal, Tipofactura, Fecha_crear, Pago) 
                                                        values(NEXT VALUE FOR codigoFactura,@NameCliente,@Cedula,@Codigo,@Tipo_De_Producto,@Producto,@Descripción,@Precio,@Cantidad,@unidad,@PrecioTotal,@Tipofactura,@Fecha_crear,@Pago) ";

               
                
                SqlParameter codigo = new SqlParameter("@Codigo", factura.Codigo);
                SqlParameter Tipo_De_Producto = new SqlParameter("@Tipo_De_Producto", factura.Tipo_De_Producto);
                SqlParameter nombre = new SqlParameter("@Producto", factura.Producto);
                SqlParameter descripcion = new SqlParameter("@Descripción", factura.Descripción);
                SqlParameter precio = new SqlParameter("@Precio", factura.Precio);
                SqlParameter cantidad = new SqlParameter("@Cantidad", factura.Cantidad);
                SqlParameter unidad = new SqlParameter("@unidad", factura.Unidad);


                SqlParameter nameCliente = new SqlParameter("@NameCliente", factura.NameCliente);
                SqlParameter cedula = new SqlParameter("@Cedula", factura.Cedula);
               // SqlParameter codigofactura = new SqlParameter("@Codigofactura", factura.Codigofactura);
                SqlParameter preciototal = new SqlParameter("@PrecioTotal", factura.PrecioTotal);
                SqlParameter tipofactura = new SqlParameter("@Tipofactura", factura.Tipofactura);
                SqlParameter fechaCrear = new SqlParameter("@Fecha_crear", factura.Fecha_crear);
                SqlParameter pago = new SqlParameter("@Pago", factura.Pago);

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(codigo);
                command.Parameters.Add(Tipo_De_Producto);
                command.Parameters.Add(nombre);
                command.Parameters.Add(descripcion);
                command.Parameters.Add(precio);
                command.Parameters.Add(cantidad);
                command.Parameters.Add(unidad);

                command.Parameters.Add(nameCliente);
                command.Parameters.Add(cedula);
                //command.Parameters.Add(codigofactura);
                command.Parameters.Add(preciototal);
                command.Parameters.Add(tipofactura);
                command.Parameters.Add(fechaCrear);
                command.Parameters.Add(pago);


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

        public List<Entidades.Factura> TenerFactura(string buscar = null)
        {
            List<Entidades.Factura> facturas = new List<Entidades.Factura>();
            try
            {
                conn.Open();
                string querry = @"select Codigofactura, NameCliente, Cedula, Codigo, Producto, Descripción, Precio, Cantidad, PrecioTotal, Tipofactura, Fecha_crear, Pago, Estado from facturas ";

                // SqlCommand command = new SqlCommand(querry, conn);
                SqlCommand command = new SqlCommand();

                if (!string.IsNullOrEmpty(buscar))
                {
                    //cambiar despues para el filtro, no tengo ganas ahora
                    querry += @" WHERE Codigo LIKE @buscar OR NameCliente LIKE @buscar OR Descripción LIKE @buscar OR Codigofactura LIKE @buscar";
                    command.Parameters.Add(new SqlParameter("@buscar", $"%{buscar}%"));
                }

                command.CommandText = querry;
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    facturas.Add(new Entidades.Factura
                    {
                        Codigofactura = reader["Codigofactura"].ToString(),
                        NameCliente   = reader["NameCliente"].ToString(),
                        Cedula        = reader["Cedula"].ToString(),
                        Codigo        = reader["Codigo"].ToString(),
                        Producto      = reader["Producto"].ToString(),
                        Descripción   = reader["Descripción"].ToString(),
                        Precio        = decimal.Parse(reader["Precio"].ToString()),
                        Cantidad      = double.Parse(reader["Cantidad"].ToString()),
                        PrecioTotal   = decimal.Parse(reader["PrecioTotal"].ToString()),
                        Tipofactura   = int.Parse(reader["Tipofactura"].ToString()),
                        Fecha_crear   = DateTime.Parse(reader["Fecha_crear"].ToString()),
                        Pago          = int.Parse(reader["Pago"].ToString()),
                        Estado        = int.Parse(reader["Estado"].ToString())
                       // Cantidad      = int.Parse(reader["Cantidad"].ToString()),

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

            return facturas;
        }

        public List<Entidades.Factura> TenerFacturaEspeficico(string buscar = null)
        {
            List<Entidades.Factura> facturas = new List<Entidades.Factura>();
            try
            {
                conn.Open();
                string querry = @"select Id, Codigofactura, NameCliente, Cedula, Codigo, Tipo_De_Producto ,Producto, Descripción, Precio, Cantidad, unidad, PrecioTotal, Tipofactura, Fecha_crear, Pago, Estado from facturas";

                // SqlCommand command = new SqlCommand(querry, conn);
                SqlCommand command = new SqlCommand();

                if (!string.IsNullOrEmpty(buscar))
                {
                    //cambiar despues para el filtro, no tengo ganas ahora
                    querry += @" WHERE Codigo LIKE @buscar OR NameCliente LIKE @buscar OR Descripción LIKE @buscar OR Codigofactura LIKE @buscar";
                    command.Parameters.Add(new SqlParameter("@buscar", $"{buscar}"));
                }

                command.CommandText = querry;
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    facturas.Add(new Entidades.Factura
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        Codigofactura = reader["Codigofactura"].ToString(),
                        NameCliente = reader["NameCliente"].ToString(),
                        Cedula = reader["Cedula"].ToString(),
                        Codigo = reader["Codigo"].ToString(),
                        Tipo_De_Producto = reader["Tipo_De_Producto"].ToString(),
                        Producto = reader["Producto"].ToString(),
                        Descripción = reader["Descripción"].ToString(),
                        Precio = decimal.Parse(reader["Precio"].ToString()),
                        Cantidad = double.Parse(reader["Cantidad"].ToString()),
                        Unidad = reader["unidad"].ToString(),
                        PrecioTotal = decimal.Parse(reader["PrecioTotal"].ToString()),
                        Tipofactura = int.Parse(reader["Tipofactura"].ToString()),
                        Fecha_crear = DateTime.Parse(reader["Fecha_crear"].ToString()),
                        Pago = int.Parse(reader["Pago"].ToString()),
                        Estado = int.Parse(reader["Estado"].ToString())
                        // Cantidad      = int.Parse(reader["Cantidad"].ToString()),

                    });
                }



            }
            catch (Exception)
            {

                // throw;
            }
            finally
            {
                conn.Close();
            }

            return facturas;
        }

        public void PagoRealizado(Entidades.Factura factura)
        {
            try
            {
                conn.Open();
                String querry = @"update facturas set Pago = 1 WHERE Codigofactura = @Codigofactura";

                SqlParameter codigo = new SqlParameter("@Codigofactura", factura.Codigofactura);

                SqlCommand command = new SqlCommand(querry, conn);

                command.Parameters.Add(codigo);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
        }

        public List<Entidades.Factura> TenerFacturafiltro(string buscar = null)
        {
            List<Entidades.Factura> facturas = new List<Entidades.Factura>();
            try
            {
                conn.Open();
                string querry = @"select Codigofactura, NameCliente, Cedula, Codigo, Producto, Descripción, Precio, Cantidad, PrecioTotal, Tipofactura, Fecha_crear, Pago from facturas";

                // SqlCommand command = new SqlCommand(querry, conn);
                SqlCommand command = new SqlCommand();

                if (!string.IsNullOrEmpty(buscar))
                {
                    //cambiar despues para el filtro, no tengo ganas ahora
                    querry += @" WHERE Codigo LIKE @buscar OR NameCliente LIKE @buscar OR Descripción LIKE @buscar OR Codigofactura LIKE @buscar";
                    command.Parameters.Add(new SqlParameter("@buscar", $"{buscar}"));
                }

                command.CommandText = querry;
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    facturas.Add(new Entidades.Factura
                    {
                        Codigofactura = reader["Codigofactura"].ToString(),
                        NameCliente = reader["NameCliente"].ToString(),
                        Cedula = reader["Cedula"].ToString(),
                        Codigo = reader["Codigo"].ToString(),
                        Producto = reader["Producto"].ToString(),
                        Descripción = reader["Descripción"].ToString(),
                        Precio = decimal.Parse(reader["Precio"].ToString()),
                        Cantidad = double.Parse(reader["Cantidad"].ToString()),
                        PrecioTotal = decimal.Parse(reader["PrecioTotal"].ToString()),
                        Tipofactura = int.Parse(reader["Tipofactura"].ToString()),
                        Fecha_crear = DateTime.Parse(reader["Fecha_crear"].ToString()),
                        Pago = int.Parse(reader["Pago"].ToString()),
                        // Cantidad      = int.Parse(reader["Cantidad"].ToString()),

                    });
                }



            }
            catch (Exception)
            {

                // throw;
            }
            finally
            {
                conn.Close();
            }

            return facturas;
        }

        public void ModificarDevolucion(Entidades.Factura factura)
        {
            try
            {
                conn.Open();
                String querry = @"update facturas 
                                  set Estado = 2
                                  Where Id = @Id";

                SqlParameter Id = new SqlParameter("@Id", factura.Id);
                //SqlParameter Estado = new SqlParameter("@estado", factura.Estado);
;


                SqlCommand command = new SqlCommand(querry, conn);
                command.Parameters.Add(Id);
               // command.Parameters.Add(Estado);

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
