using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMain.Inventario.Negocio
{
    public class RegistroNegocio
    {
        private data.RegistroData _registroData;

        public RegistroNegocio()
        {
            _registroData = new data.RegistroData();
        }

        public List<Entidades.Registro> TenerRegistro(string buscar = null)
        {
            return _registroData.TenerRegistro(buscar);
        }
    }
}
