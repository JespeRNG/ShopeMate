using System.Reflection;
using ShopMate.Persistence;
using ShopMate.Domains.Interfaces;
using Microsoft.EntityFrameworkCore;
using ShopMate.Domains.Entities;

public class ShopMateContext : DbContext
{
    public ShopMateContext(DbContextOptions<ShopMateContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        HandleDeletion();
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(IEntity).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property("CreatedAt")
                    .HasColumnType(DbConstants.DateTimeType)
                    .HasDefaultValueSql(DbConstants.DefaultDateTimeFunc)
                    .IsRequired();

                modelBuilder.Entity(entityType.ClrType)
                    .Property("UpdatedAt")
                    .HasColumnType(DbConstants.DateTimeType)
                    .HasDefaultValueSql(DbConstants.DefaultDateTimeFunc)
                    .IsRequired();
            }
        }
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