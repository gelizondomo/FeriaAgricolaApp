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
    /// Servicio encargado de gestionar operaciones relacionadas con productos.
    /// </summary>
    public class ProductoService
    {
        private readonly IRepository<Producto> productoRepo;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ProductoService"/>.
        /// </summary>
        /// <param name="ProductoRepo">Repositorio de productos.</param>
        public ProductoService(IRepository<Producto> ProductoRepo)
        {
            this.productoRepo = ProductoRepo;
        }

        /// <summary>
        /// Obtiene todos los productos disponibles en el repositorio.
        /// </summary>
        /// <returns>Lista de productos.</returns>
        public List<Producto> GetAll() => productoRepo.GetAll();

        /// <summary>
        /// Obtiene un producto por su identificador único.
        /// </summary>
        /// <param name="id">Identificador del producto.</param>
        /// <returns>El producto correspondiente, o <c>null</c> si no se encuentra.</returns>
        public Producto? GetById(int id) => productoRepo.GetById(id);

        /// <summary>
        /// Descontar del stock.
        /// </summary>
        /// <param name="productoId">El producto id.</param>
        /// <param name="cantidad">La cantidad.</param>
        /// <exception cref="System.Exception">
        /// El producto no existe.
        /// o
        /// Stock insuficiente del producto {producto.Nombre}
        /// </exception>
        public void DescontarStock(int productoId, int cantidad)
        {
            var producto = GetById(productoId);

            if (producto == null)
                throw new Exception("El producto no existe.");

            if (producto.Stock < cantidad)
                throw new Exception($"Stock insuficiente del producto {producto.Nombre}");

            producto.Stock -= cantidad;

            productoRepo.Update(producto);
        }


        /// <summary>
        /// Filtrar por provedor.
        /// </summary>
        /// <param name="proveedorId">El proveedor id.</param>
        /// <returns></returns>
        public List<Producto> FiltrarPorProvedor(List<int> proveedorId)
        {
            return productoRepo.GetAll().Where(p => proveedorId.Contains(p.ProveedorId)).ToList();
        }

    }
}