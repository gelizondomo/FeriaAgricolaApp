using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Domain.Enums;

namespace FeriaAgricolaApp.Web.Components.Services
{
    /// <summary>
    /// Maneja el estado del usuario en la sesión Blazor
    /// </summary>
    public class AppState
    {

        /// <summary>
        /// Gets el usuario actual.
        /// </summary>
        /// <value>
        /// El usuario actual.
        /// </value>
        public Usuario? UsuarioActual { get; private set; }

        /// <summary>
        /// Gets un valor indicando si [esta logueado].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [esta logueado]; else, <c>false</c>.
        /// </value>
        public bool EstaLogueado => UsuarioActual != null;

        /// <summary>
        /// Gets un valor indicando si [es admin].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [es admin]; else, <c>false</c>.
        /// </value>
        public bool EsAdmin => UsuarioActual?.Rol == RolUsuario.Administrador;

        /// <summary>
        /// Sets el usuario.
        /// </summary>
        /// <param name="usuario">The usuario.</param>
        public void SetUsuario(Usuario usuario)
        {
            UsuarioActual = usuario;
        }

        /// <summary>
        /// Cerrar la sesion.
        /// </summary>
        public void CerrarSesion()
        {
            UsuarioActual = null;
        }
    }
}
