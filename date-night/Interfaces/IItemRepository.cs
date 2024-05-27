using date_night_user.Model;

namespace date_night_user.Interfaces
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAsync();
    }
}
