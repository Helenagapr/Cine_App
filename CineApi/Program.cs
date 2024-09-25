using CineApi;
using CineApi.Data;
using Microsoft.EntityFrameworkCore;
using CineApi.Models;
using CineApi.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Configuration;
using System.Text;
using Microsoft.AspNetCore.Routing.Constraints;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddCors(opt => opt.AddDefaultPolicy(policy =>
    policy.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()));

builder.Services.AddControllers();

builder.Services.AddDbContext<CineContext>(opt =>
    opt.UseInMemoryDatabase("CineApp"));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapConfig)); // falta la clase MapConfig

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
