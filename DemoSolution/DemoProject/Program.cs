using DemoProject.DataAccess;
using DemoProject.Entities;
using DemoProject.Middleware;
using DemoProject.Repositories;
using DemoProject.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// globale instellingen registreert
// grote building blocks registreert
// dependency injection

// .Add...()

builder.Services.AddDbContext<DemoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DemoContext"));
}, ServiceLifetime.Transient);

builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddScoped<IValidator<Car>, CarValidator>();
builder.Services.AddFluentValidationAutoValidation(options =>
{
    options.DisableDataAnnotationsValidation = true;
});

// side effects.

//builder.Services.AddSingleton<ICarRepository, CarInMemoryRepository>(); // elke keer een nieuwe
builder.Services.AddTransient<ICarRepository, CarDbRepository>(); // elke keer een nieuwe
builder.Services.AddTransient<ICarTypeRepository, CarTypeDbRepository>(); // elke keer een nieuwe
builder.Services.AddSingleton<ExceptionLoggingMiddleware>();
builder.Services.AddProblemDetails();

//builder.Services.AddScoped // elk request een nieuwe
//builder.Services.AddSingleton // 1 instance to rule them all (zolang je app leeft)

var app = builder.Build();

// dit is wat er voor ieder request moet gebeuren

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app
    .UseStaticFiles()
    .UseExceptionLoggingMiddleware();

// middleware <==
// .Use...()
// .Map...()
app.MapControllers(); // doorzoekt mijn project naar controllers   : ControllerBase  Controllers/  [ApiController]
app.MapRazorPages(); // /Home => /Pages/Home.cshtml

app.Run();
