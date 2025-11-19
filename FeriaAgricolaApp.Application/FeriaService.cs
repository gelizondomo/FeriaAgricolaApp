using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Application
{
    public class FeriaService
    {
        /// <summary>
        /// Servicio encargado de gestionar operaciones relacionadas con ferias.
        /// </summary>
        private readonly IRepository<Feria> feriaRepo;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FeriaService"/>.
        /// </summary>
        /// <param name="fairRepo">Repositorio de ferias.</param>
        public FeriaService(IRepository<Feria> fairRepo)
        {
            feriaRepo = fairRepo;
        }

        /// <summary>
        /// Obtener todas las ferias.
        /// </summary>
        /// <returns></returns>
        public List<Feria> ObtenerTodas()
        {
            return feriaRepo.GetAll();
        }

        /// <summary>
        /// Obtener  por id las ferias.
        /// </summary>
        /// <param name="id">El id de feria.</param>
        /// <returns></returns>
        public Feria? ObtenerPorId(int id)
        {
            return feriaRepo.GetById(id);
        }
    }
}
