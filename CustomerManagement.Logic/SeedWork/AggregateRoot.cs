using MediatR;
using System.Collections.Generic;

namespace CustomerManagement.Logic.SeedWork
{
    public abstract class AggregateRoot : Entity
    {
        private readonly List<IRequest> _domainEvents = new List<IRequest>();
        public virtual IReadOnlyList<IRequest> DomainEvents => _domainEvents;

        protected virtual void AddDomainEvent(IRequest newEvent)
        {
            _domainEvents.Add(newEvent);
        }

        public virtual void ClearEvents()
        {
            _domainEvents.Clear();
        }
    }
}
