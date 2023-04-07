using Shared.Core;

namespace Shared.Domain
{
    public abstract class EntityBase<T> : AggregateRoot<T>
    {
        protected EntityBase(ISystemClock systemClock) : base (systemClock)
        {

        }
    }
}
