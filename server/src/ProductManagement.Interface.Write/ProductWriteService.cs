using ProductManagement.Domain.Categories;
using ProductManagement.Domain.Products;
using ProductManagement.Interface.Contract.Product.Models;
using ProductManagement.Interface.Contract.Product.Services;
using Shared.Core;
using Shared.Core.Exceptions;

namespace ProductManagement.Interface.Write
{
    public class ProductWriteService : IProductWriteService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISystemClock _systemClock;

        public ProductWriteService(IProductRepository productRepository, ICategoryRepository categoryRepository, ISystemClock systemClock)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _systemClock = systemClock;
        }

        public async Task<Guid> Create(ProductModel model)
        {
            var category = await _categoryRepository.GetBy(model.CategoryId);

            Guard<EntityNotFoundException>.AgainstNull(category);

            var product = new Product(model.Name, category, model.Weight, model.Enabled,
                (ProductType)model.ProductType, model.Description, _systemClock);

            await _productRepository.Create(product);

            return product.SurrogateKey;
        }

        public async Task Update(Guid id, ProductModel model)
        {
            var category = await _categoryRepository.GetBy(model.CategoryId);
            Guard<EntityNotFoundException>.AgainstNull(category);

            var product = await _productRepository.GetBy(id);
            Guard<EntityNotFoundException>.AgainstNull(product);

            product.Update(model.Name, category.Id, model.Weight, model.Enabled,
                (ProductType)model.ProductType, model.Description, _systemClock);

            await _productRepository.Update(product);
        }

        public async Task Delete(Guid id)
        {
            var product = await _productRepository.GetBy(id);
            if (product is null) return;

            product.Delete(_systemClock);

            await _productRepository.Delete(product);
        }
    }
}