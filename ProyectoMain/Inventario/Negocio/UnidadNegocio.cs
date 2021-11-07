using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMain.Inventario.Negocio
{
    public class UnidadNegocio
    {
        private data.UnidadData _unidadData;

        public UnidadNegocio()
        {
            _unidadData = new data.UnidadData();
        }

        public List<Entidades.Unidad> TenerUnidad(string buscar = null)
        {
            return _unidadData.TenerUnidad(buscar);
        }

    }
}
