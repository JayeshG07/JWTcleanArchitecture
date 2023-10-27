using Serilog;
using Application;
using Infrastructure;
using Presentation;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Domain.Configuration;
using Authorisation.Authorisation.AuthManagement;
using Infrastructure.Interface;
using Infrastructure.Repository;
using Authorisation.Authorisation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string conection = builder.Configuration.GetConnectionString("localString");
builder.Services.AddDbContext<AppDbContext>(p => p.UseSqlServer(conection));
builder.Services.AddAutoMapper(typeof(MapConfig));
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

IConfiguration configuration = builder.Configuration;
builder.Services.JwtService(builder.Configuration);


builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddPresentation();

//builder.Host.UseSerilog((context, configuration) =>
//configuration.ReadFrom.Configuration(context.Configuration));


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
