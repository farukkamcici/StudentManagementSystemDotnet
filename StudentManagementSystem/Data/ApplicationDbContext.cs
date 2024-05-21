using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Class>().HasData(
                new Class { Id = 1, ClassName = "A" },
                new Class { Id = 2, ClassName = "B" },
                new Class { Id = 3, ClassName = "C" },
                new Class { Id = 4, ClassName = "D" },
                new Class { Id = 5, ClassName = "E" },
                new Class { Id = 6, ClassName = "F" }
            );
        }
    }
}

