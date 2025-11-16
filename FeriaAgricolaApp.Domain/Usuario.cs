namespace FeriaAgricolaApp.Domain
{
    /// <summary>
    /// Modelo representando a Usuarios
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Inicializa una nueva instancia del <see cref="Usuario"/> class.
        /// </summary>
        /// <param name="id">El id</param>
        /// <param name="nombre">El nombre</param>
        /// <param name="email">El email</param>
        /// <param name="password">El password</param>
        /// <param name="telefono">El telefono</param>
        /// <param name="direcciones">Las direcciones</param>
        public Usuario(int id, string nombre, string email, string password, string telefono, List<Direccion> direcciones)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            Password = password;
            Telefono = telefono;
            Direcciones = new List<Direccion>();
        }

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
        /// Gets y sets las direcciones.
        /// </summary>
        /// <value>
        /// Las direcciones.
        /// </value>
        public List<Direccion> Direcciones { get; set; } = new List<Direccion>();

        /// <summary>
        /// Convierte a String
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> que representa esta instancia.
        /// </returns>
        public override string ToString()
        {
            return $"{Id},{Nombre},{Email},{Password},{Telefono},[]{Environment.NewLine}";
        }

    }
}
