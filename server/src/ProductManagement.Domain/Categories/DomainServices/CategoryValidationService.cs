using FluentValidation;
using FluentValidation.Results;

namespace ProductManagement.Domain.Categories.DomainServices
{
    public class CategoryValidationService : AbstractValidator<Category>, IDomainService
    {
        public CategoryValidationService()
        {
            RuleFor(x => x.Title).NotEmpty().WithErrorCode("CategoryTitleCouldNotBeNull").WithMessage("Please specify a title");
        }
    }
}
