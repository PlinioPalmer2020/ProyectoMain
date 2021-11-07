using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMain.Inventario.data
{
    public class UnidadData
    {
        //conexion mi casa
        private SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Ferreteria;Data Source=DESKTOP-IV4HQSQ\\SQLEXPRESS");

        //Conexion del negocio
        //private SqlConnection conn = new SqlConnection("Password=sinergit;Persist Security Info=True;User ID=sa;Initial Catalog=Ferreteria;Data Source=192.168.1.113");

        public List<Entidades.Unidad> TenerUnidad(string buscar = null)
        {
            List<Entidades.Unidad> unidades = new List<Entidades.Unidad>();
            try
            {
                conn.Open();
                string querry = @"select id_unidad, nombre_unidad, estado_unidad from unidad";

                // SqlCommand command = new SqlCommand(querry, conn);
                SqlCommand command = new SqlCommand();

                if (!string.IsNullOrEmpty(buscar))
                {
                    querry += @"WHERE id_unidad LIKE @buscar OR nombre_unidad LIKE @buscar OR estado_unidad LIKE @buscar ";
                    command.Parameters.Add(new SqlParameter("@buscar", $"%{buscar}%"));
                }

                command.CommandText = querry;
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    unidades.Add(new Entidades.Unidad
                    {
                        id_unidad = int.Parse(reader["id_unidad"].ToString()),
                        nombre_unidad = reader["nombre_unidad"].ToString(),
                        estado_unidad = int.Parse(reader["estado_unidad"].ToString())

                    });
                }



            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message, "Aviso", System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
            }

            return unidades;
        }



    }
}
