using BasicMVCApp.Models;

namespace BasicMVCApp.Services
{
    public interface IItemsService
    {
        public Task<Item> AddItemToUserAsync(int userId, Item item);

        public Task<Item> DeleteItemForUserAsync(int userId, int itemId);
    }
}
