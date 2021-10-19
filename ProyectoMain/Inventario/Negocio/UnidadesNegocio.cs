using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMain.Inventario.Negocio
{
    public class UnidadesNegocio
    {
        private data.UnidadesData _unidadesData;

        public UnidadesNegocio()
        {
            _unidadesData = new data.UnidadesData();
        }

        public List<Entidades.Unidades> TenerUnidades()
        {
            return _unidadesData.TenerUnidades();
        }
    }
}
