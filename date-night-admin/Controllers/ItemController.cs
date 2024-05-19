using date_night_admin.Interfaces;
using date_night_admin.Model;
using Microsoft.AspNetCore.Mvc;

namespace date_night_admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Item>>> GetItems()
        {
            var items = await itemRepository.GetAllAsync();

            return Ok(items);
        }
    }
}
