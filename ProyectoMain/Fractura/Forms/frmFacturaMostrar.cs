using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMain.Fractura.Forms
{
    public partial class frmFacturaMostrar : Form
    {
        private Negocio_Data.NegocioFactura _negocioFactura;
        private Inventario.Negocio.InventarioNegocio _inventarioNegocio;
        private List<Inventario.Entidades.Inventario> _inventarios;
        private List<Entidades.Factura> _imprimir;
        //private List<string> _inventarios;
        public int volver = 0;
        public frmFacturaMostrar()
        {
            InitializeComponent();
            _negocioFactura = new Negocio_Data.NegocioFactura();
            _inventarioNegocio = new Inventario.Negocio.InventarioNegocio();
            _inventarios = new List<Inventario.Entidades.Inventario>();
            _imprimir = new List<Entidades.Factura>();
            //_inventarios = new List<string>();
        }

        public void cargarDatos(string codigo) 
        {

            List<Entidades.Factura> factura = new List<Entidades.Factura>();
            factura = _negocioFactura.TenerFacturaEspeficico(codigo);
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
                                lblTipoFactura.Text = "Normal";
                                break;
                            case 1:
                                lblTipoFactura.Text = "Credito";
                                break;
                            case 2:
                                lblTipoFactura.Text = "Envio";
                                break;
                        }
                        lblNombreCliente.Text = item.NameCliente;
                        lblfechaCreacion.Text = item.Fecha_crear.ToString();
                    }

                    dgvFactura.Rows.Add(item.Codigo, item.Producto+" "+item.Descripción, item.Precio, item.Cantidad, item.Unidad ,item.PrecioTotal);
                    Inventario.Entidades.Inventario auxInventario = new Inventario.Entidades.Inventario() { Codigo = item.Codigo, Cantidad = item.Cantidad, Tipo_de_producto = item.Tipo_De_Producto, unidad = item.Unidad };
                    _inventarios.Add(auxInventario);
                    lblTotal.Text = (total += item.PrecioTotal).ToString();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Seguro?","Aviso",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Entidades.Factura factura = new Entidades.Factura();
                factura.Codigofactura = lblCodigoFactura.Text;
                foreach (var item in _inventarios)
                {
                    Inventario.Entidades.Inventario inventario = new Inventario.Entidades.Inventario() { Cantidad = item.Cantidad , Codigo = item.Codigo };;
                    ReducirInventario(inventario);
                }
                _negocioFactura.PagoRealizado(factura);
                MessageBox.Show("¡Pago Realizado!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (volver == 1)
                {
                    ((frmpago.frmMenuPago)this.Owner).cargarFacturas();
                }

                this.Close();

            }
        }

        public void ReducirInventario(Inventario.Entidades.Inventario inventario)
        {
            _inventarioNegocio.ReducirExistenciaInventario(inventario);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printDocument1 = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printDocument1.PrinterSettings = ps;
            printDocument1.PrintPage += imprimir;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            //printDocument1.Print();
        }

        private void imprimir(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial",8,FontStyle.Regular,GraphicsUnit.Point);

            int y = 20;
        

            // cabezado

            e.Graphics.DrawString("Agro Ferreteria J.S", font, Brushes.Black, new RectangleF(100, y, 150, 20));
            e.Graphics.DrawString("Direccion", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
            e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
            foreach (var item in _imprimir)
            {
                e.Graphics.DrawString("Codigo: "+item.Codigofactura, font, Brushes.Black, new RectangleF(0, y += 20, 200, 20));
                e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
                e.Graphics.DrawString("Cliente: " +item.NameCliente, font, Brushes.Black, new RectangleF(0, y += 20, 200, 20));
                e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
                e.Graphics.DrawString("Direccion: "+item.Cedula, font, Brushes.Black, new RectangleF(0, y += 20, 200, 20));
                e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
                //aqui va un switch para el nombre del tipo de factura
                switch (item.Tipofactura)
                {
                    case 0:
                        e.Graphics.DrawString("Tipo de Factura: Normal", font, Brushes.Black, new RectangleF(0, y += 20, 150, 20));
                        break;
                    case 1:
                        e.Graphics.DrawString("Tipo de Factura: Credito", font, Brushes.Black, new RectangleF(0, y += 20, 150, 20));
                        break;
                    case 2:
                        e.Graphics.DrawString("Tipo de Factura: Envio", font, Brushes.Black, new RectangleF(0, y += 20, 150, 20));
                        break;
                    default:
                        break;
                }
                break;
            }

            // Cuerpo

            e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
            e.Graphics.DrawString("-----------------------------------------------------------------------------------", font, Brushes.Black, new RectangleF(0, y += 20, 400, 20));
            e.Graphics.DrawString("FACTURA", font, Brushes.Black, new RectangleF(130, y += 20, 150, 20));
            e.Graphics.DrawString("-----------------------------------------------------------------------------------", font, Brushes.Black, new RectangleF(0, y += 20, 400, 20));
            e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));



            e.Graphics.DrawString("DESCRIPCION", font, Brushes.Black, new RectangleF(0, 295, 150, 20));
            e.Graphics.DrawString("CANTIDAD", font, Brushes.Black, new RectangleF(100, 295, 150, 20));
            e.Graphics.DrawString("PRECIO", font, Brushes.Black, new RectangleF(175, 295, 150, 20));
            e.Graphics.DrawString("TOTAL", font, Brushes.Black, new RectangleF(250, 295, 150, 20));

            foreach (var item in _imprimir)
            {

                      e.Graphics.DrawString(item.Descripción, font, Brushes.Black, new RectangleF(0, y+=20, 100, 20));
                      e.Graphics.DrawString(item.Cantidad.ToString()+" "+item.Unidad, font, Brushes.Black, new RectangleF(100, y, 100, 20));
                      e.Graphics.DrawString(item.Precio.ToString(), font, Brushes.Black, new RectangleF(175, y, 100, 20));
                      e.Graphics.DrawString(item.PrecioTotal.ToString(), font, Brushes.Black, new RectangleF(250, y, 100, 20));
                      e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
            }
            e.Graphics.DrawString("-----------------------------------------------------------------------------------", font, Brushes.Black, new RectangleF(0, y += 20, 400, 20));
            e.Graphics.DrawString("Precio Total: " + lblTotal.Text, font, Brushes.Black, new RectangleF(180, y += 20, 400, 20));
            e.Graphics.DrawString("-----------------------------------------------------------------------------------", font, Brushes.Black, new RectangleF(0, y += 20, 400, 20));

            e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
            e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
            e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
            e.Graphics.DrawString("-------------------------FINAL DE LA FACTURA---------------------------------------", font, Brushes.Black, new RectangleF(0, y += 20, 400, 20));

        }

    }
}
