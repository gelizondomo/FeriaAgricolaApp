using Moq;

namespace ClassExamplesConsole.Test
{
    using FeriaAgricolaApp.Application;
    using FeriaAgricolaApp.Application.Controllers;
    using FeriaAgricolaApp.Domain;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Contiene pruebas unitarias para la clase <see cref="AdminController"/>.
    /// Verifica que cada acción del controlador invoque correctamente
    /// los servicios correspondientes.
    /// </summary>
    [TestClass]
    public class AdminControllerTests
    {
        /// <summary>
        /// Mock del servicio de administración de usuarios.
        /// </summary>
        private Mock<AdminUsuarioService> mockAdminUsuarioService;

        /// <summary>
        /// Mock del servicio de inventario.
        /// </summary>
        private Mock<InventarioService> mockInventarioService;

        /// <summary>
        /// Mock del servicio de administración de proveedores.
        /// </summary>
        private Mock<AdminProveedorService> mockAdminProveedorService;

        /// <summary>
        /// Instancia del controlador bajo prueba.
        /// </summary>
        private AdminController adminController;

        /// <summary>
        /// Inicializa las dependencias mock y crea la instancia del controlador
        /// antes de cada prueba.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            // ARRANGE
            mockAdminUsuarioService = new Mock<AdminUsuarioService>();
            mockInventarioService = new Mock<InventarioService>();
            mockAdminProveedorService = new Mock<AdminProveedorService>();

            adminController = new AdminController(
                mockAdminUsuarioService.Object,
                mockInventarioService.Object,
                mockAdminProveedorService.Object
            );
        }

        /// <summary>
        /// Verifica que <see cref="AdminController.ResetearPasswordUsuario(int, string)"/>
        /// invoque el método correspondiente del servicio de usuarios exactamente una vez.
        /// </summary>
        [TestMethod]
        public void ResetearPasswordUsuario_DebeLlamarAlServicio()
        {
            // ARRANGE
            int usuarioId = 1;
            string nuevaPassword = "1234";

            // ACT
            adminController.ResetearPasswordUsuario(usuarioId, nuevaPassword);

            // ASSERT
            mockAdminUsuarioService.Verify(
                s => s.ResetearPassword(usuarioId, nuevaPassword),
                Times.Once
            );
        }

        /// <summary>
        /// Verifica que <see cref="AdminController.DesactivarUsuario(int)"/>
        /// invoque el servicio de usuarios para desactivar un usuario.
        /// </summary>
        [TestMethod]
        public void DesactivarUsuario_DebeLlamarAlServicio()
        {
            // ARRANGE
            int usuarioId = 5;

            // ACT
            adminController.DesactivarUsuario(usuarioId);

            // ASSERT
            mockAdminUsuarioService.Verify(
                s => s.DesactivarUsuario(usuarioId),
                Times.Once
            );
        }

        /// <summary>
        /// Verifica que <see cref="AdminController.EliminarUsuario(int)"/>
        /// invoque el método correspondiente del servicio de usuarios.
        /// </summary>
        [TestMethod]
        public void EliminarUsuario_DebeLlamarAlServicio()
        {
            // ARRANGE
            int usuarioId = 10;

            // ACT
            adminController.EliminarUsuario(usuarioId);

            // ASSERT
            mockAdminUsuarioService.Verify(
                s => s.EliminarUsuario(usuarioId),
                Times.Once
            );
        }

        /// <summary>
        /// Verifica que <see cref="AdminController.ActualizarStockProducto(int, int)"/>
        /// invoque el servicio de inventario para actualizar el stock.
        /// </summary>
        [TestMethod]
        public void ActualizarStockProducto_DebeLlamarInventarioService()
        {
            // ARRANGE
            int productoId = 3;
            int nuevoStock = 50;

            // ACT
            adminController.ActualizarStockProducto(productoId, nuevoStock);

            // ASSERT
            mockInventarioService.Verify(
                s => s.ActualizarStock(productoId, nuevoStock),
                Times.Once
            );
        }

        /// <summary>
        /// Verifica que <see cref="AdminController.CrearProveedor(Proveedor)"/>
        /// invoque el servicio de proveedores para crear un nuevo proveedor.
        /// </summary>
        [TestMethod]
        public void CrearProveedor_DebeLlamarAdminProveedorService()
        {
            // ARRANGE
            var proveedor = new Proveedor();

            // ACT
            adminController.CrearProveedor(proveedor);

            // ASSERT
            mockAdminProveedorService.Verify(
                s => s.CrearProveedor(proveedor),
                Times.Once
            );
        }

        /// <summary>
        /// Verifica que <see cref="AdminController.AsignarProveedorAFeria(int, int)"/>
        /// invoque el servicio correspondiente para asignar un proveedor a una feria.
        /// </summary>
        [TestMethod]
        public void AsignarProveedorAFeria_DebeLlamarServicio()
        {
            // ARRANGE
            int proveedorId = 2;
            int feriaId = 7;

            // ACT
            adminController.AsignarProveedorAFeria(proveedorId, feriaId);

            // ASSERT
            mockAdminProveedorService.Verify(
                s => s.AsignarProveedorAFeria(proveedorId, feriaId),
                Times.Once
            );
        }
    }
}
