namespace PetShopApi.ViewModels
{
    public class SupplyViewModel
    {
        public int id { get; set; }
        public string? invoiceNumber { get; set; }
        public DateTime dateCreate { get; set; }
        public int supplierId { get; set; }
        public string? supplierData { get; set; }

        public List<ProductViewModel> products { get; set; } = new List<ProductViewModel>();
    }
}
