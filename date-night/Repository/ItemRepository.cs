using AutoMapper;
using date_night_user.Data;
using date_night_user.Interfaces;
using date_night_user.Model;
using Microsoft.EntityFrameworkCore;

namespace date_night_user.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public ItemRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<List<ItemDto>> GetAsync()
        {
            var items = await context.Items.Include(i => i.Category).ToListAsync();
            return mapper.Map<List<ItemDto>>(items);
        }

    }
}
