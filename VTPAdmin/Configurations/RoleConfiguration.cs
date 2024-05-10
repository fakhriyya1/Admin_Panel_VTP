using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VTPAdmin.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            builder.HasData(new IdentityRole<Guid>
            {
                Id = Guid.Parse("A676FE26-AFA5-47DE-8943-73B832558695"),
                Name = "superadmin",
                NormalizedName = "SUPERADMIN",
            });
        }
    }
}
