using CustomerManagement.Logic.SeedWork;
using MediatR;
using NHibernate.Event;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Logic.Utils
{
    internal class EventListener :
        IPostInsertEventListener,
        IPostDeleteEventListener,
        IPostUpdateEventListener,
        IPostCollectionUpdateEventListener
    {
        public void OnPostDelete(PostDeleteEvent @event)
        {
            DispatchEvents(@event.Entity as AggregateRoot);
        }

        public Task OnPostDeleteAsync(PostDeleteEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void OnPostInsert(PostInsertEvent @event)
        {
            DispatchEvents(@event.Entity as AggregateRoot);
        }

        public Task OnPostInsertAsync(PostInsertEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void OnPostUpdate(PostUpdateEvent @event)
        {
            DispatchEvents(@event.Entity as AggregateRoot);
        }

        public Task OnPostUpdateAsync(PostUpdateEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void OnPostUpdateCollection(PostCollectionUpdateEvent @event)
        {
            DispatchEvents(@event.AffectedOwnerOrNull as AggregateRoot);
        }

        public Task OnPostUpdateCollectionAsync(PostCollectionUpdateEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private void DispatchEvents(AggregateRoot aggregateRoot)
        {
            if (aggregateRoot == null)
                return;

            foreach (IRequest domainEvent in aggregateRoot.DomainEvents)
            {
                //DomainEvents.Dispatch(domainEvent);
            }

            aggregateRoot.ClearEvents();
        }
    }
}
