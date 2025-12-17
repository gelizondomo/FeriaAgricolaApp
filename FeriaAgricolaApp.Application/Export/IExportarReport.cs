using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Application.Export
{

    /// <summary>
    /// Interfaz para exportar reportes en diferentes formatos.
    /// </summary>
    public interface IReportExporter
    {

        /// <summary>
        /// Exportar los datos especificos.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="datos">Los datos.</param>
        /// <param name="rutaArchivo">la ruta archivo.</param>
        void Exportar<T>(IEnumerable<T> datos, string rutaArchivo);
    }
}
