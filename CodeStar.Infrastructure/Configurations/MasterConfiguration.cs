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
    public class MasterConfiguration : IEntityTypeConfiguration<Master>
    {



        public void Configure(EntityTypeBuilder<Master> builder)
        {
            builder.Property(m => m.IntroductionVideo)
                  .HasColumnType("varbinary(max)");

            builder.HasOne(m => m.User)
                  .WithOne(u => u.Master)
                  .HasForeignKey<Master>(m => m.Fk_UserId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.Resumes)
                  .WithOne(r => r.Master)
                  .HasForeignKey(r => r.FK_MasterID)
                  .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(t => t.Certifications)
                  .WithOne(r => r.Master)
                  .HasForeignKey(r => r.FK_MasterId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
