using FeriaAgricolaApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Infrastructure.DataHandler
{
    /// <summary>
    /// Clase para manejo de carga y guardado de datos Json y csv
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="FeriaAgricolaApp.Domain.Interfaces.IDataHandler&lt;T&gt;" />
    public class FileHandler<T> : IDataHandler<T> where T : new()
    {
        /// <summary>
        /// The format
        /// </summary>
        private readonly string _format;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileHandler{T}"/> class.
        /// </summary>
        /// <param name="format">The format.</param>
        public FileHandler(string format = "json")
        {
            _format = format.ToLower();
        }

        /// <summary>
        /// Carga los datos.
        /// </summary>
        /// <param name="path">Nombre del archivo.</param>
        /// <returns>
        /// Lista de datos cargados.
        /// </returns>
        public List<T> LoadData(string path)
        {
            if (!File.Exists(path))
                return new List<T>();

            return _format switch
            {
                "json" => LoadJson(path),
                "csv" => LoadCsv(path),
                _ => throw new InvalidOperationException($"Formato no soportado: {_format}")
            };
        }

        /// <summary>
        /// Guarda los datos.
        /// </summary>
        /// <param name="data">Los datos a guardar.</param>
        /// <param name="path">Nombre del archivo.</param>
        /// <returns>
        /// true si los datos se guardan correctamente; de lo contrario, false.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">Formato no soportado: {_format}</exception>
        public bool SaveData(List<T> data, string path)
        {
            try
            {
                var dir = Path.GetDirectoryName(path);
                if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                switch (_format)
                {
                    case "json":
                        SaveJson(data, path);
                        break;

                    case "csv":
                        SaveCsv(data, path);
                        break;

                    default:
                        throw new InvalidOperationException($"Formato no soportado: {_format}");
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        // --- JSON ---

        /// <summary>
        /// Loads the json.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        private List<T> LoadJson(string path)
        {
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        /// <summary>
        /// Saves the json.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="path">The path.</param>
        private void SaveJson(List<T> data, string path)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }

        // --- CSV ---

        /// <summary>
        /// Loads the CSV.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        private List<T> LoadCsv(string path)
        {
            var result = new List<T>();
            var lines = File.ReadAllLines(path);

            var props = typeof(T).GetProperties();

            foreach (var line in lines)
            {
                var values = line.Split(',');

                var obj = new T();

                for (int i = 0; i < props.Length && i < values.Length; i++)
                {
                    var prop = props[i];
                    var value = Convert.ChangeType(values[i], prop.PropertyType);
                    prop.SetValue(obj, value);
                }

                result.Add(obj);
            }

            return result;
        }

        /// <summary>
        /// Saves the CSV.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="path">The path.</param>
        private void SaveCsv(List<T> data, string path)
        {
            using var writer = new StreamWriter(path);

            var props = typeof(T).GetProperties();

            foreach (var item in data)
            {
                var line = string.Join(",", props.Select(p => p.GetValue(item)?.ToString() ?? ""));
                writer.WriteLine(line);
            }
        }
    }
}
