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
        // capa negocio
        private Negocio_Data.NegocioFactura _negocioFactura;

        //Listas
        private List<Entidades.Factura> globalfacturas;
        //Variables
        private List<string> lista;
        public string login = string.Empty;

        public frmMenuPago()
        {
            InitializeComponent();
            globalfacturas = new List<Entidades.Factura>();
            _negocioFactura = new Negocio_Data.NegocioFactura();

            lista = new List<string>(){"Normal","Credito","Envio", "Pendintes", "Pagados" };
            for (int i = 0; i <= 2; i++)
            {cbTipoPago.Items.Add(lista[i]);}
            for (int i = 3; i <= 4; i++)
            { cbPagoPendiente.Items.Add(lista[i]); }
            cbPagoPendiente.Items.Add("Todos");
            cbTipoPago.Items.Add("Todos");

            cbTipoPago.SelectedIndex = 3;
            cbPagoPendiente.SelectedIndex = 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inventario.Forms.FormMenuInventario formMenuInventario = new Inventario.Forms.FormMenuInventario();
            formMenuInventario.Show();
            this.Hide();
        }

        public void cargarFacturas()
        {
            List<Entidades.Factura> factura = new List<Entidades.Factura>();

            dgvFacturas.Rows.Clear();
            factura = _negocioFactura.TenerFactura();
            string aux = string.Empty;
            globalfacturas = factura;
            factura = factura.OrderByDescending(f => f.Fecha_crear).ToList();

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

        public void cargarFacturas(int x, int y)
        {
            List<Entidades.Factura> factura = new List<Entidades.Factura>();

            dgvFacturas.Rows.Clear();
            var factura1 = _negocioFactura.TenerFactura();

           /* if (x == 3 && y == 2)
            {
                cargarFacturas();
            }*/
          //  else
            if(x != 3 && y == 2) // sale  los tipo de los pagos que espesificas y salen todos los pagados y pediente
            {
                factura = factura1.Where(f => f.Tipofactura == x ).OrderByDescending(f => f.Fecha_crear).ToList();
            }
            else if (x == 3 && y != 2) // sale los pagados y pendiente que espesificas y sales todos los tipos 
            {
                factura = factura1.Where(f => f.Pago == y).OrderByDescending(f => f.Fecha_crear).ToList();

            }
            else
            {
                factura = factura1.Where(f => f.Tipofactura == x && f.Pago == y).OrderByDescending(f => f.Fecha_crear).ToList();
            }
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
            if (login == "caja" || login == "factura")
            {
                btnVolverFactura.Visible = false;
                button2.Visible = false;
            }
            else if(login == "mixto")
            {
                btnVolverFactura.Visible = true;
                button2.Visible = false;
            }
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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (cbTipoPago.SelectedIndex == 3 && cbPagoPendiente.SelectedIndex == 2 )
            {
                cargarFacturas();
            }
            else
            {
                cargarFacturas(cbTipoPago.SelectedIndex,cbPagoPendiente.SelectedIndex);
            }
        }

        private void frmMenuPago_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnVolverFactura_Click(object sender, EventArgs e)
        {
            FrmMenuFactura frmMenuFactura = new FrmMenuFactura();
            if (login == "mixto")
            {
                frmMenuFactura.Login = "mixto";
            }
            frmMenuFactura.Show();
            this.Show();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.login = string.Empty;
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var factura = globalfacturas;

            factura = factura.Where(f => f.NameCliente.ToLower().Contains(txtBuscar.Text.ToLower()) || f.Fecha_crear.ToString("dd/MM/yyyy").Contains(txtBuscar.Text) || f.Codigofactura.ToLower().Contains(txtBuscar.Text.ToLower())).OrderByDescending(f => f.Fecha_crear).ToList();

            string aux = string.Empty;

            dgvFacturas.Rows.Clear();
            if (txtBuscar.Text == string.Empty)
            {
                factura = globalfacturas;
            }

            foreach (var item in factura)
            {
                if (aux != item.Codigofactura)
                {
                    dgvFacturas.Rows.Add(item.Codigofactura, item.NameCliente, item.Tipofactura, item.Fecha_crear, item.Pago);

                    aux = item.Codigofactura;
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            btnBuscar.PerformClick();
        }
    }
}
