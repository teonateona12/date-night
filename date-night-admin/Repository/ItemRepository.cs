using AutoMapper;
using date_night_admin.Data;
using date_night_admin.Interfaces;
using date_night_admin.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace date_night_admin.Repository
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

        public async Task<Item> Create(ItemDto itemDto)
        {
            var category = await context.Categories.FirstOrDefaultAsync(c => c.Title == itemDto.CategoryTitle);
            if (category == null)
            {
                throw new InvalidOperationException("Category not found.");
            }

            var item = mapper.Map<Item>(itemDto);
            item.CategoryId = category.Id;

            context.Items.Add(item);
            await context.SaveChangesAsync();

            return item;
        }

        public async Task<Item?> Delete(int id)
        {
            var item = context.Items.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                return null;
            }

            context.Items.Remove(item);

            await context.SaveChangesAsync();

            return item;
        }

        public async Task<List<ItemDto>> GetAllAsync()
        {
            var items = await context.Items.Include(i => i.Category).ToListAsync();
            return mapper.Map<List<ItemDto>>(items);
        }

        public async Task<Item?> UpdateAsync(int id, ItemDto itemDto)
        {
            var existingItem = await context.Items.Include(i => i.Category).FirstOrDefaultAsync(x => x.Id == id);

            if (existingItem == null)
            {
                return null;
            }

            var category = await context.Categories.FirstOrDefaultAsync(c => c.Title == itemDto.CategoryTitle);
            if (category == null)
            {
                return null;
            }

            existingItem.CategoryId = category.Id;

            mapper.Map<ItemDto>(existingItem);
            existingItem.Id = id;

            await context.SaveChangesAsync();
            return existingItem;
        }

    }
}
