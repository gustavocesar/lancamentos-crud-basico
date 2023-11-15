using CrudLancamentos.Entities;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace CrudLancamentos;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
        Seed();
    }

    public DbSet<Lancamento> Lancamentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Notification>();

        base.OnModelCreating(modelBuilder);
    }

    private void Seed()
    {
        Database.EnsureCreated();

        if (Lancamentos.Any()) return;

        InsertTestData();
    }

    private void InsertTestData()
    {
        Lancamentos.Add(new(500, "Entrada 1", DateTime.Now.AddDays(-3)));
        Lancamentos.Add(new(-500, "Saída A", DateTime.Now.AddDays(-3)));
        
        Lancamentos.Add(new(500, "Entrada 2", DateTime.Now.AddDays(-2)));
        Lancamentos.Add(new(-500, "Saída B", DateTime.Now.AddDays(-2)));

        Lancamentos.Add(new(1000, "Entrada 3", DateTime.Now.AddDays(-1)));
        Lancamentos.Add(new(-500, "Saída C", DateTime.Now.AddDays(-1)));

        Lancamentos.Add(new(500, "Entrada 4"));
        Lancamentos.Add(new(600, "Entrada 5"));

        var lancamentoCancelado = new Lancamento(350, "Entrada 6");
        lancamentoCancelado.Cancelar();
        Lancamentos.Add(lancamentoCancelado);

        Lancamentos.Add(new(-500, "Saída D"));

        base.SaveChanges();
    }
}