using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI;
using AutoMapper;
using RestaurantAPI.Entities;
using System.Text.Json.Serialization;
using Bogus.DataSets;
using System.Reflection;
using RestaurantAPI.Services;
using NLog.Web;
using RestaurantAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<IRestaurantService, RestaurantService>();
builder.Services.AddTransient<IDishService, DishService>();
builder.Host.UseNLog();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<TimeRequestMiddleware>();
builder.Services.AddSwaggerGen();

// Entity Framework stuff
builder.Services.AddDbContext<RestaurantDbContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantConnectionString")));
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddTransient<IRestaurantSeeder, RestaurantSeeder>();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<TimeRequestMiddleware>();
app.UseHttpsRedirection();

app.UseSwagger();

app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestaurantAPI"));

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<RestaurantDbContext>();
var dataSeeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
dataSeeder.Seed(dbContext);

app.Run();
