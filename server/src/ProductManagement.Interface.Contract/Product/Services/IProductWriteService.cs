using ProductManagement.Interface.Contract.Product.Models;

namespace ProductManagement.Interface.Contract.Product.Services
{
    public interface IProductWriteService : IFacadeService
    {
        Task<Guid> Create(ProductModel model);
        Task Update(Guid id, ProductModel model);
        Task Delete(Guid id);
    }
}
