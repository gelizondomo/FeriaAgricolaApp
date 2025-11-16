namespace FeriaAgricolaApp.Domain
{
    /// <summary>
    /// Representa un producto agregado al carrito de compras, incluyendo su cantidad y precio unitario.
    /// </summary>
    public class CarritoItem
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CarritoItem"/>.
        /// </summary>
        /// <param name="productoId">Id del producto.</param>
        /// <param name="nombreProducto">Nombre del producto.</param>
        /// <param name="cantidad">Cantidad del producto en el carrito.</param>
        /// <param name="precioUnitario">Precio unitario del producto.</param>
        public CarritoItem(int productoId, string nombreProducto, int cantidad, decimal precioUnitario)
        {
            ProductoId = productoId;
            NombreProducto = nombreProducto;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }

        /// <summary>
        /// Gets y sets el Id del producto.
        /// </summary>
        /// <value>
        /// El Id del producto.
        /// </value>
        public int ProductoId { get; set; }

        /// <summary>
        /// Gets y sets Nombre del producto.
        /// </summary>
        /// <value>
        /// El Nombre del producto.
        /// </value>
        public string NombreProducto { get; set; } = string.Empty;

        /// <summary>
        /// Gets y sets la Cantidad del producto en el carrito.
        /// </summary>
        /// <value>
        /// Cantidad del producto en el carrito.
        /// </value>
        public int Cantidad { get; set; }

        /// <summary>
        /// Gets y sets el Precio unitario del producto.
        /// </summary>
        /// <value>
        /// El Precio unitario del producto.
        /// </value>
        public decimal PrecioUnitario { get; set; }

        /// <summary>
        /// Calcula el subtotal del producto en el carrito (cantidad × precio unitario).
        /// </summary>
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}
