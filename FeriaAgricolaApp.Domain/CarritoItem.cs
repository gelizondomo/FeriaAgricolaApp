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
        /// Gets y sets la Cantidad del producto en el carrito.
        /// </summary>
        /// <value>
        /// Cantidad del producto en el carrito.
        /// </value>
        public int Cantidad { get; set; }

    }
}
