using CSharpFunctionalExtensions;

using CustomerManagement.Logic.SeedWork;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.AlunoAggregate
{
    public class LinguaEstrangeira : Enumeration
    {
        public static readonly LinguaEstrangeira Ingles = new LinguaEstrangeira(1, "Inglês");
        public static readonly LinguaEstrangeira Espanhol = new LinguaEstrangeira(2, "Espanhol");

        protected LinguaEstrangeira()
        {
        }

        private LinguaEstrangeira(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Result<LinguaEstrangeira> Get(Maybe<string> name)
        {
            if (name.HasNoValue)
                return Result.Failure<LinguaEstrangeira>("Língua estrangeira não especificada");

            if (name.Value == Ingles.Name)
                return Result.Ok(Ingles);

            if (name.Value == Espanhol.Name)
                return Result.Ok(Espanhol);

            return Result.Failure<LinguaEstrangeira>("Língua estrangeira é inválida: " + name);
        }
    }
}
