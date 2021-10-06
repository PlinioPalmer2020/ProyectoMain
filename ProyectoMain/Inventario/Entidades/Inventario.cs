using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMain.Inventario.Entidades
{
    public class Inventario
    {
        /*
         id int identity(1,1),
        codigo varchar(100) not null,
        nombre varchar(100) not null,
        descripcion varchar(100) not null,
        precio decimal(6,2) not null,
        cantidad int not null
        */

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

    }
}
