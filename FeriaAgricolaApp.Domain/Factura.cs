namespace FeriaAgricolaApp.Domain
{
    public class Factura
    {
        ///<summary>
        ///Gets or sets El id de factura .
        ///</summary>
        /// <value>El id de factura.</value>
        public int Id { get; set; }


        /// <summary>
        /// Gets or sets el codigo factura.
        /// </summary>
        /// <value>El codigo factura.</value>
        public string CodigoFactura { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets the orden compra id.
        /// </summary>
        /// <value>
        /// The orden compra id.
        /// </value>
        public int OrdenCompraId { get; set; }


        /// <summary>
        /// Gets or sets the usuario id.
        /// </summary>
        /// <value>
        /// The usuario id.
        /// </value>
        public int UsuarioId { get; set; }


        /// <summary>
        /// Gets or sets the fecha emision.
        /// </summary>
        /// <value>
        /// The fecha emision.
        /// </value>
        public DateTime FechaEmision { get; set; } = DateTime.Now;


        /// <summary>
        /// Gets or sets the nombre cliente.
        /// </summary>
        /// <value>
        /// The nombre cliente.
        /// </value>
        public string NombreCliente { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets the direccion entrega.
        /// </summary>
        /// <value>
        /// The direccion entrega.
        /// </value>
        public string DireccionEntrega { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets the carrito.
        /// </summary>
        /// <value>
        /// The carrito.
        /// </value>
        public List<CarritoItem> Carrito { get; set; } = [];


        /// <summary>
        /// Gets or sets the subtotal.
        /// </summary>
        /// <value>
        /// The subtotal.
        /// </value>
        public decimal Subtotal { get; set; }


        /// <summary>
        /// Gets or sets the impuesto.
        /// </summary>
        /// <value>
        /// The impuesto.
        /// </value>
        public decimal Impuesto { get; set; }


        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public decimal Total { get; set; }


        /// <summary>
        /// Generar desde ordencompra.
        /// </summary>
        /// <param name="ordenCompra">The ordencompra.</param>
        /// <param name="nombreCliente">The nombre cliente.</param>
        /// <param name="direccion">The direccion.</param>
        public void GenerarDesdeOrden(OrdenCompra ordenCompra, string nombreCliente, string direccion)
        {
            OrdenCompraId = ordenCompra.Id;
            UsuarioId = ordenCompra.UsuarioId;
            NombreCliente = nombreCliente;
            DireccionEntrega = direccion;
            Carrito = ordenCompra.Carrito.Select(i => new CarritoItem
            {
                ProductoId = i.ProductoId,
                NombreProducto = i.NombreProducto,
                Cantidad = i.Cantidad,
                PrecioUnitario = i.PrecioUnitario
            }).ToList();

            CalcularTotales();
        }


        /// <summary>
        /// Calculo de los totales.
        /// </summary>
        public void CalcularTotales()
        {
            Subtotal = Carrito.Sum(i => i.Subtotal);
            Impuesto = Math.Round(Subtotal * 0.13m, 2);
            Total = Subtotal + Impuesto;
        }


        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> 
        /// que representa la instancia
        /// </returns>
        public override string ToString()
        {
            return $"Factura {CodigoFactura} - {FechaEmision:dd/MM/yyyy} - Total {Total:C}";
        }
    }
}

