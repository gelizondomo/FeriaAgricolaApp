namespace FeriaAgricolaApp.Domain
{
    /// <summary>
    /// Modelo representando a Usuarios
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Gets y sets el id.
        /// </summary>
        /// <value>
        /// El id.
        /// </value>
        public int Id { get; set; } = 0;

        /// <summary>
        /// Gets y sets el nombre.
        /// </summary>
        /// <value>
        /// El nombre.
        /// </value>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Gets y sets el email.
        /// </summary>
        /// <value>
        /// El email.
        /// </value>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets y sets el password.
        /// </summary>
        /// <value>
        /// El password.
        /// </value>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Gets y sets el telefono.
        /// </summary>
        /// <value>
        /// El telefono.
        /// </value>
        public string Telefono { get; set; } = string.Empty;


    }
}
