using System.ComponentModel.DataAnnotations;

namespace BLL.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? ProductName { get; set; }

        public int ProductQuantity { get; set; }

        public float PurchasingPrice { get; set; }

        public int ManufacturerId { get; set; }
        public Manufacturer? Manufacturer { get; set; }

        public int ProductTypeId { get; set; }
        public ProductType? ProductType { get; set; }

        public List<SupplyForProduct> SupplyForProducts { get; set; } = new();

        public List<CheckForProduct> CheckForProducts { get; set; } = new();
    }
}
