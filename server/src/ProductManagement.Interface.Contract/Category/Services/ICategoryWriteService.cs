using ProductManagement.Interface.Contract.Category.Models;

namespace ProductManagement.Interface.Contract.Category.Services
{
    public interface ICategoryWriteService
    {
        Task<Guid> Create(CategoryModel model);
        Task<Guid> Update(Guid id, CategoryModel model);
        Task<Guid> Delete(Guid id);
    }
}
