namespace FeriaAgricolaApp.Domain.Interfaces
{
    /// <summary>
    /// Interfaz para el manejador de datos. La idea es definir un contrato para operaciones de datos.
    /// </summary>
    public interface IDataHandler<T>
    {
        /// <summary>
        /// Carga el path especifico.
        /// </summary>
        /// <param name="path">El path.</param>
        /// <returns></returns>
        List<T> LoadData(string path);
        /// <summary>
        /// Guarda el path especifico.
        /// </summary>
        /// <param name="path">El path.</param>
        /// <param name="data">La data.</param>
        void SaveData(string path, List<T> data);

    }

}
