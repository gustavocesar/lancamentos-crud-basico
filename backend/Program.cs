using CrudLancamentos;
using CrudLancamentos.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILancamentoService, LancamentoService>();

builder.Services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase("CrudLancamentosDatabase"));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
