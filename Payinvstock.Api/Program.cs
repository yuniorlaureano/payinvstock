using Microsoft.OpenApi.Models;
using Payinvstock.Api.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddPayinvstockDependencies(builder.Configuration);
builder.Services.AddSwaggerGen(conf => 
{
    conf.SwaggerDoc("v1", new() 
    {
        Version = "v1",
        Title = "Payinvstock API",
        Description = "API for managing inventory products",
        Contact = new OpenApiContact
        {
            Name = "Yunior Miguel Laureano",
            Email = "yuniorlaureano@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/yunior-laureano-330645127/")
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    conf.IncludeXmlComments(xmlPath);
});

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
