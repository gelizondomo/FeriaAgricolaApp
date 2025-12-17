using FeriaAgricolaApp.Application;
using FeriaAgricolaApp.Application.Controllers;
using FeriaAgricolaApp.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Contiene pruebas unitarias para la clase <see cref="FeriaAgricolaApp.Application.Controllers.CatalogoController"/>.
/// Valida el comportamiento de filtrado, consulta de ferias, proveedores,
/// productos y la lógica de agregar productos al carrito.
/// </summary>
[TestClass]
public class CatalogoControllerTests
{
    /// <summary>
    /// Mock del servicio de productos.
    /// </summary>
    private Mock<ProductoService>? mockProductoService;

    /// <summary>
    /// Mock del servicio de proveedores.
    /// </summary>
    private Mock<ProveedorService>? mockProveedorService;

    /// <summary>
    /// Mock del servicio de ferias.
    /// </summary>
    private Mock<FeriaService>? mockFeriaService;

    /// <summary>
    /// Mock del servicio de órdenes de compra.
    /// </summary>
    private Mock<OrdenCompraService>? mockOrdenCompraService;

    /// <summary>
    /// Instancia del controlador bajo prueba.
    /// </summary>
    private CatalogoController? CatalogoController;

    /// <summary>
    /// Inicializa los mocks y la instancia del controlador antes de cada prueba.
    /// </summary>
    [TestInitialize]
    public void Setup()
    {
        mockProductoService = new Mock<ProductoService>();
        mockProveedorService = new Mock<ProveedorService>();
        mockFeriaService = new Mock<FeriaService>();
        mockOrdenCompraService = new Mock<OrdenCompraService>();

        CatalogoController = new CatalogoController(
            mockProductoService.Object,
            mockProveedorService.Object,
            mockFeriaService.Object,
            mockOrdenCompraService.Object
        );
    }

    /// <summary>
    /// Verifica que <see cref="CatalogoController.FiltrarPorProveedor(int)"/>
    /// retorne el nombre del proveedor cuando existe.
    /// </summary>
    [TestMethod]
    public void FiltrarPorProveedor_ProveedorExiste_DebeRetornarNombre()
    {
        var proveedor = new Proveedor { Nombre = "Proveedor A" };

        mockProveedorService
            .Setup(s => s.ObtenerPorId(1))
            .Returns(proveedor);

        var resultado = CatalogoController.FiltrarPorProveedor(1);

        Assert.AreEqual("Proveedor A", resultado);
    }

    /// <summary>
    /// Verifica que <see cref="CatalogoController.FiltrarPorProveedor(int)"/>
    /// retorne "Desconocido" cuando el proveedor no existe.
    /// </summary>
    [TestMethod]
    public void FiltrarPorProveedor_ProveedorNoExiste_DebeRetornarDesconocido()
    {
        mockProveedorService
            .Setup(s => s.ObtenerPorId(1))
            .Returns((Proveedor)null);

        var resultado = CatalogoController.FiltrarPorProveedor(1);

        Assert.AreEqual("Desconocido", resultado);
    }

    /// <summary>
    /// Verifica que <see cref="CatalogoController.AgregarAlCarrito(int, int, int)"/>
    /// agregue un producto al carrito y guarde los cambios cuando existe stock suficiente.
    /// </summary>
    [TestMethod]
    public void AgregarAlCarrito_ProductoExisteYStockSuficiente_DebeGuardarCambios()
    {
        int usuarioId = 1;
        int productoId = 10;
        int cantidad = 2;

        var carrito = new OrdenCompra
        {
            Items = new List<CarritoItem>()
        };

        var producto = new Producto
        {
            Id = productoId,
            Stock = 10
        };

        mockOrdenCompraService
            .Setup(s => s.ObtenerOCrearCarrito(usuarioId))
            .Returns(carrito);

        mockProductoService
            .Setup(s => s.GetById(productoId))
            .Returns(producto);

        CatalogoController.AgregarAlCarrito(usuarioId, productoId, cantidad);

        Assert.AreEqual(1, carrito.Items.Count);

        mockOrdenCompraService.Verify(
            s => s.GuardarCambios(carrito),
            Times.Once
        );
    }

    /// <summary>
    /// Verifica que <see cref="CatalogoController.AgregarAlCarrito(int, int, int)"/>
    /// lance una excepción cuando el producto no existe.
    /// </summary>
    [TestMethod]
    public void AgregarAlCarrito_ProductoNoExiste_DebeLanzarExcepcion()
    {
        // ARRANGE
        mockProductoService
            .Setup(s => s.GetById(1))
            .Returns((Producto)null);

        mockOrdenCompraService
            .Setup(s => s.ObtenerOCrearCarrito(1))
            .Returns(new OrdenCompra { Items = new List<CarritoItem>() });

        // ACT / ASSERT
        Assert.Throws<Exception>(() =>
        {
            CatalogoController.AgregarAlCarrito(1, 1, 1);
        });
    }


