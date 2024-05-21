using date_night_admin.Model;

namespace date_night_admin.Interfaces
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllAsync();
        Task<Item> Create(ItemDto itemDto);
        Task<Item?> Update(int id, Item item);
        Task<Item?> Delete(int id);
    }
}
