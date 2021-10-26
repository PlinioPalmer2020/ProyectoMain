
namespace ProyectoMain.Fractura.Forms
{
    partial class FrmMenuFactura
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelAgregar = new System.Windows.Forms.Panel();
            this.gridInventario = new System.Windows.Forms.DataGridView();
            this.Codi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Canti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Agregar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panelFactura = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.cbTipoFactura = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoProductoDetalles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quitar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.panelAgregar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventario)).BeginInit();
            this.panelFactura.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(6, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(48, 171);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(428, 20);
            this.txtBuscar.TabIndex = 4;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(482, 168);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(518, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "salir del programa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panelAgregar
            // 
            this.panelAgregar.BackColor = System.Drawing.Color.Gainsboro;
            this.panelAgregar.Controls.Add(this.gridInventario);
            this.panelAgregar.Controls.Add(this.panelFactura);
            this.panelAgregar.Controls.Add(this.txtBuscar);
            this.panelAgregar.Controls.Add(this.btnBuscar);
            this.panelAgregar.Controls.Add(this.label1);
            this.panelAgregar.Location = new System.Drawing.Point(3, 3);
            this.panelAgregar.Name = "panelAgregar";
            this.panelAgregar.Size = new System.Drawing.Size(657, 588);
            this.panelAgregar.TabIndex = 7;
            // 
            // gridInventario
            // 
            this.gridInventario.AllowUserToAddRows = false;
            this.gridInventario.AllowUserToDeleteRows = false;
            this.gridInventario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridInventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codi,
            this.Descri,
            this.Preci,
            this.Canti,
            this.Unidad,
            this.tipoProducto,
            this.Agregar});
            this.gridInventario.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridInventario.Location = new System.Drawing.Point(0, 197);
            this.gridInventario.Name = "gridInventario";
            this.gridInventario.ReadOnly = true;
            this.gridInventario.Size = new System.Drawing.Size(657, 391);
            this.gridInventario.TabIndex = 8;
            this.gridInventario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridInventario_CellContentClick_1);
            this.gridInventario.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridInventario_CellFormatting);
            // 
            // Codi
            // 
            this.Codi.HeaderText = "Codigo";
            this.Codi.Name = "Codi";
            this.Codi.ReadOnly = true;
            this.Codi.Visible = false;
            // 
            // Descri
            // 
            this.Descri.HeaderText = "Descripcion";
            this.Descri.Name = "Descri";
            this.Descri.ReadOnly = true;
            // 
            // Preci
            // 
            this.Preci.HeaderText = "Precio";
            this.Preci.Name = "Preci";
            this.Preci.ReadOnly = true;
            // 
            // Canti
            // 
            this.Canti.HeaderText = "Cantidad";
            this.Canti.Name = "Canti";
            this.Canti.ReadOnly = true;
            // 
            // Unidad
            // 
            this.Unidad.HeaderText = "Unidad";
            this.Unidad.Name = "Unidad";
            this.Unidad.ReadOnly = true;
            // 
            // tipoProducto
            // 
            this.tipoProducto.HeaderText = "Tipo De Producto";
            this.tipoProducto.Name = "tipoProducto";
            this.tipoProducto.ReadOnly = true;
            this.tipoProducto.Visible = false;
            // 
            // Agregar
            // 
            this.Agregar.HeaderText = "Agregar";
            this.Agregar.Name = "Agregar";
            this.Agregar.ReadOnly = true;
            this.Agregar.Text = "Agregar";
            this.Agregar.UseColumnTextForLinkValue = true;
            // 
            // panelFactura
            // 
            this.panelFactura.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelFactura.Controls.Add(this.btnSalir);
            this.panelFactura.Controls.Add(this.cbTipoFactura);
            this.panelFactura.Controls.Add(this.label5);
            this.panelFactura.Controls.Add(this.label3);
            this.panelFactura.Controls.Add(this.label2);
            this.panelFactura.Controls.Add(this.button2);
            this.panelFactura.Controls.Add(this.txtDireccion);
            this.panelFactura.Controls.Add(this.txtNombreCliente);
            this.panelFactura.Location = new System.Drawing.Point(9, 31);
            this.panelFactura.Name = "panelFactura";
            this.panelFactura.Size = new System.Drawing.Size(645, 125);
            this.panelFactura.TabIndex = 7;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(542, 91);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // cbTipoFactura
            // 
            this.cbTipoFactura.FormattingEnabled = true;
            this.cbTipoFactura.Location = new System.Drawing.Point(106, 99);
            this.cbTipoFactura.Name = "cbTipoFactura";
            this.cbTipoFactura.Size = new System.Drawing.Size(121, 21);
            this.cbTipoFactura.TabIndex = 8;
            this.cbTipoFactura.SelectedIndexChanged += new System.EventHandler(this.cbTipoFactura_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Tipos de Factura";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Direccion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre del Cliente";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(106, 59);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(225, 20);
            this.txtDireccion.TabIndex = 1;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(106, 14);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(225, 20);
            this.txtNombreCliente.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Controls.Add(this.btnGenerar);
            this.panel1.Controls.Add(this.dgvDetalles);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(666, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 588);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblTotal);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 556);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(684, 32);
            this.panel2.TabIndex = 4;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotal.Location = new System.Drawing.Point(600, 10);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(25, 15);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "null";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(549, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "TOTAL:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(460, 26);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(176, 26);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(157, 23);
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Text = "Generar Facturar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Descripcion,
            this.Precio,
            this.Cantidad,
            this.Unidad1,
            this.PrecioTotal,
            this.tipoProductoDetalles,
            this.Quitar});
            this.dgvDetalles.Location = new System.Drawing.Point(0, 83);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.Size = new System.Drawing.Size(681, 471);
            this.dgvDetalles.TabIndex = 1;
            this.dgvDetalles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalles_CellContentClick);
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Visible = false;
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
            // Unidad1
            // 
            this.Unidad1.HeaderText = "Unidad";
            this.Unidad1.Name = "Unidad1";
            this.Unidad1.ReadOnly = true;
            // 
            // PrecioTotal
            // 
            this.PrecioTotal.HeaderText = "Precio Total";
            this.PrecioTotal.Name = "PrecioTotal";
            this.PrecioTotal.ReadOnly = true;
            // 
            // tipoProductoDetalles
            // 
            this.tipoProductoDetalles.HeaderText = "Tipo de Producto";
            this.tipoProductoDetalles.Name = "tipoProductoDetalles";
            this.tipoProductoDetalles.ReadOnly = true;
            this.tipoProductoDetalles.Visible = false;
            // 
            // Quitar
            // 
            this.Quitar.HeaderText = "Quitar";
            this.Quitar.Name = "Quitar";
            this.Quitar.ReadOnly = true;
            this.Quitar.Text = "Quitar";
            this.Quitar.UseColumnTextForLinkValue = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Productos Agregados";
            // 
            // FrmMenuFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 603);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelAgregar);
            this.Name = "FrmMenuFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu de Factura";
            this.Load += new System.EventHandler(this.FrmMenuFactura_Load);
            this.panelAgregar.ResumeLayout(false);
            this.panelAgregar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventario)).EndInit();
            this.panelFactura.ResumeLayout(false);
            this.panelFactura.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panelAgregar;
        private System.Windows.Forms.Panel panelFactura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.ComboBox cbTipoFactura;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView gridInventario;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descri;
        private System.Windows.Forms.DataGridViewTextBoxColumn Preci;
        private System.Windows.Forms.DataGridViewTextBoxColumn Canti;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoProducto;
        private System.Windows.Forms.DataGridViewLinkColumn Agregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoProductoDetalles;
        private System.Windows.Forms.DataGridViewLinkColumn Quitar;
    }
}