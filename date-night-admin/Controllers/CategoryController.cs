using date_night_admin.Data;
using date_night_admin.Interfaces;
using date_night_admin.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace date_night_admin.Controllers
{
    [Route("api/admin/[controller]")]
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
            var categories = await categoryRepository.GetAllAsync();

            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult<List<Category>>> AddCategory(Category request)
        {
            categoryRepository.Create(request);

            return Ok(request);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<List<Category>>> UpdateCategory(int id, Category request)
        {
            var category = await categoryRepository.Update(id, request);

            return Ok(category);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Category>>> DeleteCategory(int id)
        {
            categoryRepository.Delete(id);

            return Ok();
        }
    }
}
