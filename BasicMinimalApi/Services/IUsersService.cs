using BasicMinimalApi.Models;

namespace BasicMinimalApi.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();

        Task<User> GetUserByIdAsync(int userId);

        Task<User> CreateUserAsync(User user);

        Task<User> UpdateUserAsync(int userId, User user);

        Task<User> DeleteUserAsync(int userId);
    }
}
