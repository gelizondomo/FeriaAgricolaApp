namespace FeriaAgricolaApp.Presentation.Views
{
    partial class FrmCarrito
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
            dgvCarrito = new DataGridView();
            btnEliminar = new Button();
            btnComprar = new Button();
            lblDireccion = new Label();
            txtDireccion = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            SuspendLayout();
            // 
            // dgvCarrito
            // 
            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.AllowUserToDeleteRows = false;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Location = new Point(20, 20);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.ReadOnly = true;
            dgvCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarrito.Size = new Size(640, 300);
            dgvCarrito.TabIndex = 0;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(20, 380);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(200, 30);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar seleccionado";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnComprar
            // 
            btnComprar.Location = new Point(240, 380);
            btnComprar.Name = "btnComprar";
            btnComprar.Size = new Size(200, 30);
            btnComprar.TabIndex = 4;
            btnComprar.Text = "Procesar compra";
            btnComprar.Click += btnComprar_Click;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Segoe UI", 9F);
            lblDireccion.Location = new Point(20, 340);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(119, 15);
            lblDireccion.TabIndex = 1;
            lblDireccion.Text = "Dirección de entrega:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(150, 337);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(320, 23);
            txtDireccion.TabIndex = 2;
            // 
            // FrmCarrito
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 430);
            Controls.Add(dgvCarrito);
            Controls.Add(lblDireccion);
            Controls.Add(txtDireccion);
            Controls.Add(btnEliminar);
            Controls.Add(btnComprar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmCarrito";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmCarrito";
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
    }
}