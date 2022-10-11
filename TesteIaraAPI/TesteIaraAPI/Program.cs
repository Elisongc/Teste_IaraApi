using Microsoft.EntityFrameworkCore;
using TesteIaraAPI.Model.Context;
using TesteIaraAPI.Repositories.Interfaces;
using TesteIaraAPI.Repositories.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CotacaoContext>(x => x.UseSqlServer("server=localhost\\SQLEXPRESS;database=TESTEIARA;Integrated Security = True"));
builder.Services.AddScoped<ICotacaoRepository, CotacaoRepository>();

builder.Services.AddDbContext<CotacaoItemContext>(x => x.UseSqlServer("server=localhost\\SQLEXPRESS;database=TESTEIARA;Integrated Security = True"));
builder.Services.AddScoped<ICotacaoItemRepository, CotacaoItemRepository>();

builder.Services.AddControllers();
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
