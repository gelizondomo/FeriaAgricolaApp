using FeriaAgricolaApp.Domain;
using FeriaBox.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
