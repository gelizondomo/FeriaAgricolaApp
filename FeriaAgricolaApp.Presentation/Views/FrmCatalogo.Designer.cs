namespace FeriaAgricolaApp.Presentation.Views
{
    partial class FrmCatalogo
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
            lblSearch = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvProductos = new DataGridView();
            btnAgregar = new Button();
            lblFeria = new Label();
            cmbFerias = new ComboBox();
            lblProveedor = new Label();
            cmbProveedores = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(300, 20);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(45, 15);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(360, 17);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(300, 23);
            txtBuscar.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(670, 15);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(80, 25);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.Click += BtnBuscar_Click;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.Location = new Point(20, 83);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(740, 352);
            dgvProductos.TabIndex = 3;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(20, 450);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(200, 30);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar al Carrito";
            btnAgregar.Click += BtnAgregar_Click;
            // 
            // lblFeria
            // 
            lblFeria.AutoSize = true;
            lblFeria.Location = new Point(20, 20);
            lblFeria.Name = "lblFeria";
            lblFeria.Size = new Size(35, 15);
            lblFeria.TabIndex = 5;
            lblFeria.Text = "Feria:";
            // 
            // cmbFerias
            // 
            cmbFerias.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFerias.Location = new Point(90, 17);
            cmbFerias.Name = "cmbFerias";
            cmbFerias.Size = new Size(200, 23);
            cmbFerias.TabIndex = 6;
            cmbFerias.SelectedIndexChanged += cmbFerias_SelectedIndexChanged;
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Location = new Point(20, 51);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(64, 15);
            lblProveedor.TabIndex = 7;
            lblProveedor.Text = "Proveedor:";
            lblProveedor.Click += label1_Click;
            // 
            // cmbProveedores
            // 
            cmbProveedores.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedores.Location = new Point(90, 48);
            cmbProveedores.Name = "cmbProveedores";
            cmbProveedores.Size = new Size(200, 23);
            cmbProveedores.TabIndex = 8;
            cmbProveedores.SelectedIndexChanged += cmbProveedores_SelectedIndexChanged;
            // 
            // FrmCatalogo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 500);
            Controls.Add(lblProveedor);
            Controls.Add(cmbProveedores);
            Controls.Add(lblSearch);
            Controls.Add(txtBuscar);
            Controls.Add(btnBuscar);
            Controls.Add(dgvProductos);
            Controls.Add(btnAgregar);
            Controls.Add(lblFeria);
            Controls.Add(cmbFerias);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmCatalogo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmCatalogo";
            Load += FrmCatalogoCarga;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblSearch;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvProductos;
        private Button btnAgregar;
        private Label lblFeria;
        private ComboBox cmbFerias;
        private Label lblProveedor;
        private ComboBox cmbProveedores;
    }
}