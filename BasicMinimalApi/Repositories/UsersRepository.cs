using BasicMinimalApi.Data;
using BasicMinimalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicMinimalApi.Repositories
{
    public class UsersRepository(ApplicationDbContext context) : IUsersRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                .Include("Items")
                .ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users
                .Include("Items")
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteAsync(int id)
        {
            var user = await _context.Users
                .Include("Items")
                .FirstOrDefaultAsync(u => u.Id == id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
