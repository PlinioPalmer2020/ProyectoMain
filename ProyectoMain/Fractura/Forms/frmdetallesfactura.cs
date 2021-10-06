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
        public frmdetallesfactura()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Inventario.Entidades.Inventario inventario = new Inventario.Entidades.Inventario();
            inventario.Codigo = txtCodigo.Text;
            inventario.Nombre = txtNombre.Text;
            inventario.descripcion = txtDescripcion.Text;
            inventario.Precio = decimal.Parse(txtPrecio.Text);
            inventario.Cantidad = int.Parse(txtCantidad.Text);
            this.Close();
            ((FrmMenuFactura)this.Owner).cargardetalles(inventario);

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
    }
}
