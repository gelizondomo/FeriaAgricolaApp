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
        /// Actualiza el inventario al registrar una venta.
        /// </summary>
        /// <param name="productoId">Identificador del producto vendido.</param>
        /// <param name="cantidadVendida">Cantidad vendida del producto.</param>
        /// <returns>
        /// <c>true</c> si la operación fue exitosa; <c>false</c> si el producto no existe o no hay suficiente stock.
        /// </returns>
        public bool ActualizarInventario(int productoId, int cantidadVendida)
        {
            var producto = productoRepo.GetById(productoId);
            if (producto == null || producto.Stock < cantidadVendida)
                return false;

            producto.Stock -= cantidadVendida;
            productoRepo.Update(producto);
            return true;
        }

        /// <summary>
        /// Repone el inventario de un producto específico.
        /// </summary>
        /// <param name="productoId">Identificador del producto.</param>
        /// <param name="cantidad">Cantidad a reponer.</param>
        public void ReponerInventario(int productoId, int cantidad)
        {
            var producto = productoRepo.GetById(productoId);
            if (producto != null)
            {
                producto.Stock += cantidad;
                productoRepo.Update(producto);
            }
        }
    }
}
