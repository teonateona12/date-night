using date_night_admin.Model;

namespace date_night_admin.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> GetAllAsync();
        Task<Category> Create(CategoryDto categoryDto);
        Task<Category?> Update(int id, CategoryDto category);
        Task<Category?> Delete(int id);
    }
}
