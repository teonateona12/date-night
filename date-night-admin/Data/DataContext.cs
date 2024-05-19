using date_night_admin.Model;
using Microsoft.EntityFrameworkCore;

namespace date_night_admin.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(a => a.Title).IsRequired();

            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(a => a.Name).IsRequired();

                entity.HasOne(a => a.Category).WithMany(p => p.Items)
                .HasForeignKey(a => a.Id)
                .OnDelete(DeleteBehavior.NoAction);

            });
        }
    }
}
