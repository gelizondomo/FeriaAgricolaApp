using FeriaAgricolaApp.Application;
using FeriaAgricolaApp.Application.Controllers;
using FeriaAgricolaApp.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

/// <summary>
/// Contiene pruebas unitarias para la clase <see cref="LoginController"/>.
/// Valida el proceso de autenticación y registro de usuarios.
/// </summary>
[TestClass]
public class LoginControllerTests
{
    /// <summary>
    /// Mock del servicio de usuarios.
    /// </summary>
    private Mock<UsuarioService> mockUsuarioService;

    /// <summary>
    /// Instancia del controlador bajo prueba.
    /// </summary>
    private LoginController loginController;

    /// <summary>
    /// Inicializa los mocks y la instancia del controlador antes de cada prueba.
    /// </summary>
    [TestInitialize]
    public void Setup()
    {
        mockUsuarioService = new Mock<UsuarioService>();

        loginController = new LoginController(
            mockUsuarioService.Object
        );
    }

    /// <summary>
    /// Verifica que <see cref="LoginController.Login(string, string)"/>
    /// retorne un usuario válido cuando las credenciales son correctas.
    /// </summary>
    [TestMethod]
    public void Login_CredencialesValidas_DebeRetornarUsuario()
    {
        string email = "test@email.com";
        string password = "1234";

        var usuario = new Usuario
        {
            Id = 1,
            Email = email
        };

        mockUsuarioService
            .Setup(s => s.Login(email, password))
            .Returns(usuario);

        var resultado = loginController.Login(email, password);

        Assert.IsNotNull(resultado);
        Assert.AreEqual(email, resultado.Email);
    }

    /// <summary>
    /// Verifica que <see cref="LoginController.Login(string, string)"/>
    /// retorne null cuando las credenciales son inválidas.
    /// </summary>
    [TestMethod]
    public void Login_CredencialesInvalidas_DebeRetornarNull()
    {
        string email = "test@email.com";
        string password = "incorrecta";

        mockUsuarioService
            .Setup(s => s.Login(email, password))
            .Returns((Usuario?)null);

        var resultado = loginController.Login(email, password);

        Assert.IsNull(resultado);
    }

    /// <summary>
    /// Verifica que <see cref="LoginController.RegistrarUsuario(string, string, string, string)"/>
    /// retorne true cuando los datos del usuario son válidos.
    /// </summary>
    [TestMethod]
    public void RegistrarUsuario_DatosValidos_DebeRetornarTrue()
    {
        string nombre = "Juan";
        string email = "juan@email.com";
        string password = "1234";
        string telefono = "88888888";

        mockUsuarioService
            .Setup(s => s.RegistrarUsuario(nombre, email, password, telefono))
            .Returns(true);

        var resultado = loginController.RegistrarUsuario(
            nombre, email, password, telefono
        );

        Assert.IsTrue(resultado);
    }

    /// <summary>
    /// Verifica que <see cref="LoginController.RegistrarUsuario(string, string, string, string)"/>
    /// retorne false cuando los datos del usuario son inválidos.
    /// </summary>
    [TestMethod]
    public void RegistrarUsuario_DatosInvalidos_DebeRetornarFalse()
    {
        string nombre = "";
        string email = "correo_invalido";
        string password = "";
        string telefono = "";

        mockUsuarioService
            .Setup(s => s.RegistrarUsuario(nombre, email, password, telefono))
            .Returns(false);

        var resultado = loginController.RegistrarUsuario(
            nombre, email, password, telefono
        );

        Assert.IsFalse(resultado);
    }
}
