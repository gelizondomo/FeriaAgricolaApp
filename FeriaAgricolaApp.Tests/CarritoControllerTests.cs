using FeriaAgricolaApp.Application;
using FeriaAgricolaApp.Application.Controllers;
using FeriaAgricolaApp.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Contiene pruebas unitarias para la clase <see cref="CarritoController"/>.
/// Valida que cada operación del carrito invoque correctamente los servicios
/// correspondientes y retorne los valores esperados.
/// </summary>
[TestClass]
public class CarritoControllerTests
{
    /// <summary>
    /// Mock del servicio de órdenes de compra.
    /// </summary>
    private Mock<OrdenCompraService> mockOrdenCompraService = null!;

    /// <summary>
    /// Mock del servicio de productos.
    /// </summary>
    private Mock<ProductoService> mockProductoService = null!;

    /// <summary>
    /// Mock del servicio de facturación.
    /// </summary>
    private Mock<FacturaService> mockFacturaService = null!;

    /// <summary>
    /// Mock del servicio de direcciones.
    /// </summary>
    private Mock<DireccionService> mockDireccionService = null!;

    /// <summary>
    /// Instancia del controlador bajo prueba.
    /// </summary>
    private CarritoController carritoController = null!;

    /// <summary>
    /// Inicializa los mocks y la instancia del controlador antes de cada prueba.
    /// </summary>
    [TestInitialize]
    public void Setup()
    {
        mockOrdenCompraService = new Mock<OrdenCompraService>();
        mockProductoService = new Mock<ProductoService>();
        mockFacturaService = new Mock<FacturaService>();
        mockDireccionService = new Mock<DireccionService>();

        carritoController = new CarritoController(
            mockOrdenCompraService.Object,
            mockProductoService.Object,
            mockFacturaService.Object,
            mockDireccionService.Object
        );
    }

    /// <summary>
    /// Verifica que <see cref="CarritoController.ObtenerCarrito(int)"/>
    /// retorne el carrito obtenido desde el servicio.
    /// </summary>
    [TestMethod]
    public void ObtenerCarrito_DebeRetornarCarrito()
    {
        int usuarioId = 1;
        var carrito = new OrdenCompra();

        mockOrdenCompraService
            .Setup(s => s.ObtenerOCrearCarrito(usuarioId))
            .Returns(carrito);

        var resultado = carritoController.ObtenerCarrito(usuarioId);

        Assert.AreSame(carrito, resultado);
    }

    /// <summary>
    /// Verifica que <see cref="CarritoController.ObtenerNombreProducto(int)"/>
    /// retorne el nombre del producto cuando existe.
    /// </summary>
    [TestMethod]
    public void ObtenerNombreProducto_ProductoExiste_DebeRetornarNombre()
    {
        var producto = new Producto { Nombre = "Manzana" };

        mockProductoService
            .Setup(s => s.GetById(1))
            .Returns(producto);

        var nombre = carritoController.ObtenerNombreProducto(1);

        Assert.AreEqual("Manzana", nombre);
    }

    /// <summary>
    /// Verifica que <see cref="CarritoController.ObtenerNombreProducto(int)"/>
    /// retorne un mensaje cuando el producto no existe.
    /// </summary>
    [TestMethod]
    public void ObtenerNombreProducto_ProductoNoExiste_DebeRetornarMensaje()
    {
        mockProductoService
            .Setup(s => s.GetById(1))
            .Returns((Producto?)null);

        var nombre = carritoController.ObtenerNombreProducto(1);

        Assert.AreEqual("Producto no encontrado", nombre);
    }

    /// <summary>
    /// Verifica que <see cref="CarritoController.ObtenerTotalProducto(int, int)"/>
    /// calcule correctamente el total cuando el producto existe.
    /// </summary>
    [TestMethod]
    public void ObtenerTotalProducto_ProductoExiste_DebeCalcularTotal()
    {
        var producto = new Producto { Precio = 100 };

        mockProductoService
            .Setup(s => s.GetById(1))
            .Returns(producto);

        var total = carritoController.ObtenerTotalProducto(1, 2);

        Assert.AreEqual(200, total);
    }

