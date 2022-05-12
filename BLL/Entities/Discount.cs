using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Entities
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string? DiscountName { get; set; }

        /// <summary>
        /// размер скидки
        /// </summary>
        public int DiscountAmount { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }
    }
}
