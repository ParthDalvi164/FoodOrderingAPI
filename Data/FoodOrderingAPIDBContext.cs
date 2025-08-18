using Microsoft.EntityFrameworkCore;
using FoodOrderingAPI.Models;

namespace FoodOrderingAPI.Data;

public class FoodOrderingAPIDBContext : DbContext
{
    public FoodOrderingAPIDBContext() { }
    public FoodOrderingAPIDBContext(DbContextOptions<FoodOrderingAPIDBContext> options) : base(options) { }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<DeliveryAgent> DeliveryAgents { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderTracking> OrderTrackings { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRole>()
            .HasData(new UserRole { Id = 1, Role = Role.ADMIN },
            new UserRole { Id = 2, Role = Role.MEMBER });
    }
}
