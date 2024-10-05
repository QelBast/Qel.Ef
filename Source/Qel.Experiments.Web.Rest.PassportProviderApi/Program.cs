using Qel.Ef.Contexts.Main;
using Qel.Ef.DbClient;
using Qel.Ef.DbClient.Extensions;
using Qel.Ef.Providers.Postgres;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services
    .AddOpenApi()
    .AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo 
        { 
            Title = "Passport Provider API", 
            Version = "v1",
            Description = "Предоставляет возможность работы с паспортными данными и данными о заявителях",
            Contact = new OpenApiContact
            {
                Name = "Kirill",
                Email = string.Empty,
                //Url = new Uri("")
            }
        });

        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
    })
    //.AddEndpointsApiExplorer()
    ;

builder.Services.AddDbClient<DbContextMain>(register =>
    {
        register.AddTransientRepository<IPassportRepository, PassportRepository<DbContextMain>>();
        register.AddTransientRepository<IPersonRepository, PersonRepository<DbContextMain>>();
    },
    builder.Configuration, 
    [new Configurator(nameof(DbContextMain))]);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Passport Provider API v1");
    });

    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
