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
        private decimal aux = 0;
       // public string tipoProducto = string.Empty;
        public frmdetallesfactura()
        {
            InitializeComponent();
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
                switch (inventario.Tipo_de_producto)
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
                        break;
                }
                cbUnidad.SelectedItem = inventario.unidad;
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
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void cbUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (_inventario.Tipo_de_producto)
            {
                case "Arenas":
                    switch (cbUnidad.SelectedItem.ToString())
                    {
                        case "Sacos":
                            aux = decimal.Parse(txtPrecio.Text);
                            txtPrecio.Text = (aux / 8).ToString();
                            break;
                        case "Metros":
                            txtPrecio.Text = _inventario.Precio.ToString();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones_de_Validaciones.Validacion validacion = new Funciones_de_Validaciones.Validacion();

            e.KeyChar = Convert.ToChar(validacion.SoloNumero(e.KeyChar));
        }
    }
}
