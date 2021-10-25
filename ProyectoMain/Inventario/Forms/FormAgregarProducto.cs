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
        public string estado = string.Empty;
        public string tipoproducto = string.Empty;
        // public string tipoDeProducto = string.Empty;
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
            inventario.Cantidad = double.Parse(txtCantidad.Text);
            inventario.Tipo_de_producto = cbTipoProducto.SelectedItem.ToString();
            inventario.unidad = cbUnidad.SelectedItem.ToString();
            inventario.comprado = decimal.Parse(txtComprado.Text);

            inventario.Id = _inventario != null ? _inventario.Id : 0;

            switch (cbTipoProducto.SelectedItem)
            {
                case "Arenas":
                    if (inventario.unidad == "Sacos")
                    {
                        inventario.Cantidad = inventario.Cantidad / 8;
                    }
                    break;
                default:
                    break;
            }
            if (estado != "Añadir")
            {
                _inventarioNegocio.InsentarInventario(inventario);
            }
            else
            {
                _inventarioNegocio.AñadirInventario(inventario);
            }
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
           // txtTipoDeProducto.Text = tipoDeProducto;
           // txtCantidad.Enabled = false;
            txtCodigo.Text = generarCodigo();

            cbTipoProducto.Items.Add("Arenas");
            cbTipoProducto.Items.Add("Medicamentos");
            if (estado == "Añadir")
            {
                cbTipoProducto.SelectedItem = tipoproducto;
            }
        }

        private string generarCodigo()
        {
            DateTime fecha = DateTime.Now;

            string codigo = "CPN" + fecha.ToString("dd") + fecha.ToString("MM") + fecha.ToString("yyyy") + fecha.ToString("hh") + fecha.ToString("mm") + fecha.ToString("ss") + fecha.ToString("ff");
 
            return codigo;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cbTipoProducto.SelectedItem)
            {
                case "Arenas":
                    cbUnidad.Enabled = true;
                    cbUnidad.Items.Add("Metros");
                    cbUnidad.Items.Add("Sacos");
                    cbUnidad.SelectedIndex = 0;
                    break;
                default:
                    cbUnidad.Items.Clear();
                    cbUnidad.Enabled = false;
                    break;
            }
        }
    }
}
