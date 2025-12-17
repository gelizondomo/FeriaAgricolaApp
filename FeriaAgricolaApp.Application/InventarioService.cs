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
    /// Servicio encargado de gestionar el inventario de productos.
    /// </summary>
    public class InventarioService
    {
        private readonly IRepository<Producto> productoRepo;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InventarioService"/>.
        /// </summary>
        /// <param name="productoRepo">Repositorio de productos.</param>
        public InventarioService(IRepository<Producto> productoRepo)
        {
            this.productoRepo = productoRepo;
        }


        /// <summary>
        /// Actualiza el stock.
        /// </summary>
        /// <param name="productoId">El producto id.</param>
        /// <param name="nuevoStock">El nuevo stock.</param>
        /// <exception cref="System.Exception">
        /// Stock inválido
        /// o
        /// Producto no encontrado
        /// </exception>
        public void ActualizarStock(int productoId, int nuevoStock)
        {
            if (nuevoStock < 0)
                throw new Exception("Stock inválido");

            var producto = productoRepo.GetById(productoId)
                ?? throw new Exception("Producto no encontrado");

            producto.Stock = nuevoStock;
            productoRepo.Update(producto);
        }

    }
}
