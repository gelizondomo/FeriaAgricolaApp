using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Models
{
    public class Direccion
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string DireccionCompleta { get; set; }
        public bool EsPredeterminada { get; set; } = false;

        public Direccion(int id, int usuarioId, string direccionCompleta, bool esPredeterminada)
        {
            Id = id;
            UsuarioId = usuarioId;
            DireccionCompleta = direccionCompleta;
            EsPredeterminada = esPredeterminada;
        }
    }
}
