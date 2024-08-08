using Api.BLL.Services.Contracts;
using Api.BLL.Services.Entities;
using Api.DAL.Context;
using Api.DAL.Repositories.Contracts;
using Api.DAL.Repositories.Entities;
using Api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbproductoContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("conexion"));
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Repostories
builder.Services.AddScoped<IGenericRepository<Marca>, MarcaRepository>();
builder.Services.AddScoped<IGenericRepository<Categoria>, CategoriaRepository>();
builder.Services.AddScoped<IGenericRepository<Producto>, ProductoRepository>();

//Services
builder.Services.AddScoped<IMarcaService, MarcaService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IProductoService, ProductoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors(opt => opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.Run();
