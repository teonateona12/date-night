using date_night_user.Data;
using date_night_user.Interfaces;
using date_night_user.Model;
using Microsoft.EntityFrameworkCore;

namespace date_night_user.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext context;

        public ItemRepository(DataContext context)
        {
            this.context = context;
        }
        public async Task<List<Item>> GetAsync()
        {
            var items = await context.Items.Include(i => i.Category).ToListAsync();

            return items;
        }

    }
}
