using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Application.Controllers;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeriaAgricolaApp.Presentation.Views
{
    
    public partial class FrmFinanciero : Form
    {
        private readonly FinancieroController financieroController;
        private readonly Usuario usuario;
        public FrmFinanciero(FinancieroController financieroController, Usuario usuario)
        {
            this.financieroController = financieroController;
            this.usuario = usuario;
            InitializeComponent();
            CargarAños();
            CargarFacturas();
        }

        private void CargarFacturas()
        {
            var facturas = financieroController.ObtenerFacturasUsuario(usuario.Id);

            dgvFacturas.DataSource = facturas
                .Select(f => new
                {
                    f.CodigoFactura,
                    f.FechaFactura,
                    f.Total,
                    f.DireccionEntrega
                })
                .ToList();
        }
        private void CargarAños()
        {
            int añoActual = DateTime.Now.Year;

            for (int ano = añoActual - 5; ano <= añoActual; ano++)
                cmbAnno.Items.Add(ano);

            cmbAnno.SelectedIndex = cmbAnno.Items.Count - 1; // último año
            cmbMes.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int mes = cmbMes.SelectedIndex + 1;
            int ano = (int)cmbAnno.SelectedItem;

            decimal total = financieroController.TotalMensual(mes, ano);

            lblResultado.Text = $"Total: ₡ {total:N2}";
        }

        
        private void btnTopProductos_Click(object sender, EventArgs e)
        {
            var dict = financieroController.TopProductos();

            dgvTopProductos.DataSource = dict
                .Select(x => new
                {
                    Producto = x.Key,
                    Cantidad = x.Value
                })
                .ToList();
        }
    }
}
