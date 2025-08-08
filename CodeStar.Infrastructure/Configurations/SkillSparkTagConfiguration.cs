using CodeStar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SkillSparkTagConfiguration : IEntityTypeConfiguration<SkillSparkTag>
{
    public void Configure(EntityTypeBuilder<SkillSparkTag> builder)
    {
        builder.HasKey(sst => new { sst.SkillSparkId, sst.TagId });  

        builder.HasOne(sst => sst.SkillSpark)
               .WithMany(ss => ss.SkillSparkTags)
               .HasForeignKey(sst => sst.SkillSparkId);

        builder.HasOne(sst => sst.Tag)
               .WithMany(t => t.SkillSparkTags)
               .HasForeignKey(sst => sst.TagId);
    }
}
