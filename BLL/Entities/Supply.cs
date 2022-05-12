using System.ComponentModel.DataAnnotations;

namespace BLL.Entities
{
    public class Supply
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Номер накладной
        /// </summary>
        [Required]
        [StringLength(50)]
        public string? InvoiceNumber { get; set; }

        public DateTime DateCreate { get; set; }

        public string? SupplierData { get; set; }
        //public int SupplierId { get; set; }
        //public Supplier? Supplier { get; set; }

        public List<SupplyForProduct> SupplyForProducts { get; set; } = new();
    }
}
