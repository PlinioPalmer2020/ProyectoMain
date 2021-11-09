using ProyectoMain.Inventario.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMain.Fractura.Forms
{
    public partial class FrmMenuFactura : Form
    {
        Inventario.Negocio.InventarioNegocio _inventarioNegocio;
        Negocio_Data.NegocioFactura _negocioFactura;
        List<Inventario.Entidades.Inventario> _detallesfactura;
        public string Login = string.Empty; 
        public FrmMenuFactura()
        {
            InitializeComponent();
            _inventarioNegocio = new Inventario.Negocio.InventarioNegocio();
            _detallesfactura = new List<Inventario.Entidades.Inventario>();
            _negocioFactura = new Negocio_Data.NegocioFactura();


            cbTipoFactura.Items.Add("Normal");
            cbTipoFactura.Items.Add("Credito");
            cbTipoFactura.Items.Add("Envio");
            cbTipoFactura.SelectedIndex = 0;

        }

        private void FrmMenuFactura_Load(object sender, EventArgs e)
        {
            txtNombreCliente.Focus();
            CargarDatos(txtBuscar.Text);
            if (Login == "factura")
            {
                btnSalir.Visible = false;
                btnCaja.Visible = false;
            }
            else if(Login == "mixto")
            {
                btnSalir.Visible = false;
                btnCaja.Visible = true;
            }
        }
        private void cbTipoFactura_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        #region Funciones
        public void CargarDatos(string buscar)
        {
            // this.inventarioTableAdapter.Fill(this.ferreteriaDataSet1.inventario);
            botonValidos();
            var consulta = _inventarioNegocio.TenerInventarios(buscar);
            //var aux = consulta.Where( c=> c.Cantidad != 0 ).ToList();
            foreach (var item in consulta)
            {
                gridInventario.Rows.Add(item.Codigo, item.Nombre + " " + item.descripcion, item.Precio, item.Cantidad, item.unidad, item.Tipo_de_producto);
            }
        }
        private void botonValidos()
        {
            if (_detallesfactura.Count != 0)
            {
                btnGenerar.Enabled = true;
                btnLimpiar.Enabled = true;
            }
            else
            {
                btnGenerar.Enabled = false;
                btnLimpiar.Enabled = false;
            }
        }
        public void cargardetalles(Inventario.Entidades.Inventario inventario)
        {
            dgvDetalles.Rows.Clear();
            _detallesfactura.Add(inventario);
            decimal total = 0;
            foreach (var item in _detallesfactura)
            {
                dgvDetalles.Rows.Add(item.Codigo.ToString(), item.Nombre.ToString() + " " + item.descripcion.ToString(), item.Precio.ToString("##,#.##"), item.Cantidad.ToString(),item.unidad, (Convert.ToDouble(item.Precio) * item.Cantidad).ToString("##,#.##"), item.Tipo_de_producto);
                total += (item.Precio * Convert.ToDecimal(item.Cantidad));
                lblTotal.Text = total.ToString("##,#.##");
            }
            botonValidos();
        }
        private string generarCodigo()
        {
            DateTime fecha = DateTime.Now;

            //string codigo = "CDF" + fecha.ToString("dd") + fecha.ToString("MM") + fecha.ToString("yyyy") + fecha.ToString("hh") + fecha.ToString("mm") + fecha.ToString("ss") + fecha.ToString("ff");
            string codigo = "CDF" + fecha.ToString("yyyy") + fecha.ToString("hh") + fecha.ToString("mm") + fecha.ToString("ss");

            return codigo;
        }
        private void LimpiarForms()
        {
            txtNombreCliente.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            btnGenerar.Enabled = false;
            lblTotal.Text = string.Empty;
        }
        private void GenerarFactura(Entidades.Factura factura)
        {
            _negocioFactura.InsentarFactura(factura);

        }
        #endregion

        #region Botones
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            // int a = cbTipoFactura.SelectedIndex;
            DialogResult dr = MessageBox.Show("¿Estas Seguro?", "Aviso De Generar Factura", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                DateTime hoy = DateTime.Now;
                string codigoFactura = generarCodigo();
                Inventario.Entidades.Inventario inventario = new Inventario.Entidades.Inventario();
                Entidades.Factura factura = new Entidades.Factura();
                foreach (var item in _detallesfactura)
                {
                    factura.Codigofactura = codigoFactura;
                    factura.NameCliente = txtNombreCliente.Text;
                    factura.Cedula = txtDireccion.Text;
                    factura.Codigo = item.Codigo;
                    factura.Tipo_De_Producto = item.Tipo_de_producto;
                    factura.Producto = item.Nombre;
                    factura.Descripción = item.descripcion;
                    factura.Precio = decimal.Parse(item.Precio.ToString());
                    factura.Cantidad = double.Parse(item.Cantidad.ToString());
                    factura.Unidad = item.unidad;
                    factura.PrecioTotal =  decimal.Parse(item.Precio.ToString()) * decimal.Parse(item.Cantidad.ToString());
                    factura.Tipofactura = cbTipoFactura.SelectedIndex;// int.Parse(cbTipoFactura.SelectedValue.ToString());
                    factura.Fecha_crear = hoy;
                    factura.Pago = 0;

                    inventario.Cantidad = double.Parse(item.Cantidad.ToString());
                    inventario.Codigo = item.Codigo;

                    GenerarFactura(factura);
                   // ReducirInventario(inventario);

                }
                LimpiarForms();
                MessageBox.Show("Factura Generada","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
               // frmFacturaMostrar frmFacturaMostrar = new frmFacturaMostrar();
               // frmFacturaMostrar.ReducirInventario(inventario);
               // frmFacturaMostrar.cargarDatos(codigoFactura);
               // frmFacturaMostrar.ShowDialog(this);
                dgvDetalles.Rows.Clear();
                _detallesfactura.Clear();
                gridInventario.Rows.Clear();
                CargarDatos(txtBuscar.Text);

            }

        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Inventario.Forms.FormMenuInventario formMenuInventario = new FormMenuInventario();
            formMenuInventario.Show();
            this.Close();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            gridInventario.Rows.Clear();
            CargarDatos(txtBuscar.Text);
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarForms();
            dgvDetalles.Rows.Clear();
            _detallesfactura.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //((FormMenuInventario)this.Owner).Close();
        }
        #endregion

        #region DataGridViews
        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewLinkCell cell = (DataGridViewLinkCell)dgvDetalles.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value.ToString() == "Quitar")
                {
                    _detallesfactura.RemoveAt(e.RowIndex);
                    dgvDetalles.Rows.Clear();
                    foreach (var item in _detallesfactura)
                    {
                        dgvDetalles.Rows.Add(item.Codigo.ToString(), item.Nombre.ToString(), item.descripcion.ToString(), item.Precio.ToString("##,#.##"), item.Cantidad.ToString(), (Convert.ToDouble(item.Precio) * item.Cantidad).ToString()).ToString("##,#.##");
                    }
                    botonValidos();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // throw;
            }
        }
        private void gridInventario_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataGridViewLinkCell cell = (DataGridViewLinkCell)gridInventario.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell.Value.ToString() == "Agregar")
                {
                    if (Convert.ToString(gridInventario.Rows[e.RowIndex].Cells[3].Value) == "0")
                    {
                        MessageBox.Show("¡No queda en el Inventario!","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        frmdetallesfactura detallesfactura = new frmdetallesfactura();
                        detallesfactura.CargarInventario(new Inventario.Entidades.Inventario
                        {
                            // Id = int.Parse(gridInventario.Rows[e.RowIndex].Cells[0].Value.ToString()),
                            Codigo = gridInventario.Rows[e.RowIndex].Cells[0].Value.ToString(),
                            // Nombre = gridInventario.Rows[e.RowIndex].Cells[2].Value.ToString(),
                            descripcion = gridInventario.Rows[e.RowIndex].Cells[1].Value.ToString(),
                            Precio = decimal.Parse(gridInventario.Rows[e.RowIndex].Cells[2].Value.ToString()),
                            Cantidad = double.Parse(gridInventario.Rows[e.RowIndex].Cells[3].Value.ToString()),
                            unidad = gridInventario.Rows[e.RowIndex].Cells[4].Value.ToString(),
                            Tipo_de_producto = gridInventario.Rows[e.RowIndex].Cells[5].Value.ToString()
                        });

                       // detallesfactura.tipoProducto = gridInventario.Rows[e.RowIndex].Cells[5].Value.ToString();
                        detallesfactura.ShowDialog(this);

                    }
                }

            }
            catch (Exception)
            {

                //throw;
            }
        }
        private void gridInventario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //string v = this.gridInventario.Columns[e.ColumnIndex].Name;
            if (this.gridInventario.Columns[e.ColumnIndex].Name == "Canti")
            {
                if (Convert.ToInt32(e.Value) <= 10)
                {
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.BackColor = Color.FromArgb(249, 65, 68);
                }
                if (Convert.ToInt32(e.Value) <= 20 && Convert.ToInt32(e.Value) > 10)
                {
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.BackColor = Color.FromArgb(249, 199, 79);
                }
                if (Convert.ToInt32(e.Value) >= 21)
                {
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.BackColor = Color.FromArgb(67, 170, 139);
                }
            }
        }
        #endregion

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Login = string.Empty;
            this.Close();
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            frmpago.frmMenuPago frmMenuPago = new frmpago.frmMenuPago();
            if (Login == "mixto")
            {
                frmMenuPago.login = "mixto";
            }
            frmMenuPago.Show();
            this.Hide();
        }

        private void btnAgregarProductoNuevo_Click(object sender, EventArgs e)
        {
            frmdetallesfactura frmdetallesfactura = new frmdetallesfactura();
            frmdetallesfactura.genero = "generico";
            frmdetallesfactura.ShowDialog(this);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            btnBuscar.PerformClick();
        }
    }
}
