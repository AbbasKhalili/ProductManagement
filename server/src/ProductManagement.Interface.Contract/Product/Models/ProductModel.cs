namespace ProductManagement.Interface.Contract.Product.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public bool Enabled { get; set; }
        public byte ProductType { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
    }
}