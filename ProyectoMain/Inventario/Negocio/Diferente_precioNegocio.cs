using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMain.Inventario.Negocio
{
    public class Diferente_precioNegocio
    {
        private data.diferente_precioData _diferente_PrecioData;

        public Diferente_precioNegocio()
        {
            _diferente_PrecioData = new data.diferente_precioData();
        }

        public void InsentarDiferente_precio(Entidades.Diferente_precio diferente_Precio)
        {
            _diferente_PrecioData.InsentarDiferente_precio(diferente_Precio);
        }

        public List<Entidades.Diferente_precio> TenerDiferente_precio(string buscar = null)
        {
            return _diferente_PrecioData.TenerDiferente_precio(buscar);
        }
    }
}
