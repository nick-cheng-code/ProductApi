using Microsoft.Extensions.DependencyInjection;
using ProductCore;
using ProductCore.GetData;
using ProductCore.SaveData;
using ProductCore.Utilities;
using Store.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddSingleton<ICollections, Collections>();
builder.Services.AddTransient<IProductRetriever, ProductRetriever>();
builder.Services.AddTransient<IProductCreator, ProductCreator>();

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
