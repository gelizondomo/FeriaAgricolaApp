using FeriaAgricolaApp.Application;
using FeriaAgricolaApp.Application.Controllers;
using FeriaAgricolaApp.Application.DTO;
using FeriaAgricolaApp.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

/// <summary>
/// Contiene pruebas unitarias para la clase <see cref="FinancieroController"/>.
/// Valida la obtención de facturas, reportes financieros y estadísticas
/// relacionadas con ventas, ferias y proveedores.
/// </summary>
[TestClass]
public class FinancieroControllerTests
{
    /// <summary>
    /// Mock del servicio de facturación.
    /// </summary>
    private Mock<FacturaService> mockFacturaService;

    /// <summary>
    /// Mock del servicio de reportes financieros.
    /// </summary>
    private Mock<ReporteService> mockReporteService;

    /// <summary>
    /// Instancia del controlador bajo prueba.
    /// </summary>
    private FinancieroController financieroController;

    /// <summary>
    /// Inicializa los mocks y la instancia del controlador antes de cada prueba.
    /// </summary>
    [TestInitialize]
    public void Setup()
    {
        mockFacturaService = new Mock<FacturaService>();
        mockReporteService = new Mock<ReporteService>();

        financieroController = new FinancieroController(
            mockFacturaService.Object,
            mockReporteService.Object
        );
    }

    /// <summary>
    /// Verifica que <see cref="FinancieroController.ObtenerFacturasUsuario(int)"/>
    /// retorne la lista de facturas del usuario.
    /// </summary>
    [TestMethod]
    public void ObtenerFacturasUsuario_DebeRetornarFacturas()
    {
        int usuarioId = 1;

        var facturas = new List<Factura>
        {
            new Factura(),
            new Factura()
        };

        mockFacturaService
            .Setup(s => s.ObtenerPorUsuario(usuarioId))
            .Returns(facturas);

        var resultado = financieroController.ObtenerFacturasUsuario(usuarioId);

        Assert.HasCount(2, resultado);
    }

    /// <summary>
    /// Verifica que <see cref="FinancieroController.TotalMensual(int, int)"/>
    /// retorne el total de ventas del mes indicado.
    /// </summary>
    [TestMethod]
    public void TotalMensual_DebeRetornarTotal()
    {
        int mes = 5;
        int año = 2024;
        decimal totalEsperado = 150000;

        mockReporteService
            .Setup(s => s.TotalVentasPorMes(mes, año))
            .Returns(totalEsperado);

        var resultado = financieroController.TotalMensual(mes, año);

        Assert.AreEqual(totalEsperado, resultado);
    }

    /// <summary>
    /// Verifica que <see cref="FinancieroController.TopProductos()"/>
    /// retorne un diccionario con los productos más vendidos.
    /// </summary>
    [TestMethod]
    public void TopProductos_DebeRetornarDiccionario()
    {
        var topProductos = new Dictionary<string, int>
        {
            { "Manzana", 10 },
            { "Pera", 5 }
        };

        mockReporteService
            .Setup(s => s.ProductosMasVendidos())
            .Returns(topProductos);

        var resultado = financieroController.TopProductos();

        Assert.HasCount(2, resultado);
        Assert.AreEqual(10, resultado["Manzana"]);
    }

    /// <summary>
    /// Verifica que <see cref="FinancieroController.FeriaQueMasVende(DateTime, DateTime)"/>
    /// retorne el reporte de la feria con mayores ventas.
    /// </summary>
    [TestMethod]
    public void FeriaQueMasVende_DebeRetornarReporte()
    {
        var inicio = DateTime.Now.AddMonths(-1);
        var fin = DateTime.Now;

        var reporte = new ReporteGananciaDTO();

        mockReporteService
            .Setup(s => s.FeriaQueMasVende(inicio, fin))
            .Returns(reporte);

        var resultado = financieroController.FeriaQueMasVende(inicio, fin);

        Assert.AreSame(reporte, resultado);
    }

    /// <summary>
    /// Verifica que <see cref="FinancieroController.ProveedorQueMasVende(DateTime, DateTime)"/>
    /// retorne el reporte del proveedor con mayores ventas.
    /// </summary>
    [TestMethod]
    public void ProveedorQueMasVende_DebeRetornarReporte()
    {
        var inicio = DateTime.Now.AddMonths(-1);
        var fin = DateTime.Now;

        var reporte = new ReporteGananciaDTO();

        mockReporteService
            .Setup(s => s.ProveedorQueMasVende(inicio, fin))
            .Returns(reporte);

        var resultado = financieroController.ProveedorQueMasVende(inicio, fin);

        Assert.AreSame(reporte, resultado);
    }

    /// <summary>
    /// Verifica que <see cref="FinancieroController.GananciasMensualesPorFeria(DateTime, DateTime)"/>
    /// retorne la lista de reportes de ganancias por feria.
    /// </summary>
    [TestMethod]
    public void GananciasMensualesPorFeria_DebeRetornarLista()
    {
        var inicio = DateTime.Now.AddMonths(-3);
        var fin = DateTime.Now;

        var reportes = new List<ReporteGananciaDTO>
        {
            new ReporteGananciaDTO(),
            new ReporteGananciaDTO()
        };

        mockReporteService
            .Setup(s => s.GananciasMensualesPorFeria(inicio, fin))
            .Returns(reportes);

        var resultado = financieroController.GananciasMensualesPorFeria(inicio, fin);

        Assert.HasCount(2, resultado);
    }

    /// <summary>
    /// Verifica que <see cref="FinancieroController.GananciasMensualesPorProveedor(DateTime, DateTime)"/>
    /// retorne la lista de reportes de ganancias por proveedor.
    /// </summary>
    [TestMethod]
    public void GananciasMensualesPorProveedor_DebeRetornarLista()
    {
        var inicio = DateTime.Now.AddMonths(-3);
        var fin = DateTime.Now;

        var reportes = new List<ReporteGananciaDTO>
        {
            new ReporteGananciaDTO()
        };

        mockReporteService
            .Setup(s => s.GananciasMensualesPorProveedor(inicio, fin))
            .Returns(reportes);

        var resultado = financieroController.GananciasMensualesPorProveedor(inicio, fin);

        Assert.HasCount(1, resultado);
    }
}

