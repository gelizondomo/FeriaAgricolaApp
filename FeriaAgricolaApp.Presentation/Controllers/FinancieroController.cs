using FeriaAgricolaApp.Application;
using FeriaAgricolaApp.Domain;

namespace FeriaAgricolaApp.Presentation.Controllers
{
    public class FinancieroController
    {
        private readonly FacturaService facturaService;
        private readonly ReporteService reporteService;

        public FinancieroController(FacturaService facturaService, ReporteService reporteService)
        {
            this.facturaService = facturaService;
            this.reporteService = reporteService;
        }

        public List<Factura> ObtenerFacturasUsuario(int usuarioId)
        {
            return this.facturaService.ObtenerPorUsuario(usuarioId);
        }

        public decimal TotalMensual(int mes, int año)
        {
            return this.reporteService.TotalVentasPorMes(mes, año);
        }

        public Dictionary<string, int> TopProductos()
        {
            return this.reporteService.ProductosMasVendidos();
        }
    }
}

