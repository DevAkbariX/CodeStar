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
    public class SkillCategoryConfiguration : IEntityTypeConfiguration<SkillCategory>
    {
        public void Configure(EntityTypeBuilder<SkillCategory> builder)
        {
            builder.HasKey(sc => sc.ID);

            builder.HasOne(sc => sc.SkillSpark)
                   .WithMany(s => s.SkillCategorys)
                   .HasForeignKey(sc => sc.Fk_SkillSpark);

            builder.HasOne(sc => sc.Category)
                   .WithMany(c => c.SkillCategorys)
                   .HasForeignKey(sc => sc.Fk_Category);
        }
    }
}
