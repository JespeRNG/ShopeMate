using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopMate.Domains.Users;

namespace ShopMate.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            //builder.ToTable();

            builder.HasMany(u => u.Addresses)
                .WithOne()
                .HasForeignKey(u => u.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.HasIndex(u => u.Username)
                .IsUnique();
        }
    }
}
