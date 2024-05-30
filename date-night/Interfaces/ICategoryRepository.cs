using date_night_user.Model;

namespace date_night_user.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
        Task<Category> GetById(int id);
    }
}
