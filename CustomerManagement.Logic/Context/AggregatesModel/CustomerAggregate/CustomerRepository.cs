using CustomerManagement.Logic.SeedWork;
using CustomerManagement.Logic.Utils;

using System.Linq;

namespace CustomerManagement.Logic.Model
{
    public class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Customer GetByName(string name)
        {
            return unitOfWork.Query<Customer>()
                .SingleOrDefault(x => x.Name == name);
        }
    }
}
