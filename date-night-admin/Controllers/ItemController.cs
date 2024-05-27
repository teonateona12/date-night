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
        public async Task<ActionResult<List<ItemDto>>> GetItems()
        {
            var items = await itemRepository.GetAllAsync();

            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetById(int id)
        {
            var item = await itemRepository.GetById(id);

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Item>> CreateItem(ItemDto itemDto)
        {
            var item = await itemRepository.Create(itemDto);

            return Ok(itemDto);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> DeleteItem(int id)
        {
            var item = await itemRepository.Delete(id);
            if(item == null)
            {
                return NotFound("Item Not Found");
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Item>> UpdateItem(int id, ItemDto itemDto)
        {
            var updatedItem = await itemRepository.UpdateAsync(id, itemDto);

            if (updatedItem == null)
            {
                return NotFound("Item Not Found");
            }

            return Ok(itemDto);
        }
    }
}
