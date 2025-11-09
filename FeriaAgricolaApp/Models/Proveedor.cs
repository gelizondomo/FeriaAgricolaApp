namespace FeriaAgricolaApp.Models
{
    public class Proveedor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Proveedor"/> class.
        /// </summary>
        /// <param name="id">El id proveedor</param>
        /// <param name="nombre">El nombre proveedor</param>
        /// <param name="feriaId"> El id de la feria</param>
        public Proveedor(int id, string nombre, int feriaId)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.FeriaId = feriaId;
        }

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
        /// Gets y sets el id de la feria.
        /// </summary>
        /// <value>
        /// El id de la feria.
        /// </value>
        public int FeriaId { get; set; } = 0;


        /// <summary>
        /// Convierte a String
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> que representa esta instancia.
        /// </returns>
        public override string ToString()
        {
            return $"{this.Id},{this.Nombre},{this.FeriaId}{Environment.NewLine}";
        }
    }
}
