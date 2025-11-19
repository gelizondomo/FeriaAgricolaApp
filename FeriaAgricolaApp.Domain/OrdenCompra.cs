using FeriaAgricolaApp.Domain.Enums;

namespace FeriaAgricolaApp.Domain
{
    public class OrdenCompra
    {
        /// <summary>
        /// Gets or sets del id OrdenCompra.
        /// </summary>
        /// <value>
        /// El id.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets del usuario id.
        /// </summary>
        /// <value>
        /// El usuario identifier.
        /// </value>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Gets or sets de la fecha compra.
        /// </summary>
        /// <value>
        /// La fecha compra.
        /// </value>
        public DateTime FechaCompra { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets de la direccion entrega.
        /// </summary>
        /// <value>
        /// La direccion entrega.
        /// </value>
        public string? DireccionEntrega { get; set; }

        /// <summary>
        /// Gets or sets de los Carritoitems.
        /// </summary>
        /// <value>
        /// Los Carritoitems.
        /// </value>
        public List<CarritoItem> Items { get; set; } = new List<CarritoItem>();

        /// <summary>
        /// Gets or sets del total.
        /// </summary>
        /// <value>
        /// El total.
        /// </value>
        public decimal Total { get; set; }

        /// <summary>
        /// Gets or sets del estado compra.
        /// </summary>
        /// <value>
        /// El estado compra.
        /// </value>
        public Estado EstadoCompra{ get; set; } = Estado.Pendiente;

    }
}
