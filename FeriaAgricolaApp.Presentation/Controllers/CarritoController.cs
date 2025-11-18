using FeriaAgricolaApp.Domain;
using FeriaBox.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Presentation.Controllers
{
    public class ConfirmacionCompraResult
    {
        public bool Exito { get; set; }
        public Factura? Factura { get; set; }
    }

    public class CarritoController
    {
        private readonly OrdenCompraService ordenCompraService;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CarritoController"/>.
        /// </summary>
        /// <param name="ordenCompraService">The orden compra service.</param>
        public CarritoController(OrdenCompraService ordenCompraService)
        {
            this.ordenCompraService = ordenCompraService;
        }

        /// <summary>
        /// Confirmar la compra.
        /// </summary>
        /// <param name="pedido">The pedido.</param>
        /// <param name="direccion">The direccion.</param>
        /// <returns></returns>
        public ConfirmacionCompraResult ConfirmarCompra(OrdenCompra pedido, string direccion)
        {
            var resultado = this.ordenCompraService.ProcesarPedido(pedido, direccion);
            return new ConfirmacionCompraResult
            {
                Exito = resultado.Exito,
                Factura = resultado.Factura
            };
        }
    }
}
