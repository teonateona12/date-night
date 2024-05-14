using date_night.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace date_night.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            var categories = new List<Category>
            {
                new Category { Id = 1, Image="", Title="kabebi"}
            };
            return Ok(categories);
        }
    }
}
