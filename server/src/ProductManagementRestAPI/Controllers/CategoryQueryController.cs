global using Microsoft.AspNetCore.Mvc;

using ProductManagement.Interface.Contract.Category.Dtos;
using ProductManagement.Interface.Contract.Category.Services;

namespace CategoryManagementRestAPI.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryQueryController : ControllerBase
    {
        private readonly ICategoryQueryService _categoryQueryService;

        public CategoryQueryController(ICategoryQueryService categoryQueryService)
        {
            _categoryQueryService = categoryQueryService;
        }

        [HttpGet("getbyid/{id}")]
        public async Task<CategoryDto> GetById(Guid id)
        {
            return await _categoryQueryService.GetById(id);
        }

        [HttpGet("getall")]
        public async Task<List<CategoryDto>> GetAll()
        {
            return await _categoryQueryService.GetAll();
        }
    }
}