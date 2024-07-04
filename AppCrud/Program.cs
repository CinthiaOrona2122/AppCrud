using AppCrud.Data;
using Microsoft.EntityFrameworkCore;

//Creamos la aplicacion
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//contexto de la cadena de conexion
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});

//Genera la app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

//archivos que va a servir
app.UseStaticFiles();

//las rutas
app.UseRouting();

//la autenticacion
app.UseAuthorization();

//pagina de inicio
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//arranque
app.Run();
