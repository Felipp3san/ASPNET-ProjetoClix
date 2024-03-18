using AspNet_ProjetoClix.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNet_ProjetoClix.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; } = default!;
    public DbSet<Tipo> Tipos { get; set; } = default!;
    public DbSet<Item> Items { get; set; } = default!;

}
