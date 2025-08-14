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
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(rp => new { rp.RoleId, rp.Fk_PermissionId });

            builder.HasOne(rp => rp.Role)
                   .WithMany(r => r.RolePermissions)
                   .HasForeignKey(rp => rp.RoleId);

            builder.HasOne(rp => rp.Permission)
                   .WithMany(p => p.RolePermissions)
                   .HasForeignKey(rp => rp.Fk_PermissionId);
        }
    }
}
