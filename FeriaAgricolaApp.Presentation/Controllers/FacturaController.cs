using FeriaAgricolaApp.Application;
using FeriaAgricolaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Presentation.Controllers
{
    public class FacturaController
    {
        private readonly FacturaService facturaService;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref=".FacturaController"/>.
        /// </summary>
        /// <param name="facturaService">La factura service.</param>
        public FacturaController(FacturaService facturaService)
        {
            this.facturaService = facturaService;
        }

        /// <summary>
        /// Obtener todas las facturas.
        /// </summary>
        /// <returns></returns>
        public List<Factura> ObtenerTodas()
        {
            return facturaService.ObtenerTodas();
        }

        /// <summary>
        /// Obtener la factura por id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Factura? ObtenerFactura(int id)
        {
            return facturaService.ObtenerPorId(id);
        }

        /// <summary>
        /// Obtener las facturas por usuario id.
        /// </summary>
        /// <param name="usuarioId">El usuario identifier.</param>
        /// <returns></returns>
        public List<Factura> ObtenerFacturasPorUsuario(int usuarioId)
        {
            return facturaService.ObtenerPorUsuario(usuarioId);
        }

        /// <summary>
        /// Obtener la factura por orden compra id.
        /// </summary>
        /// <param name="OrdenCompraId">La orden compra identifier.</param>
        /// <returns></returns>
        public Factura? ObtenerFacturaPorOrdenCompraId(int OrdenCompraId)
        {
            return facturaService.ObtenerPorOrdenCompraId(OrdenCompraId);
        }

        /// <summary>
        /// Filtrars por fechas.
        /// </summary>
        /// <param name="inicio">The inicio.</param>
        /// <param name="fin">The fin.</param>
        /// <returns></returns>
        public List<Factura> FiltrarPorFechas(DateTime inicio, DateTime fin)
        {
            return facturaService.FiltrarPorFechas(inicio, fin);
        }

        /// <summary>
        /// Totals the facturado.
        /// </summary>
        /// <param name="inicio">The inicio.</param>
        /// <param name="fin">The fin.</param>
        /// <returns></returns>
        public decimal TotalFacturado(DateTime inicio, DateTime fin)
        {
            return facturaService.TotalFacturado(inicio, fin);
        }
    }
}
