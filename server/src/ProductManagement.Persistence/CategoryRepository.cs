using ProductManagement.Domain.Categories;

namespace ProductManagement.Persistence
{
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly ProductManagementContext _context;

        public CategoryRepository(ProductManagementContext context)
        {
            _context = context;
        }

        public async Task Create(Category entity)
        {
            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Category entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Category entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> GetBy(Guid id)
        {
            return await _context.Categories.FirstOrDefaultAsync(a => a.SurrogateKey == id);
        }

        public async Task<Category> GetBy(long id)
        {
            return await _context.Categories.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
