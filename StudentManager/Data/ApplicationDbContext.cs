using StudentManager.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Course> Course { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<LocalUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>().HasData(new Models.Course
            {
                Id= 1,
                CourseName = "Science"
            });
            
        }
    }
}
