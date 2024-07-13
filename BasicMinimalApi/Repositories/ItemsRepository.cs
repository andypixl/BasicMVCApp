using BasicMinimalApi.Data;
using BasicMinimalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicMinimalApi.Repositories
{
    public class ItemsRepository(ApplicationDbContext context) : IItemsRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context
                .Items
                .ToListAsync();
        }

        public async Task<Item> GetByIdAsync(int id)
        {
            return await _context
                .Items
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Item> CreateAsync(Item item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Item> UpdateAsync(Item item)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Item> DeleteAsync(int id)
        {
            var item = await _context.Items
                .FirstOrDefaultAsync(i => i.Id == id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
