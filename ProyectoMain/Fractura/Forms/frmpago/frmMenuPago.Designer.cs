
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
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbTipoPago = new System.Windows.Forms.ComboBox();
            this.cbPagoPendiente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            this.CodigoFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_Crear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RealizarPago = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Desactivar = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(371, 45);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 0;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(488, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Salir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbTipoPago
            // 
            this.cbTipoPago.FormattingEnabled = true;
            this.cbTipoPago.Location = new System.Drawing.Point(55, 45);
            this.cbTipoPago.Name = "cbTipoPago";
            this.cbTipoPago.Size = new System.Drawing.Size(121, 21);
            this.cbTipoPago.TabIndex = 2;
            // 
            // cbPagoPendiente
            // 
            this.cbPagoPendiente.FormattingEnabled = true;
            this.cbPagoPendiente.Location = new System.Drawing.Point(202, 45);
            this.cbPagoPendiente.Name = "cbPagoPendiente";
            this.cbPagoPendiente.Size = new System.Drawing.Size(121, 21);
            this.cbPagoPendiente.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tipo de Pago";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pago Realizado o No";
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.AllowUserToAddRows = false;
            this.dgvFacturas.AllowUserToDeleteRows = false;
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoFactura,
            this.NameCliente,
            this.Cedula,
            this.Codigo,
            this.Descripcion,
            this.Precio,
            this.Cantidad,
            this.PrecioTotal,
            this.TipoFactura,
            this.Fecha_Crear,
            this.Pago,
            this.RealizarPago,
            this.Desactivar});
            this.dgvFacturas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvFacturas.Location = new System.Drawing.Point(0, 99);
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.ReadOnly = true;
            this.dgvFacturas.Size = new System.Drawing.Size(1337, 431);
            this.dgvFacturas.TabIndex = 6;
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
            // Cedula
            // 
            this.Cedula.HeaderText = "Direccion";
            this.Cedula.Name = "Cedula";
            this.Cedula.ReadOnly = true;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo del Producto";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // PrecioTotal
            // 
            this.PrecioTotal.HeaderText = "Precio Total";
            this.PrecioTotal.Name = "PrecioTotal";
            this.PrecioTotal.ReadOnly = true;
            // 
            // TipoFactura
            // 
            this.TipoFactura.HeaderText = "Tipo de Factura";
            this.TipoFactura.Name = "TipoFactura";
            this.TipoFactura.ReadOnly = true;
            // 
            // Fecha_Crear
            // 
            this.Fecha_Crear.HeaderText = "Fechar de Creacion";
            this.Fecha_Crear.Name = "Fecha_Crear";
            this.Fecha_Crear.ReadOnly = true;
            // 
            // Pago
            // 
            this.Pago.HeaderText = "Pago";
            this.Pago.Name = "Pago";
            this.Pago.ReadOnly = true;
            // 
            // RealizarPago
            // 
            this.RealizarPago.HeaderText = "RealizarPago";
            this.RealizarPago.Name = "RealizarPago";
            this.RealizarPago.ReadOnly = true;
            this.RealizarPago.Text = "Realizar Pago";
            this.RealizarPago.UseColumnTextForLinkValue = true;
            // 
            // Desactivar
            // 
            this.Desactivar.HeaderText = "Quitar";
            this.Desactivar.Name = "Desactivar";
            this.Desactivar.ReadOnly = true;
            this.Desactivar.Text = "Quitar";
            this.Desactivar.UseColumnTextForLinkValue = true;
            // 
            // frmMenuPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 530);
            this.Controls.Add(this.dgvFacturas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPagoPendiente);
            this.Controls.Add(this.cbTipoPago);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnFiltrar);
            this.Name = "frmMenuPago";
            this.Text = "frmMenuPago";
            this.Load += new System.EventHandler(this.frmMenuPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbTipoPago;
        private System.Windows.Forms.ComboBox cbPagoPendiente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Crear;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pago;
        private System.Windows.Forms.DataGridViewLinkColumn RealizarPago;
        private System.Windows.Forms.DataGridViewLinkColumn Desactivar;
    }
}