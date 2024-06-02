using BasicMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicMVCApp.Services
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Item> Items { get; set; }
    }
}
