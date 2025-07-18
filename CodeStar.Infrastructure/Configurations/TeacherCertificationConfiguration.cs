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
    public class TeacherCertificationConfiguration : IEntityTypeConfiguration<TeacherCertification>
    {
        public void Configure(EntityTypeBuilder<TeacherCertification> builder)
        {
            builder.HasKey(tc => tc.Id);

            builder.Property(tc => tc.CertificateName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(tc => tc.Issuer)
                   .HasMaxLength(150);

            builder.Property(tc => tc.DateReceived)
                   .IsRequired();

            builder.Property(tc => tc.ExpiryDate)
                   .IsRequired(false);

            builder.HasOne(tc => tc.Teacher)
                   .WithMany(t => t.Certifications)
                   .HasForeignKey(tc => tc.FK_TeacherID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
