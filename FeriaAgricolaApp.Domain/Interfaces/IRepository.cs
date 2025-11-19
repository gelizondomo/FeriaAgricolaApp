namespace FeriaAgricolaApp.Domain.Interfaces
{
    /// <summary>
    /// Define operaciones genéricas para el acceso y manipulación de entidades en un repositorio.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad gestionada por el repositorio.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Obtiene todas las entidades del repositorio.
        /// </summary>
        /// <returns>Lista de todas las entidades de tipo T.</returns>
        List<T> GetAll();

        /// <summary>
        /// Busca una entidad por su identificador único.
        /// </summary>
        /// <param name="id">Identificador numérico de la entidad.</param>
        /// <returns>Entidad correspondiente al identificador, o null si no se encuentra.</returns>
        T GetById(int id);

        /// <summary>
        /// Agrega una nueva entidad al repositorio.
        /// </summary>
        /// <param name="entity">Entidad a agregar.</param>
        void Add(T entity);

        /// <summary>
        /// Actualiza una entidad existente en el repositorio.
        /// </summary>
        /// <param name="entity">Entidad con los datos actualizados.</param>
        void Update(T entity);

        /// <summary>
        /// Elimina una entidad del repositorio según su identificador.
        /// </summary>
        /// <param name="id">Identificador numérico de la entidad a eliminar.</param>
        void Delete(int id);

    }
}
