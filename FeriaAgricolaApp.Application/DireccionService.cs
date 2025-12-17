using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Application
{
    public class DireccionService
    {

        /// <summary>
        /// El direccion direccionRepo
        /// </summary>
        private readonly IRepository<Direccion> direccionRepo;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="DireccionService"/> .
        /// </summary>
        /// <param name="direccionRepo">Repositorio de Direcciones.</param>
        public DireccionService(IRepository<Direccion> direccionRepo)
        {
            this.direccionRepo = direccionRepo;
        }

        /// <summary>
        /// Obtener por usuario.
        /// </summary>
        /// <param name="usuarioId">El usuario id.</param>
        /// <returns></returns>
        public List<Direccion> ObtenerPorUsuario(int usuarioId)
        {
            return direccionRepo.GetAll()
                .Where(d => d.UsuarioId == usuarioId)
                .ToList();
        }

        /// <summary>
        /// Obtener la dirección principal.
        /// </summary>
        /// <param name="usuarioId">El usuario idr.</param>
        /// <returns></returns>
        public Direccion? ObtenerPrincipal(int usuarioId)
        {
            var todas = ObtenerPorUsuario(usuarioId);
            return todas.FirstOrDefault(d => d.EsPrincipal)
                   ?? todas.FirstOrDefault();
        }
    }
}
