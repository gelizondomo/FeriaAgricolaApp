using FeriaAgricolaApp.Domain.Interfaces;
using System.Collections.Generic;

namespace FeriaAgricolaApp.Presentation.Controllers
{
    /// <summary>
    /// Implementación de <see cref="IDataHandler{T}"/> para manejar operaciones de archivos.
    /// </summary>
    /// <typeparam name="T">Tipo de datos que se manejarán.</typeparam>
    public class FileHandler<T> : IDataHandler<T>
    {
        /// <summary>
        /// Carga los datos desde un archivo.
        /// </summary>
        /// <param name="fileName">Nombre del archivo.</param>
        /// <returns>
        /// Lista de datos cargados desde el archivo.
        /// </returns>
        public List<T> LoadData(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("El nombre del archivo no puede ser nulo o vacío.", nameof(fileName));
            }
            else if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("El archivo especificado no fue encontrado.", fileName);
            }

            var result = new List<T>();
            var lines = File.ReadAllLines(fileName);

            foreach (var line in lines)
            {
                var properties = line.Split(',');
                var obj = (T)Activator.CreateInstance(typeof(T), properties)!;
                result.Add(obj);
            }

            return result;
        }

        /// <summary>
        /// Guarda los datos en un archivo.
        /// </summary>
        /// <param name="data">Lista de datos a guardar.</param>
        /// <param name="fileName">Nombre del archivo.</param>
        /// <returns>
        /// true si los datos se guardan correctamente; de lo contrario, false.
        /// </returns>
        public bool SaveData(List<T> data, string fileName)
        {
            if (data == null || data.Count == 0)
            {
                throw new ArgumentException("La lista de datos no debe estar vacía.", nameof(data));
            }
            else if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("El nombre del archivo no puede ser nulo o vacío.", nameof(fileName));
            }
            else if (!Directory.Exists(Path.GetDirectoryName(fileName)))
            {
                throw new DirectoryNotFoundException("El directorio especificado no existe.");
            }

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using var writer = new StreamWriter(File.Create(fileName));
            foreach (var element in data)
            {
                writer.WriteLine(element!.ToString());
            }

            return true;
        }
    }
}
