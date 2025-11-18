using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Infrastructure.Repositorios
{
    public class UsuarioRepository : IRepository<Usuario>
    {
        private readonly string path;
        private readonly IDataHandler<Usuario> dataHandler;
        private List<Usuario> items;

        /// <summary>
        /// Inicializa una nueva instancia de la clase  <see cref="UsuarioRepository"/>.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="dataHandler">The data handler.</param>
        public UsuarioRepository(string path, IDataHandler<Usuario> dataHandler)
        {
            this.path = path;
            this.dataHandler = dataHandler;
            this.items = dataHandler.LoadData(this.path);
        }

        /// <summary>
        /// Obtiene todo por GetAll.
        /// </summary>
        /// <returns></returns>
        public List<Usuario> GetAll() => items;

        /// <summary>
        /// Obtiene el get por id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Usuario? GetById(int id)
        {
            return items.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Agrega la entidad especifica.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(Usuario entity)
        {
            items.Add(entity);
            SaveChanges();
        }

        /// <summary>
        /// Actualiza la entidad especifica.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(Usuario entity)
        {
            var idx = items.FindIndex(x => x.Id == entity.Id);
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
