using BasicMinimalApi.Models;

namespace BasicMinimalApi.Services
{
    public interface IItemsService
    {
        Task<IEnumerable<Item>> GetAllItemsAsync();

        Task<Item> GetItemByIdAsync(int itemId);

        Task<Item> CreateItemAsync(int userId, Item item);

        Task<Item> UpdateItemAsync(int itemId, Item item);

        Task<Item> DeleteItemAsync(int itemId);
    }
}
