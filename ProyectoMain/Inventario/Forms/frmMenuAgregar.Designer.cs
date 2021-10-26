
namespace ProyectoMain.Inventario.Forms
{
    partial class frmMenuAgregar
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
            this.btnAgregarArenas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAgregarArenas
            // 
            this.btnAgregarArenas.Location = new System.Drawing.Point(28, 58);
            this.btnAgregarArenas.Name = "btnAgregarArenas";
            this.btnAgregarArenas.Size = new System.Drawing.Size(100, 23);
            this.btnAgregarArenas.TabIndex = 0;
            this.btnAgregarArenas.Text = "Agregar Arenas";
            this.btnAgregarArenas.UseVisualStyleBackColor = true;
            this.btnAgregarArenas.Click += new System.EventHandler(this.btnAgregarArenas_Click);
            // 
            // frmMenuAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 276);
            this.Controls.Add(this.btnAgregarArenas);
            this.Name = "frmMenuAgregar";
            this.Text = "frmMenuAgregar";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarArenas;
    }
}