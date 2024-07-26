using DemoProject.DataAccess;
using DemoShared.Entities;
using DemoProject.Middleware;
using DemoProject.Repositories;
using DemoShared.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using DemoProject.Hubs;

var builder = WebApplication.CreateBuilder(args);

// globale instellingen registreert
// grote building blocks registreert
// dependency injection

// .Add...()

builder.Services.AddSignalR();

builder.Services.AddDbContext<DemoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DemoContext"));
}, ServiceLifetime.Transient);

builder.Services.AddCors(options =>
{
    options.AddPolicy("blazorfrontend", policy =>
    {
        policy.WithOrigins("https://localhost:7155").AllowAnyHeader().AllowCredentials().AllowAnyMethod();
    });
});

builder.Services.AddRazorPages();


builder.Services.AddControllers().AddJsonOptions(options =>
{
    //options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    //options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

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

app.UseCors("blazorfrontend");

app
    .UseStaticFiles()
    .UseExceptionLoggingMiddleware();

// middleware <==
// .Use...()
// .Map...()
app.MapHub<PollHub>("/pollHub");
app.MapControllers(); // doorzoekt mijn project naar controllers   : ControllerBase  Controllers/  [ApiController]
app.MapRazorPages(); // /Home => /Pages/Home.cshtml

app.Run();
