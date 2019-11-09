using CSharpFunctionalExtensions;

using CustomerManagement.Logic.SeedWork;

using System.Linq;

namespace CustomerManagement.Logic.Model
{
    public class IndustryRepository : Repository<Industry>
    {
        public IndustryRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Maybe<Industry> GetByName(string name)
        {
            return unitOfWork.Query<Industry>()
                .SingleOrDefault(x => x.Name == name);
        }
    }
}
