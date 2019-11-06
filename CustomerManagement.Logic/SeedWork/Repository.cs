using CSharpFunctionalExtensions;

using CustomerManagement.Logic.Utils;

namespace CustomerManagement.Logic.SeedWork
{
    public class Repository<T>
        where T : AggregateRoot
    {
        protected readonly UnitOfWork unitOfWork;

        protected Repository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Maybe<T> GetById(long id)
        {
            return unitOfWork.Get<T>(id);
        }

        public void Save(T aggregateRoot)
        {
            unitOfWork.SaveOrUpdate(aggregateRoot);
        }
    }
}
