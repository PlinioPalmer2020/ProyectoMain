using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMain.Inventario.Entidades
{
    public class tiposDeProductos
    {
        /*
         * id int identity(1,1),
            nombre varchar(30) not null,
            estado bit not null default 1
        */

        public int id { get; set; }

        public string nombre { get; set; }
        public int estado { get; set; }
    }
}
