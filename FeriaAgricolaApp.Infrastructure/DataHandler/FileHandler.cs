using FeriaAgricolaApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Infrastructure.DataHandler
{
    /// <summary>
    /// Clase para manejo de carga y guardado de datos Json y csv
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="FeriaAgricolaApp.Domain.Interfaces.IDataHandler&lt;T&gt;" />
    public class FileHandler<T> : IDataHandler<T>
    {
        private static readonly JsonSerializerOptions options = CreateDefaultOptions();

        private static JsonSerializerOptions CreateDefaultOptions()
        {
            var opts = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            // Permite deserializar/serializar enums desde/hacia strings ("Kg", "Unidad", ...)
            opts.Converters.Add(new JsonStringEnumConverter());
            return opts;
        }


        public List<T> LoadData(string path)
        {
            if (!File.Exists(path))
                return new List<T>();

            var json = File.ReadAllText(path);

            if (string.IsNullOrWhiteSpace(json))
                return new List<T>();

            return JsonSerializer.Deserialize<List<T>>(json, options) ?? new List<T>();
        }

        public void SaveData(string path, List<T> data)
        {
            var dir = Path.GetDirectoryName(path);
            if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var json = JsonSerializer.Serialize(data, options);

            File.WriteAllText(path, json);
        }
    }
}
