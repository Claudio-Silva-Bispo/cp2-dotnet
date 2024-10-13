
using CP2.API.Application.Interfaces;
using CP2.API.Application.Services;
using CP2.API.Domain.Interfaces;
using CP2.API.Infrastructure.Data.AppData;
using CP2.API.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Configurando a string e conexo oracle no banco de dados
builder.Services.AddDbContext<ApplicationContext>(options => {

    options.UseOracle(builder.Configuration.GetConnectionString("Oracle"));

});


//Adicionando a interface e classe concreta no framework de injeco de dependencia
builder.Services.AddTransient<IFornecedorRepository, FornecedorRepository>();
builder.Services.AddTransient<IFornecedorApplicationService, FornecedorApplicationService>();

builder.Services.AddTransient<IVendedorRepository, VendedorRepository>();
builder.Services.AddTransient<IVendedorApplicationService, VendedorApplicationService>();

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();

//Configurando e habilitando a documentao no swagger 
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Claudio Silva Bispo",
        Version = "RM 553472",
        Description = "API desenvolvida para CP2 de DOTNET, na faculdade FIAP."
    });
    c.EnableAnnotations(); // Habilitar anotaes no Swagger
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

