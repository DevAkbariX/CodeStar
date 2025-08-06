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
    public class InstructorResumeConfiguration : IEntityTypeConfiguration<InstructorResume>
    {
        public void Configure(EntityTypeBuilder<InstructorResume> builder)
        {
            builder.HasKey(tc => tc.Id);

            builder.Property(tc => tc.Title)
                   .IsRequired()
                   .HasMaxLength(200);

          

            builder.Property(tc => tc.StartDate)
                   .IsRequired();

            builder.Property(tc => tc.EndDate)
                   .IsRequired(false);

            builder.HasOne(tc => tc.InstructorMedia)
                   .WithMany(t => t.Resumes)
                   .HasForeignKey(tc => tc.FK_InstructorMediaID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}
