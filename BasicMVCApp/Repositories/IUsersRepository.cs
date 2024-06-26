﻿using BasicMVCApp.Models;

namespace BasicMVCApp.Repositories
{
    public interface IUsersRepository
    {
        Task<List<User>> GetAllUsersAsync();

        Task<User> GetUserByIdAsync(int id);

        Task<User> AddUserAsync(User user);

        Task<User> DeleteUserAsync(int id);
    }
}
