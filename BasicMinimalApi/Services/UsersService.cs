using BasicMinimalApi.Models;
using BasicMinimalApi.Repositories;

namespace BasicMinimalApi.Services
{
    public class UsersService(IUsersRepository usersRepository) : IUsersService
    {
        private readonly IUsersRepository _usersRepository = usersRepository;

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _usersRepository.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _usersRepository.GetByIdAsync(userId);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            return await _usersRepository.CreateAsync(user);
        }

        public async Task<User> UpdateUserAsync(int userId, User user)
        {
            var userToUpdate = await _usersRepository.GetByIdAsync(userId);

            userToUpdate.Username = user.Username;

            return await _usersRepository.UpdateAsync(userToUpdate);
        }

        public async Task<User> DeleteUserAsync(int userId)
        {
            return await _usersRepository.DeleteAsync(userId);
        }
    }
}
