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
        public List<Producto> ObtenerTodos() => productoRepo.GetAll();

        /// <summary>
        /// Obtiene un producto por su identificador único.
        /// </summary>
        /// <param name="id">Identificador del producto.</param>
        /// <returns>El producto correspondiente, o <c>null</c> si no se encuentra.</returns>
        public Producto? GetById(int id) => productoRepo.GetById(id);


        /// <summary>
        /// Actualizar el producto.
        /// </summary>
        /// <param name="producto">El producto.</param>
        public void ActualizarProducto(Producto producto)
        {
            productoRepo.Update(producto);
        }


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
        /// Agregar el producto.
        /// </summary>
        /// <param name="nuevo">El nuevo producto</param>
        public void AgregarProducto(Producto nuevo)
        {
            productoRepo.Add(nuevo);
        }

        /// <summary>
        /// Filtra productos por el identificador del productor.
        /// </summary>
        /// <param name="proveedorId">Identificador del productor.</param>
        /// <returns>Lista de productos asociados al productor.</returns>
        public List<Producto> FiltrarPorProvedor(int proveedorId)
        {
            return productoRepo.GetAll().Where(p => p.ProveedorId == proveedorId).ToList();
        }


        /// <summary>
        /// Obtener por feria.
        /// </summary>
        /// <param name="feriaId">La feria id.</param>
        /// <returns></returns>
        public List<Producto> ObtenerPorFeria(int feriaId)
        => productoRepo.GetAll().Where(p => p.FeriaId == feriaId).ToList();


        /// <summary>
        /// Buscars por nombre producto y feria.
        /// </summary>
        /// <param name="nombre">El nombre.</param>
        /// <param name="feriaId">La feria id.</param>
        /// <returns></returns>
        public List<Producto> BuscarPorNombreYFeria(string nombre, int feriaId)
            => productoRepo.GetAll()
                  .Where(p => p.FeriaId == feriaId &&
                              p.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                  .ToList();
    }
}

