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
    internal class SkillSparkConfiguration : IEntityTypeConfiguration<SkillSpark>
    {
        public void Configure(EntityTypeBuilder<SkillSpark> builder)
        {
            builder.Property(s => s.LikesCount)
                   .HasDefaultValue(0);


            builder.HasOne(s => s.Instructor)
                   .WithMany(i => i.SkillSparks)
                   .HasForeignKey(s => s.InstructorId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
