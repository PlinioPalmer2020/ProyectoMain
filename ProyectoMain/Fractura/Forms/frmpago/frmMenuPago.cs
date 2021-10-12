using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMain.Fractura.Forms.frmpago
{
    public partial class frmMenuPago : Form
    {
        private Negocio_Data.NegocioFactura _negocioFactura;
        private List<string> lista;
        public frmMenuPago()
        {
            InitializeComponent();
            _negocioFactura = new Negocio_Data.NegocioFactura();

            lista = new List<string>(){"Normal","Credito","Envio", "Pagados","Pendintes"};
            for (int i = 0; i <= 2; i++)
            {cbTipoPago.Items.Add(lista[i]);}
            for (int i = 3; i <= 4; i++)
            { cbPagoPendiente.Items.Add(lista[i]); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inventario.Forms.FormMenuInventario formMenuInventario = new Inventario.Forms.FormMenuInventario();
            formMenuInventario.Show();
            this.Close();
        }

        private void cargarFacturas()
        {
            List<Entidades.Factura> factura = new List<Entidades.Factura>();

            factura = _negocioFactura.TenerFactura();

            dgvFacturas.Rows.Clear();
            foreach (var item in factura)
            {
                dgvFacturas.Rows.Add(item.Codigofactura, item.NameCliente, item.Cedula,item.Codigo, item.Producto +"  "+ item.Descripción,item.Precio,item.Cantidad,item.PrecioTotal,item.Tipofactura,item.Fecha_crear,item.Pago);
            }
        }

        private void frmMenuPago_Load(object sender, EventArgs e)
        {
            cargarFacturas();
        }
    }
}
