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
    public partial class FormMenuInventario : Form
    {

        private Negocio.InventarioNegocio _inventarioNegocio;
        public FormMenuInventario()
        {
            InitializeComponent();
            _inventarioNegocio = new Negocio.InventarioNegocio();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAgregarProducto formAgregar = new FormAgregarProducto();
            formAgregar.ShowDialog(this);
            //frmMenuAgregar frmMenuAgregar = new frmMenuAgregar();
            //frmMenuAgregar.ShowDialog(this);
        }

        private void FormMenuInventario_Load(object sender, EventArgs e)
        {
            cargardatosdgv(txtBuscar.Text);
        }


        private void gridInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewLinkCell cell = (DataGridViewLinkCell)gridInventario.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell.Value.ToString() == "Modificar")
                {
                    FormAgregarProducto agregarProducto = new FormAgregarProducto();
                    agregarProducto.CargarInventario(new Entidades.Inventario
                    {
                        Id = int.Parse(gridInventario.Rows[e.RowIndex].Cells[0].Value.ToString()),
                        Codigo = gridInventario.Rows[e.RowIndex].Cells[1].Value.ToString(),
                        Nombre = gridInventario.Rows[e.RowIndex].Cells[2].Value.ToString(),
                        descripcion = gridInventario.Rows[e.RowIndex].Cells[3].Value.ToString(),
                        Precio = decimal.Parse(gridInventario.Rows[e.RowIndex].Cells[4].Value.ToString()),
                        Cantidad = double.Parse(gridInventario.Rows[e.RowIndex].Cells[5].Value.ToString()),
                        comprado = decimal.Parse(gridInventario.Rows[e.RowIndex].Cells[7].Value.ToString())

                    });

                    //agregarProducto.cbTipoProducto.Enabled = false;
                    //agregarProducto.cbUnidad.Enabled = false;
                    agregarProducto.estado = "Modificar";
                    agregarProducto.tipoproducto = gridInventario.Rows[e.RowIndex].Cells[6].Value.ToString();
                    agregarProducto.txtCantidad.Enabled = false;
                    agregarProducto.btnAgregar.Text = "Modificar";
                    agregarProducto.ShowDialog(this);
                }
                else if (cell.Value.ToString() == "Añadir")
                {
                    FormAgregarProducto agregarProducto = new FormAgregarProducto();
                    agregarProducto.CargarInventario(new Entidades.Inventario
                    {
                        Id = int.Parse(gridInventario.Rows[e.RowIndex].Cells[0].Value.ToString()),
                        Codigo = gridInventario.Rows[e.RowIndex].Cells[1].Value.ToString(),
                        Nombre = gridInventario.Rows[e.RowIndex].Cells[2].Value.ToString(),
                        descripcion = gridInventario.Rows[e.RowIndex].Cells[3].Value.ToString(),
                        Precio = decimal.Parse(gridInventario.Rows[e.RowIndex].Cells[4].Value.ToString()),
                        Cantidad = 0,
                        comprado = decimal.Parse(gridInventario.Rows[e.RowIndex].Cells[7].Value.ToString())

                    });

                    agregarProducto.txtCantidad.Enabled = true;
                    agregarProducto.txtNombre.Enabled = false;
                    agregarProducto.txtPrecio.Enabled = false;
                    agregarProducto.txtComprado.Enabled = false;
                    agregarProducto.txtDescripcion.Enabled = false;
                    agregarProducto.txtCantidad.Enabled = true;

                    agregarProducto.btnAgregar.Text = "Añadir";
                    agregarProducto.cbTipoProducto.Enabled = false;
                    //agregarProducto.txtComprado.Text = "0";
                    agregarProducto.tipoproducto = gridInventario.Rows[e.RowIndex].Cells[6].Value.ToString();
                    agregarProducto.estado = "Añadir";

                    agregarProducto.ShowDialog(this);
                }
                else if (cell.Value.ToString() == "Eliminar")
                {
                    DialogResult dr = MessageBox.Show("¿Seguro de Eliminar este producto del Inventario?","Aviso",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        Entidades.Inventario inventario = new Entidades.Inventario();
                        inventario.Codigo = gridInventario.Rows[e.RowIndex].Cells[1].Value.ToString();
                        _inventarioNegocio.EliminarInventario(inventario.Codigo);
                        cargardatosdgv(txtBuscar.Text);
                    }

                }

            }
            catch (Exception)
            {

                //throw;
                MessageBox.Show("algo fallo");
            }
        }



        public void cargardatosdgv(string buscar)
        {
            gridInventario.DataSource = _inventarioNegocio.TenerInventarios(buscar);
        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            Fractura.Forms.FrmMenuFactura frmMenuFactura = new Fractura.Forms.FrmMenuFactura();
            frmMenuFactura.Show(this);
            this.Hide();
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            Fractura.Forms.frmpago.frmMenuPago frmMenuMenuPago = new Fractura.Forms.frmpago.frmMenuPago();
            frmMenuMenuPago.Show(this);
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargardatosdgv(txtBuscar.Text);
        }

        private void gridInventario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.gridInventario.Columns[e.ColumnIndex].Name == "cantidadDataGridViewTextBoxColumn")
            {
                if (Convert.ToInt32(e.Value) <= 10)
                {
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.BackColor = Color.FromArgb(249, 65, 68);
                }
                if (Convert.ToInt32(e.Value) <= 20 && Convert.ToInt32(e.Value) > 10)
                {
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.BackColor = Color.FromArgb(249, 199, 79);
                }
                if (Convert.ToInt32(e.Value) >= 21)
                {
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.BackColor = Color.FromArgb(67, 170, 139);
                }
            }
        }

        private void btnHistoria_Click(object sender, EventArgs e)
        {
            Registro.frmMenuRegistroEntrada frmMenuRegistroEntrada = new Registro.frmMenuRegistroEntrada();
            frmMenuRegistroEntrada.Show();
            this.Hide();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            //this.Login = string.Empty;
            this.Hide();
        }

        private void FormMenuInventario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnContabidad_Click(object sender, EventArgs e)
        {
            Contabilidad.frmMenuContabilidad1 frmMenuContabilidad1 = new Contabilidad.frmMenuContabilidad1();
            frmMenuContabilidad1.Show();
            this.Hide();
        }
    }
}
