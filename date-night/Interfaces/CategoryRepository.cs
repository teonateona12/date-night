using date_night_user.Data;
using date_night_user.Model;
using Microsoft.EntityFrameworkCore;

namespace date_night_user.Interfaces
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext context;

        public CategoryRepository(DataContext context)
        {
            this.context = context;
        }
        public Task<List<Category>> GetAll()
        {
            return context.Categories.ToListAsync();
        }
    }
}
