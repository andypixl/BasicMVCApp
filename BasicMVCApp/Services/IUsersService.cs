using BasicMinimalApi.Models;

namespace BasicMinimalApi.Services
{
    public interface IUsersService
    {
        Task<List<User>> GetAllUsersAsync();

        Task<User> GetUserByIdAsync(int id);

        Task<User> AddUserAsync(User user);

        Task<User> DeleteUserAsync(int id);
    }
}
