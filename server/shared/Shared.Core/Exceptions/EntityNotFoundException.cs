namespace Shared.Core.Exceptions
{
    public class EntityNotFoundException : BusinessException
    {
        public EntityNotFoundException() : base("Notfound", "Notfound!")
        {
        }
        public EntityNotFoundException(long id) : base("Notfound", $"Id: {id} NotFound!")
        {
        }
        public EntityNotFoundException(string message) : base("Notfound", message)
        {
        }
    }
}