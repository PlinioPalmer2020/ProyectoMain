using ProyectoMain.Inventario.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
//using System.Drawing;
using System.Drawing.Printing;

namespace ProyectoMain.Fractura.Forms
{
    public partial class FrmMenuFactura : Form
    {
        Inventario.Negocio.InventarioNegocio _inventarioNegocio;
        Negocio_Data.NegocioFactura _negocioFactura;
        List<Inventario.Entidades.Inventario> _detallesfactura;
        private List<Entidades.Factura> _imprimir;
        public string Login = string.Empty;
        public FrmMenuFactura()
        {
            InitializeComponent();
            _inventarioNegocio = new Inventario.Negocio.InventarioNegocio();
            _detallesfactura = new List<Inventario.Entidades.Inventario>();
            _negocioFactura = new Negocio_Data.NegocioFactura();
            _imprimir = new List<Entidades.Factura>();


            cbTipoFactura.Items.Add("Descontado");
            cbTipoFactura.Items.Add("Crédito");
            cbTipoFactura.Items.Add("Cotización");
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
            else if (Login == "mixto")
            {
                btnSalir.Visible = false;
                btnCaja.Visible = true;
            }
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
                dgvDetalles.Rows.Add(item.Codigo.ToString(), item.Nombre.ToString() + " " + item.descripcion.ToString(), item.Precio.ToString("##,#.##"), item.Cantidad.ToString(), item.unidad, (Convert.ToDouble(item.Precio) * item.Cantidad).ToString("##,#.##"), item.Tipo_de_producto);
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
            lblTotal.Text = "0";
            txtTelefono.Text = string.Empty;
        }
        private void GenerarFactura(Entidades.Factura factura, int secuencia = 0)
        {
            _negocioFactura.InsentarFactura(factura, secuencia);

        }
        #endregion

