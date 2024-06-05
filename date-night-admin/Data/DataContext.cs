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
        public DbSet<CompanyInformation> CompanyInformation { get; set; }
        public DbSet<AboutCompany> AboutCompany { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Title).IsRequired();
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(i => i.Id);
                entity.Property(i => i.Name).IsRequired();
                entity.HasOne(i => i.Category)
                      .WithMany(c => c.Items)
                      .HasForeignKey(i => i.CategoryId)
                      .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
