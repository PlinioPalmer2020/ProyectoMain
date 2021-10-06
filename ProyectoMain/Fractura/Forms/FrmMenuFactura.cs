using ProyectoMain.Inventario.Forms;
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
    public partial class FrmMenuFactura : Form
    {
        Inventario.Negocio.InventarioNegocio _inventarioNegocio;
        Negocio_Data.NegocioFactura _negocioFactura;
        List<Inventario.Entidades.Inventario> _detallesfactura;
        public FrmMenuFactura()
        {
            InitializeComponent();
            _inventarioNegocio = new Inventario.Negocio.InventarioNegocio();
            _detallesfactura = new List<Inventario.Entidades.Inventario>();
            _negocioFactura = new Negocio_Data.NegocioFactura();

         
            cbTipoFactura.Items.Add("Normal");
            cbTipoFactura.Items.Add("Prestame");
            cbTipoFactura.Items.Add("Envio");
            cbTipoFactura.SelectedIndex = 0;
            
        }

        private void FrmMenuFactura_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'ferreteriaDataSet1.inventario' Puede moverla o quitarla según sea necesario.

            try
            {
            this.inventarioTableAdapter.Fill(this.ferreteriaDataSet1.inventario);

            }
            catch (Exception)
            {

                
            }

        }

        private void panelAgregar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //((FormMenuInventario)this.Owner).Close();
        }



        private void gridInventario_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewLinkCell cell = (DataGridViewLinkCell)gridInventario.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.Value.ToString() == "Agregar")
            {
                frmdetallesfactura detallesfactura = new frmdetallesfactura();
                detallesfactura.CargarInventario(new Inventario.Entidades.Inventario
                {
                    Id = int.Parse(gridInventario.Rows[e.RowIndex].Cells[0].Value.ToString()),
                    Codigo = gridInventario.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    Nombre = gridInventario.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    descripcion = gridInventario.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    Precio = decimal.Parse(gridInventario.Rows[e.RowIndex].Cells[4].Value.ToString()),
                    Cantidad = int.Parse(gridInventario.Rows[e.RowIndex].Cells[5].Value.ToString()),

                });

                detallesfactura.ShowDialog(this);
            }
        }

        public void cargardetalles(Inventario.Entidades.Inventario inventario) 
        {
            dgvDetalles.Rows.Clear();
                _detallesfactura.Add(inventario);
             foreach (var item in _detallesfactura)
                {
                    dgvDetalles.Rows.Add(item.Codigo.ToString(),item.Nombre.ToString(), item.descripcion.ToString(), item.Precio.ToString(), item.Cantidad.ToString(), (item.Precio * item.Cantidad).ToString());
                }

        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewLinkCell cell = (DataGridViewLinkCell)dgvDetalles.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Value.ToString() == "Quitar")
            {
                _detallesfactura.RemoveAt(e.RowIndex);
                dgvDetalles.Rows.Clear();
                foreach (var item in _detallesfactura)
                {
                    dgvDetalles.Rows.Add(item.Codigo.ToString(), item.Nombre.ToString(), item.descripcion.ToString(), item.Precio.ToString(), item.Cantidad.ToString(), (item.Precio * item.Cantidad).ToString());
                }
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
           // int a = cbTipoFactura.SelectedIndex;
            DateTime hoy = DateTime.Today;
            foreach (var item in _detallesfactura)
            {
                Entidades.Factura factura = new Entidades.Factura();
                factura.Codigofactura = "CDF" + hoy.ToString("dd-MM-yyyy");
                factura.NameCliente = txtNombreCliente.Text;
                factura.Cedula = txtCedula.Text;
                factura.Codigo = item.Codigo;
                factura.Producto = item.Nombre;
                factura.Descripción = item.descripcion;
                factura.Precio = decimal.Parse(item.Precio.ToString());
                factura.Cantidad = int.Parse(item.Cantidad.ToString());
                factura.PrecioTotal =  decimal.Parse(item.Precio.ToString()) * decimal.Parse(item.Cantidad.ToString());
                factura.Tipofactura = cbTipoFactura.SelectedIndex;// int.Parse(cbTipoFactura.SelectedValue.ToString());
                factura.Fecha_crear = hoy;
                factura.Pago = 0;
                GenerarFactura(factura);
            }
            _detallesfactura.Clear();
            dgvDetalles.Rows.Clear();

        }

        private void GenerarFactura(Entidades.Factura factura)
        {
            _negocioFactura.InsentarFactura(factura);

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Inventario.Forms.FormMenuInventario formMenuInventario = new FormMenuInventario();
            formMenuInventario.Show();
            this.Close();
        }
    }
}
