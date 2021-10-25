using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMain.Inventario.Negocio
{
    public class InventarioNegocio
    {
        private data.InventarioData _inventarioData;

        public InventarioNegocio()
        {
            _inventarioData = new data.InventarioData();
        }

        public List<Entidades.Inventario> TenerInventarios(string buscartxt = null) 
        {
            return _inventarioData.TenerInventarios(buscartxt);
        }

        public Entidades.Inventario InsentarInventario(Entidades.Inventario inventario) 
        {
            if (inventario.Id == 0)
            {
                _inventarioData.InsentarInventario(inventario);
            }
            else
            {
                _inventarioData.ModificarInventario(inventario);
            }

            return inventario;
        }

        public void AñadirInventario(Entidades.Inventario inventario)
        {
            _inventarioData.AñadirInventario(inventario);
        }
        public void ReducirExistenciaInventario(Entidades.Inventario inventario)
        {
            _inventarioData.ReducirExistenciaInventario(inventario);
        }

        public void EliminarInventario(string codigo)
        {
            _inventarioData.EliminarInventario(codigo);
        }
    }
}
