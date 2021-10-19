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
        private Negocio.UnidadesNegocio _unidadesNegocio;
        private Negocio.TiposDeProductosNegocio _tiposDeProductosNegocio;
        private Entidades.Inventario _inventario;
        public FormAgregarProducto()
        {
            InitializeComponent();
            _inventarioNegocio = new Negocio.InventarioNegocio();
            _tiposDeProductosNegocio = new Negocio.TiposDeProductosNegocio();
            _unidadesNegocio = new Negocio.UnidadesNegocio();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guardarInventario(Entidades.Inventario inventario)
        {
            _inventarioNegocio.InsentarInventario(inventario);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Entidades.Inventario inventario = new Entidades.Inventario();
            inventario.Codigo = txtCodigo.Text;
            inventario.TipoProducto = cbTiposDeProductos.SelectedIndex;
            inventario.Nombre = txtNombre.Text;
            inventario.descripcion = txtDescripcion.Text;
            inventario.precioComprado = decimal.Parse(txtPrecio.Text);
            inventario.precioVendido = decimal.Parse(txtPrecioVender.Text);
            inventario.Cantidad = double.Parse(txtCantidad.Text);
            inventario.UnidadCantidad = cbUnidades.SelectedIndex;
            inventario.Contiene = double.Parse(txtContiene.Text) ;
            inventario.unidadContiene = cbUnidadDerivadas.SelectedIndex;

            inventario.Id = _inventario != null ? _inventario.Id : 0;
            switch (cbTiposDeProductos.SelectedItem.ToString())
            {
                case "Areas Y Cementos":
                    if (cbUnidades.SelectedItem.ToString() == "Saco")
                    {
                        inventario.Cantidad = inventario.Cantidad / 8;
                        inventario.UnidadCantidad = 1;
                    }
                    else if (cbUnidades.SelectedItem.ToString() == "Libra")
                    {
                        inventario.Cantidad = inventario.Cantidad / 98;
                        inventario.UnidadCantidad = 2;
                    }
                    //guardarInventario(inventario);
                    break;
                default:
                    break;
            }

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
                txtPrecio.Text = inventario.precioVendido.ToString();
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
           //txtCantidad.Enabled = false;
            txtCodigo.Text = generarCodigo();
            txtContiene.Text = "0";
            CargarCbTiposDeProducos();
            CargarCbUnidades();
            CargarCbUnidadesDerivadas();

        }

        #region Cargas Datos de ComboBox

            private void CargarCbTiposDeProducos()
            {
                List<Entidades.tiposDeProductos> tiposDeProductos = new List<Entidades.tiposDeProductos>();
                tiposDeProductos = _tiposDeProductosNegocio.TenerTiposDeProductos();

                foreach (var item in tiposDeProductos)
                {
                    cbTiposDeProductos.Items.Add(item.nombre);
                }

                cbTiposDeProductos.SelectedText = "Productos y Herramientas";
            }

            private void CargarCbUnidades()
            {
                List<Entidades.Unidades> unidades = new List<Entidades.Unidades>();
                unidades = _unidadesNegocio.TenerUnidades();

                foreach (var item in unidades)
                {
                    cbUnidades.Items.Add(item.nombre);
                }

                cbUnidades.SelectedText = "Unidad";
            }

            private void CargarCbUnidadesDerivadas()
            {
                List<Entidades.Unidades> unidades = new List<Entidades.Unidades>();
                unidades = _unidadesNegocio.TenerUnidades();

                foreach (var item in unidades)
                {
                    cbUnidadDerivadas.Items.Add(item.nombre);
                }

                cbUnidadDerivadas.SelectedText = "Unidad";
            }
        #endregion



        private string generarCodigo()
        {
            DateTime fecha = DateTime.Now;

            string codigo = "CPN" + fecha.ToString("dd") + fecha.ToString("MM") + fecha.ToString("yyyy") + fecha.ToString("hh") + fecha.ToString("mm") + fecha.ToString("ss") + fecha.ToString("ff");
 
            return codigo;
        }

        private void cbTiposDeProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbTiposDeProductos.SelectedItem.ToString() != "Medicamentos")
            {
                txtContiene.Enabled = false;
                cbUnidadDerivadas.Enabled = false;
            }
            else
            {
                txtContiene.Enabled = true;
                cbUnidadDerivadas.Enabled = true;
            }
        }
    }
}
