namespace FeriaAgricolaApp.Domain.Interfaces
{
    /// <summary>
    /// Interfaz para el manejador de datos. La idea es definir un contrato para operaciones de datos.
    /// </summary>
    public interface IDataHandler<T>
    {
        /// <summary>
        /// Guarda los datos.
        /// </summary>
        /// <param name="data">Los datos a guardar.</param>
        /// <param name="fileName">Nombre del archivo.</param>
        /// <returns>
        /// true si los datos se guardan correctamente; de lo contrario, false.
        /// </returns>
        public bool SaveData(List<T> data, string fileName);

        /// <summary>
        /// Carga los datos.
        /// </summary>
        /// <param name="fileName">Nombre del archivo.</param>
        /// <returns>
        /// Lista de datos cargados.
        /// </returns>
        public List<T> LoadData(string fileName);
        void SaveData(string path, List<Factura> items);
        void SaveData(string path, List<OrdenCompra> items);
        void SaveData(string path, List<Producto> items);
        void SaveData(string path, List<Proveedor> items);
        void SaveData(object path, List<Usuario> items);
    }

}
