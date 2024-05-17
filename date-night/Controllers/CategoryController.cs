using date_night_user.Interfaces;
using date_night_user.Model;
using Microsoft.AspNetCore.Mvc;

namespace date_night_user.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            var categories = await categoryRepository.GetAll();

            return Ok(categories);
        }
    }
}
