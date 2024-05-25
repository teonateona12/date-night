﻿using AutoMapper;
using date_night_admin.Data;
using date_night_admin.Interfaces;
using date_night_admin.Model;
using Microsoft.EntityFrameworkCore;

namespace date_night_admin.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public CategoryRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Category> Create(CategoryDto categoryDto)
        {
            var category = mapper.Map<Category>(categoryDto);

            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            return category;
        }

        public async Task<Category?> Delete(int id)
        {
            var existingCategory = context.Categories.FirstOrDefault(c => c.Id == id);

            if (existingCategory == null)
            {
                return null;
            }

            context.Categories.Remove(existingCategory);

            await context.SaveChangesAsync();

            return existingCategory;
        }

        public Task<List<CategoryDto>> GetAllAsync()
        {
            var category = context.Categories.Select(c => mapper.Map<CategoryDto>(c));
            return category.ToListAsync();
        }

        public async Task<Category?> Update(int id, Category category)
        {
            var existingCategory = context.Categories.FirstOrDefault(c => c.Id == id);

            if (existingCategory == null)
            {
                return null;
            }

            existingCategory.Title = category.Title;
            existingCategory.Image = category.Image;

            await context.SaveChangesAsync();

            return existingCategory;

        }
    }
}
