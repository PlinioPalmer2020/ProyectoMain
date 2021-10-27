using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMain
{
    public partial class Form1 : Form
    {
        Login.Negocio.LoginNegocio _loginNegocio;
        public Form1()
        {
            InitializeComponent();
            _loginNegocio = new Login.Negocio.LoginNegocio();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            var login = _loginNegocio.isLogin(txtUsuario.Text,txtContraseña.Text);

            if (login.Count != 0)
            {
                foreach (var item in login)
                {
                    switch (item.rol)
                    {
                        case "admin":
                            Inventario.Forms.FormMenuInventario formMenuInventario = new Inventario.Forms.FormMenuInventario();
                            formMenuInventario.Show();
                            this.Hide();
                            break;
                        case "factura":
                            Fractura.Forms.FrmMenuFactura frmMenuFactura = new Fractura.Forms.FrmMenuFactura();
                            frmMenuFactura.Show();
                            this.Hide();
                            break;

                        case "caja":
                            Fractura.Forms.frmpago.frmMenuPago frmMenuPago = new Fractura.Forms.frmpago.frmMenuPago();
                            frmMenuPago.Show();
                            this.Hide();
                            break;
                        
                    }
                }
            }
            else
            {
                MessageBox.Show("El Usuario o Contraseña esta incorrecta","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
