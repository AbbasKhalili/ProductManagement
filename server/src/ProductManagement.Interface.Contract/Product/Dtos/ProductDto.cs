namespace ProductManagement.Interface.Contract.Product.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public bool Enabled { get; set; }
        public byte ProductType { get; set; }
        public string ProductTypeTitle { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
