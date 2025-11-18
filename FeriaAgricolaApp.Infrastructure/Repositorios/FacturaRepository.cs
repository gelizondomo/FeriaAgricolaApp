using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Infrastructure.Repositorios
{

    public class FacturaRepository : IRepository<Factura>
    {
        private readonly string path;
        private readonly IDataHandler<Factura> dataHandler;
        private readonly List<Factura> items;


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FacturaRepository"/>.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="dataHandler">The dataHandler.</param>
        public FacturaRepository(string path, IDataHandler<Factura> dataHandler)
        {
            this.path = path;
            this.dataHandler = dataHandler;
            this.items = this.dataHandler.LoadData(this.path);
        }

        /// <summary>
        /// Obtiene todo por GetAll.
        /// </summary>
        /// <returns></returns>
        public List<Factura> GetAll() => items;


        /// <summary>
        /// Obtiene el get por id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Factura? GetById(int id)
        {
            return items.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Agrega la entidad especifica.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(Factura entity)
        {
            this.items.Add(entity);
            SaveChanges();
        }


        /// <summary>
        /// Actualiza la entidad especifica
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(Factura entity)
        {
            var idx = items.FindIndex(x => x.Id == entity.Id);
            if (idx >= 0)
            {
                items[idx] = entity;
                SaveChanges();
            }
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