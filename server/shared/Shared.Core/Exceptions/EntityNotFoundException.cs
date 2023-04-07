namespace Shared.Core.Exceptions
{
    public class EntityNotFoundException : BusinessException
    {
        public EntityNotFoundException() : base(1, "Notfound!")
        {
        }
        public EntityNotFoundException(long id) : base(1, $"Id: {id} NotFound!")
        {
        }
        public EntityNotFoundException(string message) : base(1, message)
        {
        }
    }
}