using Microsoft.EntityFrameworkCore;
using StudentManagerAPI.Models;

namespace StudentManagerAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<LocalUser> Users { get; set; }
    }
}
