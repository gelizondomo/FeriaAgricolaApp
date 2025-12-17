using FeriaAgricolaApp.Domain.Enums;

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


        /// <summary>
        /// Gets y sets de direcciones.
        /// </summary>
        /// <value>
        /// Las direcciones.
        /// </value>
        public List<Direccion> Direcciones { get; set; } = new();

        /// <summary>
        /// Gets y sets del rol.
        /// </summary>
        /// <value>
        /// El rol.
        /// </value>
        public RolUsuario Rol { get; set; } = RolUsuario.Comprador;

        /// <summary>
        /// Gets y sets valor que indica si este <see cref="Usuario"/> está activo.
        /// </summary>
        /// <value>
        ///   <c>true</c> si está activo; de lo contrario, <c>false</c>.
        /// </value>

        public bool Activo { get; set; } = true;
    }
}
