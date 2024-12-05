using AspStart;
using AspStart.services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDb>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<Service>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
