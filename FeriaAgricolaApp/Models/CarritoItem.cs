using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Models
{
    public class CarritoItem
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario;

        public CarritoItem(int productoId, string nombreProducto, int cantidad, decimal crecioUnitario)
        {
            ProductoId = productoId;
            NombreProducto = nombreProducto;
            Cantidad = cantidad;
            PrecioUnitario = crecioUnitario;
        }
    }
}
