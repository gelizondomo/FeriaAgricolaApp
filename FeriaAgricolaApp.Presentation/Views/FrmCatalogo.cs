using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Infrastructure.Configuration;
using FeriaAgricolaApp.Application.Controllers;
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
            var direccionesUsuario = Program.DireccionService.ObtenerPorUsuario(usuario.Id);

            if (direccionesUsuario.Count == 0)
            {
                // Sin direcciones → cargar todas las ferias
                ferias = catalogoController.ObtenerFerias();
            }
            else
            {
                // Buscar principal o primera
                var dirPrincipal = direccionesUsuario
                    .FirstOrDefault(d => d.EsPrincipal)
                    ?? direccionesUsuario.First();

                string provincia = dirPrincipal.Provincia?.Trim() ?? "";

                ferias = catalogoController.ObtenerFeriasPorProvincia(provincia);
            }

            cmbFerias.DataSource = ferias;
            cmbFerias.DisplayMember = "Nombre";
            cmbFerias.ValueMember = "Id";

            if (ferias.Count > 0)
            {
                feriaSeleccionada = ferias[0].Id;
                CargarProductosPorFeria(feriaSeleccionada);
            }
        }
        private void CargarProductosPorFeria(int feriaId)
        {
            var productos = catalogoController.ObtenerProductosPorFeria(feriaId);

            var lista = productos.Select(p => new
            {
                p.Id,
                Producto = p.Nombre,
                Proveedor = catalogoController.FiltrarPorProveedor(p.ProveedorId),
                p.Precio,
                Unidad = p.UnidadMedida.ToString(),
                p.Stock
            }).ToList();

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = lista;
        }

        private void CargarProveedoresPorFeria(int feriaId)
        {
            var proveedores = catalogoController.ObtenerProveedoresPorFeria(feriaId);

            // Insertar opción "Todos"
            proveedores.Insert(0, new Proveedor
            {
                Id = 0,
                Nombre = "Todos los proveedores"
            });

            cmbProveedores.DataSource = null;
            cmbProveedores.DataSource = proveedores;
            cmbProveedores.DisplayMember = "Nombre";
            cmbProveedores.ValueMember = "Id";

            cmbProveedores.SelectedIndex = 0;
        }

        /// <summary>
        /// Cargar los productos por proveedor.
        /// </summary>
        /// <param name="proveedorId">The proveedor od.</param>
        private void CargarProductosPorProveedor(int proveedorId)
        {
            var productos = catalogoController.ObtenerProductosPorProveedor(proveedorId);

            var lista = productos.Select(p => new
            {
                p.Id,
                Producto = p.Nombre,
                Proveedor = catalogoController.FiltrarPorProveedor(p.ProveedorId),
                Precio = p.Precio,
                Unidad = p.UnidadMedida.ToString(),
                Stock = p.Stock
            }).ToList();

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = lista;
        }

        private void cmbProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProveedores.SelectedItem is Proveedor proveedor)
            {
                if (proveedor.Id == 0)
                {
                    // Todos los proveedores → volver a cargar por feria
                    CargarProductosPorFeria(feriaSeleccionada);
                }
                else
                {
                    CargarProductosPorProveedor(proveedor.Id);
                }
            }
        }


        private void cmbFerias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFerias.SelectedItem is Feria feria)
            {
                feriaSeleccionada = feria.Id;
                CargarProveedoresPorFeria(feria.Id);
                CargarProductosPorFeria(feria.Id);
            }
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
