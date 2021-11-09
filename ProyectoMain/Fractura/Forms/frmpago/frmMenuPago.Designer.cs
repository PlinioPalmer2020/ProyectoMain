
namespace ProyectoMain.Fractura.Forms.frmpago
{
    partial class frmMenuPago
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuPago));
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbTipoPago = new System.Windows.Forms.ComboBox();
            this.cbPagoPendiente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            this.btnVolverFactura = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.CodigoFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_Crear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RealizarPago = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Detalles = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Desactivar = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.panelFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(300, 42);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(169, 23);
            this.btnFiltrar.TabIndex = 0;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(720, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Volver al Inventario";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbTipoPago
            // 
            this.cbTipoPago.FormattingEnabled = true;
            this.cbTipoPago.Location = new System.Drawing.Point(26, 44);
            this.cbTipoPago.Name = "cbTipoPago";
            this.cbTipoPago.Size = new System.Drawing.Size(121, 21);
            this.cbTipoPago.TabIndex = 2;
            // 
            // cbPagoPendiente
            // 
            this.cbPagoPendiente.FormattingEnabled = true;
            this.cbPagoPendiente.Location = new System.Drawing.Point(173, 44);
            this.cbPagoPendiente.Name = "cbPagoPendiente";
            this.cbPagoPendiente.Size = new System.Drawing.Size(121, 21);
            this.cbPagoPendiente.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tipo de Pago";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pago Realizado o No";
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.AllowUserToAddRows = false;
            this.dgvFacturas.AllowUserToDeleteRows = false;
            this.dgvFacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoFactura,
            this.NameCliente,
            this.TipoFactura,
            this.Fecha_Crear,
            this.Pago,
            this.RealizarPago,
            this.Detalles,
            this.Desactivar});
            this.dgvFacturas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvFacturas.Location = new System.Drawing.Point(0, 149);
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.ReadOnly = true;
            this.dgvFacturas.Size = new System.Drawing.Size(854, 381);
            this.dgvFacturas.TabIndex = 6;
            this.dgvFacturas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacturas_CellContentClick);
            this.dgvFacturas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFacturas_CellFormatting);
            // 
            // btnVolverFactura
            // 
            this.btnVolverFactura.Location = new System.Drawing.Point(720, 60);
            this.btnVolverFactura.Name = "btnVolverFactura";
            this.btnVolverFactura.Size = new System.Drawing.Size(106, 23);
            this.btnVolverFactura.TabIndex = 7;
            this.btnVolverFactura.Text = "Volver A Factura";
            this.btnVolverFactura.UseVisualStyleBackColor = true;
            this.btnVolverFactura.Click += new System.EventHandler(this.btnVolverFactura_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(574, 25);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(107, 23);
            this.btnCerrarSesion.TabIndex = 8;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // panelFiltros
            // 
            this.panelFiltros.Controls.Add(this.label3);
            this.panelFiltros.Controls.Add(this.btnBuscar);
            this.panelFiltros.Controls.Add(this.txtBuscar);
            this.panelFiltros.Controls.Add(this.label1);
            this.panelFiltros.Controls.Add(this.btnFiltrar);
            this.panelFiltros.Controls.Add(this.cbTipoPago);
            this.panelFiltros.Controls.Add(this.cbPagoPendiente);
            this.panelFiltros.Controls.Add(this.label2);
            this.panelFiltros.Location = new System.Drawing.Point(0, 0);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(568, 143);
            this.panelFiltros.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(23, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Buscar:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(387, 116);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(82, 23);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "  Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(89, 119);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(292, 20);
            this.txtBuscar.TabIndex = 6;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // CodigoFactura
            // 
            this.CodigoFactura.HeaderText = "Codigo Factura";
            this.CodigoFactura.Name = "CodigoFactura";
            this.CodigoFactura.ReadOnly = true;
            // 
            // NameCliente
            // 
            this.NameCliente.HeaderText = "Nombre del Cliente";
            this.NameCliente.Name = "NameCliente";
            this.NameCliente.ReadOnly = true;
            // 
            // TipoFactura
            // 
            this.TipoFactura.HeaderText = "Tipo de Factura";
            this.TipoFactura.Name = "TipoFactura";
            this.TipoFactura.ReadOnly = true;
            // 
            // Fecha_Crear
            // 
            this.Fecha_Crear.HeaderText = "Fecha de Creacion";
            this.Fecha_Crear.Name = "Fecha_Crear";
            this.Fecha_Crear.ReadOnly = true;
            // 
            // Pago
            // 
            this.Pago.HeaderText = "Estado";
            this.Pago.Name = "Pago";
            this.Pago.ReadOnly = true;
            // 
            // RealizarPago
            // 
            this.RealizarPago.HeaderText = "Realizar Pago";
            this.RealizarPago.Name = "RealizarPago";
            this.RealizarPago.ReadOnly = true;
            this.RealizarPago.Text = "Realizar Pago";
            this.RealizarPago.UseColumnTextForLinkValue = true;
            // 
            // Detalles
            // 
            this.Detalles.HeaderText = "Detalles";
            this.Detalles.Name = "Detalles";
            this.Detalles.ReadOnly = true;
            this.Detalles.Text = "Detalles";
            this.Detalles.UseColumnTextForLinkValue = true;
            // 
            // Desactivar
            // 
            this.Desactivar.HeaderText = "Quitar";
            this.Desactivar.Name = "Desactivar";
            this.Desactivar.ReadOnly = true;
            this.Desactivar.Text = "Quitar";
            this.Desactivar.UseColumnTextForLinkValue = true;
            this.Desactivar.Visible = false;
            // 
            // frmMenuPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 530);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnVolverFactura);
            this.Controls.Add(this.dgvFacturas);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmMenuPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu de Facturas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMenuPago_FormClosing);
            this.Load += new System.EventHandler(this.frmMenuPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbTipoPago;
        private System.Windows.Forms.ComboBox cbPagoPendiente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.Button btnVolverFactura;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Crear;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pago;
        private System.Windows.Forms.DataGridViewLinkColumn RealizarPago;
        private System.Windows.Forms.DataGridViewLinkColumn Detalles;
        private System.Windows.Forms.DataGridViewLinkColumn Desactivar;
    }
}