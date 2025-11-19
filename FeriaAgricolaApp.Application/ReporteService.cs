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
    /// Servicio encargado de generar reportes relacionados con órdenes y productos.
    /// </summary>
    public class ReporteService
    {
        private readonly IRepository<OrdenCompra> OrdenRepo;
        private readonly IRepository<Producto> ProductoRepo;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ReporteService"/>.
        /// </summary>
        /// <param name="ordenRepo">Repositorio de órdenes.</param>
        /// <param name="productoRepo">Repositorio de productos.</param>
        public ReporteService(IRepository<OrdenCompra> ordenRepo, IRepository<Producto> productoRepo)
        {
            OrdenRepo = ordenRepo;
            ProductoRepo = productoRepo;
        }

        /// <summary>
        /// Calcula el total de ventas realizadas en un mes y año específicos.
        /// </summary>
        /// <param name="mes">Mes del año (1 a 12).</param>
        /// <param name="año">Año calendario.</param>
        /// <returns>Total de ventas en el periodo especificado.</returns>
        public decimal TotalVentasPorMes(int mes, int año)
        {
            return OrdenRepo.GetAll()
                .Where(o => o.FechaCompra.Month == mes && o.FechaCompra.Year == año)
                .Sum(o => o.Total);
        }

        /// <summary>
        /// Obtiene los productos más vendidos, ordenados por cantidad.
        /// </summary>
        /// <returns>
        /// Un diccionario con los nombres de los productos como clave y la cantidad vendida como valor.
        /// Solo se incluyen los 10 productos más vendidos.
        /// </returns>

        public Dictionary<string, int> ProductosMasVendidos()
        {
            var productos = ProductoRepo.GetAll().ToDictionary(p => p.Id, p => p.Nombre);

            var conteo = new Dictionary<string, int>();

            foreach (var order in OrdenRepo.GetAll().Where(o => o.EstadoCompra== FeriaAgricolaApp.Domain.Enums.Estado.Completado))
            {
                foreach (var item in order.Items)
                {
                    var nombre = productos.ContainsKey(item.ProductoId) ? productos[item.ProductoId] : "Desconocido";
                    if (!conteo.ContainsKey(nombre))
                        conteo[nombre] = 0;
                    conteo[nombre] += item.Cantidad;
                }
            }

            return conteo
                .OrderByDescending(x => x.Value)
                .Take(10)
                .ToDictionary(x => x.Key, x => x.Value);
        }

        
        /// <summary>
        /// Filtra las órdenes realizadas dentro de un rango de fechas.
        /// </summary>
        /// <param name="inicio">Fecha de inicio del rango.</param>
        /// <param name="fin">Fecha de fin del rango.</param>
        /// <returns>Lista de órdenes dentro del periodo especificado.</returns>
        public List<OrdenCompra> FiltrarPedidosPorFecha(DateTime inicio, DateTime fin)
        {
            return OrdenRepo.GetAll()
                .Where(o => o.FechaCompra >= inicio && o.FechaCompra <= fin)
                .ToList();
        }
    }
}

