using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Application.Export
{

    /// <summary>
    /// Clase encargada de exportar reportes en formato TXT.
    /// </summary>
    /// <seealso cref="FeriaAgricolaApp.Application.Export.IReportExporter" />
    public class TxtReportExporter : IReportExporter
    {

        /// <summary>
        /// Exportar los datos especificos.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="ruta"></param>
        public void Exportar<T>(IEnumerable<T> data, string ruta)
        {
            var lineas = data.Select(d => d?.ToString() ?? string.Empty);
            File.WriteAllLines(ruta, lineas);
        }
    }
}
