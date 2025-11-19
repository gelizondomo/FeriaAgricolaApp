using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Application
{
    /// <summary>
    /// Servicio encargado de gestionar operaciones relacionadas con facturas.
    /// </summary>
    public class FacturaService
    {
        private readonly IRepository<Factura> facturaRepo;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FacturaService"/>.
        /// </summary>
        /// <param name="facturaRepo">Repositorio de facturas.</param>
        public FacturaService(IRepository<Factura> facturaRepo)
        {
            this.facturaRepo = facturaRepo;
        }

        /// <summary>
        /// Genera una nueva factura a partir de una orden.
        /// </summary>
        /// <param name="orden">La orden asociada.</param>
        /// <param name="nombreCliente">Nombre del cliente.</param>
        /// <param name="direccionEntrega">Dirección de entrega.</param>
        /// <returns>La factura generada.</returns>
        public Factura GenerarFactura(OrdenCompra orden, int usuariId, string direccionEntrega)
        {
            var factura = new Factura
            {
                OrdenCompraId = orden.Id,
                UsuarioId = usuariId,
                Total = orden.Total,
                DireccionEntrega = direccionEntrega,
                CodigoFactura = $"FAC-{DateTime.Now:HHmmssddMMyyyy}"
            };
            
            facturaRepo.Add(factura);
            return factura;
        }

        /// <summary>
        /// Obtiene todas las facturas registradas.
        /// </summary>
        /// <returns>Lista de todas las facturas.</returns>
        public List<Factura> ObtenerTodas() => facturaRepo.GetAll();

        /// <summary>
        /// Obtiene una factura por su identificador único.
        /// </summary>
        /// <param name="id">Identificador de la factura.</param>
        /// <returns>La factura correspondiente, o null si no se encuentra.</returns>
        public Factura? ObtenerPorId(int id) => facturaRepo.GetById(id);

        /// <summary>
        /// Obtiene todas las facturas asociadas a un usuario.
        /// </summary>
        /// <param name="UsuarioId">Identificador del usuario.</param>
        /// <returns>Lista de facturas del usuario.</returns>
        public List<Factura> ObtenerPorUsuario(int UsuarioId) =>
            facturaRepo.GetAll().Where(f => f.UsuarioId == UsuarioId).ToList();

        /// <summary>
        /// Obtiene la factura asociada a una orden específica.
        /// </summary>
        /// <param name="OrdenId">Identificador de la orden.</param>
        /// <returns>La factura correspondiente, o null si no se encuentra.</returns>
        public Factura? ObtenerPorOrdenId(int OrdenCompraId) =>
            facturaRepo.GetAll().FirstOrDefault(f => f.OrdenCompraId == OrdenCompraId);

        /// <summary>
        /// Filtra las facturas emitidas dentro de un rango de fechas.
        /// </summary>
        /// <param name="inicio">Fecha de inicio del rango.</param>
        /// <param name="fin">Fecha de fin del rango.</param>
        /// <returns>Lista de facturas dentro del rango de fechas.</returns>
        public List<Factura> FiltrarPorFechas(DateTime inicio, DateTime fin) =>
            facturaRepo.GetAll().Where(f => f.FechaFactura >= inicio && f.FechaFactura <= fin).ToList();

        /// <summary>
        /// Calcula el total facturado dentro de un rango de fechas.
        /// </summary>
        /// <param name="inicio">Fecha de inicio del rango.</param>
        /// <param name="fin">Fecha de fin del rango.</param>
        /// <returns>Total facturado en el periodo.</returns>
        public decimal TotalFacturado(DateTime inicio, DateTime fin) =>
            FiltrarPorFechas(inicio, fin).Sum(f => f.Total);

        public Factura? ObtenerPorOrdenCompraId(int ordenCompraId)
        {
            throw new NotImplementedException();
        }
    }
}

