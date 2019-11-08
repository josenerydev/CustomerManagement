using CustomerManagement.Logic.SecretariaContext.AggregatesModel.Common;
using CustomerManagement.Logic.SeedWork;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.AlunoAggregate
{
    public class Colegio : AggregateRoot
    {
        public Nome Nome { get; set; }
        public Cidade Cidade { get; set; }
        public UF UF { get; set; }
    }
}
