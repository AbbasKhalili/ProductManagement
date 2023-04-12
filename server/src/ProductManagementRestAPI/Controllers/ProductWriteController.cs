using ProductManagement.Interface.Contract.Product.Models;
using ProductManagement.Interface.Contract.Product.Services;

namespace ProductManagementRestAPI.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductWriteController : ControllerBase
    {
        private readonly IProductWriteService _productWriteService;

        public ProductWriteController(IProductWriteService productWriteService)
        {
            _productWriteService = productWriteService;
        }

        [HttpPost]
        public async Task<Guid> Create(ProductModel model)
        {
            return await _productWriteService.Create(model);
        }

        [HttpPut("update/{id}")]
        public async Task Update(Guid id, ProductModel model)
        {
            await _productWriteService.Update(id,model);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _productWriteService.Delete(id);
        }
    }
}