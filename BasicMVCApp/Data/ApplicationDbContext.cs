using BasicMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicMVCApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = default;

        public DbSet<Item> Items { get; set; } = default;
    }
}
