namespace BLL.Entities
{
    public class SupplyForProduct
    {
        public int SupplyId { get; set; }
        public Supply? Supply { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        /// <summary>
        /// ���������� ����
        /// </summary>
        public float PurchasingPrice { get; set; }

        /// <summary>
        /// ���������� ��������
        /// </summary>
        public int ProductQuantity { get; set; }
    }
}
