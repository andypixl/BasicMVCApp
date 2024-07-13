using BasicMinimalApi.Models;

namespace BasicMinimalApi.Repositories
{
    public interface IItemsRepository
    {
        Task<IEnumerable<Item>> GetAllAsync();

        Task<Item> GetByIdAsync(int id);

        Task<Item> CreateAsync(Item item);

        Task<Item> UpdateAsync(Item item);

        Task<Item> DeleteAsync(int id);
    }
}
