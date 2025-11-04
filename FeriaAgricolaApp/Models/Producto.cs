using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string UnidadMedida { get; set; }
        public int Stock { get; set; }
        public int ProveedorId { get; set; }

        public Producto(int id, string nombre, decimal precio, string unidadMedida, int stock, int proveedorId)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            UnidadMedida = unidadMedida;
            Stock = stock;
            ProveedorId = proveedorId;
        }
    }
}
