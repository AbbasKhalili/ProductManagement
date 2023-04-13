global using FluentValidation;

using ProductManagement.Domain.Products;

namespace ProductManagement.Domain.Categories
{
    public class Category : EntityBase<long>
    {
        public string Title { get; private set; }

        public List<Product> Products { get; private set; }


        protected Category() : base(null) { }
        public Category(string title, ISystemClock systemClock, IValidator<Category> validator) : base(systemClock)
        {
            SetProperties(title, validator);
        }

        public void Update(string title, ISystemClock systemClock, IValidator<Category> validator)
        {
            SetProperties(title, validator);
            EntityModified(systemClock);
        }

        private void SetProperties(string title, IValidator<Category> validator)
        {
            Title = title;
            validator.ValidateAndThrow(this);
        }

        public void Delete(ISystemClock systemClock)
        {
            EntityDeleted(systemClock);
        }
    }
}
