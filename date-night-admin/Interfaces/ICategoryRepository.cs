using date_night_admin.Model;

namespace date_night_admin.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> GetAllAsync();
        Task<Category> Create(Category category);
        Task<Category?> Update(int id, Category category);
        Task<Category?> Delete(int id);
    }
}
