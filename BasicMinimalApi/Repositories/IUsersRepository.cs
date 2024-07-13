using BasicMinimalApi.Models;

namespace BasicMinimalApi.Repositories
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetByIdAsync(int id);

        Task<User> CreateAsync(User user);

        Task<User> UpdateAsync(User user);

        Task<User> DeleteAsync(int id);
    }
}
