using date_night_admin.Data;
using date_night_admin.Interfaces;
using date_night_admin.Model;
using Microsoft.EntityFrameworkCore;

namespace date_night_admin.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext context;

        public ItemRepository(DataContext context)
        {
            this.context = context;
        }
        public async Task<Item> Create(Item item)
        {
            await context.Items.AddAsync(item);

            await context.SaveChangesAsync();
            
            return item;
        }

        public Task<Item?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> GetAllAsync()
        {
            return context.Items.ToListAsync();
        }

        public Task<Item?> Update(int id, Item item)
        {
            throw new NotImplementedException();
        }
    }
}
