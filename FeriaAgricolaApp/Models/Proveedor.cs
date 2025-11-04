using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int FeriaId { get; set; }

        public Proveedor(int id, string nombre, int feriaId)
        {
            Id = id;
            Nombre = nombre;
            FeriaId = feriaId;
        }
    }
}
