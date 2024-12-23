using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopMate.Domains.Entities;

namespace ShopMate.Persistence.Configurations
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasKey(sc => sc.Id);

            builder.ToTable(DbConstants.Tables.ShoppingCarts);

            builder.HasOne(sc => sc.User)
                .WithOne()
                .HasForeignKey<ShoppingCart>(sc => sc.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(sc => sc.CartItems)
                .WithOne(ci => ci.ShoppingCart)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(sc => !sc.IsDeleted);
        }
    }

}
