using Microsoft.Extensions.Hosting;

namespace date_night_admin.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
