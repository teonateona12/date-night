using date_night_admin.Data;
using date_night_admin.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace date_night_admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext context;

        public CategoryController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            var categories = await context.Categories.ToListAsync();

            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult<List<Category>>> AddCategory(Category request)
        {

            context.Categories.Add(request);

            await context.SaveChangesAsync();

            return Ok(await context.Categories.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Category>>> UpdateCategory(Category request)
        {
            var category = await context.Categories.FindAsync(request.Id);

            if(category == null)
            {
                return BadRequest("Category not found");
            }

            category.Title = request.Title;
            category.Image = request.Image;

            await context.SaveChangesAsync();

            return Ok(category);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Category>>> DeleteCategory(int id)
        {
            var category = await context.Categories.FindAsync(id);

            if(category == null)
            {
                return BadRequest("Category not found");
            }

            context.Categories.Remove(category);

            await context.SaveChangesAsync();

            return Ok(await context.Categories.ToListAsync());
        }
    }
}
