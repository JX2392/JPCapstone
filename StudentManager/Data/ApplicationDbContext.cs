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
    }
}
