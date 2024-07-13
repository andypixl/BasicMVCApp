using BasicMinimalApi.Models;
using BasicMinimalApi.Repositories;

namespace BasicMinimalApi.Services
{
    public class ItemsService(IItemsRepository itemsRepository) : IItemsService
    {
        private readonly IItemsRepository _itemsRepository = itemsRepository;

        public async Task<Item> AddItemToUserAsync(int userId, Item item) => await _itemsRepository.AddItemToUserAsync(userId, item);

        public async Task<Item> DeleteItemForUserAsync(int userId, int itemId) => await _itemsRepository.DeleteItemForUserAsync(userId, itemId);
    }
}
