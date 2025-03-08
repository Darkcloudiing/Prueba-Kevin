using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Prueba_Kevin.Models;

public class WorkContext : DbContext
{
    public DbSet<Client> Clientes { get; set; }
    public DbSet<Accounts> Cuentas { get; set; }
    public DbSet<AccountTypes> TipoDeCuentas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=desktop-cf4rllp\\sqlexpress;Database=PruebaKevin;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");
    }
}