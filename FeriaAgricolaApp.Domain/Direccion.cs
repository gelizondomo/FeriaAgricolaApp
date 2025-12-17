namespace FeriaAgricolaApp.Domain
{
    /// <summary>
    /// Clse a cargo de representar la direccion de un usuario.
    /// </summary>
    public class Direccion
    {

        /// <summary>
        /// Gets y sets del id de dirección.
        /// </summary>
        /// <value>
        /// El id.
        /// </value>
        public int Id { get; set; }


        /// <summary>
        /// Gets y sets del usuarioId.
        /// </summary>
        /// <value>
        /// El usuarioId.
        /// </value>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Gets y sets la provincia.
        /// </summary>
        /// <value>
        /// La provincia.
        /// </value>
        public string Provincia { get; set; } = string.Empty;

        /// <summary>
        /// Gets y sets el cantón.
        /// </summary>
        /// <value>
        /// El Cantón.
        /// </value>
        public string Canton { get; set; } = string.Empty;

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

        public override string ToString()
        {
            return $"{Provincia}, {Canton}, {Distrito}, {DireccionCompleta}";
        }
    }
}
