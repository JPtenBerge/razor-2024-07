using DemoProject.Repositories;

var builder = WebApplication.CreateBuilder(args);

// globale instellingen registreert
// grote building blocks registreert
// dependency injection

// .Add...()

builder.Services.AddRazorPages();

// side effects.


builder.Services.AddSingleton<ICarRepository, CarInMemoryRepository>(); // elke keer een nieuwe
//builder.Services.AddScoped // elk request een nieuwe
//builder.Services.AddSingleton // 1 instance to rule them all (zolang je app leeft)

var app = builder.Build();

// dit is wat er voor ieder request moet gebeuren

// middleware
// .Use...()
// .Map...()
app.MapRazorPages(); // /Home => /Pages/Home.cshtml

app.Run();
