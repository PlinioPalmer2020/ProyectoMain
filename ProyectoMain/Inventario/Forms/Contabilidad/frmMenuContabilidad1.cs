using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMain.Inventario.Forms.Contabilidad
{
    public partial class frmMenuContabilidad1 : Form
    {
        private Fractura.Negocio_Data.NegocioFactura _negocioFactura;
        private List<string> lista;
        private List<Fractura.Entidades.Factura> _facturas;

        public frmMenuContabilidad1()
        {
            InitializeComponent();
            _negocioFactura = new Fractura.Negocio_Data.NegocioFactura();
            _facturas = new List<Fractura.Entidades.Factura>();
            lista = new List<string>() { "Normal", "Credito", "Envio", "Pendintes", "Pagados" };

        }

        private void frmMenuContabilidad1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormMenuInventario formMenuInventario = new FormMenuInventario();
            formMenuInventario.Show();
            this.Hide();
        }


        public void cargarFacturas()
        {
            List<Fractura.Entidades.Factura> factura = new List<Fractura.Entidades.Factura>();

            dgvFacturas.Rows.Clear();
            factura = _negocioFactura.TenerFactura();
            _facturas = factura;
            string aux = string.Empty;

            dgvFacturas.Rows.Clear();
            int i = 1;
            foreach (var item in factura)
            {
                if (aux != item.Codigofactura && item.Estado != 2)
                {
                    var lista = _facturas.Where(f => f.Codigofactura == item.Codigofactura).ToList();
                    var total = lista.Sum(l => l.PrecioTotal);
                    dgvFacturas.Rows.Add(i,item.Codigofactura, item.NameCliente, item.Tipofactura, item.Fecha_crear,total.ToString("##,#.##"), item.Pago);
                    i++;
                    aux = item.Codigofactura;
                }
            }
        }

        private void Busqueda(string Buscar = null)
        {
            if (Buscar == null)
            {
                cargarFacturas();
            }
            else
            {
                var aux2 = _facturas.Where(f => f.Codigofactura.ToLower().Contains(Buscar.ToLower()) || f.NameCliente.ToLower().Contains(Buscar.ToLower())).ToList() ;
                //var aux2 = _facturas.Where(f => f.Codigofactura.ToUpper() == Buscar.ToUpper()).ToList();
                string aux = string.Empty;
                int i = 1;
                dgvFacturas.Rows.Clear();

                foreach (var item in aux2)
                {
                    if (aux != item.Codigofactura)
                    {
                        var lista = aux2.Where(f => f.Codigofactura == item.Codigofactura).ToList();
                        var total = lista.Sum(l => l.PrecioTotal);
                        //dgvFacturas.Rows.Add(i, item.Codigofactura, item.NameCliente, item.Tipofactura, item.Fecha_crear, item.Pago);
                        dgvFacturas.Rows.Add(i, item.Codigofactura, item.NameCliente, item.Tipofactura, item.Fecha_crear, total.ToString("##,#.##"), item.Pago);
                        i++;
                        aux = item.Codigofactura;
                    }
                }
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

            if (this.dgvFacturas.Columns[e.ColumnIndex].Name == "Pago")
            {
                e.Value = Convert.ToInt32(e.Value) == 0 ? "Sin Pagar" : "Pagado";

            }
        }

        private void frmMenuContabilidad1_Load(object sender, EventArgs e)
        {
            cargarFacturas();

           // var f = dtpFechaInicio.Value.ToString(); 

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Busqueda(txtBuscar.Text);
        }

        #region Reportes Rapidos
        private void CalcularVendaHoy()
        {
            decimal total = 0;
            List<Fractura.Entidades.Factura> aux = new List<Fractura.Entidades.Factura>();
            if (rbTodos.Checked == true)
            {
                 aux = _facturas.Where(f => f.Fecha_crear.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy") && f.Estado != 2).ToList();
            }
            else if (rbPagados.Checked == true)
            {
                 aux = _facturas.Where(f => f.Fecha_crear.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy") && f.Pago == 1 && f.Estado != 2).ToList();
            }
            else
            {
                 aux = _facturas.Where(f => f.Fecha_crear.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy") && f.Pago == 0 && f.Estado != 2).ToList();
            }
            foreach (var item in aux)
            {
                total += item.PrecioTotal;
            }
            if (total == 0)
            {
                MessageBox.Show("El total de la venta de Hoy Pagadas Son: RD$" + total.ToString() + " Pesos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
            else
            {
                MessageBox.Show("El total de la venta de Hoy Pagadas Son: RD$" + total.ToString("##,#.##") + " Pesos" ,"Información",MessageBoxButtons.OK,MessageBoxIcon.Information);;
            }
        }
        private void CalcularVendaAyer()
        {
            decimal total = 0;
            List<Fractura.Entidades.Factura> aux = new List<Fractura.Entidades.Factura>();

            if (rbTodos.Checked == true)
            {
                aux = _facturas.Where(f => f.Fecha_crear.ToString("dd/MM/yyyy") == DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy") && f.Estado != 2 ).ToList();
            }
            else if (rbPagados.Checked == true)
            {
                aux = _facturas.Where(f => f.Fecha_crear.ToString("dd/MM/yyyy") == DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy") && f.Pago == 1 && f.Estado != 2).ToList();
            }
            else
            {
                aux = _facturas.Where(f => f.Fecha_crear.ToString("dd/MM/yyyy") == DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy") && f.Pago == 0 && f.Estado != 2).ToList();
            }
            foreach (var item in aux)
            {
                total += item.PrecioTotal;
            }
            MessageBox.Show("El total de la venta de Ayer Pagadas Son: RD$" + total.ToString("##,#.##") + " Pesos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
        }

        private void CalcularVendaMes()
        {
            decimal total = 0;
            List<Fractura.Entidades.Factura> aux = new List<Fractura.Entidades.Factura>();

            if (rbTodos.Checked == true)
            {
                aux = _facturas.Where(f => f.Fecha_crear.ToString("MM/yyyy") == DateTime.Now.ToString("MM/yyyy") && f.Estado != 2).ToList();
            }
            else if (rbPagados.Checked == true)
            {
                aux = _facturas.Where(f => f.Fecha_crear.ToString("MM/yyyy") == DateTime.Now.ToString("MM/yyyy") && f.Pago == 1 && f.Estado != 2).ToList();
            }
            else
            {
                aux = _facturas.Where(f => f.Fecha_crear.ToString("MM/yyyy") == DateTime.Now.ToString("MM/yyyy") && f.Pago == 0 && f.Estado != 2).ToList();
            }
            foreach (var item in aux)
            {
                total += item.PrecioTotal;
            }
            MessageBox.Show("El total de la venta de estes Mes Pagadas Son: RD$" + total.ToString("##,#.##") + " Pesos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
        }


        #endregion

        #region Botones del los Reportes Rapidos
            private void btnHoy_Click(object sender, EventArgs e)
            {
                CalcularVendaHoy();
            }

            private void btnAyer_Click(object sender, EventArgs e)
            {
                CalcularVendaAyer();
            }

            private void btnMes_Click(object sender, EventArgs e)
            {
                CalcularVendaMes();
            }





        #endregion

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            btnBuscar.PerformClick();
        }

        private void btnBuscarFecha_Click(object sender, EventArgs e)
        {
            var aux2 = _facturas.Where(f => f.Fecha_crear.ToString("dd/MM/yyyy").Contains(dtpFechaInicio.Value.ToString("dd/MM/yyyy")) || f.Fecha_crear.ToString("dd/MM/yyyy").Contains(dtpFechaFinal.Value.ToString("dd/MM/yyyy"))).ToList();
            //&& f.Fecha_crear.ToString("dd/MM/yyyy") == dtpFechaFinal.Value.ToString("dd/MM/yyyy")
            string aux = string.Empty;
            int i = 1;
            dgvFacturas.Rows.Clear();

            foreach (var item in aux2)
            {
                if (aux != item.Codigofactura && item.Estado != 2)
                {
                    var lista = aux2.Where(f => f.Codigofactura == item.Codigofactura).ToList();
                    var total = lista.Sum(l => l.PrecioTotal);
                    dgvFacturas.Rows.Add(i, item.Codigofactura, item.NameCliente, item.Tipofactura, item.Fecha_crear, total.ToString("##,#.##"), item.Pago);

                    //dgvFacturas.Rows.Add(i, item.Codigofactura, item.NameCliente, item.Tipofactura, item.Fecha_crear, item.Pago);
                    i++;
                    aux = item.Codigofactura;
                }
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            cargarFacturas();
        }
    }
}
