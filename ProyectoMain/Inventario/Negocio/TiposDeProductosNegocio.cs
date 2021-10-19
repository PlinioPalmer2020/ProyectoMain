using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMain.Inventario.Negocio
{
    public class TiposDeProductosNegocio
    {
        data.tiposDeProductosData _tiposDeProductosData;

        public TiposDeProductosNegocio()
        {
            _tiposDeProductosData = new data.tiposDeProductosData();
        }

        public List<Entidades.tiposDeProductos> TenerTiposDeProductos()
        {
            return _tiposDeProductosData.TenerTiposDeProductos();
        }
    }
}
