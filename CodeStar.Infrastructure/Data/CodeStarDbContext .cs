using CodeStar.Domain.Entities;
using CodeStar.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Infrastructure.Data
{
    public class CodeStarDbContext:DbContext
    {
        public CodeStarDbContext()
        {
        }
        public CodeStarDbContext(DbContextOptions<CodeStarDbContext> options): base(options) { }

       public DbSet<InstructorCertification> InstructorCertification { get; set; }
       public DbSet<InstructorResume> InstructorResume { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<InstructorMedia> InstructorMedia { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Tag> Tags { get; set; }    
        public DbSet<SkillSpark> SkillSpark { get; set; }
        public DbSet<SkillQuestion> SkillQuestion { get; set; }
        public DbSet<SkillSparkTag> skillSparkTags { get; set; }
        public DbSet<SkillEpisode> SkillEpisode { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=localhost;Database=CodeStarDb;Trusted_Connection=True;TrustServerCertificate=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new InstructorMediaConfiguration());
            modelBuilder.ApplyConfiguration(new InstructorConfiguration());
            modelBuilder.ApplyConfiguration(new InstructorResumeConfiguration());
            modelBuilder.ApplyConfiguration(new InstructorCertificationConfiguration());
            modelBuilder.ApplyConfiguration(new SkillEpisodeConfiguration());
            modelBuilder.ApplyConfiguration(new SkillQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new SkillSparkConfiguration());
            modelBuilder.ApplyConfiguration(new SkillSparkTagConfiguration());

        }
    }
}
