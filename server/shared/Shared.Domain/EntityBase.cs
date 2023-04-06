using Shared.Core;
using System;

namespace Shared.Domain
{
    public abstract class EntityBase<T>
    {
        public T Id { get; protected set; }
        public Guid SurrogateKey { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public DateTime LastModified { get; protected set; }
        public DateTime? DeletedDate { get; protected set; }
        public bool IsDeleted { get; protected set; }

        protected EntityBase(ISystemClock systemClock)
        {
            CreatedDate = systemClock.ReturnNow();
            LastModified = systemClock.ReturnNow();
            DeletedDate = null;
            IsDeleted = false;
        }

        public void EntityModified(ISystemClock systemClock)
        {
            LastModified = systemClock.ReturnNow();
        }

        public void EntityDeleted(ISystemClock systemClock)
        {
            DeletedDate = systemClock.ReturnNow();
            IsDeleted = true;
        }
    }
}
