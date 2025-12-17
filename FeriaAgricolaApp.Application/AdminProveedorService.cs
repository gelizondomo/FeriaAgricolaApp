using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Application
{
    public class AdminProveedorService
    {
        private readonly IRepository<Proveedor> proveedorRepo;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AdminProveedorService"/> .
        /// </summary>
        /// <param name="proveedorRepo">El proveedor repo.</param>
        public AdminProveedorService(IRepository<Proveedor> proveedorRepo)
        {
            this.proveedorRepo = proveedorRepo;
        }

        /// <summary>
        /// Crear el proveedor.
        /// </summary>
        /// <param name="proveedor">The proveedor.</param>
        public void CrearProveedor(Proveedor proveedor)
        {
            proveedorRepo.Add(proveedor);
        }

        /// <summary>
        /// Asignar el proveedor a feria.
        /// </summary>
        /// <param name="proveedorId">El proveedor id.</param>
        /// <param name="feriaId">El feria id.</param>
        /// <exception cref="System.Exception">Proveedor no encontrado</exception>
        public void AsignarProveedorAFeria(int proveedorId, int feriaId)
        {
            var proveedor = proveedorRepo.GetById(proveedorId)
                ?? throw new Exception("Proveedor no encontrado");

            proveedor.FeriaId = feriaId;
            proveedorRepo.Update(proveedor);
        }
    }
}
