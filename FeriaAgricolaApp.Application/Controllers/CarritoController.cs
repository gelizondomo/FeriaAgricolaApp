using FeriaAgricolaApp.Application;
using FeriaAgricolaApp.Domain;

namespace FeriaAgricolaApp.Application.Controllers
{ 
    public class CarritoController
    {
        private readonly OrdenCompraService ordenCompraService;
        private readonly ProductoService productoService;
        private readonly FacturaService facturaService;
        private readonly DireccionService direccionService;


        /// <summary>
        /// Inicializa la instancia de la clase <see cref="CarritoController" />.
        /// </summary>
        /// <param name="ordenCompraService">La orden compra service.</param>
        /// <param name="productoService">El producto service.</param>
        /// <param name="facturaService">La factura service.</param>
        /// <param name="direccionService">The direccion service.</param>
        public CarritoController(OrdenCompraService ordenCompraService, ProductoService productoService, FacturaService facturaService, DireccionService direccionService)
        {
            this.ordenCompraService = ordenCompraService;
            this.productoService = productoService;
            this.facturaService = facturaService;
            this.direccionService = direccionService;
        }

        /// <summary>
        /// Obtiene el carrito.
        /// </summary>
        /// <param name="usuarioId">The usuario identifier.</param>
        /// <returns></returns>
        public OrdenCompra ObtenerCarrito(int usuarioId)
        {
            return ordenCompraService.ObtenerOCrearCarrito(usuarioId);
        }

        /// <summary>
        /// Obtener el nombre producto.
        /// </summary>
        /// <param name="productoId">El producto id.</param>
        /// <returns></returns>
        public string ObtenerNombreProducto(int productoId)
        {
            var producto = productoService.GetById(productoId);

            if (producto == null)
                return "Producto no encontrado";

            return producto.Nombre;
        }


        /// <summary>
        /// Obtener el total producto.
        /// </summary>
        /// <param name="productoId">El producto id.</param>
        /// <param name="cantidad">La cantidad.</param>
        /// <returns></returns>
        public decimal ObtenerTotalProducto(int productoId, int cantidad)
        {
            var p = productoService.GetById(productoId);
            if (p == null) return 0;
            return p.Precio * cantidad;
        }


        /// <summary>
        /// Quitar el producto.
        /// </summary>
        /// <param name="usuarioId">El usuario id.</param>
        /// <param name="productoId">El producto id.</param>
        public void QuitarProducto(int usuarioId, int productoId)
        {
            var carrito = ordenCompraService.ObtenerOCrearCarrito(usuarioId);

            var item = carrito.Items.FirstOrDefault(i => i.ProductoId == productoId);
            if (item != null)
            {
                carrito.Items.Remove(item);
                ordenCompraService.GuardarCambios(carrito);
            }
        }

        /// <summary>
        /// Obtener la direcciones de entrega.
        /// </summary>
        /// <param name="usuarioId">The usuario id.</param>
        /// <returns></returns>
        public List<Direccion> ObtenerDireccionesDeEntrega(int usuarioId)
        {
            return direccionService.ObtenerPorUsuario(usuarioId);
        }

        public (bool Exito, Factura? Factura) ProcesarCompra(int usuarioId, string direccion)
        {
            // El método FinalizarOrden devuelve OrdenCompra, pero se espera una tupla (bool, Factura?)
            // Solución: obtener la factura desde el servicio de facturaService y devolver la tupla correctamente

            var orden = ordenCompraService.FinalizarOrden(usuarioId, direccion);
            if (orden == null)
                return (false, null);

            // Suponiendo que la factura se genera a partir de la orden finalizada
            var factura = facturaService.GenerarFactura(orden, usuarioId, direccion);
            return (factura != null, factura);
        }
    }
}
