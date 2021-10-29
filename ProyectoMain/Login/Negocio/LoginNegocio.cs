using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMain.Login.Negocio
{
    public class LoginNegocio
    {
        private Data.LoginData _loginData;

        public LoginNegocio()
        {
            _loginData = new Data.LoginData();
        }

        public List<Entidad.Login> isLogin(string usuario, string contraseña)
        {
            return _loginData.isLogin(usuario,contraseña);
        }
    }
}
