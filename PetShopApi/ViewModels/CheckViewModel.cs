namespace PetShopApi.ViewModels
{
    public class CheckViewModel
    {
        public int checkId { get; set; }

        public DateTime date { get; set; }

        public int totalPrice { get; set; }

        public int userId { get; set; }

        public int bonusCardId { get; set; }

        public float bonusPoints { get; set; }

        public List<ProductViewModel> products { get; set; } = new List<ProductViewModel>();
    }
}
