using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Domain.Enums;
using FeriaAgricolaApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Infrastructure.Repositorios
{
    public class OrdenCompraRepository : IRepository<OrdenCompra>
    {
        private readonly string path;
        private readonly IDataHandler<OrdenCompra> dataHandler;
        private readonly List<OrdenCompra> items;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="OrdenCompraRepository"/>.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="dataHandler">The dataHandler.</param>
        public OrdenCompraRepository(string path, IDataHandler<OrdenCompra> dataHandler)
        {
            this.path = path;
            this.dataHandler = dataHandler;
            items = this.dataHandler.LoadData(this.path);
        }

        /// <summary>
        /// Obtiene todo por GetAll.
        /// </summary>
        /// <returns></returns>
        public List<OrdenCompra> GetAll() => items;

        /// <summary>
        /// Obtiene todo por GetAll.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public OrdenCompra? GetById(int id)
        {
            return items.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Agrega la entidad especifica.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(OrdenCompra entity)
        {
            items.Add(entity);
            SaveChanges();
        }

        /// <summary>
        /// Actualiza la entidad especifica
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(OrdenCompra entity)
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
        /// <param name="id">El Id.</param>
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
            dataHandler.SaveData(path: path, items);

        }


        /// <summary>
        /// Obtener el estado orden.
        /// </summary>
        /// <param name="usuarioId">El usuario id.</param>
        /// <returns></returns>
        public OrdenCompra? ObtenerEstadoOrden (int usuarioId)
        {
            return items.FirstOrDefault(o => o.UsuarioId == usuarioId && o.EstadoCompra == Estado.Pendiente);
        }


        /// <summary>
        /// Crear estado orden.
        /// </summary>
        /// <param name="usuarioId">El usuario id.</param>
        /// <returns></returns>
        public OrdenCompra CrearEstadoOrden(int usuarioId)
        {
            var orden = new OrdenCompra
            {
                UsuarioId = usuarioId,
                EstadoCompra = Estado.Pendiente,
                FechaCompra = DateTime.Now,
                Items = new List<CarritoItem>()
            };

            Add(orden);
            return orden;
        }
    }
}
