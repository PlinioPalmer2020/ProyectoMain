using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMain.Inventario.Forms
{
    public partial class FormAgregarProducto : Form
    {
        private Negocio.InventarioNegocio _inventarioNegocio;
        private Entidades.Inventario _inventario;
        public FormAgregarProducto()
        {
            InitializeComponent();
            _inventarioNegocio = new Negocio.InventarioNegocio();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guardarInventario()
        {
            Entidades.Inventario inventario = new Entidades.Inventario();
            inventario.Codigo = txtCodigo.Text;
            inventario.Nombre = txtNombre.Text;
            inventario.descripcion = txtDescripcion.Text;
            inventario.Precio = decimal.Parse(txtPrecio.Text);
            inventario.Cantidad = int.Parse(txtCantidad.Text);

            inventario.Id = _inventario != null ? _inventario.Id : 0;

            _inventarioNegocio.InsentarInventario(inventario);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            guardarInventario();
            //txtCantidad.Enabled = true; 
            this.Close();
            ((FormMenuInventario)this.Owner).cargardatosdgv(null);
        }

        public void CargarInventario(Entidades.Inventario inventario) 
        {
            _inventario = inventario;
            if (inventario != null)
            {
                limpiarForm();

                txtCantidad.Text = inventario.Cantidad.ToString();
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

        private void FormAgregarProducto_Load(object sender, EventArgs e)
        {
            txtCodigo.Enabled = false;
           // txtCantidad.Enabled = false;
            txtCodigo.Text = generarCodigo();
        }

        private string generarCodigo()
        {
            DateTime fecha = DateTime.Now;

            string codigo = "CPN" + fecha.ToString("dd") + fecha.ToString("MM") + fecha.ToString("yyyy") + fecha.ToString("hh") + fecha.ToString("mm") + fecha.ToString("ss") + fecha.ToString("ff");
 
            return codigo;
        }
    }
}
