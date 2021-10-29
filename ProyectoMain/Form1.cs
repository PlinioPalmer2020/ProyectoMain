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
            IsLogin();
        }

        private void IsLogin()
        {
            var login = _loginNegocio.isLogin(txtUsuario.Text, txtContraseña.Text);

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
                            frmMenuFactura.Login = item.rol;
                            frmMenuFactura.Show();
                            this.Hide();
                            break;

                        case "caja":
                            Fractura.Forms.frmpago.frmMenuPago frmMenuPago = new Fractura.Forms.frmpago.frmMenuPago();
                            frmMenuPago.login = item.rol;
                            frmMenuPago.Show();
                            this.Hide();
                            break;

                        case "mixto":
                            Fractura.Forms.FrmMenuFactura frmMenu = new Fractura.Forms.FrmMenuFactura();
                            frmMenu.Login = item.rol;
                            frmMenu.Show();
                            this.Hide();

                            break;

                    }
                }
            }
            else
            {
                MessageBox.Show("El Usuario o Contraseña esta incorrecta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }
        #region Fuciones para salir de la aplicacion
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region KeyPress
        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                IsLogin();
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                IsLogin();
            }
        }

        #endregion

    }
}
