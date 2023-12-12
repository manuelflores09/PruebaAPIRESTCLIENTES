using System.Data.Entity;
using WebApiCliente.Models;

public class ClientesDbContext : DbContext
{
    public ClientesDbContext() : base("name=DefaultConnection")
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
}
