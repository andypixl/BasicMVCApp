using BasicMinimalApi.Models;

namespace BasicMinimalApi.Repositories
{
    public interface IUsersRepository
    {
        Task<List<User>> GetAllUsersAsync();

        Task<User> GetUserByIdAsync(int id);

        Task<User> AddUserAsync(User user);

        Task<User> DeleteUserAsync(int id);
    }
}
