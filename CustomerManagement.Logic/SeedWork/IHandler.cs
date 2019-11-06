namespace CustomerManagement.Logic.SeedWork
{
    public interface IHandler<T>
        where T : IDomainEvent
    {
        void Handle(T domainEvent);
    }
}
