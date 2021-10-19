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
        tipoProducto int not null,
        nombre varchar(100) not null,
        descripcion varchar(100) not null,
        precioComprado decimal(18,2) not null,
        precioVendido decimal(18,2) not null,
        unidad varchar(30) not null,
        cantidad int not null
        */

        public int Id { get; set; }
        public string Codigo { get; set; }
        public int TipoProducto { get; set; }
        public string Nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precioComprado { get; set; }
        public decimal precioVendido { get; set; }
        public double Cantidad { get; set; }
        public int UnidadCantidad { get; set; }

        public double Contiene { get; set; }

        public int unidadContiene { get; set; }


    }
}
