using FeriaAgricolaApp.Application;
using FeriaAgricolaApp.Domain;

namespace FeriaAgricolaApp.Presentation.Controllers
{ 
    public class CarritoController
    {
        private readonly OrdenCompraService ordenCompraService;
        private readonly ProductoService productoService;
        private readonly FacturaService facturaService;


        /// <summary>
        /// Inicializa la instancia de la clase <see cref="CarritoController"/>.
        /// </summary>
        /// <param name="ordenCompraService">La orden compra service.</param>
        /// <param name="productoService">El producto service.</param>
        /// <param name="facturaService">La factura service.</param>
        public CarritoController(OrdenCompraService ordenCompraService, ProductoService productoService, FacturaService facturaService)
        {
            this.ordenCompraService = ordenCompraService;
            this.productoService = productoService;
            this.facturaService = facturaService;
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
        /// Agregar el producto.
        /// </summary>
        /// <param name="usuarioId">El usuario id.</param>
        /// <param name="productoId">El producto id.</param>
        /// <param name="cantidad">La cantidad.</param>
        /// <exception cref="System.Exception">
        /// El producto no existe
        /// o
        /// No hay suficiente stock disponible
        /// </exception>
        public void AgregarProducto(int usuarioId, int productoId, int cantidad)
        {
            // Obtener carrito (nunca será null)
            var carrito = ordenCompraService.ObtenerOCrearCarrito(usuarioId);

            // Obtener producto
            var producto = productoService.GetById(productoId);
            if (producto == null)
                throw new Exception("El producto no existe");

            // Validar stock
            if (producto.Stock < cantidad)
                throw new Exception("No hay suficiente stock disponible");

            // Buscar item en carrito
            var item = carrito.Items.FirstOrDefault(i => i.ProductoId == productoId);

            if (item != null)
            {
                item.Cantidad += cantidad;
            }
            else
            {
                carrito.Items.Add(new CarritoItem
                {
                    ProductoId = productoId,
                    Cantidad = cantidad
                });
            }

            // 5. Guardar cambios
            ordenCompraService.GuardarCambios(carrito);
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
        /// Actualizar la cantidad.
        /// </summary>
        /// <param name="usuarioId">El usuario id.</param>
        /// <param name="productoId">El producto id.</param>
        /// <param name="cantidad">La cantidad.</param>
        public void ActualizarCantidad(int usuarioId, int productoId, int cantidad)
        {
            var carrito = ordenCompraService.ObtenerOCrearCarrito(usuarioId);

            var item = carrito.Items.FirstOrDefault(i => i.ProductoId == productoId);
            if (item == null)
                return;

            if (cantidad <= 0)
            {
                carrito.Items.Remove(item);
            }
            else
            {
                item.Cantidad = cantidad;
            }

            ordenCompraService.GuardarCambios(carrito);
        }



        /// <summary>
        /// Obtener los items.
        /// </summary>
        /// <param name="usuarioId">El usuario id.</param>
        /// <returns></returns>
        public List<CarritoItem> ObtenerItems(int usuarioId)
        {
            var carrito = ordenCompraService.ObtenerOCrearCarrito(usuarioId);
            return carrito.Items;
        }


        /// <summary>
        /// Calcular el total.
        /// </summary>
        /// <param name="usuarioId">The usuario id.</param>
        /// <returns></returns>
        public decimal CalcularTotal(int usuarioId)
        {
            var carrito = ordenCompraService.ObtenerOCrearCarrito(usuarioId);

            return carrito.Items.Sum(item =>
            {
                Producto? producto = productoService.GetById(item.ProductoId);
                return producto.Precio * item.Cantidad;
            });
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

        /// <summary>
        /// Vaciar el carrito.
        /// </summary>
        /// <param name="usuarioId">El usuario id.</param>
        public void VaciarCarrito(int usuarioId)
        {
            var carrito = ordenCompraService.ObtenerOCrearCarrito(usuarioId);
            carrito.Items.Clear();
            ordenCompraService.GuardarCambios(carrito);
        }
    }
}
