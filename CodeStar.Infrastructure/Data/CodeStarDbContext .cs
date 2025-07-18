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

       public DbSet<Teacher> Teachers { get; set; }
       public DbSet<TeacherCertification> TeacherCertifications { get; set; }
       public DbSet<TeacherResume> TeacherResumes { get; set; }

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

            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherCertificationConfiguration());

        }
    }
}
