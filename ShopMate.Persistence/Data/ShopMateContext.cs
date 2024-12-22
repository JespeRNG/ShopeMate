using System.Reflection;
using ShopMate.Domains.Users;
using ShopMate.Domains.Orders;
using ShopMate.Domains.Products;
using ShopMate.Domains.Payments;
using ShopMate.Domains.Addresses;
using ShopMate.Domains.CartItems;
using ShopMate.Domains.Interfaces;
using ShopMate.Domains.Categories;
using ShopMate.Domains.OrderItems;
using Microsoft.EntityFrameworkCore;
using ShopMate.Domains.ShoppingCarts;

public class ShopMateContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }

    public ShopMateContext(DbContextOptions<ShopMateContext> options) : base(options) { }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        HandleDeletion();
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
        modelBuilder.Entity<Order>().HasQueryFilter(o => !o.IsDeleted);
        modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);
        modelBuilder.Entity<Category>().HasQueryFilter(c => !c.IsDeleted);
        modelBuilder.Entity<OrderItem>().HasQueryFilter(oi => !oi.IsDeleted);
        modelBuilder.Entity<ShoppingCart>().HasQueryFilter(sc => !sc.IsDeleted);
    }
        
    private void HandleDeletion()
    {
        ChangeTracker.DetectChanges();
        var entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted);

        foreach (var entry in entries)
        {
            if (entry.Entity is ISoftDeletable softDeleted)
            {
                softDeleted.IsDeleted = true;
                softDeleted.DeletedAt = DateTime.UtcNow;
                entry.State = EntityState.Modified;
            }
        }
    }
}