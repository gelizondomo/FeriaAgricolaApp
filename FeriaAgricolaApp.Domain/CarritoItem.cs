namespace FeriaAgricolaApp.Domain
{
    /// <summary>
    /// Representa un producto agregado al carrito de compras, incluyendo su cantidad y precio unitario.
    /// </summary>
    public class CarritoItem
    {
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
