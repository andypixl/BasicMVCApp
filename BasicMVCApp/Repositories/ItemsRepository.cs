using BasicMinimalApi.Models;
using BasicMinimalApi.Services;
using Microsoft.EntityFrameworkCore;

namespace BasicMinimalApi.Repositories
{
    public class ItemsRepository(ApplicationDbContext context, IUsersRepository usersRepository) : IItemsRepository
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IUsersRepository _usersRepository = usersRepository;

        public async Task<Item> AddItemToUserAsync(int userId, Item item)
        {
            var user = await _usersRepository.GetUserByIdAsync(userId);
            user.Items.Add(item);
            _context.Update(user);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Item> DeleteItemForUserAsync(int userId, int itemId)
        {
            var user = await _usersRepository.GetUserByIdAsync(userId);
            var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == itemId);
            user.Items.Remove(item);
            _context.Update(user);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
