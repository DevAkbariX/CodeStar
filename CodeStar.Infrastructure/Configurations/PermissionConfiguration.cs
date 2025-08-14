using CodeStar.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Infrastructure.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.RolePermissions)
                   .WithOne(rp => rp.Permission)
                   .HasForeignKey(rp => rp.Fk_PermissionId);
        }
    }
}
