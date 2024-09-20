using Qel.Ef.Contexts.Main;
using Qel.Ef.DbClient;
using Qel.Ef.DbClient.Extensions;
using Qel.Ef.Providers.Postgres;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddRepository<IPassportRepository, PassportRepository<DbContextMain>, DbContextMain>(builder.Configuration, 
    [new Configurator(nameof(DbContextMain))]);
builder.Services.AddRepository<IPersonRepository, PersonRepository<DbContextMain>, DbContextMain>(builder.Configuration, 
    [new Configurator(nameof(DbContextMain))]);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
