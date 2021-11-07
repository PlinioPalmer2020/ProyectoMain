using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMain.Inventario.Entidades
{
    public class Unidad
    {
        /*
         * Id_unidad
            Nombre_unidad
            Estado_unidad

         */

        public int id_unidad { get; set; }
        public string nombre_unidad { get; set; }

        public int estado_unidad { get; set; }
    }
}
