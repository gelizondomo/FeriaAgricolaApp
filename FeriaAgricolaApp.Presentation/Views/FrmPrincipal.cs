using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Presentation.Controllers;
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
    public partial class FrmPrincipal : Form
    {
        private readonly Usuario usuario;
        private readonly CatalogoController catalogoController;
        private readonly CarritoController carritoController;
        private readonly FinancieroController financieroController;

        public FrmPrincipal(Usuario usuario,
            CatalogoController catalogoController,
            CarritoController carritoController,
            FinancieroController financieroController)
        {
            this.usuario = usuario;
            this.catalogoController = catalogoController;
            this.carritoController = carritoController;
            this.financieroController = financieroController;


            InitializeComponent();
        }
        private void BtnCatalogo_Click(object sender, EventArgs e)
        {
        new FrmCatalogo(catalogoController, this.usuario).ShowDialog();
        }

        private void BtnCarrito_Click(object sender, EventArgs e)
        {
            new FrmCarrito(carritoController, this.usuario).ShowDialog();
        }

        private void BtnFacturas_Click(object sender, EventArgs e)
        {
            new FrmFinanciero(financieroController, this.usuario).ShowDialog();
        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            new FrmFinanciero(financieroController,usuario).ShowDialog();
        }
    }
}
