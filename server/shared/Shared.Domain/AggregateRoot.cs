using Shared.Core;
using System;

namespace Shared.Domain
{
    public abstract class AggregateRoot<T>
    {
        public T Id { get; protected set; }
        public Guid SurrogateKey { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public DateTime LastModified { get; protected set; }
        public DateTime? DeletedDate { get; protected set; }
        public bool IsDeleted { get; protected set; }

        protected AggregateRoot(ISystemClock systemClock)
        {
            SurrogateKey = Guid.NewGuid();
            CreatedDate = systemClock?.ReturnNow() ?? CreatedDate;
            LastModified = systemClock?.ReturnNow() ?? LastModified;
            DeletedDate = null;
            IsDeleted = false;
        }

        protected void EntityModified(ISystemClock systemClock)
        {
            LastModified = systemClock?.ReturnNow() ?? LastModified;
        }

        protected void EntityDeleted(ISystemClock systemClock)
        {
            DeletedDate = systemClock?.ReturnNow() ?? DeletedDate;
            IsDeleted = true;
        }
    }
}
