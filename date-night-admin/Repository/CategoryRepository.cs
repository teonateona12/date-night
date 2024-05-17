using date_night_admin.Data;
using date_night_admin.Interfaces;
using date_night_admin.Model;
using Microsoft.EntityFrameworkCore;

namespace date_night_admin.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext context;

        public CategoryRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<Category> Create(Category category)
        {
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return category;
        }

        public Task<List<Category>> GetAllAsync()
        {
            return context.Categories.ToListAsync();
        }

        public async Task<Category?> Update(int id, Category category)
        {
            var existingCategory = context.Categories.FirstOrDefault(c => c.Id == id);

            if (existingCategory == null)
            {
                return null;
            }

            existingCategory.Title = category.Title;
            existingCategory.Image = category.Image;

            await context.SaveChangesAsync();

            return existingCategory;

        }
    }
}
