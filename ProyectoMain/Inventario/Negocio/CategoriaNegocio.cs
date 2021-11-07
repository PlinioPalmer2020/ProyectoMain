using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMain.Inventario.Negocio
{
    public class CategoriaNegocio
    {
        private data.CategoriaData _categoriaData;

        public CategoriaNegocio()
        {
            _categoriaData = new data.CategoriaData();
        }

        public List<Entidades.Categoria> TenerCategoria(string buscar = null)
        {
            return _categoriaData.TenerCategoria(buscar);
        }
    }
}
