global using Shared.Domain;
global using Shared.Core;

using ProductManagement.Domain.Categories;

namespace ProductManagement.Domain.Products
{
    public class Product : AggregateRoot<long>
    {
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public bool Enabled { get; private set; }
        public ProductType ProductType { get; private set; }
        public string Description { get; private set; }

        public long CategoryId { get; private set; }
        public Category Category { get; private set; }


        protected Product() : base(null) { }
        public Product(string name, Category category, double weight, bool enabled, ProductType productType,
            string description, ISystemClock systemClock, IValidator<Product> validator) : base(systemClock)
        {
            SetProperties(name, category.Id, weight, enabled, productType, description, validator);
        }

        public void Update(string name, long categoryId, double weight, bool enabled, ProductType productType,
            string description, ISystemClock systemClock, IValidator<Product> validator)
        {
            SetProperties(name, categoryId, weight, enabled, productType, description, validator);
            EntityModified(systemClock);
        }

        private void SetProperties(string name, long categoryId, double weight, bool enabled, 
            ProductType productType, string description, IValidator<Product> validator)
        {
            Name = name;
            CategoryId = categoryId;
            Weight = weight;
            Enabled = enabled;
            ProductType = productType;
            Description = description;
            validator.ValidateAndThrow(this);
        }

        public void Delete(ISystemClock systemClock)
        {
            EntityDeleted(systemClock);
        }
    }
}
