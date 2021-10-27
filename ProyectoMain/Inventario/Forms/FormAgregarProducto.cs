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


        private void FormAgregarProducto_Load(object sender, EventArgs e)
        {
            txtCodigo.Enabled = false;
           // txtTipoDeProducto.Text = tipoDeProducto;
           // txtCantidad.Enabled = false;
            txtCodigo.Text = generarCodigo();

            cbTipoProducto.Items.Add("Arenas");
            cbTipoProducto.Items.Add("Medicamentos");
            cbTipoProducto.Items.Add("Tubos");
            cbTipoProducto.Items.Add("Cemento");
            cbTipoProducto.Items.Add("Alimentos");
            cbTipoProducto.Items.Add("Herramientas o otros productos");

            if (estado == "Añadir" || estado == "Modificar")
            {
                cbTipoProducto.SelectedItem = tipoproducto;
            }
        }


        #region Botones
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            guardarInventario();
            //txtCantidad.Enabled = true; 
            this.Close();
            ((FormMenuInventario)this.Owner).cargardatosdgv(null);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Funciones
        private string generarCodigo()
        {
            DateTime fecha = DateTime.Now;

            string codigo = "CPN" + fecha.ToString("dd") + fecha.ToString("MM") + fecha.ToString("yyyy") + fecha.ToString("hh") + fecha.ToString("mm") + fecha.ToString("ss") + fecha.ToString("ff");
 
            return codigo;
        }
        private void limpiarForm()
        {
            txtCantidad.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtPrecio.Text = string.Empty;
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
                txtComprado.Text = inventario.comprado.ToString();
            }
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
                case "Cemento":
                    if (inventario.unidad == "Libra")
                    {
                        inventario.Cantidad = inventario.Cantidad / 98;
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

        #endregion

        #region Eventos
        private void cbTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

            cbUnidad.Items.Clear();
            cbUnidad.Text = string.Empty;
            switch (cbTipoProducto.SelectedItem)
            {
                case "Arenas":
                    cbUnidad.Items.Add("Metros");
                    cbUnidad.Items.Add("Sacos");
                    break;
                case "Cemento":
                    cbUnidad.Items.Add("Funda");
                    cbUnidad.Items.Add("Libra");
                    break;
                case "Tubos":
                    cbUnidad.Items.Add("Pie");
                    break;
                case "Medicamentos":
                    cbUnidad.Items.Add("CC");
                    break;
                case "Alimentos":
                    cbUnidad.Items.Add("Saco");
                    cbUnidad.Items.Add("Medi Saco");
                    cbUnidad.Items.Add("Libra");
                    break;
                case "Herramientas o otros productos":
                    cbUnidad.Items.Add("Unidad");
                    break;
                default:
                    cbUnidad.Enabled = false;
                    break;
            }
            if (estado == "Añadir" || estado == null)
            {
                cbUnidad.Enabled = true;
            }
            cbUnidad.SelectedIndex = 0;

        }

        #endregion

        #region Validación de solo numero los precio, compra y cantidad 
        private void txtComprado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones_de_Validaciones.Validacion validacion = new Funciones_de_Validaciones.Validacion();

            e.KeyChar = Convert.ToChar(validacion.SoloNumero(e.KeyChar));
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones_de_Validaciones.Validacion validacion = new Funciones_de_Validaciones.Validacion();

            e.KeyChar = Convert.ToChar(validacion.SoloNumero(e.KeyChar));
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones_de_Validaciones.Validacion validacion = new Funciones_de_Validaciones.Validacion();

            e.KeyChar = Convert.ToChar(validacion.SoloNumero(e.KeyChar));
        }

        #endregion
    }
}
