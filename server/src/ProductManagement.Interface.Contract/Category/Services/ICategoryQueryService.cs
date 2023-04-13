using ProductManagement.Interface.Contract.Category.Dtos;

namespace ProductManagement.Interface.Contract.Category.Services
{
    public interface ICategoryQueryService : IFacadeService
    {
        Task<List<CategoryDto>> GetAll();
        Task<CategoryDto> GetById(Guid id);
    }
}
