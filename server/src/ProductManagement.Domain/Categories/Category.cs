using ProductManagement.Domain.Products;

namespace ProductManagement.Domain.Categories
{
    public class Category : EntityBase<long>
    {
        public string Title { get; private set; }

        public List<Product> Products { get; private set; }

        public Category(string title, ISystemClock systemClock) : base(systemClock)
        {
            Title = title;
        }

        public void Update(string title, ISystemClock systemClock)
        {
            SetProperties(title);
            EntityModified(systemClock);
        }

        private void SetProperties(string title)
        {
            Title = title;
        }

        public void Delete(ISystemClock systemClock)
        {
            EntityDeleted(systemClock);
        }
    }
}
