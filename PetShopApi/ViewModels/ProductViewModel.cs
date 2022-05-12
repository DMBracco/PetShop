namespace PetShopApi.ViewModels
{
    public class ProductViewModel
    {
        public int productId { get; set; }

        public string? productName { get; set; }

        /// <summary>
        /// Закупочная цена
        /// </summary>
        public float purchasingPrice { get; set; }

        /// <summary>
        /// Количество продукта
        /// </summary>
        public int productQuantity { get; set; }

        public int discountId { get; set; }
        public int discountAmount { get; set; }

        public int manufacturerId { get; set; }
        public string? manufacturerName { get; set; }

        public int productTypeId { get; set; }
        public string? productTypeName { get; set; }

        public bool check { get; set; }
    }
}