    /// <summary>
    /// Verifica que <see cref="CarritoController.ObtenerTotalProducto(int, int)"/>
    /// retorne cero cuando el producto no existe.
    /// </summary>
    [TestMethod]
    public void ObtenerTotalProducto_ProductoNoExiste_DebeRetornarCero()
    {
        mockProductoService
            .Setup(s => s.GetById(1))
            .Returns((Producto?)null);

        var total = carritoController.ObtenerTotalProducto(1, 5);

        Assert.AreEqual(0, total);
    }

    /// <summary>
    /// Verifica que <see cref="CarritoController.QuitarProducto(int, int)"/>
    /// elimine el producto del carrito y guarde los cambios cuando existe.
    /// </summary>
    [TestMethod]
    public void QuitarProducto_ProductoExiste_DebeRemoverYGuardar()
    {
        int usuarioId = 1;
        int productoId = 10;

        var carrito = new OrdenCompra
        {
            Items = new List<CarritoItem>
            {
                new CarritoItem { ProductoId = productoId }
            }
        };

        mockOrdenCompraService
            .Setup(s => s.ObtenerOCrearCarrito(usuarioId))
            .Returns(carrito);

        carritoController.QuitarProducto(usuarioId, productoId);

        Assert.IsEmpty(carrito.Items);

        mockOrdenCompraService.Verify(
            s => s.GuardarCambios(carrito),
            Times.Once
        );
    }

    /// <summary>
    /// Verifica que <see cref="CarritoController.QuitarProducto(int, int)"/>
    /// no guarde cambios cuando el producto no existe en el carrito.
    /// </summary>
    [TestMethod]
    public void QuitarProducto_ProductoNoExiste_NoDebeGuardarCambios()
    {
        int usuarioId = 1;

        var carrito = new OrdenCompra
        {
            Items = new List<CarritoItem>()
        };

        mockOrdenCompraService
            .Setup(s => s.ObtenerOCrearCarrito(usuarioId))
            .Returns(carrito);

        carritoController.QuitarProducto(usuarioId, 99);

        mockOrdenCompraService.Verify(
            s => s.GuardarCambios(It.IsAny<OrdenCompra>()),
            Times.Never
        );
    }

    /// <summary>
    /// Verifica que <see cref="CarritoController.ObtenerDireccionesDeEntrega(int)"/>
    /// retorne la lista de direcciones del usuario.
    /// </summary>
    [TestMethod]
    public void ObtenerDireccionesDeEntrega_DebeRetornarLista()
    {
        var direcciones = new List<Direccion>
        {
            new Direccion()
        };

        mockDireccionService
            .Setup(s => s.ObtenerPorUsuario(1))
            .Returns(direcciones);

        var resultado = carritoController.ObtenerDireccionesDeEntrega(1);

        Assert.HasCount(1, resultado);
    }

    /// <summary>
    /// Verifica que <see cref="CarritoController.ProcesarCompra(int, string)"/>
    /// retorne un resultado fallido cuando la orden finalizada es nula.
    /// </summary>
    [TestMethod]
    public void ProcesarCompra_OrdenNull_DeboRetornarFalso()
    {
        mockOrdenCompraService
            .Setup(s => s.FinalizarOrden(1, "Casa"))
            .Returns((OrdenCompra)null!);

        var resultado = carritoController.ProcesarCompra(1, "Casa");

        Assert.IsFalse(resultado.Exito);
        Assert.IsNull(resultado.Factura);
    }

    /// <summary>
    /// Verifica que <see cref="CarritoController.ProcesarCompra(int, string)"/>
    /// retorne éxito y la factura generada cuando la compra se procesa correctamente.
    /// </summary>
    [TestMethod]
    public void ProcesarCompra_FacturaGenerada_DebeRetornarExito()
    {
        var orden = new OrdenCompra();
        var factura = new Factura();

        mockOrdenCompraService
            .Setup(s => s.FinalizarOrden(1, "Casa"))
            .Returns(orden);

        mockFacturaService
            .Setup(s => s.GenerarFactura(orden, 1, "Casa"))
            .Returns(factura);

        var resultado = carritoController.ProcesarCompra(1, "Casa");

        Assert.IsTrue(resultado.Exito);
        Assert.AreSame(factura, resultado.Factura);
    }
}