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
    public partial class frmFacturaMostrar : Form
    {
        private Negocio_Data.NegocioFactura _negocioFactura;
        private Inventario.Negocio.InventarioNegocio _inventarioNegocio;
        private List<Inventario.Entidades.Inventario> _inventarios;
        //private List<string> _inventarios;
        public int volver = 0;
        public frmFacturaMostrar()
        {
            InitializeComponent();
            _negocioFactura = new Negocio_Data.NegocioFactura();
            _inventarioNegocio = new Inventario.Negocio.InventarioNegocio();
            _inventarios = new List<Inventario.Entidades.Inventario>();
            //_inventarios = new List<string>();
        }

        public void cargarDatos(string codigo) 
        {

            List<Entidades.Factura> factura = new List<Entidades.Factura>();
            factura = _negocioFactura.TenerFacturaEspeficico(codigo);

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


    }
}
