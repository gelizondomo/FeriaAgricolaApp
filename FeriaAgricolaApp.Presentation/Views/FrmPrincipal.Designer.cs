namespace FeriaAgricolaApp.Presentation.Views
{
    partial class FrmPrincipal
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
            lblBienvenida = new Label();
            btnCatalogo = new Button();
            btnCarrito = new Button();
            btnFacturas = new Button();
            btnReportes = new Button();
            SuspendLayout();
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Location = new Point(220, 30);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(126, 15);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "Seleccione una opción";
            // 
            // btnCatalogo
            // 
            btnCatalogo.Location = new Point(180, 80);
            btnCatalogo.Name = "btnCatalogo";
            btnCatalogo.Size = new Size(200, 34);
            btnCatalogo.TabIndex = 1;
            btnCatalogo.Text = "Catálogo de Productos";
            btnCatalogo.Click += BtnCatalogo_Click;
            // 
            // btnCarrito
            // 
            btnCarrito.Location = new Point(180, 130);
            btnCarrito.Name = "btnCarrito";
            btnCarrito.Size = new Size(200, 34);
            btnCarrito.TabIndex = 2;
            btnCarrito.Text = "Carrito de Compras";
            btnCarrito.Click += BtnCarrito_Click;
            // 
            // btnFacturas
            // 
            btnFacturas.Location = new Point(180, 180);
            btnFacturas.Name = "btnFacturas";
            btnFacturas.Size = new Size(200, 34);
            btnFacturas.TabIndex = 3;
            btnFacturas.Text = "Facturas";
            btnFacturas.Click += BtnFacturas_Click;
            // 
            // btnReportes
            // 
            btnReportes.Location = new Point(180, 230);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(200, 34);
            btnReportes.TabIndex = 4;
            btnReportes.Text = "Reportes";
            btnReportes.Click += BtnReportes_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 310);
            Controls.Add(lblBienvenida);
            Controls.Add(btnCatalogo);
            Controls.Add(btnCarrito);
            Controls.Add(btnFacturas);
            Controls.Add(btnReportes);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmPrincipal";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBienvenida;
        private Button btnCatalogo;
        private Button btnCarrito;
        private Button btnFacturas;
        private Button btnReportes;
    }
}