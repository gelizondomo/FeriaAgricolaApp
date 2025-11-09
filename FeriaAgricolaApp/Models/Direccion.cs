namespace FeriaAgricolaApp.Models
{
    /// <summary>
    /// Clse a cargo de representar la direccion de un usuario.
    /// </summary>
    public class Direccion
    {
        /// <summary>
        /// Gets y sets la provicia.
        /// </summary>
        /// <value>
        /// La provicia.
        /// </value>
        public string Provicia { get; set; } = string.Empty;

        /// <summary>
        /// Gets y sets el distrito.
        /// </summary>
        /// <value>
        /// El distrito.
        /// </value>
        public string Distrito { get; set; } = string.Empty;

        /// <summary>
        /// Gets y sets la dirección completa.
        /// </summary>
        /// <value>
        /// La dirección completa.
        /// </value>
        public string DireccionCompleta { get; set; } = string.Empty;

        /// <summary>
        /// Gets y sets el valor que indica si esta dirección es la dirección principal del Usuario.
        /// </summary>
        /// <value>
        ///   <c>true</c> si esta instancia es principal; de lo contrario, <c>false</c>.
        /// </value>
        public bool EsPrincipal { get; set; } = false;
    }
}
