namespace date_night_user.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public ICollection<Item> Items { get; set; }

    }
}
