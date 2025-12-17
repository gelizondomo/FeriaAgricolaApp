using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Application.Export
{

    /// <summary>
    /// Clase encargada de exportar reportes en formato CSV.
    /// </summary>
    /// <seealso cref="FeriaAgricolaApp.Application.Export.IReportExporter" />
    public class ExportarCsvReport : IReportExporter
    {

        /// <summary>
        /// Exportar los datos especificos.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="ruta"></param>
        public void Exportar<T>(IEnumerable<T> data, string ruta)
        {
            // Obtiene todas las propiedades públicas de la clase T (el tipo genérico)
            var propiedades = typeof(T).GetProperties();

            // Crea una lista de líneas que representarán el contenido del archivo
            // La primera línea será el encabezado con los nombres de las propiedades separados por comas
            var lineas = new List<string>
            {
                string.Join(",", propiedades.Select(p => p.Name))
            };

            // Recorre cada objeto de la colección 'data'
            foreach (var item in data)
            {
                // Obtiene los valores de todas las propiedades del objeto actual
                var valores = propiedades.Select(p => p.GetValue(item)?.ToString());

                // Une los valores en una sola línea separados por comas y la agrega a la lista
                lineas.Add(string.Join(",", valores));
            }

            // Escribe todas las líneas en el archivo especificado por 'ruta'
            File.WriteAllLines(ruta, lineas);

        }
    }

}
