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
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using RestaurantAPI.Models;
using RestaurantAPI.Models.Validators;
using FluentValidation.AspNetCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var authenticationSettings = new AuthenticationSettings();
builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Bearer";
    options.DefaultScheme = "Bearer";
    options.DefaultChallengeScheme = "Bearer";

}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
    };
});
builder.Services.AddSingleton(authenticationSettings);
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IDishService, DishService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Host.UseNLog();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<TimeRequestMiddleware>();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();

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

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestaurantAPI"));
app.MapControllers();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<RestaurantDbContext>();
var dataSeeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
dataSeeder.Seed(dbContext);

app.Run();
