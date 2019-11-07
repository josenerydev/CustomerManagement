using MediatR;
using System.Collections.Generic;

namespace CustomerManagement.Logic.SeedWork
{
    public abstract class AggregateRoot : Entity
    {
        private readonly List<INotification> _domainEvents = new List<INotification>();
        public virtual IReadOnlyList<INotification> DomainEvents => _domainEvents;

        protected virtual void AddDomainEvent(INotification newEvent)
        {
            _domainEvents.Add(newEvent);
        }

        public virtual void ClearEvents()
        {
            _domainEvents.Clear();
        }
    }
}
