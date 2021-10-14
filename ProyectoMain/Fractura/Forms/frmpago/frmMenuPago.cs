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

        public void cargarFacturas()
        {
            List<Entidades.Factura> factura = new List<Entidades.Factura>();

            dgvFacturas.Rows.Clear();
            factura = _negocioFactura.TenerFactura();
            string aux = string.Empty;

            dgvFacturas.Rows.Clear();
            foreach (var item in factura)
            {
                if (aux != item.Codigofactura)
                {
                    dgvFacturas.Rows.Add(item.Codigofactura, item.NameCliente, item.Tipofactura, item.Fecha_crear, item.Pago);

                    aux = item.Codigofactura;
                }
            }
        }

        private void frmMenuPago_Load(object sender, EventArgs e)
        {
            cargarFacturas();
        }

        private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewLinkCell cell = (DataGridViewLinkCell)dgvFacturas.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell.Value.ToString() == "Detalles")
                {
                    frmFacturaMostrar frmFacturaMostrar = new frmFacturaMostrar();
                    frmFacturaMostrar.cargarDatos(dgvFacturas.Rows[e.RowIndex].Cells[0].Value.ToString());
                    frmFacturaMostrar.btnPagar.Enabled = false;
                    frmFacturaMostrar.ShowDialog();
                }
                else if (cell.Value.ToString() == "Realizar Pago")
                {
                    if (Convert.ToInt32(dgvFacturas.Rows[e.RowIndex].Cells[4].Value.ToString()) != 1)
                    {
                        frmFacturaMostrar frmFacturaMostrar = new frmFacturaMostrar();
                        frmFacturaMostrar.cargarDatos(dgvFacturas.Rows[e.RowIndex].Cells[0].Value.ToString());
                        frmFacturaMostrar.volver = 1;
                        frmFacturaMostrar.ShowDialog(this);
                    }
                    else
                    {
                        MessageBox.Show("¡Esta Factura ha sido Pagada!","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void dgvFacturas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvFacturas.Columns[e.ColumnIndex].Name == "TipoFactura")
            {


                switch (Convert.ToInt32(e.Value))
                {
                    case 0:
                            e.Value = lista[0];
                        break;

                    case 1:
                        e.Value = lista[1];
                        break;

                    case 2:
                        e.Value = lista[2];
                        break;
                }
            }

            if (this.dgvFacturas.Columns[e.ColumnIndex].Name == "Pago" )
            {
                e.Value =  Convert.ToInt32(e.Value) == 0 ?  "Sin Pagar" : "Pagado";
                
            }
        }
    }
}
