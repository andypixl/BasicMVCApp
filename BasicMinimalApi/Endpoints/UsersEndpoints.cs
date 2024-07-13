using BasicMinimalApi.Models;
using BasicMinimalApi.Services;

namespace BasicMinimalApi.Endpoints
{
    public static class UsersEndpoints
    {
        public static void MapUsersEndpoints(this WebApplication app)
        {
            var root = app.MapGroup("/api/users");

            root.MapGet("", GetUsers);

            root.MapGet("/{id}", GetUser);

            root.MapPost("", CreateUser);

            root.MapPut("/{id}", UpdateUser);

            root.MapDelete("/{id}", DeleteUser);
        }

        public static async Task<IResult> GetUsers(IUsersService usersService)
        {
            var users = await usersService.GetAllUsersAsync();

            return Results.Ok(users);
        }

        public static async Task<IResult> GetUser(int id, IUsersService usersService)
        {
            var user = await usersService.GetUserByIdAsync(id);

            return Results.Ok(user);
        }

        public static async Task<IResult> CreateUser(User user, IUsersService usersService)
        {
            var createdUser = await usersService.CreateUserAsync(user);

            return Results.Ok(createdUser);
        }

        public static async Task<IResult> UpdateUser(int id, User user, IUsersService usersService)
        {
            var updatedUser = await usersService.UpdateUserAsync(id, user);

            return Results.Ok(updatedUser);
        }

        public static async Task<IResult> DeleteUser(int id, IUsersService usersService)
        {
            var deletedUser = await usersService.DeleteUserAsync(id);

            return Results.Ok(deletedUser);
        }
    }
}
