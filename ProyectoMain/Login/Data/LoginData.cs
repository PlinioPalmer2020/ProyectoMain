using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProyectoMain.Properties;
namespace ProyectoMain.Login.Data
{
    public class LoginData
    {
        // private SqlConnection conn = new SqlConnection(Settings.Default.Conecion2.ToString());
        //  private string a = Settings.Default.Conecion2.ToString();

        // conexion de la laptop 
        //private SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Ferreteria;Data Source=DESKTOP-J8KTPBL\\SQLEXPRESS");

        //conexion mi casa
        private SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Ferreteria;Data Source=DESKTOP-IV4HQSQ\\SQLEXPRESS");

        //Conexion del negocio
        //private SqlConnection conn = new SqlConnection("Password=sinergit;Persist Security Info=True;User ID=sa;Initial Catalog=Ferreteria;Data Source=192.168.1.113");

        public List<Entidad.Login> isLogin(string usuario, string contraseña)
        {
            List<Entidad.Login> logins = new List<Entidad.Login>();
            try
            {
                conn.Open();
                string querry = @"select id, usuario, contraseña, rol, estado from usuario where usuario = @usuario AND contraseña = @contraseña AND estado = 1";

                SqlCommand command = new SqlCommand(querry, conn );

                SqlParameter usua = new SqlParameter("@usuario", usuario);
                SqlParameter contr = new SqlParameter("@contraseña", contraseña);

                command.Parameters.Add(usua);
                command.Parameters.Add(contr);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    logins.Add( new Entidad.Login {
                    id = int.Parse(reader["id"].ToString()),
                    usuario = reader["usuario"].ToString(),
                    contraseña = reader["contraseña"].ToString(),
                    rol = reader["rol"].ToString(),
                    estado = int.Parse(reader["estado"].ToString())
                    });
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message,"Error",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally { conn.Close(); }

            return logins;
        }
    }
}