        #region Botones
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            // Inicio de la Generar Contizacion
            if (cbTipoFactura.SelectedItem.ToString() == "Cotización")
            {
                DialogResult dr = MessageBox.Show("¿Estas Seguro?", "Aviso De Generar Cotización", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    DateTime hoy = DateTime.Now;
                    Inventario.Entidades.Inventario inventario = new Inventario.Entidades.Inventario();
                    foreach (var item in _detallesfactura)
                    {
                        Entidades.Factura factura = new Entidades.Factura();
                        factura.NameCliente = txtNombreCliente.Text;
                        factura.Telefono = txtTelefono.Text;
                        factura.Cedula = txtDireccion.Text;
                        factura.Codigo = item.Codigo;
                        factura.Tipo_De_Producto = item.Tipo_de_producto;
                        factura.Producto = item.Nombre;
                        factura.Descripción = item.descripcion;
                        factura.Precio = decimal.Parse(item.Precio.ToString());
                        factura.Cantidad = double.Parse(item.Cantidad.ToString());
                        factura.Unidad = item.unidad;
                        factura.PrecioTotal = decimal.Parse(item.Precio.ToString()) * decimal.Parse(item.Cantidad.ToString());
                        factura.Tipofactura = cbTipoFactura.SelectedIndex;// int.Parse(cbTipoFactura.SelectedValue.ToString());
                        factura.Fecha_crear = hoy;
                        factura.Pago = 0;

                        inventario.Cantidad = double.Parse(item.Cantidad.ToString());
                        inventario.Codigo = item.Codigo;

                        _imprimir.Add(factura);
                    }

                    MessageBox.Show("Cotización Generada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //DialogResult dr = MessageBox.Show("¿Incluir RNC?","Aviso",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    //RNC = dr == DialogResult.Yes ? "00445516156" : string.Empty;

                    printDocument1 = new PrintDocument();
                    PrinterSettings ps = new PrinterSettings();
                    printDocument1.PrinterSettings = ps;
                    printDocument1.PrintPage += imprimir;
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.ShowDialog();
                    //printDocument1.Print();

                    _imprimir.Clear();
                    LimpiarForms();
                    dgvDetalles.Rows.Clear();
                    _detallesfactura.Clear();
                    gridInventario.Rows.Clear();
                    CargarDatos(txtBuscar.Text);

                }
            }
           
           // Inicio de Generar Factura
           else
            {
                DialogResult dr = MessageBox.Show("¿Estas Seguro?", "Aviso De Generar Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    DateTime hoy = DateTime.Now;
                    Inventario.Entidades.Inventario inventario = new Inventario.Entidades.Inventario();
                    Entidades.Factura factura = new Entidades.Factura();
                    int i = 0;
                    foreach (var item in _detallesfactura)
                    {
                        factura.NameCliente = txtNombreCliente.Text;
                        factura.Telefono = txtTelefono.Text;
                        factura.Cedula = txtDireccion.Text;
                        factura.Codigo = item.Codigo;
                        factura.Tipo_De_Producto = item.Tipo_de_producto;
                        factura.Producto = item.Nombre;
                        factura.Descripción = item.descripcion;
                        factura.Precio = decimal.Parse(item.Precio.ToString());
                        factura.Cantidad = double.Parse(item.Cantidad.ToString());
                        factura.Unidad = item.unidad;
                        factura.PrecioTotal = decimal.Parse(item.Precio.ToString()) * decimal.Parse(item.Cantidad.ToString());
                        factura.Tipofactura = cbTipoFactura.SelectedIndex;// int.Parse(cbTipoFactura.SelectedValue.ToString());
                        factura.Fecha_crear = hoy;
                        factura.Pago = 0;

                        inventario.Cantidad = double.Parse(item.Cantidad.ToString());
                        inventario.Codigo = item.Codigo;

                        GenerarFactura(factura, i);
                        i = 1;
                        // ReducirInventario(inventario);

                    }
                    LimpiarForms();
                    MessageBox.Show("Factura Generada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDetalles.Rows.Clear();
                    _detallesfactura.Clear();
                    gridInventario.Rows.Clear();
                    CargarDatos(txtBuscar.Text);

                }
            }

        }

        private void imprimir(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 5, FontStyle.Bold, GraphicsUnit.Point);
            Font fonttitulo = new Font("Arial", 15, FontStyle.Bold, GraphicsUnit.Point);

            int y = 20;
            int aux5 = 0;

            // cabezado

            e.Graphics.DrawString("Agro Ferreteria J.S", fonttitulo, Brushes.Black, new RectangleF(70, y, 250, 50));
            e.Graphics.DrawString("Carr. Haras Nacionales", font, Brushes.Black, new RectangleF(90, y += 25, 150, 20));
            e.Graphics.DrawString("(El Jobo)  Sto. Dgo. Norte, R.D", font, Brushes.Black, new RectangleF(90, y += 15, 200, 20));
            e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
            e.Graphics.DrawString("Tel.:809-368-9406", font, Brushes.Black, new RectangleF(0, y += 15, 200, 20));
            e.Graphics.DrawString("Cel.:809-782-5547", font, Brushes.Black, new RectangleF(0, y += 15, 200, 20));
            e.Graphics.DrawString("        809-838-6999", font, Brushes.Black, new RectangleF(0, y += 15, 200, 20));
            e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
            e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
            foreach (var item in _imprimir)
            {
                e.Graphics.DrawString("Factura No.: " + item.Codigofactura, font, Brushes.Black, new RectangleF(0, y += 20, 200, 20));
                // e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
                e.Graphics.DrawString("Cliente: " + item.NameCliente, font, Brushes.Black, new RectangleF(0, y += 20, 200, 20));
                // e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
                e.Graphics.DrawString("Direccion: " + item.Cedula, font, Brushes.Black, new RectangleF(0, y += 20, 200, 20));
                e.Graphics.DrawString("Telefono: " + item.Telefono, font, Brushes.Black, new RectangleF(0, y += 20, 200, 20));
                // e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
                e.Graphics.DrawString("Fecha de creacion: " + item.Fecha_crear, font, Brushes.Black, new RectangleF(0, y += 20, 200, 40));
                //e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
                //e.Graphics.DrawString("RNC: " + RNC, font, Brushes.Black, new RectangleF(0, y += 20, 200, 40));
                e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
                //aqui va un switch para el nombre del tipo de factura
                switch (item.Tipofactura)
                {
                    case 0:
                        //  e.Graphics.DrawString("Tipo de Factura: Descontado", font, Brushes.Black, new RectangleF(0, y += 20, 150, 20));
                        aux5 = 0;
                        break;
                    case 1:
                        //  e.Graphics.DrawString("Tipo de Factura: Crédito", font, Brushes.Black, new RectangleF(0, y += 20, 150, 20));
                        aux5 = 1;
                        break;
                    /* case 2:
                         e.Graphics.DrawString("Tipo de Factura: Envio", font, Brushes.Black, new RectangleF(0, y += 20, 150, 20));
                         break;*/
                    default:
                        break;
                }
                break;
            }

            //var tipo = aux5 == 0 ? "DESCONTADO" : "CRÉDITO";
            // Cuerpo

            e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 200));
            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------", font, Brushes.Black, new RectangleF(0, y += 20, 400, 20));
            e.Graphics.DrawString("   COTIZACIÓN", font, Brushes.Black, new RectangleF(115, y += 20, 150, 20));
            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------", font, Brushes.Black, new RectangleF(0, y += 20, 400, 20));
            e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));


            e.Graphics.DrawString("CODIGO", font, Brushes.Black, new RectangleF(0, y, 150, 20));
            e.Graphics.DrawString("DESCRIPCION", font, Brushes.Black, new RectangleF(75, y, 150, 20));
            e.Graphics.DrawString("CANTIDAD", font, Brushes.Black, new RectangleF(150, y, 150, 20));
            e.Graphics.DrawString("PRECIO", font, Brushes.Black, new RectangleF(200, y, 150, 20));
            e.Graphics.DrawString("TOTAL", font, Brushes.Black, new RectangleF(250, y, 150, 20));

            foreach (var item in _imprimir)
            {
                e.Graphics.DrawString(item.Codigo, font, Brushes.Black, new RectangleF(0, y += 20, 50, 50));
                e.Graphics.DrawString(item.Descripción, font, Brushes.Black, new RectangleF(75, y, 50, 200));
                e.Graphics.DrawString(item.Cantidad.ToString() + " " + item.Unidad, font, Brushes.Black, new RectangleF(150, y, 100, 20));
                e.Graphics.DrawString(item.Precio.ToString(), font, Brushes.Black, new RectangleF(200, y, 100, 20));
                e.Graphics.DrawString(item.PrecioTotal.ToString(), font, Brushes.Black, new RectangleF(250, y, 100, 20));
                e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
            }
            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------", font, Brushes.Black, new RectangleF(0, y += 20, 400, 20));
            e.Graphics.DrawString("Precio Total: " + lblTotal.Text, font, Brushes.Black, new RectangleF(250, y += 20, 400, 20));
            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------", font, Brushes.Black, new RectangleF(0, y += 20, 400, 20));

            e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
            e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
            if (aux5 == 1)
            {
                e.Graphics.DrawString("Entregado por", font, Brushes.Black, new RectangleF(50, y, 150, 20));
                e.Graphics.DrawString("-----------------", font, Brushes.Black, new RectangleF(50, y += 20, 150, 20));
                e.Graphics.DrawString("Recibido Por", font, Brushes.Black, new RectangleF(220, y -= 20, 150, 20));
                e.Graphics.DrawString("-----------------", font, Brushes.Black, new RectangleF(220, y += 20, 150, 20));
            }
            e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
            e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
            e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
            e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
            e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
            //e.Graphics.DrawString("-------------------------FINAL DE LA FACTURA---------------------------------------", font, Brushes.Black, new RectangleF(0, y += 20, 400, 20));

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
                    decimal total = 0;
                    foreach (var item in _detallesfactura)
                    {
                        dgvDetalles.Rows.Add(item.Codigo.ToString(), item.Nombre.ToString(), item.descripcion.ToString(), item.Precio.ToString("##,#.##"), item.Cantidad.ToString(), (Convert.ToDouble(item.Precio) * item.Cantidad).ToString()).ToString("##,#.##");
                        total += (item.Precio * Convert.ToDecimal(item.Cantidad));
                        lblTotal.Text = total.ToString("##,#.##");
                    }
                    if (_detallesfactura.Count == 0)
                    {
                        lblTotal.Text = "0";
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
                        MessageBox.Show("¡No queda en el Inventario!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            gridInventario.Rows.Clear();
            CargarDatos(txtBuscar.Text);
        }

        private void cbTipoFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbTipoFactura.SelectedItem.ToString())
            {
                case "Cotización":
                    btnGenerar.Text = "Generar Cotizacion";
                    break;
                default:
                    btnGenerar.Text = "Generar Facturar";
                    break;
            }
        }
    }
}
