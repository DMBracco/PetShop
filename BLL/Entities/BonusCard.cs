namespace BLL.Entities
{
    public class BonusCard
    {
        public int Id { get; set; }
        public float Points { get; set; }

        public User? User { get; set; }
    }
}
