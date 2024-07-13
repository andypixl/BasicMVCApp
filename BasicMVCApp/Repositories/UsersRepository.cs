using BasicMinimalApi.Models;
using BasicMinimalApi.Services;
using Microsoft.EntityFrameworkCore;

namespace BasicMinimalApi.Repositories
{
    public class UsersRepository(ApplicationDbContext context) : IUsersRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = await _context.Users
                .Include("Items")
                .ToListAsync();
            return users;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users
                .Include("Items")
                .FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            var user = GetUserByIdAsync(id).Result;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
