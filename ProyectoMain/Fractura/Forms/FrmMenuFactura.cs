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
            cbTipoFactura.Items.Add("Credito");
            cbTipoFactura.Items.Add("Envio");
            cbTipoFactura.SelectedIndex = 0;

        }

        private void FrmMenuFactura_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'ferreteriaDataSet1.inventario' Puede moverla o quitarla según sea necesario.

            try
            {
                //  this.inventarioTableAdapter.Fill(this.ferreteriaDataSet1.inventario);
                CargarDatos(txtBuscar.Text);
            }
            catch (Exception)
            {


            }

        }

        private void CargarDatos(string buscar)
        {
            // this.inventarioTableAdapter.Fill(this.ferreteriaDataSet1.inventario);
            botonValidos();
            var consulta = _inventarioNegocio.TenerInventarios(buscar);
            foreach (var item in consulta)
            {
                gridInventario.Rows.Add(item.Codigo, item.Nombre + " " + item.descripcion, item.Precio, item.Cantidad);
            }
        }

        private void botonValidos()
        {
            if (_detallesfactura.Count != 0)
            {
                btnGenerar.Enabled = true;
            }
            else
            {
                btnGenerar.Enabled = false;
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //((FormMenuInventario)this.Owner).Close();
        }



        private void gridInventario_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataGridViewLinkCell cell = (DataGridViewLinkCell)gridInventario.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell.Value.ToString() == "Agregar")
                {
                    frmdetallesfactura detallesfactura = new frmdetallesfactura();
                    detallesfactura.CargarInventario(new Inventario.Entidades.Inventario
                    {
                        // Id = int.Parse(gridInventario.Rows[e.RowIndex].Cells[0].Value.ToString()),
                        Codigo = gridInventario.Rows[e.RowIndex].Cells[0].Value.ToString(),
                        // Nombre = gridInventario.Rows[e.RowIndex].Cells[2].Value.ToString(),
                        descripcion = gridInventario.Rows[e.RowIndex].Cells[1].Value.ToString(),
                        Precio = decimal.Parse(gridInventario.Rows[e.RowIndex].Cells[2].Value.ToString()),
                        Cantidad = int.Parse(gridInventario.Rows[e.RowIndex].Cells[3].Value.ToString()),

                    });

                    detallesfactura.ShowDialog(this);
                }

            }
            catch (Exception)
            {

                //throw;
            }
        }

        public void cargardetalles(Inventario.Entidades.Inventario inventario)
        {
            dgvDetalles.Rows.Clear();
            _detallesfactura.Add(inventario);
            foreach (var item in _detallesfactura)
            {
                dgvDetalles.Rows.Add(item.Codigo.ToString(), item.Nombre.ToString() + " " + item.descripcion.ToString(), item.Precio.ToString(), item.Cantidad.ToString(), (item.Precio * item.Cantidad).ToString());
            }
            botonValidos();
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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
                    botonValidos();
                }

            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            // int a = cbTipoFactura.SelectedIndex;
            DialogResult dr = MessageBox.Show("¿Estas Seguro?", "Aviso De Generar Factura", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                DateTime hoy = DateTime.Today;
                foreach (var item in _detallesfactura)
                {
                    Inventario.Entidades.Inventario inventario = new Inventario.Entidades.Inventario();
                    Entidades.Factura factura = new Entidades.Factura();
                    factura.Codigofactura = "CDF" + hoy.ToString("dd-MM-yyyy");
                    factura.NameCliente = txtNombreCliente.Text;
                    factura.Cedula = txtDireccion.Text;
                    factura.Codigo = item.Codigo;
                    factura.Producto = item.Nombre;
                    factura.Descripción = item.descripcion;
                    factura.Precio = decimal.Parse(item.Precio.ToString());
                    factura.Cantidad = int.Parse(item.Cantidad.ToString());
                    factura.PrecioTotal =  decimal.Parse(item.Precio.ToString()) * decimal.Parse(item.Cantidad.ToString());
                    factura.Tipofactura = cbTipoFactura.SelectedIndex;// int.Parse(cbTipoFactura.SelectedValue.ToString());
                    factura.Fecha_crear = hoy;
                    factura.Pago = 0;

                    inventario.Cantidad = int.Parse(item.Cantidad.ToString());
                    inventario.Codigo = item.Codigo;

                    GenerarFactura(factura);
                    ReducirInventario(inventario);

                }
                gridInventario.Rows.Clear() ;
                CargarDatos(txtBuscar.Text);
                _detallesfactura.Clear();
                dgvDetalles.Rows.Clear();

                MessageBox.Show("Factura Generada","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }

        private void GenerarFactura(Entidades.Factura factura)
        {
            _negocioFactura.InsentarFactura(factura);

        }

        private void ReducirInventario(Inventario.Entidades.Inventario inventario)
        {
            _inventarioNegocio.ReducirExistenciaInventario(inventario);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Inventario.Forms.FormMenuInventario formMenuInventario = new FormMenuInventario();
            formMenuInventario.Show();
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            gridInventario.Rows.Clear();
            CargarDatos(txtBuscar.Text);
        }
    }
}
