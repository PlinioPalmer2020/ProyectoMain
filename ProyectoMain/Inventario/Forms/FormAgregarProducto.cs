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
        private Negocio.CategoriaNegocio _categoriaNegocio;
        private Negocio.UnidadNegocio _unidadNegocio;
        private Negocio.Diferente_precioNegocio _Diferente_PrecioNegocio;

        private Entidades.Inventario _inventario;
        private List<Entidades.Diferente_precio> _diferente_Precios;
        private List<Entidades.Diferente_precio> _diferente_Precios_eliminar;
        private List<Entidades.Diferente_precio> _diferente_Precios_aux;
        private List<Entidades.Unidad> _unidads;
        public string estado = string.Empty;
        public string tipoproducto = string.Empty;
        private int indice = 0;
        private int auxid = 0;
        // public string tipoDeProducto = string.Empty;
        public FormAgregarProducto()
        {
            InitializeComponent();
            _inventarioNegocio = new Negocio.InventarioNegocio();
            _categoriaNegocio = new Negocio.CategoriaNegocio();
            _unidadNegocio = new Negocio.UnidadNegocio();
            _diferente_Precios = new List<Entidades.Diferente_precio>();
            _diferente_Precios_eliminar = new List<Entidades.Diferente_precio>();
            _diferente_Precios_aux = new List<Entidades.Diferente_precio>();
            _Diferente_PrecioNegocio = new Negocio.Diferente_precioNegocio();
            _unidads = new List<Entidades.Unidad>(); ;
        }


    private void FormAgregarProducto_Load(object sender, EventArgs e)
        {
            txtCodigo.Enabled = false;

            var categorias = _categoriaNegocio.TenerCategoria(null);
            var unidades = _unidadNegocio.TenerUnidad(null);


            foreach (var item in categorias)
            {
                cbTipoProducto.Items.Add(item.familia_categoria);
            }

            foreach (var item in unidades)
            {
                cbUnidad.Items.Add(item.nombre_unidad);
            }

            if (estado == "crear")
            {
                cbUnidad.SelectedItem = "Unidad";
            }

            if (estado == "Añadir" || estado == "Modificar")
            {
                cbTipoProducto.SelectedItem = tipoproducto;
            }
        }


        #region Botones
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (_diferente_Precios.Count != 0)
            {
                if (_diferente_Precios_eliminar.Count() != 0 && estado == "Modificar")
                {
                    foreach (var item in _diferente_Precios_eliminar)
                    {
                        _Diferente_PrecioNegocio.EliminarPrecio(item.id_diferente);
                    }
                }
                // Valido para cuando se quiere agregar un nuevo precio
                else if(_diferente_Precios.Count() > _diferente_Precios_aux.Count())
                {
                    guardarInventario();
                }
                else // cuando se crear un nuevo producto
                {
                    guardarInventario();
                }
                //txtCantidad.Enabled = true; 
                this.Close();
                ((FormMenuInventario)this.Owner).cargardatosdgv(null);
            }
            else
            {
                MessageBox.Show("!DEBE AGREGARLE UN UNIDAD Y UN PRECIO PARA GUADARLO¡","AVISO",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Funciones
        private string generarCodigo()
        {
            // DateTime fecha = DateTime.Now;

            //string codigo = "CPN" + fecha.ToString("dd") + fecha.ToString("MM") + fecha.ToString("yyyy") + fecha.ToString("hh") + fecha.ToString("mm") + fecha.ToString("ss") + fecha.ToString("ff");

            string codigo = string.Empty;
            var c = _inventarioNegocio.TenerCodigoInventario();

            if (c.Count != 0 )
            {
                foreach (var item in c)
                {

                    int aux = int.Parse(item.Codigo) + 1;
                    codigo = aux.ToString();

                }
            }
            else
            {
                codigo = "1";
            }



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
               // txtPrecio.Text = inventario.Precio.ToString();
                txtComprado.Text = inventario.comprado.ToString();

                _diferente_Precios = _Diferente_PrecioNegocio.TenerDiferente_precio(inventario.Codigo);
                _diferente_Precios_aux = _diferente_Precios;
                foreach (var item in _diferente_Precios)
                {
                    dgvDiferente.Rows.Add(item.unidad_diferente,item.precio,item.id_diferente);
                }
            }
        }
        private void guardarInventario()
        {
            //txtCodigo.Text = generarCodigo();

            Entidades.Inventario inventario = new Entidades.Inventario();
            inventario.Codigo = txtCodigo.Text;
            inventario.Nombre = txtNombre.Text;
            inventario.descripcion = txtDescripcion.Text;
            inventario.Cantidad = double.Parse(txtCantidad.Text);
            inventario.Tipo_de_producto = cbTipoProducto.SelectedItem.ToString();
            inventario.comprado = decimal.Parse(txtComprado.Text);

            foreach (var item in _diferente_Precios)
            {
                inventario.Precio = item.precio;
                inventario.unidad = item.unidad_diferente;
                break;
            }

            inventario.Id = _inventario != null ? _inventario.Id : 0;


            if (estado != "Añadir")
            {
                _inventarioNegocio.InsentarInventario(inventario);
                foreach (var item in _diferente_Precios)
                {
                    Entidades.Diferente_precio diferente_Precio = new Entidades.Diferente_precio();
                    diferente_Precio.id_diferente = item.id_diferente;
                    diferente_Precio.codigo_producto_diferente = item.codigo_producto_diferente;
                    diferente_Precio.unidad_diferente = item.unidad_diferente;
                    diferente_Precio.precio = item.precio;
                    _Diferente_PrecioNegocio.InsentarDiferente_precio(diferente_Precio);
                }
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


            if (cbTipoProducto.SelectedItem.ToString() == "Medicamentos")
            {
                if (lblContieneOExistencia.Text == "Existencia / Contiene")
                {
                    lblContieneOExistencia.Text = "Existencia";
                }
                else
                {
                    lblContieneOExistencia.Text += " / Contiene";
                }
            }

            if (estado == "Añadir" || estado == null)
            {
                cbUnidad.Enabled = true;
            }
            //cbUnidad.SelectedIndex = 0;

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

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            dgvDiferente.Rows.Clear();
            Entidades.Diferente_precio diferente_Precio = new Entidades.Diferente_precio();
            diferente_Precio.id_diferente = auxid;
            diferente_Precio.codigo_producto_diferente = txtCodigo.Text;
            diferente_Precio.unidad_diferente = cbUnidad.SelectedItem.ToString();
            diferente_Precio.precio = decimal.Parse(txtPrecio.Text);

            if (btnAñadir.Text == "Añadir Precio")
            {
                _diferente_Precios.Add(diferente_Precio);

            }
            else
            {
                _diferente_Precios.RemoveAt(indice);
                _diferente_Precios.Insert(indice,diferente_Precio);
                btnAñadir.Text = "Añadir Precio";

            }
            foreach (var item in _diferente_Precios)
            {
                dgvDiferente.Rows.Add(item.unidad_diferente,item.precio, item.id_diferente);
            }
            txtPrecio.Text = string.Empty;
            cbUnidad.Text = string.Empty;
        }

        private void dgvDiferente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewLinkCell cell = (DataGridViewLinkCell)dgvDiferente.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value.ToString() == "Quitar")
                {
                    Entidades.Diferente_precio diferente_ = new Entidades.Diferente_precio();
                    diferente_.id_diferente = int.Parse(dgvDiferente.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    _diferente_Precios_eliminar.Add(diferente_);
                    _diferente_Precios.RemoveAt(e.RowIndex);
                    dgvDiferente.Rows.Clear();
                    foreach (var item in _diferente_Precios)
                    {
                        dgvDiferente.Rows.Add(item.unidad_diferente,item.precio, item.id_diferente);
                    }
                }
                else
                {
                    btnAñadir.Text = "Actualizar";
                    txtPrecio.Text = dgvDiferente.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
                    cbUnidad.SelectedItem = dgvDiferente.Rows[e.RowIndex].Cells["Unidad"].Value.ToString();
                    auxid = int.Parse(dgvDiferente.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    indice = e.RowIndex;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // throw;
            }
        }

        private void cbUnidad_DropDown(object sender, EventArgs e)
        {
            cbUnidad.Items.Clear();
            cbUnidad.Text = string.Empty;
            _unidads = _unidadNegocio.TenerUnidad(null);
            foreach (var item in _unidads)
            {
                cbUnidad.Items.Add(item.nombre_unidad);
            }
        }
    }
}
