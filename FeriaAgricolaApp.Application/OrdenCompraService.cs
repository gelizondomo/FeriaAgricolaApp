using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Domain.Enums;
using FeriaAgricolaApp.Domain.Interfaces;

namespace FeriaAgricolaApp.Application
{
    /// <summary>
    /// Servicio encargado de procesar y gestionar órdenes de compra.
    /// </summary>
    public class OrdenCompraService
    {
        private readonly IRepository<OrdenCompra> ordenRepo;
        private readonly ProductoService productoService;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="OrdenCompraService"/>.
        /// </summary>
        /// <param name="IRepository<OrdenCompra>">Repositorio de órdenes.</param>
        /// <param name="ProductoService">Servicio de productos.</param>
        public OrdenCompraService(
            IRepository<OrdenCompra> ordenRepo,
            ProductoService ProductoService)
        {
            this.ordenRepo = ordenRepo;
            this.productoService = productoService;
        }

        /// <summary>
        /// Obtiene o Crea la orden pendiente.
        /// </summary>
        /// <param name="usuarioId">El usuario id.</param>
        /// <returns></returns>
        public OrdenCompra ObtenerOCrearCarrito(int usuarioId)
        {
            // Buscar carrito pendiente
            var existente = ordenRepo.GetAll()
                .FirstOrDefault(o => o.UsuarioId == usuarioId && o.EstadoCompra == Estado.Pendiente);

            if (existente != null)
                return existente;

            // No existe → crear uno nuevo
            var nuevo = new OrdenCompra
            {
                UsuarioId = usuarioId,
                FechaCompra = DateTime.Now,
                EstadoCompra = Estado.Pendiente,
                Items = new List<CarritoItem>()
            };

            ordenRepo.Add(nuevo);
            return nuevo;
        }

        /// <summary>
        /// Guarda los cambios.
        /// </summary>
        /// <param name="orden">La orden.</param>
        /// <returns></returns>
        public void GuardarCambios(OrdenCompra orden)
        {
            ordenRepo.Update(orden);
        }


        /// <summary>
        /// Finalizar la orden.
        /// </summary>
        /// <param name="usuarioId">El usuario id.</param>
        /// <param name="direccionEntrega">La direccion entrega.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">
        /// El carrito está vacío.
        /// o
        /// Producto no encontrado.
        /// o
        /// Stock insuficiente para {prod.Nombre}
        /// </exception>
        public OrdenCompra FinalizarOrden(int usuarioId, string direccionEntrega)
        {
            var orden = ObtenerOCrearCarrito(usuarioId);

            if (orden.Items.Count == 0)
                throw new Exception("El carrito está vacío.");

            // Validación de inventario
            foreach (var item in orden.Items)
            {
                var prod = productoService.GetById(item.ProductoId);
                if (prod == null)
                    throw new Exception("Producto no encontrado.");

                if (prod.Stock < item.Cantidad)
                    throw new Exception($"Stock insuficiente para {prod.Nombre}");
            }

            // Descontar inventario
            foreach (var item in orden.Items)
            {
                productoService.DescontarStock(item.ProductoId, item.Cantidad);
            }

            orden.EstadoCompra = Estado.Completado;
            orden.FechaCompra = DateTime.Now;
            orden.DireccionEntrega = direccionEntrega;

            ordenRepo.Update(orden);
            return orden;
        }


        /// <summary>
        /// Obtener el historial.
        /// </summary>
        /// <param name="usuarioId">The usuario id.</param>
        /// <returns></returns>
        public List<OrdenCompra> ObtenerHistorial(int usuarioId)
        {
            return ordenRepo
                .GetAll()
                .Where(o => o.UsuarioId == usuarioId &&
                            o.EstadoCompra == Estado.Completado)
                .ToList();
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
        /// Vaciar el carrito.
        /// </summary>
        /// <param name="usuarioId">The usuario id.</param>
        public void VaciarCarrito(int usuarioId)
        {
            var carrito = ObtenerOCrearCarrito(usuarioId);
            carrito.Items.Clear();
            ordenRepo.Update(carrito);
        }


    }
}

