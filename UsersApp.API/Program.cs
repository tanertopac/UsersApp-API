﻿using Microsoft.EntityFrameworkCore;
using UsersApp.Infrastructure;
using UsersApp.Application;
using UsersApp.Domain;
using UsersApp.API.ExceptionHandling;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = String.Empty;
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
    connection = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
}
else
{
    connection = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connection));

builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new GlobalExceptionFilter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

