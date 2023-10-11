using Bazaarr.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Bazaarr.Data.DbContexts;

public class AppDbContext : DbContext
{
    public DbSet<Cart> Carts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = "Server = (localdb)\\MSSQLLocalDB; " +
                      "Database = BazaarrDb; " +
                      "Trusted_Connection = True";

        optionsBuilder.UseSqlServer(path);
    }
}
