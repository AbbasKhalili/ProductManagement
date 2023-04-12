using ProductManagement.Domain.Categories;
using ProductManagement.Interface.Contract.Category.Dtos;

namespace ProductManagement.Interface.Query.Mappers
{
    internal static class CategoryMapper
    {
        internal static List<CategoryDto> Map(List<Category> list)
        {
            return list.Select(Map).ToList();
        }

        internal static CategoryDto Map(Category item)
        {
            return new()
            {
                Name = item.Title,
                Id = item.SurrogateKey,
            };
        }
    }
}
