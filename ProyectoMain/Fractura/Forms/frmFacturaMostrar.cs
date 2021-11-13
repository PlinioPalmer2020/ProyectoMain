using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace ProyectoMain.Fractura.Forms
{
    public partial class frmFacturaMostrar : Form
    {
        //capa de negocios
        private Negocio_Data.NegocioFactura _negocioFactura;
        private Inventario.Negocio.InventarioNegocio _inventarioNegocio;
        private Inventario.Negocio.Diferente_precioNegocio _diferente_PrecioNegocio;

        //Listas
        private List<Inventario.Entidades.Inventario> _inventarios;
        private List<Inventario.Entidades.Inventario> _inventariosAunmentar;
        private List<Entidades.Factura> _imprimir;
        private List<Inventario.Entidades.Diferente_precio> diferente_Precios;
        private List<Entidades.Factura> Devolucionfacturas;
        //private List<string> _inventarios;

        // Variables
        public int volver = 0;
        private decimal precioMaximo = 0;
        private string RNC = string.Empty;
        public string estado = string.Empty;
        private string pass = "1234";
        public frmFacturaMostrar()
        {
            InitializeComponent();
            // Capa de negocios
            _negocioFactura = new Negocio_Data.NegocioFactura();
            _inventarioNegocio = new Inventario.Negocio.InventarioNegocio();
            _diferente_PrecioNegocio = new Inventario.Negocio.Diferente_precioNegocio();

            Devolucionfacturas = new List<Entidades.Factura>();
            _inventariosAunmentar = new List<Inventario.Entidades.Inventario>();



            // List
            _inventarios = new List<Inventario.Entidades.Inventario>();
            _imprimir = new List<Entidades.Factura>();
            diferente_Precios = new List<Inventario.Entidades.Diferente_precio>();

            //_inventarios = new List<string>();
        }





        #region Funciones
        public void cargarDatos(string codigo)
        {

            List<Entidades.Factura> factura = new List<Entidades.Factura>();
            factura = _negocioFactura.TenerFacturaEspeficico(codigo);
            factura = factura.Where(f => f.Estado == 1 || f.Estado == 0).ToList();
            _imprimir = factura;
            if (factura != null)
            {
                decimal total = 0;
                int i = 0;
                foreach (var item in factura)
                {
                    if (i == 0)
                    {
                        lblCodigoFactura.Text = item.Codigofactura;
                        lblDireccion.Text = item.Cedula;
                        switch (item.Tipofactura)
                        {
                            case 0:
                                lblTipoFactura.Text = "Descontado";
                                break;
                            case 1:
                                lblTipoFactura.Text = "Crédito";
                                break;
                                /*case 2:
                                    lblTipoFactura.Text = "Envio";
                                    break;*/
                        }
                        lblNombreCliente.Text = item.NameCliente;
                        lblfechaCreacion.Text = item.Fecha_crear.ToString();
                    }

                    dgvFactura.Rows.Add(item.Codigo, item.Producto + " " + item.Descripción, item.Precio.ToString("##,#.##"), item.Cantidad, item.Unidad, item.PrecioTotal.ToString("##,#.##"));
                    Inventario.Entidades.Inventario auxInventario = new Inventario.Entidades.Inventario() { Codigo = item.Codigo, Cantidad = item.Cantidad, Tipo_de_producto = item.Tipo_De_Producto, unidad = item.Unidad };
                    _inventarios.Add(auxInventario);
                    lblTotal.Text = (total += item.PrecioTotal).ToString("##,#.##");
                }
            }
        }
        public void ReducirInventario(Inventario.Entidades.Inventario inventario)
        {
            _inventarioNegocio.ReducirExistenciaInventario(inventario);
        }

        public void AumentarInventario(Inventario.Entidades.Inventario inventario)
        {
            _inventarioNegocio.AumentarExistenciaInventario(inventario);
        }
        #endregion

        #region Botones
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //DialogResult dr = MessageBox.Show("¿Incluir RNC?","Aviso",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            //RNC = dr == DialogResult.Yes ? "00445516156" : string.Empty;

            printDocument1 = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printDocument1.PrinterSettings = ps;
            printDocument1.PrintPage += imprimir;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            //printDocument1.Print();
        }
        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (estado == "devolucion")
            {
                DialogResult dr = MessageBox.Show("¿Seguro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {//--------------

                    var contra = Interaction.InputBox("Ingrese Contraseña", "Devolucion", "*", 100, 0);
                    if (contra == pass)
                    {


                        foreach (var item3 in Devolucionfacturas)
                        {
                            _negocioFactura.ModificarDevolucion(item3);
                        }

                        foreach (var item in _inventariosAunmentar)
                        {
                            Inventario.Entidades.Inventario inventario = new Inventario.Entidades.Inventario() { Tipo_de_producto = item.Tipo_de_producto, Cantidad = item.Cantidad, Codigo = item.Codigo, unidad = item.unidad };
                            var a = _diferente_PrecioNegocio.TenerDiferente_precio(item.Codigo);
                            precioMaximo = 1;
                            foreach (var item2 in a)
                            {
                                precioMaximo = a.Count() == 0 ? 1 : item2.precio;
                                break;
                            }

                            foreach (var fac in _imprimir)
                            {
                                if (item.unidad == "Detallado")
                                {
                                    inventario.Cantidad = inventario.Cantidad / (double)precioMaximo;
                                }
                                else
                                {
                                    inventario.Cantidad = (double)fac.PrecioTotal / (double)precioMaximo;
                                }
                                break;
                            }
                            if (a.Count != 0)
                            {
                                AumentarInventario(inventario);
                            }
                        }

                        MessageBox.Show("Realizado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ((frmpago.frmMenuPago)this.Owner).cargarFacturas();
                            this.Close();
                        

                    }
                    else
                    {
                        MessageBox.Show("Error Contraseña Incorrecta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }//--------------
            }
            else
            {
                DialogResult dr = MessageBox.Show("¿Seguro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Entidades.Factura factura = new Entidades.Factura();
                    factura.Codigofactura = lblCodigoFactura.Text;
                    foreach (var item in _inventarios)
                    {
                        Inventario.Entidades.Inventario inventario = new Inventario.Entidades.Inventario() { Tipo_de_producto = item.Tipo_de_producto, Cantidad = item.Cantidad, Codigo = item.Codigo, unidad = item.unidad };
                        var a = _diferente_PrecioNegocio.TenerDiferente_precio(item.Codigo);
                        precioMaximo = 1;
                        foreach (var item2 in a)
                        {
                            precioMaximo = a.Count() == 0 ? 1 : item2.precio;
                            break;
                        }

                        foreach (var fac in _imprimir)
                        {
                            if (item.unidad == "Detallado")
                            {
                                inventario.Cantidad = inventario.Cantidad / (double)precioMaximo;
                            }
                            else
                            {
                                inventario.Cantidad = (double)fac.PrecioTotal / (double)precioMaximo;
                            }
                            break;
                        }
                        if (a.Count != 0)
                        {
                            ReducirInventario(inventario);
                        }
                    }
                    _negocioFactura.PagoRealizado(factura);
                    MessageBox.Show("¡Pago Realizado!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (volver == 1)
                    {
                        ((frmpago.frmMenuPago)this.Owner).cargarFacturas();
                    }

                    DialogResult dw = MessageBox.Show("¿Quieres Imprimir la Factura?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dw == DialogResult.Yes)
                    {
                        btnImprimir.PerformClick();
                        this.Close();

                    }
                    else
                    {
                        this.Close();
                    }

                }
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        #region funcion encargado de imprimir ticket
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
                // e.Graphics.DrawString("Telefono: "+item.Cedula, font, Brushes.Black, new RectangleF(0, y += 20, 200, 20));
                // e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
                e.Graphics.DrawString("Fecha de creacion: " + item.Fecha_crear, font, Brushes.Black, new RectangleF(0, y += 20, 200, 40));
                //e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
                e.Graphics.DrawString("RNC: " + RNC, font, Brushes.Black, new RectangleF(0, y += 20, 200, 40));
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

            var tipo = aux5 == 0 ? "DESCONTADO" : "CRÉDITO";
            // Cuerpo

            e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 200));
            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------", font, Brushes.Black, new RectangleF(0, y += 20, 400, 20));
            e.Graphics.DrawString("FACTURA " + tipo, font, Brushes.Black, new RectangleF(115, y += 20, 150, 20));
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
                e.Graphics.DrawString(item.Descripción, font, Brushes.Black, new RectangleF(75, y, 100, 100));
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




        #endregion

        private void frmFacturaMostrar_Load(object sender, EventArgs e)
        {
            if (estado == "devolucion")
            {
                DataGridViewLinkColumn devolver = new DataGridViewLinkColumn();
                devolver.HeaderText = "devolución";
                devolver.Name = "devolucion";
                devolver.Text = "devolución";
                devolver.UseColumnTextForLinkValue = true;
                devolver.Width = 100;
                dgvFactura.Columns.Add(devolver);

                btnPagar.Text = "Confirmar Devolucion";
                btnPagar.Enabled = true;

            }
        }

        private void dgvFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewLinkCell cell = (DataGridViewLinkCell)dgvFactura.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell.Value.ToString() == "devolución")
                {
                    var devolver = _imprimir.Where(d => d.Codigo == dgvFactura.Rows[e.RowIndex].Cells[0].Value.ToString()).ToList();
                    foreach (var item in devolver)
                    {
                        Devolucionfacturas.Add(item);
                        dgvFactura.CurrentRow.Cells["Descripcion"].Style.BackColor = Color.Red;
                        var Aunmentar = _inventarios.Where(i => i.Codigo == item.Codigo).ToList();
                        foreach (var item2 in Aunmentar)
                        {
                            _inventariosAunmentar.Add(item2);
                        }
                        // dgvFactura.Rows[e.RowIndex].Cells[0].Style.BackColor = Color.Red;
                    }
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }
    }
}
