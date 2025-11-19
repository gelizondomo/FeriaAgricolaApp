using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Presentation.Controllers;
using System.Data;

namespace FeriaAgricolaApp.Presentation.Views
{
    public partial class FrmCatalogo : Form
    {
        private readonly CatalogoController catalogoController;
        private readonly Usuario usuario;
        private List<Feria> ferias;
        private int feriaSeleccionada;

        public FrmCatalogo(CatalogoController catalogoController, Usuario usuario)
        {
            this.catalogoController = catalogoController;
            this.usuario = usuario;
            InitializeComponent();
        }

        private void FrmCatalogoCarga(object sender, EventArgs e)
        {
            CargarFerias();
        }

        private void CargarFerias()
        {
            ferias = catalogoController.ObtenerFerias();
            cmbFerias.Items.Clear();

            foreach (var feria in ferias)
                cmbFerias.Items.Add(new ComboBoxItem(feria.Nombre, feria.Id));

            if (cmbFerias.Items.Count > 0)
                cmbFerias.SelectedIndex = 0;
        }

        private void cmbFerias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFerias.SelectedItem is ComboBoxItem item)
            {
                feriaSeleccionada = item.Value;
                CargarProductosPorFeria(item.Value);
            }
        }

        private void CargarProductosPorFeria(int feriaId)
        {
            var productos = catalogoController.ObtenerProductosPorFeria(feriaId);
            dgvProductos.DataSource = productos;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            var texto = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(texto))
            {
                CargarProductosPorFeria(feriaSeleccionada);
                return;
            }

            var productos = catalogoController.BuscarProductosPorNombre(texto, feriaSeleccionada);
            dgvProductos.DataSource = productos;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            var productId = (int)dgvProductos.SelectedRows[0].Cells["Id"].Value;

            catalogoController.AgregarAlCarrito(usuario.Id, productId);
            MessageBox.Show("Producto agregado al carrito.");
        }

        public class ComboBoxItem
        {
            public string Text { get; }
            public int Value { get; }

            public ComboBoxItem(string text, int value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString() => Text;
        }
    }
}
