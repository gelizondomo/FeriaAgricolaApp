namespace FeriaAgricolaApp.Models
{
    public class Producto
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">El id del producto</param>
        /// <param name="nombre">El nombre del producto</param>
        /// <param name="precio">El precio del producto</param>
        /// <param name="unidadMedida">La unidadMedida del producto</param>
        /// <param name="stock">El stock del producto</param>
        /// <param name="proveedorId">El id del proveedor</param>
        public Producto(int id, string nombre, decimal precio, string unidadMedida, int stock, int proveedorId)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Precio = precio;
            this.UnidadMedida = unidadMedida;
            this.Stock = stock;
            this.ProveedorId = proveedorId;
        }

        /// <summary>
        /// Gets y sets el id del producto.
        /// </summary>
        /// <value>
        /// El id del producto.
        /// </value>
        public int Id { get; set; } = 0;

        /// <summary>
        /// Gets y sets el nombre del producto.
        /// </summary>
        /// <value>
        /// El nombre del producto.
        /// </value>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Gets y sets el precio del producto.
        /// </summary>
        /// <value>
        /// El precio del producto.
        /// </value>
        public decimal Precio { get; set; } = decimal.Zero;

        /// <summary>
        /// Gets y sets la unidadMedida del producto.
        /// </summary>
        /// <value>
        /// La unidadMedida del producto.
        /// </value>
        public string UnidadMedida { get; set; } = string.Empty;

        /// <summary>
        /// Gets y sets el stock del producto.
        /// </summary>
        /// <value>
        /// El stock del producto.
        /// </value>
        public int Stock { get; set; } = 0;

        /// <summary>
        /// Gets y sets el id del proveedor.
        /// </summary>
        /// <value>
        /// El id del proveedor.
        /// </value>
        public int ProveedorId { get; set; } = 0;   

        /// <summary>
        /// Convierte a String
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> que representa esta instancia.
        /// </returns>
        public override string ToString()
        {
            return $"{this.Id},{this.Nombre},{this.Precio},{this.UnidadMedida},{this.Stock},{this.ProveedorId}{Environment.NewLine}";
        }

    }
}
