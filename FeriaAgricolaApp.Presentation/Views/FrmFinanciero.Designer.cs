namespace FeriaAgricolaApp.Presentation.Views
{
    partial class FrmFinanciero
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
            tabControl = new TabControl();
            tabFacturas = new TabPage();
            dgvFacturas = new DataGridView();
            tabReportes = new TabPage();
            cmbMes = new ComboBox();
            cmbAnno = new ComboBox();
            btnCalcular = new Button();
            lblResultado = new Label();
            btnTopProductos = new Button();
            dgvTopProductos = new DataGridView();
            tabControl.SuspendLayout();
            tabFacturas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
            tabReportes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopProductos).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabFacturas);
            tabControl.Controls.Add(tabReportes);
            tabControl.Location = new Point(15, 15);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(700, 420);
            tabControl.TabIndex = 0;
            // 
            // tabFacturas
            // 
            tabFacturas.Controls.Add(dgvFacturas);
            tabFacturas.Location = new Point(4, 24);
            tabFacturas.Name = "tabFacturas";
            tabFacturas.Size = new Size(692, 392);
            tabFacturas.TabIndex = 0;
            tabFacturas.Text = "Facturas";
            // 
            // dgvFacturas
            // 
            dgvFacturas.Location = new Point(10, 10);
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.ReadOnly = true;
            dgvFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFacturas.Size = new Size(660, 360);
            dgvFacturas.TabIndex = 0;
            // 
            // tabReportes
            // 
            tabReportes.Controls.Add(cmbMes);
            tabReportes.Controls.Add(cmbAnno);
            tabReportes.Controls.Add(btnCalcular);
            tabReportes.Controls.Add(lblResultado);
            tabReportes.Controls.Add(btnTopProductos);
            tabReportes.Controls.Add(dgvTopProductos);
            tabReportes.Location = new Point(4, 24);
            tabReportes.Name = "tabReportes";
            tabReportes.Size = new Size(692, 392);
            tabReportes.TabIndex = 1;
            tabReportes.Text = "Reportes";
            // 
            // cmbMes
            // 
            cmbMes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMes.Items.AddRange(new object[] { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Setiembre", "Octubre", "Noviembre", "Diciembre" });
            cmbMes.Location = new Point(20, 20);
            cmbMes.Name = "cmbMes";
            cmbMes.Size = new Size(121, 23);
            cmbMes.TabIndex = 0;
            // 
            // cmbAnno
            // 
            cmbAnno.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAnno.Location = new Point(200, 20);
            cmbAnno.Name = "cmbAnno";
            cmbAnno.Size = new Size(121, 23);
            cmbAnno.TabIndex = 1;
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(400, 18);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(75, 23);
            btnCalcular.TabIndex = 2;
            btnCalcular.Text = "Calcular total del mes";
            btnCalcular.Click += btnCalcular_Click;
            // 
            // lblResultado
            // 
            lblResultado.Location = new Point(20, 60);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(300, 25);
            lblResultado.TabIndex = 3;
            lblResultado.Text = "Total: ---";
            // 
            // btnTopProductos
            // 
            btnTopProductos.Location = new Point(20, 100);
            btnTopProductos.Name = "btnTopProductos";
            btnTopProductos.Size = new Size(97, 23);
            btnTopProductos.TabIndex = 4;
            btnTopProductos.Text = "Top productos";
            btnTopProductos.Click += btnTopProductos_Click;
            // 
            // dgvTopProductos
            // 
            dgvTopProductos.Location = new Point(20, 140);
            dgvTopProductos.Name = "dgvTopProductos";
            dgvTopProductos.ReadOnly = true;
            dgvTopProductos.Size = new Size(650, 230);
            dgvTopProductos.TabIndex = 5;
            // 
            // FrmFinanciero
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 450);
            Controls.Add(tabControl);
            Name = "FrmFinanciero";
            Text = "FrmFinanciero";
            tabControl.ResumeLayout(false);
            tabFacturas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
            tabReportes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTopProductos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabFacturas;
        private System.Windows.Forms.TabPage tabReportes;

        private System.Windows.Forms.DataGridView dgvFacturas;

        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.ComboBox cmbAnno;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label lblResultado;

        private System.Windows.Forms.Button btnTopProductos;
        private System.Windows.Forms.DataGridView dgvTopProductos;

    }
}