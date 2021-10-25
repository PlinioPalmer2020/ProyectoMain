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
    public partial class frmdetallesfactura : Form
    {

        private Inventario.Entidades.Inventario _inventario;
       // public string tipoProducto = string.Empty;
        public frmdetallesfactura()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (_inventario.Cantidad >= int.Parse(txtCantidad.Text))
            {
                Inventario.Entidades.Inventario inventario = new Inventario.Entidades.Inventario();
                inventario.Codigo = txtCodigo.Text;
                inventario.Nombre = txtNombre.Text;
                inventario.descripcion = txtDescripcion.Text;
                inventario.Precio = decimal.Parse(txtPrecio.Text);
                inventario.Cantidad = int.Parse(txtCantidad.Text);
                inventario.unidad = cbUnidad.SelectedItem.ToString();
                inventario.Tipo_de_producto = _inventario.Tipo_de_producto;
                this.Close();
                ((FrmMenuFactura)this.Owner).cargardetalles(inventario);

            }
            else
            {
               MessageBox.Show("Usted no puede agregar mas que no hay en el inventario");
            }

        }


        public void CargarInventario(Inventario.Entidades.Inventario inventario)
        {
            _inventario = inventario;
            if (inventario != null)
            {
                limpiarForm();

                txtCantidad.Text = "1";
                txtCodigo.Text = inventario.Codigo;
                txtDescripcion.Text = inventario.descripcion;
                txtNombre.Text = inventario.Nombre;
                txtPrecio.Text = inventario.Precio.ToString();
                switch (inventario.Tipo_de_producto)
                {
                    case "Arenas":
                        cbUnidad.Items.Add("Metros");
                        cbUnidad.Items.Add("Sacos");
                        cbUnidad.SelectedItem = inventario.unidad;
                        break;
                    default:
                        break;
                }
            }
        }

        private void limpiarForm()
        {
            txtCantidad.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtPrecio.Text = string.Empty;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
