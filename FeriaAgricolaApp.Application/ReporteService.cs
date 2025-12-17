using FeriaAgricolaApp.Application.DTO;
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
        private readonly IRepository<OrdenCompra> ordenRepo;
        private readonly IRepository<Producto> productoRepo;
        private readonly IRepository<Factura> facturaRepo;
        private readonly IRepository<Feria> feriaRepo;
        private readonly IRepository<Proveedor> proveedorRepo;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ReporteService"/>.
        /// </summary>
        /// <param name="ordenRepo">Repositorio de órdenes.</param>
        /// <param name="productoRepo">Repositorio de productos.</param>
        public ReporteService(IRepository<OrdenCompra> ordenRepo, IRepository<Producto> productoRepo, IRepository<Factura> facturaRepo, IRepository<Feria> feriaRepo, IRepository<Proveedor> proveedorRepo)
        {
            this.ordenRepo = ordenRepo;
            this.productoRepo = productoRepo;
            this.facturaRepo = facturaRepo;
            this.feriaRepo = feriaRepo;
            this.proveedorRepo = proveedorRepo;
        }

        /// <summary>
        /// Calcula el total de ventas realizadas en un mes y año específicos.
        /// </summary>
        /// <param name="mes">Mes del año (1 a 12).</param>
        /// <param name="año">Año calendario.</param>
        /// <returns>Total de ventas en el periodo especificado.</returns>
        public decimal TotalVentasPorMes(int mes, int año)
        {
            return ordenRepo.GetAll()
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
            var productos = productoRepo.GetAll().ToDictionary(p => p.Id, p => p.Nombre);

            var conteo = new Dictionary<string, int>();

            foreach (var order in ordenRepo.GetAll().Where(o => o.EstadoCompra== FeriaAgricolaApp.Domain.Enums.Estado.Completado))
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
        public ReporteGananciaDTO FeriaQueMasVende(DateTime inicio, DateTime fin)
        {
            // Cargar todas las ferias de una vez
            var ferias = feriaRepo.GetAll()
                .ToDictionary(f => f.Id, f => f.Nombre);

            return facturaRepo.GetAll()
                .Where(f => f.FechaFactura >= inicio && f.FechaFactura <= fin)
                .GroupBy(f => f.FeriaId)
                .Select(g => new
                {
                    FeriaId = g.Key,
                    Total = g.Sum(f => f.Total)
                })
                .OrderByDescending(x => x.Total)
                .Select(x => new ReporteGananciaDTO
                {
                    Id = x.FeriaId,
                    Nombre = ferias.GetValueOrDefault(x.FeriaId) ?? "Desconocido",
                    Total = x.Total
                })
                .FirstOrDefault()
                ?? new ReporteGananciaDTO();
        }
        public ReporteGananciaDTO ProveedorQueMasVende(DateTime inicio, DateTime fin)
        {
            // 1 consulta: todos los proveedores
            var proveedores = proveedorRepo.GetAll()
                .ToDictionary(p => p.Id, p => p.Nombre);

            // 1 consulta: órdenes filtradas y agrupadas
            var proveedorTop = ordenRepo.GetAll()
                .Where(o => o.FechaCompra >= inicio &&
                           o.FechaCompra <= fin &&
                           o.EstadoCompra == Domain.Enums.Estado.Completado)
                .GroupBy(o => o.ProveedorId)
                .Select(g => new
                {
                    ProveedorId = g.Key,
                    Total = g.Sum(o => o.Total)
                })
                .OrderByDescending(x => x.Total)
                .FirstOrDefault();

            if (proveedorTop == null)
                return new ReporteGananciaDTO { Nombre = "Ninguno", Total = 0 };

            return new ReporteGananciaDTO
            {
                Nombre = proveedores.GetValueOrDefault(proveedorTop.ProveedorId) ?? "Desconocido",
                Total = proveedorTop.Total
            };
        }

        /// <summary>
        /// Ganancias mensuales por feria.
        /// </summary>
        /// <param name="inicio">The inicio.</param>
        /// <param name="fin">The fin.</param>
        /// <returns></returns>
        public List<ReporteGananciaDTO> GananciasMensualesPorFeria(DateTime inicio, DateTime fin)
        {
            return facturaRepo.GetAll()
                .Where(f => f.FechaFactura >= inicio && f.FechaFactura <= fin)
                .GroupBy(f => new
                {
                    f.FeriaId,
                    f.FechaFactura.Year,
                    f.FechaFactura.Month
                })
                .Select(g => new ReporteGananciaDTO
                {
                    Id = g.Key.FeriaId,
                    Nombre = feriaRepo.GetById(g.Key.FeriaId)?.Nombre ?? "Desconocido",
                    Anio = g.Key.Year,
                    Mes = g.Key.Month,
                    Total = g.Sum(f => f.Total)
                })
                .OrderBy(r => r.Anio)
                .ThenBy(r => r.Mes)
                .ToList();
        }

        /// <summary>
        /// Ganancias mensuales por proveedor.
        /// </summary>
        /// <param name="inicio">The inicio.</param>
        /// <param name="fin">The fin.</param>
        /// <returns></returns>
        public List<ReporteGananciaDTO> GananciasMensualesPorProveedor(DateTime inicio, DateTime fin)
        {

            return facturaRepo.GetAll()
                .Where(f => f.FechaFactura >= inicio && f.FechaFactura <= fin)
                .GroupBy(f => new
                {
                    f.ProveedorId,
                    f.FechaFactura.Year,
                    f.FechaFactura.Month
                })
                .Select(g => new ReporteGananciaDTO
                {
                    Id = g.Key.ProveedorId,
                    Nombre = proveedorRepo.GetById(g.Key.ProveedorId)?.Nombre ?? "Desconocido",
                    Anio = g.Key.Year,
                    Mes = g.Key.Month,
                    Total = g.Sum(f => f.Total)
                })
                .OrderBy(r => r.Anio)
                .ThenBy(r => r.Mes)
                .ToList();
        }
    }
}

