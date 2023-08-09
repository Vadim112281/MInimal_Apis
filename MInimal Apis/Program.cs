using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MInimal_Apis.Data;
using MInimal_Apis.Models;
using MInimal_Apis.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IService, Service>();

var app = builder.Build();

app.MapPost("/api/", ([FromServices] IService service, Item item) =>
{
    return service.Add(item);
});

app.MapGet("/api/items/", ([FromServices] IService service) =>
{
    return service.GetAll();
});

app.MapGet("/api/itms/{id}", ([FromServices] IService service, int id) =>
{
    return service.GetById(id);
});

app.MapPut("/api/items/{id}", ([FromServices] IService service, int id, Item item) =>
{
    item.Id = id;
    return service.Update(item);
});

app.MapDelete("/api/items/{id}", ([FromServices] IService service, int id, Item item) =>
{
    item.Id = id;
    return service.Delete(item);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

