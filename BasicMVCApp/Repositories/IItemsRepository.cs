using BasicMVCApp.Models;

namespace BasicMVCApp.Repositories
{
    public interface IItemsRepository
    {
        Task<Item> AddItemToUserAsync(int userId, Item item);

        Task<Item> DeleteItemForUserAsync(int userId, int itemId);
    }
}
