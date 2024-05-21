﻿using AutoMapper;
using date_night_admin.Data;
using date_night_admin.Interfaces;
using date_night_admin.Model;
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
            var item = mapper.Map<Item>(itemDto);

            await context.Items.AddAsync(item);

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

        public Task<List<Item>> GetAllAsync()
        {
            return context.Items.ToListAsync();
        }

        public async Task<Item?> Update(int id, Item item)
        {
            var existingItem = context.Items.FirstOrDefault(x => x.Id == id);

            if (existingItem == null)
            {
                return null;
            }

            existingItem.Description = item.Description;
            existingItem.Name = item.Name;
            existingItem.Category = item.Category;

            await context.SaveChangesAsync();

            return existingItem;
        }
    }
}
