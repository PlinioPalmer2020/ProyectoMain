using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMain.Inventario.Entidades
{
    public class Categoria
    {
        /*
         * 
         * id_categoria int identity(1,1),
            familia_categoria varchar(50) not null,
            nombre_categoria varchar(50) not null,
            estado_categoria bit default 1
         * 
         * 
         */

        public int id_categoria { get; set; }
        public string familia_categoria { get; set; }
        public string nombre_categoria { get; set; }

        public int estado_categoria { get; set; }

    }
}
