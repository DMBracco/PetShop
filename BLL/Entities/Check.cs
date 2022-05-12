namespace BLL.Entities
{
    public class Check
    {
        public int Id { get; set; }

        public DateTime DateCreate { get; set; }

        public int TotalPrice { get; set; }

        public User User { get; set; } = new User();

        public List<CheckForProduct> CheckForProducts { get; set; } = new();
    }
}
