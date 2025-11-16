namespace FeriaAgricolaApp.Domain
{
    public class Feria
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">El id de la feria</param>
        /// <param name="nombre">El nombre de la feria</param>
        /// <param name="localidad">La localidad de la feria</param>
        /// <param name="horario">El horario de la feria</param>
        public Feria(int id, string nombre, string localidad, string horario)
        {
            Id = id;
            Nombre = nombre;
            Localidad = localidad;
            Horario = horario;
        }

        /// <summary>
        /// Gets y sets el id de la feria.
        /// </summary>
        /// <value>
        /// El stock del producto.
        /// </value>
        public int Id { get; set; } = 0;

        /// <summary>
        /// Gets y sets el id de la feria.
        /// </summary>
        /// <value>
        /// El stock del producto.
        /// </value>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Gets y sets el id de la feria.
        /// </summary>
        /// <value>
        /// El stock del producto.
        /// </value>
        public string Localidad { get; set; } = string.Empty;

        /// <summary>
        /// Gets y sets el id de la feria.
        /// </summary>
        /// <value>
        /// El stock del producto.
        /// </value>
        public string Horario { get; set; } = string.Empty;

        /// <summary>
        /// Convierte a String
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> que representa esta instancia.
        /// </returns>
        public override string ToString()
        {
            return $"{Id},{Nombre},{Localidad},{Horario}{Environment.NewLine}";
        }

    }
}
