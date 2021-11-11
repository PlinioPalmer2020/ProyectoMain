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
        // capa de negpcio
        private Inventario.Negocio.Diferente_precioNegocio _diferente_PrecioNegocio;
        private Inventario.Negocio.UnidadNegocio _unidadNegocio;

        // capa entidades
        private Inventario.Entidades.Inventario _inventario;

        // listas 
        private List<Inventario.Entidades.Diferente_precio> diferente_Precios;

        //algunas variables
        private string unidadPrincipal = string.Empty;
        private decimal precioMaximo = 0;
        public string genero = string.Empty;
        private int i = 0;
        // public string tipoProducto = string.Empty;
        public frmdetallesfactura()
        {
            InitializeComponent();
            _diferente_PrecioNegocio = new Inventario.Negocio.Diferente_precioNegocio();
            diferente_Precios = new List<Inventario.Entidades.Diferente_precio>();
            _unidadNegocio = new Inventario.Negocio.UnidadNegocio();
        }


    #region Funciones
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

                diferente_Precios = _diferente_PrecioNegocio.TenerDiferente_precio(inventario.Codigo);

                foreach (var item in diferente_Precios)
                {
                    cbUnidad.Items.Add(item.unidad_diferente);
                }
               
                cbUnidad.SelectedItem = inventario.unidad;

                unidadPrincipal = inventario.unidad;
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
        #endregion

        #region Botones
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (genero == "generico")
            {
                Inventario.Entidades.Inventario inventario = new Inventario.Entidades.Inventario();

                
                inventario.Codigo = txtCodigo.Text;
                inventario.Nombre = txtNombre.Text;
                inventario.descripcion = txtDescripcion.Text;
                inventario.Precio = decimal.Parse(txtPrecio.Text);
                inventario.Cantidad = int.Parse(txtCantidad.Text);
                inventario.unidad = cbUnidad.Text;
                inventario.Tipo_de_producto = "Generico";
                this.Close();
                ((FrmMenuFactura)this.Owner).cargardetalles(inventario);
            }
            else if (cbUnidad.SelectedItem.ToString() != unidadPrincipal)
            {
                decimal preciofull = decimal.Parse(txtCantidad.Text) *  decimal.Parse(txtPrecio.Text);
                double validacion = double.Parse(preciofull.ToString()) / double.Parse(precioMaximo.ToString());
                if (validacion > _inventario.Cantidad )
                {
                    MessageBox.Show("¡Usted no puede agregar mas que no hay en el inventario!");
                    return;
                }
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
            else if (_inventario.Cantidad >= int.Parse(txtCantidad.Text))
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
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void cbUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (var item in diferente_Precios)
            {
                if (item.unidad_diferente == cbUnidad.SelectedItem.ToString() )
                {
                    if (i == 0)
                    {
                        precioMaximo = item.precio;
                        i++;
                    }
                    txtPrecio.Text = item.precio.ToString();
                }
            }
          
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones_de_Validaciones.Validacion validacion = new Funciones_de_Validaciones.Validacion();

            e.KeyChar = Convert.ToChar(validacion.SoloNumero(e.KeyChar));
        }

        private void frmdetallesfactura_Load(object sender, EventArgs e)
        {
            if (genero == "generico")
            {
                txtCodigo.Text = generarCodigo();
                txtDescripcion.Enabled = true;
                txtPrecio.Enabled = true;
                txtCantidad.Enabled = true;
                List<Inventario.Entidades.Unidad> unidads = new List<Inventario.Entidades.Unidad>();

                unidads = _unidadNegocio.TenerUnidad();

                foreach (var item in unidads)
                {
                    cbUnidad.Items.Add(item.nombre_unidad);
                }
            }
        }

        private string generarCodigo()
        {
            DateTime fecha = DateTime.Now;

            string codigo = "CPN" + fecha.ToString("dd") + fecha.ToString("MM") + fecha.ToString("yyyy") + fecha.ToString("hh") + fecha.ToString("mm") + fecha.ToString("ss") + fecha.ToString("ff");

            return codigo;
        }
    }
}
