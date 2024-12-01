using urlShortener.DbContextClass;
using urlShortener;
using Microsoft.EntityFrameworkCore;
using urlShortener.Models;
using urlShortener.Services;
using urlShortener.Entity;
using urlShortener.Helper;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using urlShortener.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<ShortenService>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // app.ApplyMigrations();

}
app.UseRouting();
app.MapControllers();
app.UseHttpsRedirection();
app.Run();
