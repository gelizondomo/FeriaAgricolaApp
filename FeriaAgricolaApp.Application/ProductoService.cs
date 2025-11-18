using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaBox.Application.Services
{
    /// <summary>
    /// Servicio encargado de gestionar operaciones relacionadas con productos.
    /// </summary>
    public class ProductoService
    {
        private readonly IRepository<Producto> ProductoRepo;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ProductoService"/>.
        /// </summary>
        /// <param name="ProductoRepo">Repositorio de productos.</param>
        public ProductoService(IRepository<Producto> ProductoRepo)
        {
            this.ProductoRepo = ProductoRepo;
        }

        /// <summary>
        /// Obtiene todos los productos disponibles en el repositorio.
        /// </summary>
        /// <returns>Lista de productos.</returns>
        public List<Producto> ObtenerTodos() => ProductoRepo.GetAll();

        /// <summary>
        /// Obtiene un producto por su identificador único.
        /// </summary>
        /// <param name="id">Identificador del producto.</param>
        /// <returns>El producto correspondiente, o <c>null</c> si no se encuentra.</returns>
        public Producto? ObtenerPorId(int id) => ProductoRepo.GetById(id);

        /// <summary>
        /// Busca productos cuyo nombre contenga el texto especificado.
        /// </summary>
        /// <param name="nombre">Texto a buscar en el nombre del producto.</param>
        /// <returns>Lista de productos que coinciden con el criterio de búsqueda.</returns>
        public List<Producto> BuscarPorNombre(string nombre)
        {
            return ProductoRepo.GetAll()
                .Where(p => p.Nombre.Contains(nombre, System.StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        /// <summary>
        /// Filtra productos por el identificador del productor.
        /// </summary>
        /// <param name="proveedorId">Identificador del productor.</param>
        /// <returns>Lista de productos asociados al productor.</returns>
        public List<Producto> FiltrarPorProductor(int proveedorId)
        {
            return ProductoRepo.GetAll().Where(p => p.ProveedorId == proveedorId).ToList();
        }
    }
}

