using CustomerManagement.Logic.SeedWork;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.AlunoAggregate
{
    public class Carreira : Entity
    {
        public Nome Nome { get; set; }
        public Area Area { get; set; }
    }
}
