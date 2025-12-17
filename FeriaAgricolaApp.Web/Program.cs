using FeriaAgricolaApp.Application;
using FeriaAgricolaApp.Application.Controllers;
using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Domain.Interfaces;
using FeriaAgricolaApp.Infrastructure.Configuration;
using FeriaAgricolaApp.Infrastructure.DataHandler;
using FeriaAgricolaApp.Infrastructure.Repositorios;
using FeriaAgricolaApp.Web.Components;
using FeriaAgricolaApp.Web.Components.Services;
using System.Net.NetworkInformation;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<AppState>();

// DataHandlers
builder.Services.AddSingleton<IDataHandler<Usuario>, FileHandler<Usuario>>();
builder.Services.AddSingleton<IDataHandler<Direccion>, FileHandler<Direccion>>();
builder.Services.AddSingleton<IDataHandler<Feria>, FileHandler<Feria>>();
builder.Services.AddSingleton<IDataHandler<Proveedor>, FileHandler<Proveedor>>();
builder.Services.AddSingleton<IDataHandler<Producto>, FileHandler<Producto>>();
builder.Services.AddSingleton<IDataHandler<OrdenCompra>, FileHandler<OrdenCompra>>();
builder.Services.AddSingleton<IDataHandler<Factura>, FileHandler<Factura>>();

// Repos
builder.Services.AddSingleton<IRepository<Usuario>>(sp =>
    new UsuarioRepository(FilePaths.Usuarios, sp.GetRequiredService<IDataHandler<Usuario>>()));

builder.Services.AddSingleton<IRepository<Direccion>>(sp =>
    new DireccionRepository(FilePaths.Direcciones, sp.GetRequiredService<IDataHandler<Direccion>>()));

builder.Services.AddSingleton<IRepository<Feria>>(sp =>
    new FeriaRepository(FilePaths.Ferias, sp.GetRequiredService<IDataHandler<Feria>>()));

builder.Services.AddSingleton<IRepository<Proveedor>>(sp =>
    new ProveedorRepository(FilePaths.Proveedores, sp.GetRequiredService<IDataHandler<Proveedor>>()));

builder.Services.AddSingleton<IRepository<Producto>>(sp =>
    new ProductoRepository(FilePaths.Productos, sp.GetRequiredService<IDataHandler<Producto>>()));

builder.Services.AddSingleton<IRepository<OrdenCompra>>(sp =>
    new OrdenCompraRepository(FilePaths.Compras, sp.GetRequiredService<IDataHandler<OrdenCompra>>()));

builder.Services.AddSingleton<IRepository<Factura>>(sp =>
    new FacturaRepository(FilePaths.Facturas, sp.GetRequiredService<IDataHandler<Factura>>()));

// Services
builder.Services.AddSingleton<UsuarioService>();
builder.Services.AddSingleton<DireccionService>();
builder.Services.AddSingleton<FeriaService>();
builder.Services.AddSingleton<ProveedorService>();
builder.Services.AddSingleton<ProductoService>();
builder.Services.AddSingleton<OrdenCompraService>();
builder.Services.AddSingleton<FacturaService>();
builder.Services.AddSingleton<ReporteService>();

// Admin services
builder.Services.AddSingleton<AdminUsuarioService>();
builder.Services.AddSingleton<InventarioService>();
builder.Services.AddSingleton<AdminProveedorService>();

// Controllers 
builder.Services.AddSingleton<LoginController>();
builder.Services.AddSingleton<CatalogoController>();
builder.Services.AddSingleton<CarritoController>();
builder.Services.AddSingleton<FinancieroController>();
builder.Services.AddSingleton<AdminController>();

// Export / download
builder.Services.AddScoped<DescargaReporteService>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
