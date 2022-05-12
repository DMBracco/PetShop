namespace BLL.Entities
{
    public class CheckForProduct
    {
        public int CheckId { get; set; }
        public Check? Check { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int ProductQuantity { get; set; }
    }
}
