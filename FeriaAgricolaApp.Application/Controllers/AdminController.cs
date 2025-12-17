using FeriaAgricolaApp.Application;
using FeriaAgricolaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Application.Controllers
{
    public class AdminController
    {
        private readonly AdminUsuarioService adminUsuarioService;
        private readonly InventarioService adminInventarioService;
        private readonly AdminProveedorService adminProveedorService;

        public AdminController(
            AdminUsuarioService adminUsuarioService,
            InventarioService adminInventarioService,
            AdminProveedorService adminProveedorService)
        {
            this.adminUsuarioService = adminUsuarioService;
            this.adminInventarioService = adminInventarioService;
            this.adminProveedorService = adminProveedorService;
        }

        /// <summary>
        /// Resetear el password usuario.
        /// </summary>
        /// <param name="usuarioId">El usuario identifier.</param>
        /// <param name="nuevaPassword">El nuevo password.</param>
        public void ResetearPasswordUsuario(int usuarioId, string nuevaPassword)
        {
            adminUsuarioService.ResetearPassword(usuarioId, nuevaPassword);
        }

        /// <summary>
        /// Desactivar el usuario.
        /// </summary>
        /// <param name="usuarioId">El usuario id.</param>
        public void DesactivarUsuario(int usuarioId)
        {
            adminUsuarioService.DesactivarUsuario(usuarioId);
        }

        /// <summary>
        /// Activar el usuario.
        /// </summary>
        /// <param name="usuarioId">El usuario id.</param>
        public void ActivarUsuario(int usuarioId)
        {
            adminUsuarioService.ActivarUsuario(usuarioId);
        }

        /// <summary>
        /// Eliminar el usuario.
        /// </summary>
        /// <param name="usuarioId">El usuario id.</param>
        public void EliminarUsuario(int usuarioId)
        {
            adminUsuarioService.EliminarUsuario(usuarioId);
        }

        /// <summary>
        /// Actualizar el stock producto.
        /// </summary>
        /// <param name="productoId">El producto id.</param>
        /// <param name="nuevoStock">El nuevo stock.</param>
        public void ActualizarStockProducto(int productoId, int nuevoStock)
        {
            adminInventarioService.ActualizarStock(productoId, nuevoStock);
        }


        /// <summary>
        /// Crear el proveedor.
        /// </summary>
        /// <param name="proveedor">El proveedor.</param>
        public void CrearProveedor(Proveedor proveedor)
        {
            adminProveedorService.CrearProveedor(proveedor);
        }

        /// <summary>
        /// Asignar el proveedor a feria.
        /// </summary>
        /// <param name="proveedorId">El proveedor id.</param>
        /// <param name="feriaId">El feria id.</param>
        public void AsignarProveedorAFeria(int proveedorId, int feriaId)
        {
            adminProveedorService.AsignarProveedorAFeria(proveedorId, feriaId);
        }
    }
}
