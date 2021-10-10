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
        }

        private void FormMenuInventario_Load(object sender, EventArgs e)
        {


            cargardatosdgv(txtBuscar.Text);

            //foreach (Control item in gridInventario.Controls)
            //{
            //    if (item is Button)
            //    {
            //        item.Click += eventoboton;
            //    }
            //}

        }

        //private void eventoboton(object sender, EventArgs e)
        //{
        //    Button button = (Button)sender;
        //    MessageBox.Show(button.Name);
        //}

        private void gridInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                    Cantidad = int.Parse(gridInventario.Rows[e.RowIndex].Cells[5].Value.ToString()),

                });

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
                    Cantidad = int.Parse(gridInventario.Rows[e.RowIndex].Cells[5].Value.ToString()),

                });

                agregarProducto.txtCantidad.Enabled = true;
                agregarProducto.txtNombre.Enabled = false;
                agregarProducto.txtPrecio.Enabled = false;
                agregarProducto.txtDescripcion.Enabled = false;
                agregarProducto.txtCantidad.Enabled = true;

                agregarProducto.btnAgregar.Text = "Añadir";
                agregarProducto.ShowDialog(this);
            }
        }

        public void cargar()
        {
            //this.inventarioTableAdapter.Fill(this.ferreteriaDataSet.inventario);

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
    }
}
