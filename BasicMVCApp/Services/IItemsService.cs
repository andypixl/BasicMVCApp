using BasicMinimalApi.Models;

namespace BasicMinimalApi.Services
{
    public interface IItemsService
    {
        public Task<Item> AddItemToUserAsync(int userId, Item item);

        public Task<Item> DeleteItemForUserAsync(int userId, int itemId);
    }
}
