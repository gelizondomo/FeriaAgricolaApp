using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Application
{
    public class ProveedorService
    {
        private readonly IRepository<Proveedor> proveedorRepo;

        public ProveedorService(IRepository<Proveedor> proveedorRepo)
        {
            this.proveedorRepo = proveedorRepo;
        }

        /// <summary>
        /// Obtiene todos los proveedores del sistema
        /// </summary>
        public List<Proveedor> GetAll()
        {
            return proveedorRepo.GetAll();
        }

        /// <summary>
        /// Obtiene un proveedor por su Id
        /// </summary>
        public Proveedor? ObtenerPorId(int id)
        {
            return proveedorRepo.GetById(id);
        }

        /// <summary>
        /// Obtiene los proveedores que pertenecen a una feria específica
        /// </summary>
        public List<Proveedor> ObtenerPorFeria(int feriaId)
        {
            return proveedorRepo.GetAll()
                .Where(p => p.FeriaId == feriaId)
                .ToList();
        }
    }

}
