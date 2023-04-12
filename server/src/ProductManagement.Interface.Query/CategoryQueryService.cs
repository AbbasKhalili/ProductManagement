using ProductManagement.Domain.Categories;
using ProductManagement.Interface.Contract.Category.Dtos;
using ProductManagement.Interface.Contract.Category.Services;
using ProductManagement.Interface.Query.Mappers;

namespace ProductManagement.Interface.Query
{
    internal class CategoryQueryService : ICategoryQueryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public async Task<List<CategoryDto>> GetAll()
        {
            var categories = await _categoryRepository.GetAll();
            return CategoryMapper.Map(categories);
        }

        public async Task<CategoryDto> GetById(Guid id)
        {
            var category = await _categoryRepository.GetBy(id);
            return CategoryMapper.Map(category);
        }
    }
}
