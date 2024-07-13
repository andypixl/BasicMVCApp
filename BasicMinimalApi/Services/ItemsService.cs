using BasicMinimalApi.Models;
using BasicMinimalApi.Repositories;

namespace BasicMinimalApi.Services
{
    public class ItemsService(IItemsRepository itemsRepository, IUsersRepository usersRepository) : IItemsService
    {
        private readonly IItemsRepository _itemsRepository = itemsRepository;
        private readonly IUsersRepository _usersRepository = usersRepository;

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return await _itemsRepository.GetAllAsync();
        }

        public async Task<Item> GetItemByIdAsync(int itemId)
        {
            return await _itemsRepository.GetByIdAsync(itemId);
        }

        public async Task<Item> CreateItemAsync(int userId, Item item)
        {
            var user = await _usersRepository.GetByIdAsync(userId);

            var itemToCreate = new Item
            {
                Type = item.Type,
                UserId = user.Id
            };

            return await _itemsRepository.CreateAsync(itemToCreate);
        }

        public async Task<Item> UpdateItemAsync(int itemId, Item item)
        {
            var itemToUpdate = await _itemsRepository.GetByIdAsync(itemId);

            itemToUpdate.Type = item.Type;

            return await _itemsRepository.UpdateAsync(itemToUpdate);
        }

        public async Task<Item> DeleteItemAsync(int itemId)
        {
            return await _itemsRepository.DeleteAsync(itemId);
        }
    }
}
