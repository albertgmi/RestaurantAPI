using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestaurantAPI.Entities.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u=>u.Email)
                .IsRequired();

            builder.HasOne(u => u.Role)
                .WithOne(r => r.User)
                .HasForeignKey<User>(fk => fk.RoleId);
        }
    }
}
