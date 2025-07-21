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

       public DbSet<MasterCertification> MasterCertifications { get; set; }
       public DbSet<MasterResume> MasterResumes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Role> Master { get; set; }
        public DbSet<InstructorRequest> Instructors { get; set; }

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
            modelBuilder.ApplyConfiguration(new MasterConfiguration());
            modelBuilder.ApplyConfiguration(new MasterResumeConfiguration());
            modelBuilder.ApplyConfiguration(new MasterCertificationConfiguration());

        }
    }
}
