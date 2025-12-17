using FeriaAgricolaApp.Application;
using FeriaAgricolaApp.Domain;

namespace FeriaAgricolaApp.Application.Controllers
{
    public class CatalogoController
    {
        private readonly ProductoService productoService;
        private readonly ProveedorService proveedorService;
        private readonly FeriaService feriaService;
        private readonly OrdenCompraService ordenCompraService;



        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CatalogoController"/> class.
        /// </summary>
        /// <param name="productoService">El producto service.</param>
        /// <param name="proveedorService">El proveedor service.</param>
        /// <param name="feriaService">El feria service.</param>
        /// <param name="ordenCompraService">El orden compra service.</param>
        public CatalogoController(ProductoService productoService,ProveedorService proveedorService, FeriaService feriaService,  OrdenCompraService ordenCompraService)
        {
            this.productoService = productoService;
            this.proveedorService = proveedorService;
            this.feriaService = feriaService;
            this.ordenCompraService = ordenCompraService;
        }

        /// <summary>
        /// Filtrar por proveedor.
        /// </summary>
        /// <param name="proveedorId">El proveedor id.</param>
        /// <returns></returns>
        public string FiltrarPorProveedor(int proveedorId)
        {
            var proveedor = proveedorService.ObtenerPorId(proveedorId);
            return proveedor != null ? proveedor.Nombre : "Desconocido";
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

            var producto = productoService.GetById(productoId);
            if (producto == null)
                throw new Exception("El producto no existe");

            // Validar stock
            if (producto.Stock < cantidad)
                throw new Exception("No hay suficiente stock disponible");

            var item = carrito.Items.FirstOrDefault(i => i.ProductoId == productoId);

            if (item != null)
            {
                item.Cantidad += cantidad;
            }    
            else
                carrito.Items.Add(new CarritoItem
                {
                    ProductoId = productoId,
                    Cantidad = cantidad
                });

            ordenCompraService.GuardarCambios(carrito);
        }

        /// <summary>
        /// Obtener todas las ferias.
        /// </summary>
        /// <returns></returns>
        public List<Feria> ObtenerFerias()
        => feriaService.GetAll();

        /// <summary>
        /// Obtener las ferias por provincia.
        /// </summary>
        /// <param name="provincia">The provincia.</param>
        /// <returns></returns>
        public List<Feria> ObtenerFeriasPorProvincia(string provincia)
        {
            provincia = provincia.Trim().ToLower();

            return feriaService.GetAll()
                .Where(f => f.Localidad.Trim().ToLower()
                .Contains(provincia))
                .ToList();
        }

        /// <summary>
        /// Obtener los productos por feria.
        /// </summary>
        /// <param name="feriaId">The feria id.</param>
        /// <returns></returns>
        public List<Producto> ObtenerProductosPorFeria(int feriaId)
        {
            var proveedores = proveedorService.ObtenerPorFeria(feriaId);

            if (proveedores.Count == 0)
                return new List<Producto>();

            var proveedorId = proveedores.Select(p => p.Id).ToList();

            return productoService.FiltrarPorProvedor(proveedorId);
        }

        public List<Producto> ObtenerProductosPorProveedor(int proveedorId)
        {
            return productoService.FiltrarPorProvedor(new List<int> { proveedorId });
        }

        /// <summary>
        /// Obtener los proveedores por feria.
        /// </summary>
        /// <param name="feriaId">The feria id.</param>
        /// <returns></returns>
        public List<Proveedor> ObtenerProveedoresPorFeria(int feriaId)
        {
            return proveedorService.ObtenerPorFeria(feriaId);
        }

        /// <summary>
        /// Buscar el productos por nombre.
        /// </summary>
        /// <param name="nombre">The nombre.</param>
        /// <param name="feriaId">The feria id.</param>
        /// <returns></returns>
        public List<Producto> BuscarProductosPorNombre(string nombre, int feriaId)
        {
            var productosPorFeria = ObtenerProductosPorFeria(feriaId);
            nombre = nombre.Trim().ToLower();
            return productosPorFeria
                .Where(p => p.Nombre.Trim().ToLower().Contains(nombre))
                .ToList();
        }

    }
}