    /// <summary>
    /// Verifica que <see cref="CatalogoController.AgregarAlCarrito(int, int, int)"/>
    /// lance una excepción cuando el stock es insuficiente.
    /// </summary>
    [TestMethod]
    public void AgregarAlCarrito_StockInsuficiente_DebeLanzarExcepcion()
    {
        // ARRANGE
        var producto = new Producto
        {
            Id = 1,
            Stock = 1
        };

        mockProductoService
            .Setup(s => s.GetById(1))
            .Returns(producto);

        mockOrdenCompraService
            .Setup(s => s.ObtenerOCrearCarrito(1))
            .Returns(new OrdenCompra { Items = new List<CarritoItem>() });

        // ACT + ASSERT
        Assert.Throws<Exception>(() =>
        {
            CatalogoController.AgregarAlCarrito(1, 1, 5);
        });
    }


    /// <summary>
    /// Verifica que <see cref="CatalogoController.ObtenerFerias()"/>
    /// retorne la lista de ferias.
    /// </summary>
    [TestMethod]
    public void ObtenerFerias_DebeRetornarLista()
    {
        var ferias = new List<Feria> { new Feria() };

        mockFeriaService
            .Setup(s => s.GetAll())
            .Returns(ferias);

        var resultado = CatalogoController.ObtenerFerias();

        Assert.AreEqual(1, resultado.Count);
    }

    /// <summary>
    /// Verifica que <see cref="CatalogoController.ObtenerFeriasPorProvincia(string)"/>
    /// filtre correctamente las ferias por provincia.
    /// </summary>
    [TestMethod]
    public void ObtenerFeriasPorProvincia_DebeFiltrarCorrectamente()
    {
        var ferias = new List<Feria>
        {
            new Feria { Localidad = "San Jose" },
            new Feria { Localidad = "Alajuela" }
        };

        mockFeriaService
            .Setup(s => s.GetAll())
            .Returns(ferias);

        var resultado = CatalogoController.ObtenerFeriasPorProvincia("san");

        Assert.AreEqual(1, resultado.Count);
    }

    /// <summary>
    /// Verifica que <see cref="CatalogoController.ObtenerProductosPorFeria(int)"/>
    /// retorne una lista vacía cuando no hay proveedores asociados.
    /// </summary>
    [TestMethod]
    public void ObtenerProductosPorFeria_SinProveedores_DebeRetornarListaVacia()
    {
        mockProveedorService
            .Setup(s => s.ObtenerPorFeria(1))
            .Returns(new List<Proveedor>());

        var resultado = CatalogoController.ObtenerProductosPorFeria(1);

        Assert.AreEqual(0, resultado.Count);
    }

    /// <summary>
    /// Verifica que <see cref="CatalogoController.ObtenerProductosPorProveedor(int)"/>
    /// retorne la lista de productos filtrados por proveedor.
    /// </summary>
    [TestMethod]
    public void ObtenerProductosPorProveedor_DebeRetornarProductos()
    {
        var productos = new List<Producto> { new Producto() };

        mockProductoService
            .Setup(s => s.FiltrarPorProvedor(It.IsAny<List<int>>()))
            .Returns(productos);

        var resultado = CatalogoController.ObtenerProductosPorProveedor(1);

        Assert.AreEqual(1, resultado.Count);
    }

    /// <summary>
    /// Verifica que <see cref="CatalogoController.BuscarProductosPorNombre(string, int)"/>
    /// filtre correctamente los productos por nombre.
    /// </summary>
    [TestMethod]
    public void BuscarProductosPorNombre_DebeFiltrarPorNombre()
    {
        var productos = new List<Producto>
        {
            new Producto { Nombre = "Manzana Roja" },
            new Producto { Nombre = "Pera" }
        };

        mockProveedorService
            .Setup(s => s.ObtenerPorFeria(1))
            .Returns(new List<Proveedor> { new Proveedor { Id = 1 } });

        mockProductoService
            .Setup(s => s.FiltrarPorProvedor(It.IsAny<List<int>>()))
            .Returns(productos);

        var resultado = CatalogoController.BuscarProductosPorNombre("manzana", 1);

        Assert.AreEqual(1, resultado.Count);
    }
}
