using System.Text;

namespace FeriaAgricolaApp.Web.Components.Services
{
    public class DescargaReporteService
    {
        public byte[] ToCsvBytes<T>(IEnumerable<T> data)
        {
            // 1. Obtener las propiedades públicas del tipo T
            var props = typeof(T).GetProperties();

            // 2. Crear un StringBuilder para armar el contenido del CSV
            var sb = new StringBuilder();

            // 3. Escribir la primera línea con los nombres de las columnas
            sb.AppendLine(string.Join(",", props.Select(p => p.Name)));

            // 4. Recorrer cada elemento de la colección
            foreach (var item in data)
            {
                // 5. Obtener los valores de cada propiedad del objeto
                var values = props.Select(p => p.GetValue(item)?.ToString()?.Replace(",", " ") ?? "");

                // 6. Agregar la fila al CSV
                sb.AppendLine(string.Join(",", values));
            }

            // 7. Convertir el contenido a bytes en UTF-8
            return Encoding.UTF8.GetBytes(sb.ToString());

        }

        public byte[] ToTxtBytes(IEnumerable<string> lines)
          => Encoding.UTF8.GetBytes(string.Join(Environment.NewLine, lines));
    }
}
