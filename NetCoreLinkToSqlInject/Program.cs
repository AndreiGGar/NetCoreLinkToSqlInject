using NetCoreLinkToSqlInject.Models;
using NetCoreLinkToSqlInject.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*builder.Services.AddTransient<Coche>();*/
/*builder.Services.AddSingleton<Coche>();*/
/*builder.Services.AddSingleton<ICoche, Deportivo>();*/
Coche car = new Coche();
car.Marca = "Lamborghini";
car.Modelo = "Aventador";
car.Imagen = "https://www.lamborghini.com/sites/it-en/files/DAM/lamborghini/facelift_2019/model_gw/aventador/2023/model_chooser/aventador_ultimae_roadster_m.jpg";
car.Velocidad = 0;
car.VelocidadMax = 350;
builder.Services.AddTransient<ICoche, Coche>(x => car);
/*builder.Services.AddTransient<RepositoryDoctorSQL>();*/
builder.Services.AddTransient<RepositoryDoctorOracle>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
