using FeriaAgricolaApp.Domain;
using FeriaBox.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Presentation.Controllers
{
    public class CatalogoController
    {
        private readonly ProductoService productoService;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref=".CatalogoController"/>.
        /// </summary>
        /// <param name="productoService">The producto service.</param>
        public CatalogoController(ProductoService productoService)
        {
            this.productoService = productoService;
        }

        /// <summary>
        /// Obtener los productos.
        /// </summary>
        /// <returns></returns>
        public List<Producto> ObtenerProductos()
        {
            return productoService.ObtenerTodos();
        }

        /// <summary>
        /// Buscar por nombre.
        /// </summary>
        /// <param name="nombre">The nombre.</param>
        /// <returns></returns>
        public List<Producto> BuscarPorNombre(string nombre)
        {
            return productoService.BuscarPorNombre(nombre);
        }

        /// <summary>
        /// Filtrar por proveedor.
        /// </summary>
        /// <param name="proveedorId">El proveedor id.</param>
        /// <returns></returns>
        public List<Producto> FiltrarPorProveedor(int proveedorId)
        {
            return productoService.FiltrarPorProductor(proveedorId);
        }
    }
}
