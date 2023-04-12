using ProductManagement.Domain.Products;
using ProductManagement.Interface.Contract.Product.Dtos;

namespace ProductManagement.Interface.Query.Mappers
{
    internal static class ProductMapper
    {
        internal static List<ProductDto> Map(List<Product> list)
        {
            return list.Select(Map).ToList();
        }

        internal static ProductDto Map(Product item)
        {
            return new ProductDto
            {
                Name = item.Name,
                Id = item.SurrogateKey,
                Description = item.Description,
                Enabled = item.Enabled,
                Weight = item.Weight,
                ProductType = (byte)item.ProductType,
                ProductTypeTitle = item.ProductType.ToString(),
                CategoryName = item.Category.Title,
                CategoryId = item.Category.SurrogateKey,
            };
        }
    }
}
