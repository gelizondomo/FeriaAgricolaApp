using FeriaAgricolaApp.Application.Utils;
using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Application
{
    /// <summary>
    /// Servicio encargado de gestionar operaciones relacionadas con usuarios.
    /// </summary>
    public class UsuarioService
    {
        private readonly IRepository<Usuario> usuarioRepo;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UsuarioService"/>.
        /// </summary>
        /// <param name="usuarioRepo">Repositorio de usuarios.</param>
        public UsuarioService(IRepository<Usuario> usuarioRepo)
        {
            this.usuarioRepo = usuarioRepo;
        }

        /// <summary>
        /// Verifica las credenciales de acceso del usuario.
        /// </summary>
        /// <param name="email">Correo electrónico del usuario.</param>
        /// <param name="password">Contraseña del usuario.</param>
        /// <returns>
        /// El usuario correspondiente si las credenciales son válidas; de lo contrario, <c>null</c>.
        /// </returns>
        public Usuario? Login(string email, string password)
        {
            return usuarioRepo.GetAll()
            .FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                && u.Password == password);
        }

        /// <summary>
        /// Registra un nuevo usuario si el correo es válido y no está registrado previamente.
        /// </summary>
        /// <param name="nombre">Nombre del usuario.</param>
        /// <param name="email">Correo electrónico del usuario.</param>
        /// <param name="password">Contraseña del usuario.</param>
        /// <param name="telefono">Número de teléfono del usuario.</param>
        /// <returns>
        /// <c>true</c> si el usuario fue registrado exitosamente; <c>false</c> si el correo es inválido o ya existe.
        /// </returns>
        public bool RegistrarUsuario(string nombre, string email, string password, string telefono)
        {
            if (!ValidationUtils.EmailValido(email)) return false;
            if (usuarioRepo.GetAll().Any(u => u.Email == email)) return false;

            int nuevoId = usuarioRepo.GetAll().Count > 0
                ? usuarioRepo.GetAll().Max(u => u.Id) + 1
                : 1;

            var nuevo = new Usuario
            {
                Id = nuevoId,
                Nombre = nombre,
                Email = email,
                Password = password,
                Telefono = telefono,
                
            };
            usuarioRepo.Add(nuevo);
            return true;
        }

        /// <summary>
        /// Obtiene todos los usuarios registrados en el sistema.
        /// </summary>
        /// <returns>Lista de usuarios.</returns>
        public List<Usuario> GetAll() => usuarioRepo.GetAll();

        /// <summary>
        /// Obteners por id.
        /// </summary>
        /// <param name="id">El id de usuario.</param>
        /// <returns></returns>
        public Usuario? ObtenerPorId(int id) => usuarioRepo.GetById(id);
    }
}

