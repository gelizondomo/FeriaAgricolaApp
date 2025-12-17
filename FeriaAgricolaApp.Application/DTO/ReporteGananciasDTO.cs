using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Application.DTO
{
    public class ReporteGananciaDTO
    {
        /// <summary>
        /// Gets y sets el id.
        /// </summary>
        /// <value>
        /// El id.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets y sets el nombre.
        /// </summary>
        /// <value>
        /// El nombre.
        /// </value>
        public string Nombre { get; set; } = string.Empty;
        /// <summary>
        /// Gets y sets el mes.
        /// </summary>
        /// <value>
        /// El mes.
        /// </value>
        public int Mes { get; set; }
        /// <summary>
        /// Gets y sets el anio.
        /// </summary>
        /// <value>
        /// El anio.
        /// </value>
        public int Anio { get; set; }
        /// <summary>
        /// Gets y sets el total.
        /// </summary>
        /// <value>
        /// El total.
        /// </value>
        public decimal Total { get; set; }
    }
}
