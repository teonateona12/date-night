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
        public async Task<ActionResult<List<Category>>> AddUser(Category request)
        {

            context.Categories.Add(request);
            await context.SaveChangesAsync();
            return Ok(await context.Categories.ToListAsync());
        }
    }
}
