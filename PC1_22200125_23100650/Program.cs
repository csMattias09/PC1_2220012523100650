using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TallerMecanico.Library.Core.Interfaces;
using TallerMecanico.Library.Infrastructure.Data;
using TallerMecanico.Library.Infrastructure.Repositories;
using TallerMecanico.Library.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<TallerMecanicoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TallerMecanicoDB")));

builder.Services.AddScoped<IOrdenServicioRepository, OrdenServicioRepository>();
builder.Services.AddScoped<IOrdenServicioService, OrdenServicioService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
