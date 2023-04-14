namespace ProductManagement.Domain.Products.DomainServices
{
    public class ProductValidationService : AbstractValidator<Product>, IDomainService
    {
        public ProductValidationService()
        {
            RuleFor(a => a.Name).NotEmpty().NotNull().WithErrorCode("ProductNameCouldNotBeNull").WithMessage("Please specify product name");
            RuleFor(a => a.CategoryId).Must(a => a > 0).WithErrorCode("ProductCategoryMustBeProvide").WithMessage("Please specify product Category");
        }
    }
}
