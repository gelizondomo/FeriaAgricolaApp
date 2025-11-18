using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Domain.Interfaces;
using FeriaBox.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaBox.Application.Services
{
    /// <summary>
    /// Servicio encargado de gestionar operaciones relacionadas con usuarios.
    /// </summary>
    public class UsuarioService
    {
        private readonly IRepository<Usuario> UsuarioRepo;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UsuarioService"/>.
        /// </summary>
        /// <param name="UsuarioRepo">Repositorio de usuarios.</param>
        public UsuarioService(IRepository<Usuario> UsuarioRepo)
        {
            this.UsuarioRepo = UsuarioRepo;
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
            if (UsuarioRepo.GetAll().Any(u => u.Email == email)) return false;

            var nuevo = new Usuario
            {
                Id = 0, // O asigna el valor adecuado si corresponde
                Nombre = nombre,
                Email = email,
                Password = password,
                Telefono = telefono,
                Direcciones = new List<Direccion>() // Inicializa la lista si es necesario
            };
            UsuarioRepo.Add(nuevo);
            return true;
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
            return UsuarioRepo.GetAll().FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        /// <summary>
        /// Obtiene todos los usuarios registrados en el sistema.
        /// </summary>
        /// <returns>Lista de usuarios.</returns>
        public List<Usuario> ObtenerTodos() => UsuarioRepo.GetAll();
    }
}

