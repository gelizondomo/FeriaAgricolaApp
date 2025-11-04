using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal Total { get; set; }
        public int DireccionEntregaId { get; set; }
        /*Proceso para cargar el historial de compras todavía no implementado public List<CompraItem> Items { get; set; } = new List<CompraItem>();*/
    }
}
