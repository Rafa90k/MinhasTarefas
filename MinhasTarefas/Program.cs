using Microsoft.EntityFrameworkCore;
using MinhasTarefas.Data;
using MinhasTarefas.Repositorios;
using MinhasTarefas.Repositorios.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string _stringConexao = builder.Configuration.GetConnectionString("DataBase");
builder.Services.AddEntityFrameworkMySql()
    .AddDbContext<TarefasDbContext>(
        options => options.UseMySql(_stringConexao, ServerVersion.AutoDetect(_stringConexao))
        );

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();