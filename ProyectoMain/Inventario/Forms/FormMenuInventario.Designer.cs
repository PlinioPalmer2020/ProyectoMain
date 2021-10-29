
namespace ProyectoMain.Inventario.Forms
{
    partial class FormMenuInventario
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
            this.components = new System.ComponentModel.Container();
            this.gridInventario = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comprado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Añadir = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Modificar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.inventarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ferreteriaDataSet = new ProyectoMain.FerreteriaDataSet();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnHistoria = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.inventarioTableAdapter = new ProyectoMain.FerreteriaDataSetTableAdapters.inventarioTableAdapter();
            this.btnFacturacion = new System.Windows.Forms.Button();
            this.btnPagos = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnContabidad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ferreteriaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // gridInventario
            // 
            this.gridInventario.AllowUserToAddRows = false;
            this.gridInventario.AllowUserToDeleteRows = false;
            this.gridInventario.AutoGenerateColumns = false;
            this.gridInventario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridInventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.codigoDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.precioDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.tipoProducto,
            this.Comprado,
            this.Añadir,
            this.Modificar,
            this.Eliminar});
            this.gridInventario.DataSource = this.inventarioBindingSource;
            this.gridInventario.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridInventario.Location = new System.Drawing.Point(0, 135);
            this.gridInventario.Name = "gridInventario";
            this.gridInventario.ReadOnly = true;
            this.gridInventario.Size = new System.Drawing.Size(951, 315);
            this.gridInventario.TabIndex = 0;
            this.gridInventario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridInventario_CellContentClick);
            this.gridInventario.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridInventario_CellFormatting);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            this.codigoDataGridViewTextBoxColumn.DataPropertyName = "codigo";
            this.codigoDataGridViewTextBoxColumn.HeaderText = "codigo";
            this.codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            this.codigoDataGridViewTextBoxColumn.ReadOnly = true;
            this.codigoDataGridViewTextBoxColumn.Visible = false;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioDataGridViewTextBoxColumn
            // 
            this.precioDataGridViewTextBoxColumn.DataPropertyName = "precio";
            this.precioDataGridViewTextBoxColumn.HeaderText = "precio";
            this.precioDataGridViewTextBoxColumn.Name = "precioDataGridViewTextBoxColumn";
            this.precioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipoProducto
            // 
            this.tipoProducto.DataPropertyName = "tipo_de_producto";
            this.tipoProducto.HeaderText = "Tipo De Producto";
            this.tipoProducto.Name = "tipoProducto";
            this.tipoProducto.ReadOnly = true;
            this.tipoProducto.Visible = false;
            // 
            // Comprado
            // 
            this.Comprado.DataPropertyName = "comprado";
            this.Comprado.HeaderText = "Comprado";
            this.Comprado.Name = "Comprado";
            this.Comprado.ReadOnly = true;
            this.Comprado.Visible = false;
            // 
            // Añadir
            // 
            this.Añadir.HeaderText = "Añadir";
            this.Añadir.Name = "Añadir";
            this.Añadir.ReadOnly = true;
            this.Añadir.Text = "Añadir";
            this.Añadir.UseColumnTextForLinkValue = true;
            // 
            // Modificar
            // 
            this.Modificar.HeaderText = "Modificar";
            this.Modificar.Name = "Modificar";
            this.Modificar.ReadOnly = true;
            this.Modificar.Text = "Modificar";
            this.Modificar.UseColumnTextForLinkValue = true;
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseColumnTextForLinkValue = true;
            // 
            // inventarioBindingSource
            // 
            this.inventarioBindingSource.DataMember = "inventario";
            this.inventarioBindingSource.DataSource = this.ferreteriaDataSet;
            // 
            // ferreteriaDataSet
            // 
            this.ferreteriaDataSet.DataSetName = "FerreteriaDataSet";
            this.ferreteriaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(368, 92);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(449, 92);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(148, 23);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar nuevo producto";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnHistoria
            // 
            this.btnHistoria.Location = new System.Drawing.Point(680, 65);
            this.btnHistoria.Name = "btnHistoria";
            this.btnHistoria.Size = new System.Drawing.Size(126, 20);
            this.btnHistoria.TabIndex = 3;
            this.btnHistoria.Text = "Historial de Entrada";
            this.btnHistoria.UseVisualStyleBackColor = true;
            this.btnHistoria.Click += new System.EventHandler(this.btnHistoria_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Buscar";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(56, 92);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(306, 20);
            this.txtBuscar.TabIndex = 5;
            // 
            // inventarioTableAdapter
            // 
            this.inventarioTableAdapter.ClearBeforeFill = true;
            // 
            // btnFacturacion
            // 
            this.btnFacturacion.Location = new System.Drawing.Point(680, 36);
            this.btnFacturacion.Name = "btnFacturacion";
            this.btnFacturacion.Size = new System.Drawing.Size(126, 23);
            this.btnFacturacion.TabIndex = 6;
            this.btnFacturacion.Text = "Facturacion";
            this.btnFacturacion.UseVisualStyleBackColor = true;
            this.btnFacturacion.Click += new System.EventHandler(this.btnFacturacion_Click);
            // 
            // btnPagos
            // 
            this.btnPagos.Location = new System.Drawing.Point(680, 91);
            this.btnPagos.Name = "btnPagos";
            this.btnPagos.Size = new System.Drawing.Size(126, 23);
            this.btnPagos.TabIndex = 7;
            this.btnPagos.Text = "Caja";
            this.btnPagos.UseVisualStyleBackColor = true;
            this.btnPagos.Click += new System.EventHandler(this.btnPagos_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(812, 90);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(126, 23);
            this.btnCerrarSesion.TabIndex = 8;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnContabidad
            // 
            this.btnContabidad.Location = new System.Drawing.Point(812, 36);
            this.btnContabidad.Name = "btnContabidad";
            this.btnContabidad.Size = new System.Drawing.Size(126, 48);
            this.btnContabidad.TabIndex = 9;
            this.btnContabidad.Text = "Contabilidad y Reportes";
            this.btnContabidad.UseVisualStyleBackColor = true;
            this.btnContabidad.Click += new System.EventHandler(this.btnContabidad_Click);
            // 
            // FormMenuInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 450);
            this.Controls.Add(this.btnContabidad);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnPagos);
            this.Controls.Add(this.btnFacturacion);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHistoria);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.gridInventario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMenuInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMenuInventario_FormClosing);
            this.Load += new System.EventHandler(this.FormMenuInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ferreteriaDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridInventario;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnHistoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
        private FerreteriaDataSet ferreteriaDataSet;
        private System.Windows.Forms.BindingSource inventarioBindingSource;
        private FerreteriaDataSetTableAdapters.inventarioTableAdapter inventarioTableAdapter;
        private System.Windows.Forms.Button btnFacturacion;
        private System.Windows.Forms.Button btnPagos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comprado;
        private System.Windows.Forms.DataGridViewLinkColumn Añadir;
        private System.Windows.Forms.DataGridViewLinkColumn Modificar;
        private System.Windows.Forms.DataGridViewLinkColumn Eliminar;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnContabidad;
    }
}