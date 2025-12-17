using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Domain.Interfaces;
using FeriaAgricolaApp.Infrastructure.Configuration;
using FeriaAgricolaApp.Infrastructure.DataHandler;
using FeriaAgricolaApp.Infrastructure.Repositorios;
using FeriaAgricolaApp.Presentation.Views;
using FeriaAgricolaApp.Application;
using FeriaAgricolaApp.Application.Controllers;

namespace FeriaAgricolaApp.Presentation
{
    internal static class Program
    {

        /// <summary>
        /// Gets or sets del usuario actual.
        /// </summary>
        /// <value>
        /// El usuario actual.
        /// </value>
        public static Usuario? UsuarioActual {  get; private set; }

        /// <summary>
        /// Obtiene el  direccion service.
        /// </summary>
        /// <value>
        /// El direccion service.
        /// </value>
        public static DireccionService? DireccionService { get; private set; }

        /// <summary>
        /// Obtiene el proveedor service.
        /// </summary>
        /// <value>
        /// El proveedor service.
        /// </value>
        public static ProveedorService? ProveedorService { get; private set; }

        public static void SetUsuarioActual(Usuario usuario)
        {
            UsuarioActual = usuario;
        }

        public static FrmPrincipal CrearFrmPrincipal()
        {
            return new FrmPrincipal(UsuarioActual!, catalogoController, carritoController, financieroController);
        }

        public static FrmCatalogo CrearFrmCatalogo()
        {
            return new FrmCatalogo(catalogoController, UsuarioActual!);
        }

        public static FrmCarrito CrearFrmCarrito()
        {
            return new FrmCarrito(carritoController, UsuarioActual!);
        }

        public static FrmFinanciero CrearFrmFinanciero()
        {
            return new FrmFinanciero(financieroController, UsuarioActual!);
        }


        // Servicios
        private static UsuarioService usuarioService;
        private static DireccionService direccionService;
        private static FeriaService feriaService;
        private static ProductoService productoService;
        private static ProveedorService proveedorService;
        private static InventarioService inventarioService;
        private static OrdenCompraService ordenCompraService;
        private static FacturaService facturaService;
        private static ReporteService reporteService;

        //Controladores
        private static LoginController loginController;
        private static AdminController adminController;
        private static CatalogoController catalogoController;
        private static CarritoController carritoController;
        private static FinancieroController financieroController;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Forzar que use SIEMPRE System.Windows.Forms.Application
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
            //carga de repositorios
            IDataHandler<Usuario> usuarioHandler = new FileHandler<Usuario>();
            IDataHandler<Direccion> direccionHandler = new FileHandler<Direccion>();
            IDataHandler<Producto> productoHandler = new FileHandler<Producto>();
            IDataHandler<OrdenCompra> ordenCompraHandler = new FileHandler<OrdenCompra>();
            IDataHandler<Factura> facturaHandler = new FileHandler<Factura>();
            IDataHandler<Proveedor> proveedorHandler = new FileHandler<Proveedor>();
            IDataHandler<Feria> feriaHandler = new FileHandler<Feria>();

            IRepository<Usuario> usuarioRepo = new UsuarioRepository(FilePaths.Usuarios, usuarioHandler);
            IRepository<Direccion> direccionRepo = new DireccionRepository(FilePaths.Direcciones, direccionHandler);
            IRepository<Producto> productoRepo = new ProductoRepository(FilePaths.Productos, productoHandler);
            IRepository<OrdenCompra> ordenCompraRepo = new OrdenCompraRepository(FilePaths.Compras, ordenCompraHandler);
            IRepository<Factura> facturaRepo = new FacturaRepository(FilePaths.Facturas, facturaHandler);
            IRepository<Proveedor> proveedorRepo = new ProveedorRepository(FilePaths.Proveedores, proveedorHandler);
            IRepository<Feria> feriaRepo = new FeriaRepository(FilePaths.Ferias, feriaHandler);

            // Services
            usuarioService = new UsuarioService(usuarioRepo);
            direccionService = new DireccionService(direccionRepo);
            Program.DireccionService = direccionService;
            feriaService = new FeriaService(feriaRepo);
            productoService = new ProductoService(productoRepo);
            proveedorService = new ProveedorService(proveedorRepo);
            inventarioService = new InventarioService(productoRepo);
            facturaService = new FacturaService(facturaRepo);
            ordenCompraService = new OrdenCompraService(ordenCompraRepo, productoService);
            reporteService = new ReporteService(ordenCompraRepo, productoRepo, facturaRepo, feriaRepo, proveedorRepo);
            AdminUsuarioService adminUsuarioService = new AdminUsuarioService(usuarioRepo);
            AdminProveedorService adminProveedorService = new AdminProveedorService(proveedorRepo);

            // Controllers
            loginController = new LoginController(usuarioService);
            catalogoController = new CatalogoController(productoService, proveedorService, feriaService, ordenCompraService);
            carritoController = new CarritoController(ordenCompraService, productoService, facturaService, direccionService);
            financieroController = new FinancieroController(facturaService, reporteService);
            adminController = new AdminController(adminUsuarioService, inventarioService,adminProveedorService);


            System.Windows.Forms.Application.Run(new FrmLogin(loginController));
        }
    }
}