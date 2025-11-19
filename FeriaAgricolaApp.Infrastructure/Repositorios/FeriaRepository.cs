using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Domain.Interfaces;

namespace FeriaAgricolaApp.Infrastructure.Repositorios
{
    public class FeriaRepository : IRepository<Feria>
    {
        private readonly string path;
        private readonly IDataHandler<Feria> dataHandler;
        private readonly List<Feria> items;


        /// <summary>
        /// Inicializa una nueva instancia de la clase  <see cref="FeriaRepository"/>.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="dataHandler">The data handler.</param>
        public FeriaRepository(string path, IDataHandler<Feria> dataHandler)
        {
            this.path = path;
            this.dataHandler = dataHandler;
            this.items = this.dataHandler.LoadData(this.path);
        }

        /// <summary>
        /// Obtiene todo por GetAll.
        /// </summary>
        /// <returns></returns>
        public List<Feria> GetAll() => items;

        /// <summary>
        /// Obtiene el get por id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Feria? GetById(int id)
        {
            return items.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Agrega la entidad especifica.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(Feria entity)
        {
            items.Add(entity);
            SaveChanges();
        }

        /// <summary>
        /// Actualiza la entidad especifica
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(Feria entity)
        {
            var idx = items.FindIndex(x => x.Id == entity.Id);
            if (idx >= 0)
                items[idx] = entity;

            SaveChanges();
        }

        /// <summary>
        /// Elimina la entidad especifica.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
            items.RemoveAll(x => x.Id == id);
            SaveChanges();
        }

        /// <summary>
        /// Guarda los cambios.
        /// </summary>
        public void SaveChanges()
        {
            dataHandler.SaveData(path, items);
        }
    }


}
