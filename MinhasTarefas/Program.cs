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

//Instancia MySQL 

//string _stringConexao = builder.Configuration.GetConnectionString("DataBase");
//builder.Services.AddEntityFrameworkMySql()
//    .AddDbContext<TarefasDbContext>(
//        options => options.UseMySql(_stringConexao, ServerVersion.AutoDetect(_stringConexao))
//        );
//builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();


//Intancia SQL Server
var connectionstring = builder.Configuration.GetConnectionString("DataBaseSQL-Server");
builder.Services.AddDbContext<TarefasDbContext>(option => option.UseSqlServer(connectionstring));

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();

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