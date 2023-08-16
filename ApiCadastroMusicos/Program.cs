using ApiCadastroMusico.Context;
using ApiCadastroMusico.Entites;
using ApiCadastroMusicos.Application.AppServices;
using ApiCadastroMusicos.Application.Interfaces;
using ApiCadastroMusicos.Domain.Repositories;
using ApiCadastroMusicos.Infra.Database.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPessoaAppService, PessoaAppService>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DbContext, AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
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
