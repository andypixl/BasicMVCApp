using BasicMVCApp.Data;
using BasicMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BasicMVCApp.Controllers
{
    public class HomeController(ILogger<HomeController> logger, ApplicationDbContext context) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly ApplicationDbContext _context = context;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Users

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users
                .Include("Items")
                .ToList();

            return View(users);
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("GetAllUsers");
        }

        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Id == id);
            _context.Users.Remove(user);
            _context.SaveChanges();

            return RedirectToAction("GetAllUsers");
        }

        // Items

        [HttpGet]
        public IActionResult GetUserDetails(int id)
        {
            var user = _context.Users
                .Include("Items")
                .FirstOrDefault(u => u.Id == id);

            return View(user);
        }

        [HttpPost]
        public IActionResult AddItemToUser(int id, string type)
        {
            var item = new Item
            {
                Type = type
            };
            var user = _context.Users
                .Include("Items")
                .FirstOrDefault(u => u.Id == id);
            user.Items.Add(item);
            _context.Update(user);
            _context.SaveChanges();

            return View("GetUserDetails", user);
        }

        [HttpPost]
        public IActionResult DeleteItem(int userId, int itemId)
        {
            var user = _context.Users
                .Include("Items")
                .FirstOrDefault(u => u.Id == userId);
            user.Items.Remove(user.Items.FirstOrDefault(i => i.Id == itemId));
            _context.Users.Update(user);
            _context.SaveChanges();

            return View("GetUserDetails", user);
        }
    }
}
