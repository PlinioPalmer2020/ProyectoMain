using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMain.Login.Entidad
{
    public class Login
    {
        /*
         * create table usuario
            (
            id int identity(1,1),
            usuario varchar(100) not null,
            contraseña varchar(100) not null,
            rol varchar(50) not null,
            estado int default 1 not null 
            )
         */

        public int id { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public string rol { get; set; }
        public int estado { get; set; }

    }
}
