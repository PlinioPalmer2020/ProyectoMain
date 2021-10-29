using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMain.Inventario.Entidades
{
    public class Registro
    {

        /*
         * id int identity(1,1),
            codigo varchar(100) not null,
            tipo_de_producto varchar(30) not null,
            nombre varchar(100) not null,
            descripcion varchar(100) not null,
            precio decimal(18,2) not null,
            comprado decimal(18,2) not null,
            cantidad real not null,
            unidad varchar(30) not null,
            fecha_entrada Datetime not null,
         */

        public int id { get; set; }
        public string codigo { get; set; }
        public string tipo_de_producto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public decimal comprado { get; set; }
        public double cantidad { get; set; }
        public string unidad { get; set; }
        public DateTime fecha_entrada { get; set; }
    }
}
