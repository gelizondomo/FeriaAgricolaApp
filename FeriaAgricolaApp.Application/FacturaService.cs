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
        /// Obtiene todas las facturas asociadas a un usuario.
        /// </summary>
        /// <param name="UsuarioId">Identificador del usuario.</param>
        /// <returns>Lista de facturas del usuario.</returns>
        public List<Factura> ObtenerPorUsuario(int UsuarioId) =>
            facturaRepo.GetAll().Where(f => f.UsuarioId == UsuarioId).ToList();
    }
}

