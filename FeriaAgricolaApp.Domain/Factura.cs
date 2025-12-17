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
        /// Gets or sets el orden compra id.
        /// </summary>
        /// <value>
        /// EL orden compra id.
        /// </value>
        public int OrdenCompraId { get; set; }


        /// <summary>
        /// Gets or sets el usuario id.
        /// </summary>
        /// <value>
        /// El usuario id.
        /// </value>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Gets t sets el feria id.
        /// </summary>
        /// <value>
        /// El feria id.
        /// </value>
        public int FeriaId { get; set; }

        /// <summary>
        /// Gets t sets el proveedor id.
        /// </summary>
        /// <value>
        /// El proveedor id.
        /// </value>
        public int ProveedorId { get; set; }


        /// <summary>
        /// Gets or sets la fecha factura.
        /// </summary>
        /// <value>
        /// La fecha factura.
        /// </value>
        public DateTime FechaFactura { get; set; } = DateTime.Now;


        /// <summary>
        /// Gets or sets el total.
        /// </summary>
        /// <value>
        /// El total.
        /// </value>
        public decimal Total { get; set; }


        /// <summary>
        /// Gets or sets la direccion entrega.
        /// </summary>
        /// <value>
        /// La direccion entrega.
        /// </value>
        public string DireccionEntrega { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the impuesto.
        /// </summary>
        /// <value>
        /// The impuesto.
        /// </value>
        public decimal Impuesto { get; set; }

        /// <summary>
        /// Gets or sets the subtotal.
        /// </summary>
        /// <value>
        /// The subtotal.
        /// </value>
        public decimal Subtotal => Total - Impuesto;  

    }
}

