using ProductManagement.Interface.Contract.Category.Models;
using ProductManagement.Interface.Contract.Category.Services;

namespace CategoryManagementRestAPI.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryWriteController : ControllerBase
    {
        private readonly ICategoryWriteService _categoryWriteService;

        public CategoryWriteController(ICategoryWriteService categoryWriteService)
        {
            _categoryWriteService = categoryWriteService;
        }

        [HttpPost]
        public async Task<Guid> Create(CategoryModel model)
        {
            return await _categoryWriteService.Create(model);
        }

        [HttpPut("update/{id}")]
        public async Task Update(Guid id, CategoryModel model)
        {
            await _categoryWriteService.Update(id, model);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _categoryWriteService.Delete(id);
        }
    }
}