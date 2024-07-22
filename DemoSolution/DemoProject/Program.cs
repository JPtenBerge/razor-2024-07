var builder = WebApplication.CreateBuilder(args);

// globale instellingen registreert
// grote building blocks registreert
// dependency injection

// .Add...()

builder.Services.AddRazorPages();

var app = builder.Build();

// dit is wat er voor ieder request moet gebeuren

// middleware
// .Use...()
// .Map...()
app.MapRazorPages(); // /Home => /Pages/Home.cshtml

app.Run();
