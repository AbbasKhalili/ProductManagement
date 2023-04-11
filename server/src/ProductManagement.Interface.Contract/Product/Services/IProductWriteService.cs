using ProductManagement.Interface.Contract.Product.Models;

namespace ProductManagement.Interface.Contract.Product.Services
{
    public interface IProductWriteService
    {
        Task<Guid> Create(ProductModel model);
        Task<Guid> Update(Guid id, ProductModel model);
        Task<Guid> Delete(Guid id);
    }
}
