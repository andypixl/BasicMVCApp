using BasicMinimalApi.Models;
using BasicMinimalApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasicMinimalApi.Controllers
{
    public class UsersController(IUsersService usersService) : Controller
    {
        private readonly IUsersService _usersService = usersService;

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _usersService.GetAllUsersAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserDetails(int id)
        {
            var user = await _usersService.GetUserByIdAsync(id);
            return View(user);
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            await _usersService.AddUserAsync(user);
            return RedirectToAction(nameof(GetAllUsers));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _usersService.DeleteUserAsync(id);
            return RedirectToAction(nameof(GetAllUsers));
        }
    }
}
