namespace ProductManagement.Domain.Products
{
    public interface IProductRepository : IRepository<Product, long>
    {
        Task<Product> GetBy(Guid id);
        Task<List<Product>> GetAll();
    }
}
