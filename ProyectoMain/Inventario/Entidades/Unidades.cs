using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMain.Inventario.Entidades
{
    public class Unidades
    {
        /*
         id int identity(1,1),
        nombre varchar(30),
        estado bit not null default 1)
        */

        public int id { get; set; }
        public string nombre { get; set; }
        public int estado { get; set; }
    }
}
