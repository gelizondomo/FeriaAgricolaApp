using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Infrastructure.Repositorios
{
    public class ProductoRepository : IRepository<Producto>
    {
        private readonly string path;
        private readonly IDataHandler<Producto> dataHandler;
        private List<Producto> items;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ProductoRepository"/>.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="dataHandler">The data handler.</param>
        public ProductoRepository(string path, IDataHandler<Producto> dataHandler)
        {
            this.path = path;
            this.dataHandler = dataHandler;
            this.items = dataHandler.LoadData(this.path);
        }

        /// <summary>
        /// Obtiene todo por GetAll.
        /// </summary>
        /// <returns></returns>
        public List<Producto> GetAll() => items;

        /// <summary>
        /// Obtiene el get por id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Producto? GetById(int id)
        {
            return items.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Agrega la entidad especifica.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(Producto entity)
        {
            this.items.Add(entity);
            SaveChanges();
        }

        /// <summary>
        /// Actualiza la entidad especifica
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(Producto entity)
        {
            var idx = this.items.FindIndex(x => x.Id == entity.Id);
            if (idx >= 0)
            {
                this.items[idx] = entity;
                SaveChanges();
            }
        }

        /// <summary>
        /// Elimina la entidad especifica.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
            this.items.RemoveAll(x => x.Id == id);
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
