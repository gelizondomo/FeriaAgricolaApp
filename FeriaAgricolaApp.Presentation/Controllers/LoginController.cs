using FeriaAgricolaApp.Application;
using FeriaAgricolaApp.Domain;

namespace FeriaAgricolaApp.Presentation.Controllers
{
    public class LoginController
    {

        private readonly UsuarioService usuarioService;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref=".LoginController"/>.
        /// </summary>
        /// <param name="usuarioService">The usuario service.</param>
        public LoginController(UsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        /// <summary>
        /// Login con correo y password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public Usuario? Login(string email, string password)
        {
            return this.usuarioService.Login(email, password);
        }


        /// <summary>
        /// Registro del usuario.
        /// </summary>
        /// <param name="nombre">The nombre.</param>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="telefono">The telefono.</param>
        /// <returns></returns>
        public bool RegistrarUsuario(string nombre, string email, string password, string telefono)
        {
            return usuarioService.RegistrarUsuario(nombre, email, password, telefono);
        }

    }
}
