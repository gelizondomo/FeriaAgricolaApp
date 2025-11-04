using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Models
{
    public class Feria
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string Localidad { get; set; }
        public string Horario { get; set; }

        public Feria(int id, string nombre, string localidad, string horario)
        {
            this.id = id;
            this.nombre = nombre;
            Localidad = localidad;
            Horario = horario;
        }
    }
}
