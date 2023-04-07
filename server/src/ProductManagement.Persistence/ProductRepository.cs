using ProductManagement.Domain.Products;

namespace ProductManagement.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductManagementContext _context;

        public ProductRepository(ProductManagementContext context)
        {
            _context = context;
        }

        public async Task Create(Product entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Product entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Product entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetBy(long id)
        {
            return await _context.Products.FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}