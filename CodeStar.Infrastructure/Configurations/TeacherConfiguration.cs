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
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.FullName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasMany(t => t.Resumes)
                   .WithOne(r => r.Teacher)
                   .HasForeignKey(r => r.FK_TeacherID)
                   .OnDelete(DeleteBehavior.Cascade);

            
        }
    }
}
