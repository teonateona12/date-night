using date_night.Model;
using Microsoft.EntityFrameworkCore;

namespace date_night.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
    }
}
