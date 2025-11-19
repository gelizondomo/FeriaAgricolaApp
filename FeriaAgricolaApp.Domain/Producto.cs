using FeriaAgricolaApp.Domain.Enums;

namespace FeriaAgricolaApp.Domain
{
    public class Producto
    {
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
        public decimal Precio { get; set; }


        /// <summary>
        /// Gets y sets de unidad medida.
        /// </summary>
        /// <value>
        /// The unidad medida.
        /// </value>
        public UnidadMedida UnidadMedida { get; set; }

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
        /// Gets or sets del feria id.
        /// </summary>
        /// <value>
        /// The feria id.
        /// </value>
        public int FeriaId { get; set; }

    }
}
