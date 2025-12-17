using FeriaAgricolaApp.Application;
using FeriaAgricolaApp.Application.DTO;
using FeriaAgricolaApp.Domain;

namespace FeriaAgricolaApp.Application.Controllers
{
    public class FinancieroController
    {
        private readonly FacturaService facturaService;
        private readonly ReporteService reporteService;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FinancieroController"/> .
        /// </summary>
        /// <param name="facturaService">El factura service.</param>
        /// <param name="reporteService">El reporte service.</param>
        public FinancieroController(FacturaService facturaService, ReporteService reporteService)
        {
            this.facturaService = facturaService;
            this.reporteService = reporteService;
        }

        /// <summary>
        /// Obtener las facturas por usuario.
        /// </summary>
        /// <param name="usuarioId">The usuario identifier.</param>
        /// <returns></returns>
        public List<Factura> ObtenerFacturasUsuario(int usuarioId)
        {
            return this.facturaService.ObtenerPorUsuario(usuarioId);
        }

        /// <summary>
        /// Reporte Total mensual.
        /// </summary>
        /// <param name="mes">The mes.</param>
        /// <param name="año">The año.</param>
        /// <returns></returns>
        public decimal TotalMensual(int mes, int año)
        {
            return this.reporteService.TotalVentasPorMes(mes, año);
        }

        /// <summary>
        /// Reporte Top productos.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, int> TopProductos()
        {
            return this.reporteService.ProductosMasVendidos();
        }

        /// <summary>
        /// Ferias que mas vende.
        /// </summary>
        /// <param name="inicio">The inicio.</param>
        /// <param name="fin">The fin.</param>
        /// <returns></returns>
        public ReporteGananciaDTO FeriaQueMasVende(DateTime inicio, DateTime fin)
        {
            return reporteService.FeriaQueMasVende(inicio, fin);
        }

        /// <summary>
        /// Proveedor  que mas vende.
        /// </summary>
        /// <param name="inicio">The inicio.</param>
        /// <param name="fin">The fin.</param>
        /// <returns></returns>
        public ReporteGananciaDTO ProveedorQueMasVende(DateTime inicio, DateTime fin)
        {
            return reporteService.ProveedorQueMasVende(inicio, fin);
        }

        /// <summary>
        /// Ganancias mensuales por feria.
        /// </summary>
        /// <param name="inicio">The inicio.</param>
        /// <param name="fin">The fin.</param>
        /// <returns></returns>
        public List<ReporteGananciaDTO> GananciasMensualesPorFeria(
            DateTime inicio,
            DateTime fin)
        {
            return reporteService.GananciasMensualesPorFeria(inicio, fin);
        }

        /// <summary>
        /// Ganancias mensuales por proveedor.
        /// </summary>
        /// <param name="inicio">The inicio.</param>
        /// <param name="fin">The fin.</param>
        /// <returns></returns>
        public List<ReporteGananciaDTO> GananciasMensualesPorProveedor(
            DateTime inicio,
            DateTime fin)
        {
            return reporteService.GananciasMensualesPorProveedor(inicio, fin);
        }
    }
}

