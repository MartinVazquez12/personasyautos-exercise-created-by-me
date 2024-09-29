using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using peryautWebApi.Mappings;
using peryautWebApi.Models;
using peryautWebApi.Repositories;
using peryautWebApi.Repositories.Interfaces;
using peryautWebApi.Services;
using peryautWebApi.Services.Int;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//REPOS-SERVICES
builder.Services.AddScoped<IPersonaRepo, PersonaRepo>();
builder.Services.AddScoped<IAutoRepo, AutoRepo>();
builder.Services.AddScoped<IMarcaRepo, MarcaRepo>();
builder.Services.AddScoped<IFinalService, FinalService>();

//FLUENT
builder.Services.AddFluentValidation((options) =>
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly())
);

//AUTOMAPPER
builder.Services.AddAutoMapper(typeof(MappingProfile));

//DBCONTEXT
builder.Services.AddDbContext<PersonasyautosContext>((context) =>
{
    context.UseSqlServer(builder.Configuration.GetConnectionString("peyauDB"));
});

var app = builder.Build();

//CORS
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

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
