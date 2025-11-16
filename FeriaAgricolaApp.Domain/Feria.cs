namespace FeriaAgricolaApp.Domain
{
    public class Feria
    {
        /// <summary>
        /// Gets y sets el id de la feria.
        /// </summary>
        /// <value>
        /// El id de la feria.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets y sets el nombre de la feria.
        /// </summary>
        /// <value>
        /// El nombre de la feria.
        /// </value>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Gets y sets la localidad de la feria.
        /// </summary>
        /// <value>
        /// La localidad de la feria.
        /// </value>
        public string Localidad { get; set; } = string.Empty;

        /// <summary>
        /// Gets y sets el horario de la feria.
        /// </summary>
        /// <value>
        /// El horario de la feria.
        /// </value>
        public string Horario { get; set; } = string.Empty;

    }
}
