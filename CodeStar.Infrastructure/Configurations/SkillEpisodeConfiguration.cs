using CodeStar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class SkillEpisodeConfiguration : IEntityTypeConfiguration<SkillEpisode>
{
    public void Configure(EntityTypeBuilder<SkillEpisode> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Title)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(e => e.Description)
               .HasMaxLength(1000);

        builder.Property(e => e.EpisodeNumber)
               .IsRequired();

        builder.Property(e => e.DurationInMinutes)
               .IsRequired();

        builder.Property(e => e.VideoUrl)
               .HasMaxLength(500);

        builder.Property(e => e.CreatedAt)
               .HasDefaultValueSql("GETDATE()");

        builder.HasOne(e => e.SkillSpark)
               .WithMany(s => s.Episodes)
               .HasForeignKey(e => e.SkillSparkId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
