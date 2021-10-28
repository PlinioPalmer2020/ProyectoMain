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





        #region Funciones
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

                    dgvFactura.Rows.Add(item.Codigo, item.Producto+" "+item.Descripción, item.Precio.ToString("##,#.##"), item.Cantidad, item.Unidad ,item.PrecioTotal.ToString("##,#.##"));
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
        #endregion

        #region Botones
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printDocument1 = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printDocument1.PrinterSettings = ps;
            printDocument1.PrintPage += imprimir;
            //printPreviewDialog1.Document = printDocument1;
          //  printPreviewDialog1.ShowDialog();
            printDocument1.Print();
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
                    Inventario.Entidades.Inventario inventario = new Inventario.Entidades.Inventario() { Tipo_de_producto = item.Tipo_de_producto ,Cantidad = item.Cantidad , Codigo = item.Codigo, unidad = item.unidad };

                    switch (inventario.Tipo_de_producto)
                    {
                        case"Arenas":
                            if (inventario.unidad == "Sacos")
                            {
                                inventario.Cantidad = inventario.Cantidad / 8;
                            }
                            break;
                        case "Cemento":
                            if (inventario.unidad == "Libra")
                            {
                                inventario.Cantidad = inventario.Cantidad / 98;
                            }
                            break;
                        default:
                            break;
                    }
                    ReducirInventario(inventario);
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
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        #region funcion encargado de imprimir ticket
        private void imprimir(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial",8,FontStyle.Bold,GraphicsUnit.Point);
            Font fonttitulo = new Font("Arial",15,FontStyle.Bold,GraphicsUnit.Point);

            int y = 20;
        

            // cabezado

            e.Graphics.DrawString("Agro Ferreteria J.S", fonttitulo, Brushes.Black, new RectangleF(95, y, 150, 50));
           // e.Graphics.DrawString("Direccion", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
            e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
            e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
            foreach (var item in _imprimir)
            {
                e.Graphics.DrawString("Codigo: "+item.Codigofactura, font, Brushes.Black, new RectangleF(0, y += 20, 200, 20));
                e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
                e.Graphics.DrawString("Cliente: " +item.NameCliente, font, Brushes.Black, new RectangleF(0, y += 20, 200, 20));
                e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
                e.Graphics.DrawString("Direccion: "+item.Cedula, font, Brushes.Black, new RectangleF(0, y += 20, 200, 20));
                e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
                e.Graphics.DrawString("Fecha de creacion: " + item.Fecha_crear, font, Brushes.Black, new RectangleF(0, y += 20, 200, 40));
                e.Graphics.DrawString("\n", font, Brushes.Black, new RectangleF(100, y += 20, 150, 20));
                e.Graphics.DrawString("Fecha de Impresion: " + DateTime.Now, font, Brushes.Black, new RectangleF(0, y += 20, 200, 40));
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



            e.Graphics.DrawString("DESCRIPCION", font, Brushes.Black, new RectangleF(0, y, 150, 20));
            e.Graphics.DrawString("CANTIDAD", font, Brushes.Black, new RectangleF(100, y, 150, 20));
            e.Graphics.DrawString("PRECIO", font, Brushes.Black, new RectangleF(175, y, 150, 20));
            e.Graphics.DrawString("TOTAL", font, Brushes.Black, new RectangleF(250, y, 150, 20));

            foreach (var item in _imprimir)
            {

                      e.Graphics.DrawString(item.Descripción, font, Brushes.Black, new RectangleF(0, y+=20, 100, 100));
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

        #endregion

    }
}
