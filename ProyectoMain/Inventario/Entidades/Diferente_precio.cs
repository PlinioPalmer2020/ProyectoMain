using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMain.Inventario.Entidades
{
    public class Diferente_precio
    {
        /*
         * id_diferente int identity(1,1),
            codigo_producto_diferente varchar(50),
            unidad_diferente varchar(50),
            precio decimal(18,2)
         */

        public int id_diferente { get; set; }
        public string codigo_producto_diferente { get; set; }
        public string unidad_diferente { get; set; }
        public decimal precio { get; set; }
 
    }
}
