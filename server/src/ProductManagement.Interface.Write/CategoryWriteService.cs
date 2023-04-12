using ProductManagement.Domain.Categories;
using ProductManagement.Interface.Contract.Category.Models;
using ProductManagement.Interface.Contract.Category.Services;
using Shared.Core;

namespace ProductManagement.Interface.Write
{
    internal class CategoryWriteService : ICategoryWriteService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISystemClock _systemClock;

        public CategoryWriteService(ICategoryRepository categoryRepository, ISystemClock systemClock)
        {
            _categoryRepository = categoryRepository;
            _systemClock = systemClock;
        }

        public async Task<Guid> Create(CategoryModel model)
        {
            var category = new Category(model.Name, _systemClock);

            await _categoryRepository.Create(category);

            return category.SurrogateKey;
        }

        public async Task Update(Guid id, CategoryModel model)
        {
            var category = await _categoryRepository.GetBy(id);

            category.Update(model.Name, _systemClock);

            await _categoryRepository.Update(category);
        }

        public async Task Delete(Guid id)
        {
            var category = await _categoryRepository.GetBy(id);

            category.Delete(_systemClock);

            await _categoryRepository.Delete(category);
        }
    }
}
