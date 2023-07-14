using tarea1_U2_AnderA_AngelA.Interfaces;
using tarea1_U2_AnderA_AngelA.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IRepositorioNoticia, RepositorioNoticia>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Noticia/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
app.MapControllerRoute(
    name: "buscar",
    pattern: "Noticia/BuscarPorCategoria/{categoria}",
    defaults: new { controller = "Noticia", action = "BuscarPorCategoria" }
);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Noticia}/{action=Index}/{id?}");

app.Run();
