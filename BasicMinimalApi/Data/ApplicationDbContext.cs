using BasicMinimalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicMinimalApi.Data
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Item> Items { get; set; }
    }
}
