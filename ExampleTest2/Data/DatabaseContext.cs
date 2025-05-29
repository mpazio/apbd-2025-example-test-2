using ExampleTest2.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<ProductOrder> ProductOrders { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().HasData(new List<Client>()
        {
            new Client() { Id = 1, FirstName = "John", LastName = "Doe" },
            new Client() { Id = 2, FirstName = "Jane", LastName = "Doe" },
            new Client() { Id = 3, FirstName = "Julie", LastName = "Doe" },
        });
        
        modelBuilder.Entity<Status>().HasData(new List<Status>()
        {
            new Status() { Id = 1, Name = "Created" },
            new Status() { Id = 2, Name = "Ongoing" },
            new Status() { Id = 3, Name = "Completed" },
        });
        
        modelBuilder.Entity<Product>().HasData(new List<Product>()
        {
            new Product() { Id = 1, Name = "Apple", Price = 3.45 },
            new Product() { Id = 2, Name = "Bananas", Price = 5.55 },
            new Product() { Id = 3, Name = "Orange", Price = 12.37 },
        });
        
        modelBuilder.Entity<Order>().HasData(new List<Order>()
        {
            new Order() { Id = 1, CreatedAt = DateTime.Parse("2025-05-01"), FulfilledAt = DateTime.Parse("2025-05-02"), ClientId = 1, StatusId = 3},
            new Order() { Id = 2, CreatedAt = DateTime.Parse("2025-05-02"), FulfilledAt = null, ClientId = 1, StatusId = 2},
            new Order() { Id = 3, CreatedAt = DateTime.Parse("2025-05-03"), FulfilledAt = null, ClientId = 1, StatusId = 1},
            new Order() { Id = 4, CreatedAt = DateTime.Parse("2025-05-04"), FulfilledAt = null, ClientId = 2, StatusId = 1},
        });
        
        modelBuilder.Entity<ProductOrder>().HasData(new List<ProductOrder>()
        {
            new ProductOrder() { ProductId = 1, OrderId = 1, Amount = 3},
            new ProductOrder() { ProductId = 2, OrderId = 1, Amount = 5},
            new ProductOrder() { ProductId = 3, OrderId = 1, Amount = 8},
            new ProductOrder() { ProductId = 3, OrderId = 2, Amount = 1},
            new ProductOrder() { ProductId = 2, OrderId = 2, Amount = 2},
            new ProductOrder() { ProductId = 3, OrderId = 3, Amount = 8},
            new ProductOrder() { ProductId = 1, OrderId = 3, Amount = 12},
        });
    }
}