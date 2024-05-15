﻿using date_night_user.Model;
using Microsoft.EntityFrameworkCore;

namespace date_night_user.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
    }
}
