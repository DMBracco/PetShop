namespace PetShopApi.ViewModels
{
    public class MessageViewModel
    {
        public string? message { get; set; }
        public IList<string> roleName { get; set; } = new List<string>();
        public string? user { get; set; }
    }
}
