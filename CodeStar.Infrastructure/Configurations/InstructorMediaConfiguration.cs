using CodeStar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Infrastructure.Configurations
{
    public class InstructorMediaConfiguration : IEntityTypeConfiguration<InstructorMedia>
    {



        public void Configure(EntityTypeBuilder<InstructorMedia> builder)
        {
            builder.Property(m => m.IntroductionVideo)
                  .HasColumnType("varbinary(max)");

            builder.HasOne(m => m.Instructor) 
                   .WithOne(i => i.InstructorMedia) 
                   .HasForeignKey<InstructorMedia>(m => m.Fk_InstructorID) 
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
