namespace ProductManagement.Domain.Categories
{
    public interface ICategoryRepository : IRepository<Category, long>
    {
        Task<Category> GetBy(Guid id);
        Task<List<Category>> GetAll();
    }
}
