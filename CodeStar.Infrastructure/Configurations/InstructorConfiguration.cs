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
    internal class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {

        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasOne(i => i.Role)
                   .WithMany(r => r.Instructor)
                   .HasForeignKey(i => i.Fk_RoleId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
