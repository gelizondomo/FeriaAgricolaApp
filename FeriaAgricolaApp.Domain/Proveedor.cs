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
        /// Gets y sets del feria id.
        /// </summary>
        /// <value>
        /// La  feria.
        /// </value>
        public int FeriaId { get; set; }

    }
}
