using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.UserRoles).WithOne(e => e.User).HasForeignKey(e => e.UserId);

            builder.HasQueryFilter(m => EF.Property<DateTime?>(m, "DeletedDate") == null);
        }
    }
}
