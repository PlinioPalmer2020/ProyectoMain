using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMain.Fractura.Entidades
{
    public class Factura
    {
        /*
         * id int identity(1,1),
            codigofactura varchar(100) not null,
            nameCliente varchar(100),
            Cedula varchar(20),
            Código varchar(100) not null,
            Producto varchar(100)not null,
            Descripción varchar(100) not null,
            Precio
            Tipofactura int not null,
            Fecha_crear datetime not null,
            Pago int not null,
            estado int not null default 1
         */

        public int Id { get; set; }
        public string Codigofactura { get; set; }
        public string NameCliente { get; set; }
        public string Cedula { get; set; } // Direccion

        public string Telefono { get; set; }
        public string Codigo { get; set; }
        public string Tipo_De_Producto { get; set; }
        public string Producto { get; set; }
        public string Descripción { get; set; }
        public decimal Precio { get; set; }

        public double Cantidad { get; set; }

        public string Unidad { get; set; }
        public decimal PrecioTotal {get; set; }
        public int Tipofactura { get; set; }
        public DateTime Fecha_crear { get; set; }
        public int Pago { get; set; }
        public int Estado { get; set; }

    }
}
