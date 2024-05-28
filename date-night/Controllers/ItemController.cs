using date_night_user.Interfaces;
using date_night_user.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace date_night_user.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository item;

        public ItemController(IItemRepository item)
        {
            this.item = item;
        }
        [HttpGet]
        public async Task<ActionResult<List<ItemDto>>> GetItems()
        {
            var items = await item.GetAsync();

            return Ok(items);
        }
    }
}
