
namespace ProyectoMain.Inventario.Forms.Registro
{
    partial class frmMenuRegistroEntrada
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
            this.dgvRegistroEntrada = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comprado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_de_Entrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroEntrada)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRegistroEntrada
            // 
            this.dgvRegistroEntrada.AllowUserToAddRows = false;
            this.dgvRegistroEntrada.AllowUserToDeleteRows = false;
            this.dgvRegistroEntrada.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRegistroEntrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistroEntrada.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Tipo_Producto,
            this.Descripcion,
            this.Comprado,
            this.Precio,
            this.Unidad,
            this.Fecha_de_Entrada});
            this.dgvRegistroEntrada.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvRegistroEntrada.Location = new System.Drawing.Point(0, 142);
            this.dgvRegistroEntrada.Name = "dgvRegistroEntrada";
            this.dgvRegistroEntrada.ReadOnly = true;
            this.dgvRegistroEntrada.Size = new System.Drawing.Size(800, 308);
            this.dgvRegistroEntrada.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "#";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // Tipo_Producto
            // 
            this.Tipo_Producto.HeaderText = "Tipo de Producto";
            this.Tipo_Producto.Name = "Tipo_Producto";
            this.Tipo_Producto.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Comprado
            // 
            this.Comprado.HeaderText = "Comprado";
            this.Comprado.Name = "Comprado";
            this.Comprado.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // Unidad
            // 
            this.Unidad.HeaderText = "Unidad";
            this.Unidad.Name = "Unidad";
            this.Unidad.ReadOnly = true;
            // 
            // Fecha_de_Entrada
            // 
            this.Fecha_de_Entrada.HeaderText = "Fecha de Entrada";
            this.Fecha_de_Entrada.Name = "Fecha_de_Entrada";
            this.Fecha_de_Entrada.ReadOnly = true;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(725, 13);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // frmMenuRegistroEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dgvRegistroEntrada);
            this.Name = "frmMenuRegistroEntrada";
            this.Text = "Registro de entrada";
            this.Load += new System.EventHandler(this.frmMenuRegistroEntrada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroEntrada)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRegistroEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comprado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_de_Entrada;
        private System.Windows.Forms.Button btnVolver;
    }
}