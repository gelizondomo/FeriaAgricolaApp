namespace FeriaAgricolaApp.Domain
{
    public class Proveedor
    {
        /// <summary>
        /// Gets y sets el id proveedor.
        /// </summary>
        /// <value>
        /// El id proveedor.
        /// </value>
        public int Id { get; set; } = 0;

        /// <summary>
        /// Gets y sets el nombre proveedor.
        /// </summary>
        /// <value>
        /// El nombre proveedor.
        /// </value>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Gets y sets de la feria.
        /// </summary>
        /// <value>
        /// La  feria.
        /// </value>
        public string Feria { get; set; } = string.Empty;

        /// <summary>
        /// Gets y sets los productos.
        /// </summary>
        /// <value>
        /// Los productos.
        /// </value>
        public List<Producto> Productos { get; set; } = new List<Producto>();

    }
}
