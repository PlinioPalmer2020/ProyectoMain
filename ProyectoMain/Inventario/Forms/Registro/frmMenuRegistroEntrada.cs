using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMain.Inventario.Forms.Registro
{
    public partial class frmMenuRegistroEntrada : Form
    {
        private Negocio.RegistroNegocio _registroNegocio;
        public frmMenuRegistroEntrada()
        {
            InitializeComponent();
            _registroNegocio = new Negocio.RegistroNegocio();
        }

        private void frmMenuRegistroEntrada_Load(object sender, EventArgs e)
        {
            CargarRegistros(string.Empty);
        }

        #region Funciones
        private void CargarRegistros(string buscar) 
        {
            var registros = _registroNegocio.TenerRegistro(buscar);

            foreach (var item in registros)
            {
                dgvRegistroEntrada.Rows.Add(item.id,item.tipo_de_producto,item.nombre +" "+ item.descripcion,item.comprado.ToString(),item.precio,item.unidad,item.fecha_entrada);
            }
        }
        #endregion

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormMenuInventario formMenuInventario = new FormMenuInventario();
            formMenuInventario.Show();
            this.Close();
        }
    }
}
