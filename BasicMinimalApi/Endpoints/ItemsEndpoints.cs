using BasicMinimalApi.Models;
using BasicMinimalApi.Services;

namespace BasicMinimalApi.Endpoints
{
    public static class ItemsEndpoints
    {
        public static void MapItemsEndpoints(this WebApplication app)
        {
            var root = app.MapGroup("/api/items");

            root.MapGet("", GetItems);

            root.MapGet("/{id}", GetItem);

            root.MapPost("", CreateItem);

            root.MapPut("/{id}", UpdateItem);

            root.MapDelete("/{id}", DeleteItem);
        }

        public static async Task<IResult> GetItems(IItemsService itemsService)
        {
            var items = await itemsService.GetAllItemsAsync();

            return Results.Ok(items);
        }

        public static async Task<IResult> GetItem(int id, IItemsService itemsService)
        {
            var item = await itemsService.GetItemByIdAsync(id);

            return Results.Ok(item);
        }

        public static async Task<IResult> CreateItem(int userId, Item item, IItemsService itemsService)
        {
            var createdItem = await itemsService.CreateItemAsync(userId, item);

            return Results.Ok(createdItem);
        }

        public static async Task<IResult> UpdateItem(int id, Item item, IItemsService itemsService)
        {
            var updatedItem = await itemsService.UpdateItemAsync(id, item);

            return Results.Ok(updatedItem);
        }

        public static async Task<IResult> DeleteItem(int id, IItemsService itemsService)
        {

            var deletedItem = await itemsService.DeleteItemAsync(id);

            return Results.Ok(deletedItem);
        }
    }
}
