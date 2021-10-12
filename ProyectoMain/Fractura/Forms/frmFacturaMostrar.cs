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
        Negocio_Data.NegocioFactura _negocioFactura;
        public frmFacturaMostrar()
        {
            InitializeComponent();
            _negocioFactura = new Negocio_Data.NegocioFactura();
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

                    dgvFactura.Rows.Add(item.Codigo, item.Producto+" "+item.Descripción, item.Precio, item.Cantidad ,item.PrecioTotal);
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
                _negocioFactura.PagoRealizado(factura);
                MessageBox.Show("¡Pago Realizado!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
        }


    }
}
