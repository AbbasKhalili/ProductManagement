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

        public async Task Update(Product entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Product entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetBy(long id)
        {
            return await _context.Products.Include(a => a.Category).FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
        }

        public async Task<Product> GetBy(Guid id)
        {
            return await _context.Products.Include(a => a.Category).FirstOrDefaultAsync(a => a.SurrogateKey == id && !a.IsDeleted);
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.Include(a => a.Category).Where(a => !a.IsDeleted).ToListAsync();
        }
    }
}