using BasicMinimalApi.Models;
using BasicMinimalApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasicMinimalApi.Controllers
{
    public class ItemsController(IItemsService itemsService) : Controller
    {
        private readonly IItemsService _itemsService = itemsService;

        [HttpPost]
        public async Task<IActionResult> AddItemToUser(int id, Item item)
        {
            await _itemsService.AddItemToUserAsync(id, item);
            return RedirectToAction("GetUserDetails", "Users", new { id });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteItemForUser(int userId, int itemId)
        {

            await _itemsService.DeleteItemForUserAsync(userId, itemId);
            return RedirectToAction("GetUserDetails", "Users", new { id = userId });
        }
    }
}
