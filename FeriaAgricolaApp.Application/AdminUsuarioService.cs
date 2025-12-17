using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Application
{
    public class AdminUsuarioService
    {
        private readonly IRepository<Usuario> usuarioRepo;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AdminUsuarioService"/> .
        /// </summary>
        /// <param name="usuarioRepo">El usuario repo.</param>
        public AdminUsuarioService(IRepository<Usuario> usuarioRepo)
        {
            this.usuarioRepo = usuarioRepo;
        }

        /// <summary>
        /// Resetea el password.
        /// </summary>
        /// <param name="usuarioId">El usuario id.</param>
        /// <param name="nuevaPassword">La nueva password.</param>
        /// <exception cref="System.Exception">Usuario no encontrado</exception>
        public void ResetearPassword(int usuarioId, string nuevaPassword)
        {
            var usuario = usuarioRepo.GetById(usuarioId)
                ?? throw new Exception("Usuario no encontrado");

            usuario.Password = nuevaPassword;
            usuarioRepo.Update(usuario);
        }

        /// <summary>
        /// Desactivar el usuario.
        /// </summary>
        /// <param name="usuarioId">El usuario id.</param>
        /// <exception cref="System.Exception">Usuario no encontrado</exception>
        public void DesactivarUsuario(int usuarioId)
        {
            var usuario = usuarioRepo.GetById(usuarioId)
                ?? throw new Exception("Usuario no encontrado");

            usuario.Activo = false;
            usuarioRepo.Update(usuario);
        }

        /// <summary>
        /// Activar el usuario.
        /// </summary>
        /// <param name="usuarioId">El usuario id.</param>
        /// <exception cref="System.Exception">Usuario no encontrado</exception>
        public void ActivarUsuario(int usuarioId)
        {
            var usuario = usuarioRepo.GetById(usuarioId)
                ?? throw new Exception("Usuario no encontrado");
            usuario.Activo = true;
            usuarioRepo.Update(usuario);
        }

        /// <summary>
        /// Eliminar el usuario.
        /// </summary>
        /// <param name="usuarioId">El usuario id.</param>
        public void EliminarUsuario(int usuarioId)
        {
            usuarioRepo.Delete(usuarioId);
        }
    }
}
