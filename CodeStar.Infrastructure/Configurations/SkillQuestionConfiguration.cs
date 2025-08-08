using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class SkillQuestionConfiguration : IEntityTypeConfiguration<SkillQuestion>
{
    public void Configure(EntityTypeBuilder<SkillQuestion> builder)
    {
        builder.HasKey(q => q.Id);

        builder.Property(q => q.Content)
               .IsRequired()
               .HasMaxLength(2000);

        builder.Property(q => q.CreatedAt)
               .HasDefaultValueSql("GETDATE()");

        builder.HasOne(q => q.SkillSpark)
               .WithMany(s => s.SkillQuestions)
               .HasForeignKey(q => q.SkillSparkId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(q => q.ParentQuestion)
               .WithMany(q => q.Replies)
               .HasForeignKey(q => q.ParentQuestionId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(q => q.User)
              .WithMany(u => u.SkillQuestions)
              .HasForeignKey(q => q.UserId)
              .OnDelete(DeleteBehavior.Cascade);
    }
}
