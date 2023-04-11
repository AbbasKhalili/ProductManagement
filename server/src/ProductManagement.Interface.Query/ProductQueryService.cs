using ProductManagement.Interface.Contract.Product.Dtos;
using ProductManagement.Interface.Contract.Product.Services;

namespace ProductManagement.Interface.Query
{
    public class ProductQueryService : IProductQueryService
    {
        public async Task<List<ProductDto>> GetAll()
        {
            
        }

        public async Task<ProductDto> GetById(Guid id)
        {

        }
    }
}