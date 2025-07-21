using CodeStar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Infrastructure.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasData(
            new Role { Id = 1, Title = "Admin", PersionTitle = "مدیر سیستم", IsActived = true },
            new Role { Id = 2, Title = "User", PersionTitle = "کاربر عادی", IsActived = true },
            new Role { Id = 3, Title = "Mentor", PersionTitle = "منتور راهنما", IsActived = true },
            new Role { Id = 4, Title = "Teacher", PersionTitle = "مدرس دوره", IsActived = true }
        );
        }
    }
}
