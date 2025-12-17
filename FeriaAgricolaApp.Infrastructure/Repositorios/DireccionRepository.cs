using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Infrastructure.Repositorios
{
    public class DireccionRepository : IRepository<Direccion>
    {
        private readonly string path;
        private readonly IDataHandler<Direccion> dataHandler;
        private readonly List<Direccion> items;


        /// <summary>
        /// Initializes a new instance of the <see cref="DireccionRepository"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="dataHandler">The data handler.</param>
        public DireccionRepository(string path, IDataHandler<Direccion> dataHandler)
        {
            this.path = path;
            this.dataHandler = dataHandler;
            this.items = dataHandler.LoadData(path) ?? new List<Direccion>();
        }

        /// <summary>
        /// Obtiene todas las entidades del repositorio.
        /// </summary>
        /// <returns>
        /// Lista de todas las entidades de tipo T.
        /// </returns>
        public List<Direccion> GetAll() => items;

        /// <summary>
        /// Busca una entidad por su identificador único.
        /// </summary>
        /// <param name="id">Identificador numérico de la entidad.</param>
        /// <returns>
        /// Entidad correspondiente al identificador, o null si no se encuentra.
        /// </returns>
        public Direccion GetById(int id)
        {
            return items.FirstOrDefault(d => d.Id == id);
        }

        /// <summary>
        /// Agrega una nueva entidad al repositorio.
        /// </summary>
        /// <param name="entity">Entidad a agregar.</param>
        public void Add(Direccion entity)
        {
            items.Add(entity);
            dataHandler.SaveData(path, items);
        }

        /// <summary>
        /// Actualiza una entidad existente en el repositorio.
        /// </summary>
        /// <param name="entity">Entidad con los datos actualizados.</param>
        public void Update(Direccion entity)
        {
            var idx = items.FindIndex(d => d.Id == entity.Id);
            if (idx >= 0)
            {
                items[idx] = entity;
                dataHandler.SaveData(path, items);
            }
        }

        /// <summary>
        /// Elimina una entidad del repositorio según su identificador.
        /// </summary>
        /// <param name="id">Identificador numérico de la entidad a eliminar.</param>
        public void Delete(int id)
        {
            var d = GetById(id);
            if (d != null)
            {
                items.Remove(d);
                dataHandler.SaveData(path, items);
            }
        }
    }
}
