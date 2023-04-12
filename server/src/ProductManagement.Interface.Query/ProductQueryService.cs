using ProductManagement.Domain.Products;
using ProductManagement.Interface.Contract.Product.Dtos;
using ProductManagement.Interface.Contract.Product.Services;
using ProductManagement.Interface.Query.Mappers;

namespace ProductManagement.Interface.Query
{
    public class ProductQueryService : IProductQueryService
    {
        private readonly IProductRepository _productRepository;

        public ProductQueryService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> GetAll()
        {
            var products = await _productRepository.GetAll();
            return ProductMapper.Map(products);
        }

        public async Task<ProductDto> GetById(Guid id)
        {
            var product = await _productRepository.GetBy(id);
            return ProductMapper.Map(product);
        }
    }
}