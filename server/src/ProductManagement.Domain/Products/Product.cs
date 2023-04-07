global using Shared.Domain;
global using Shared.Core;

namespace ProductManagement.Domain.Products
{
    public class Product : AggregateRoot<long>
    {
        public string Name { get; private set; }
        public string Category { get; private set; }
        public double Weight { get; private set; }
        public bool Enabled { get; private set; }
        public ProductType ProductType { get; private set; }
        public string ImageUrl { get; private set; }
        public string Description { get; private set; }


        protected Product() : base(null) { }
        public Product(string name, string category, double weight, bool enabled, ProductType productType,
            string imageUrl, string description, ISystemClock systemClock) : base(systemClock)
        {
            SetProperties(name, category, weight, enabled, productType, imageUrl, description);
        }

        public void Update(string name, string category, double weight, bool enabled, ProductType productType,
            string imageUrl, string description, ISystemClock systemClock)
        {
            SetProperties(name, category, weight, enabled, productType, imageUrl, description);
            EntityModified(systemClock);
        }

        private void SetProperties(string name, string category, double weight, bool enabled, ProductType productType,
            string imageUrl, string description)
        {
            Name = name;
            Category = category;
            Weight = weight;
            Enabled = enabled;
            ProductType = productType;
            ImageUrl = imageUrl;
            Description = description;
        }

        public void Delete(ISystemClock systemClock)
        {
            EntityDeleted(systemClock);
        }
    }
}
