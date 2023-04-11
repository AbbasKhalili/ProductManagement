global using Shared.Core;

using ProductManagement.Interface.Contract.Product.Dtos;

namespace ProductManagement.Interface.Contract.Product.Services
{
    public interface IProductQueryService : IFacadeService
    {
        Task<List<ProductDto>> GetAll();
        Task<ProductDto> GetById(Guid id);
    }
}
