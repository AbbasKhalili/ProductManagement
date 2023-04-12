using ProductManagement.Interface.Contract.Product.Dtos;
using ProductManagement.Interface.Contract.Product.Services;

namespace ProductManagementRestAPI.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductQueryController : ControllerBase
    {
        private readonly IProductQueryService _productQueryService;

        public ProductQueryController(IProductQueryService productQueryService)
        {
            _productQueryService = productQueryService;
        }

        [HttpGet("getbyid/{id}")]
        public async Task<ProductDto> GetById(Guid id)
        {
            return await _productQueryService.GetById(id);
        }

        [HttpGet("getall")]
        public async Task<List<ProductDto>> GetAll()
        {
            return await _productQueryService.GetAll();
        }
    }
}