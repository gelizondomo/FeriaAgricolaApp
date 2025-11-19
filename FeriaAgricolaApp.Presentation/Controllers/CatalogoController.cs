using FeriaAgricolaApp.Application;
using FeriaAgricolaApp.Domain;

namespace FeriaAgricolaApp.Presentation.Controllers
{
    public class CatalogoController
    {
        private readonly ProductoService productoService;
        private readonly FeriaService feriaService;
        private readonly OrdenCompraService ordenCompraService;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref=".CatalogoController"/>.
        /// </summary>
        /// <param name="productoService">The producto service.</param>
        public CatalogoController(ProductoService productoService, OrdenCompraService ordenCompraService)
        {
            this.productoService = productoService;
            this.ordenCompraService = ordenCompraService;
        }

        /// <summary>
        /// Obtener los productos.
        /// </summary>
        /// <returns></returns>
        public List<Producto> ObtenerProductos()
        {
            return productoService.ObtenerTodos();
        }

        /// <summary>
        /// Filtrar por proveedor.
        /// </summary>
        /// <param name="proveedorId">El proveedor id.</param>
        /// <returns></returns>
        public List<Producto> FiltrarPorProveedor(int proveedorId)
        {
            return productoService.FiltrarPorProvedor(proveedorId);
        }

        /// <summary>
        /// Agregar  al carrito.
        /// </summary>
        /// <param name="usuarioId">El usuario id.</param>
        /// <param name="productoId">El producto id.</param>
        /// <param name="cantidad">La cantidad.</param>
        public void AgregarAlCarrito(int usuarioId, int productoId, int cantidad = 1)
        {
            var carrito = ordenCompraService.ObtenerOCrearCarrito(usuarioId);

            var item = carrito.Items.FirstOrDefault(i => i.ProductoId == productoId);

            if (item != null)
                item.Cantidad += cantidad;
            else
                carrito.Items.Add(new CarritoItem
                {
                    ProductoId = productoId,
                    Cantidad = cantidad
                });

            ordenCompraService.GuardarCambios(carrito);
        }

        public List<Feria> ObtenerFerias()
        => feriaService.ObtenerTodas();

        public List<Producto> ObtenerProductosPorFeria(int feriaId)
            => productoService.ObtenerPorFeria(feriaId);

        public List<Producto> BuscarProductosPorNombre(string nombre, int feriaId)
            => productoService.BuscarPorNombreYFeria(nombre, feriaId);

    }
}
