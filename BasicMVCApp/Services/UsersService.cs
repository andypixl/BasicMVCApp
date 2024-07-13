using BasicMinimalApi.Models;
using BasicMinimalApi.Repositories;

namespace BasicMinimalApi.Services
{
    public class UsersService(IUsersRepository usersRepository) : IUsersService
    {
        private readonly IUsersRepository _usersRepository = usersRepository;

        public async Task<List<User>> GetAllUsersAsync() => await _usersRepository.GetAllUsersAsync();

        public async Task<User> GetUserByIdAsync(int id) => await _usersRepository.GetUserByIdAsync(id);

        public async Task<User> AddUserAsync(User user) => await _usersRepository.AddUserAsync(user);

        public async Task<User> DeleteUserAsync(int id) => await _usersRepository.DeleteUserAsync(id);
    }
}
