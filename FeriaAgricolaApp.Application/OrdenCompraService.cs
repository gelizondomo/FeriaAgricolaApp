using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Domain.Interfaces;
using FeriaAgricolaApp.Infrastructure.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaBox.Application.Services
{
    /// <summary>
    /// Servicio encargado de procesar y gestionar órdenes de compra.
    /// </summary>
    public class OrdenCompraService
    {
        private readonly OrdenCompraRepository ordenRepo;
        private readonly InventarioService InventarioService;
        private readonly ProductoService ProductoService;
        private readonly FacturaService FacturaService;
        private readonly UsuarioService UsuarioService;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="OrdenCompraService"/>.
        /// </summary>
        /// <param name="OrdenCompraRepository">Repositorio de órdenes.</param>
        /// <param name="InventarioService">Servicio de inventario.</param>
        /// <param name="ProductoService">Servicio de productos.</param>
        /// <param name="FacturaService">Servicio de facturación.</param>
        /// <param name="UsuarioService">Servicio de usuarios.</param>
        public OrdenCompraService(
            OrdenCompraRepository ordenRepo,
            InventarioService InventarioService,
            ProductoService ProductoService,
            FacturaService FacturaService,
            UsuarioService UsuarioService)
        {
            this.ordenRepo = ordenRepo;
            this.InventarioService = InventarioService;
            this.ProductoService = ProductoService;
            this.FacturaService = FacturaService;
            this.UsuarioService = UsuarioService;
        }

        /// <summary>
        /// Crea o recupera el carrito de compras pendiente para un usuario.
        /// </summary>
        /// <param name="usuarioId">El identificador del usuario.</param>
        /// <returns>Una instancia de <see cref="OrdenCompra"/> correspondiente al carrito actual del usuario.</returns>

        public OrdenCompra CrearCarrito(int usuarioId)
        {
            var pendiente = ordenRepo.ObtenerEstadoOrden(usuarioId);
            if (pendiente != null)
                return pendiente;

            return ordenRepo.CrearEstadoOrden(usuarioId);
        }

        /// <summary>
        /// Agrega un producto al carrito de compras del usuario. Si el producto ya existe, incrementa su cantidad.
        /// </summary>
        /// <param name="usuarioId">El identificador del usuario.</param>
        /// <param name="productoId">El identificador del producto a agregar.</param>
        /// <param name="cantidad">La cantidad del producto a agregar.</param>

        public void AgregarCarrito(int usuarioId, int productoId, int cantidad)
        {
            var carrito = CrearCarrito(usuarioId);

            var item = carrito.Items.FirstOrDefault(i => i.ProductId == productoId);
            if (item != null)
                item.Cantidad += cantidad;
            else
                carrito.Items.Add(new CarritoItem { ProductoId = productoId, Cantidad = cantidad });

            ordenRepo.Update(carrito);
        }

        /// <summary>
        /// Elimina un producto específico del carrito de compras del usuario.
        /// </summary>
        /// <param name="usuarioId">El identificador del usuario.</param>
        /// <param name="productoId">El identificador del producto a eliminar.</param>

        public void EliminarCarrito(int usuarioId, int productoId)
        {
            var carrito = CrearCarrito(usuarioId);
            carrito.Items.RemoveAll(i => i.ProductoId == productoId);
            ordenRepo.Update(carrito);
        }

        /// <summary>
        /// Obtiene el nombre del producto según su identificador.
        /// </summary>
        /// <param name="productoId">El identificador del producto.</param>
        /// <returns>El nombre del producto si existe; de lo contrario, "Desconocido".</returns>

        public string ObtenerNombreProducto(int productoId)
        {
            var p = ProductoService.ObtenerPorId(productoId);
            return p?.Nombre ?? "Desconocido";
        }

        /// <summary>
        /// Procesa un pedido, actualiza el inventario, registra la orden y genera la factura.
        /// </summary>
        /// <param name="pedido">La orden a procesar.</param>
        /// <param name="direccionEntrega">Dirección de entrega del pedido.</param>
        /// <returns>
        /// Una tupla que indica si el proceso fue exitoso y, en caso afirmativo, la factura generada.
        /// </returns>
        public (bool Exito, Factura? Factura) ProcesarPedido(OrdenCompra pedido, string direccionEntrega)
        {
            decimal total = 0;

            foreach (var item in pedido.Items)
            {
                var producto = ProductoService.ObtenerPorId(item.ProductoId);
                if (producto == null || producto.Stock < item.Cantidad)
                    return (false, null);

                total += producto.Precio * item.Cantidad;
                InventarioService.ActualizarInventario(item.ProductoId, item.Cantidad);
            }

            pedido.Total = total;
            ordenRepo.Add(pedido);

            var usuario = UsuarioService.ObtenerTodos().FirstOrDefault(u => u.Id == pedido.UsuarioId);
            if (usuario == null)
                return (true, null);

            var factura = FacturaService.GenerarFactura(pedido, usuario.Nombre, direccionEntrega);
            return (true, factura);
        }

        /// <summary>
        /// Obtiene todas las órdenes realizadas por un usuario específico.
        /// </summary>
        /// <param name="usuarioId">Identificador del usuario.</param>
        /// <returns>Lista de órdenes del usuario.</returns>
        public List<OrdenCompra> ObtenerPedidosUsuario(int usuarioId)
        {
            return ordenRepo.GetAll().Where(o => o.UsuarioId == usuarioId).ToList();
        }

        /// <summary>
        /// Obtiene todas las órdenes registradas en el sistema.
        /// </summary>
        /// <returns>Lista de todas las órdenes.</returns>
        public List<OrdenCompra> ObtenerTodosPedidos() => ordenRepo.GetAll();


    }
}

