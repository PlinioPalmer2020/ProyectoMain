using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMain.Fractura.Negocio_Data
{
    public class NegocioFactura
    {
        private DataFactura _dataFactura;

        public NegocioFactura()
        {
            _dataFactura = new DataFactura();
        }

        public void InsentarFactura(Entidades.Factura factura, int secuencia = 0)
        {
            _dataFactura.InsentarFactura(factura,secuencia);
        }

        public List<Entidades.Factura> TenerFactura(string buscar = null)
        {
           return _dataFactura.TenerFactura(buscar);
        }

        public List<Entidades.Factura> TenerFacturaEspeficico(string buscar = null)
        {
            return _dataFactura.TenerFacturaEspeficico(buscar);
        }

        public void PagoRealizado(Entidades.Factura factura)
        {
            _dataFactura.PagoRealizado(factura);
        }

        public void ModificarDevolucion(Entidades.Factura factura)
        {
            _dataFactura.ModificarDevolucion(factura);
        }

    }
}
