using CSharpFunctionalExtensions;

using CustomerManagement.Logic.SeedWork;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.AlunoAggregate
{
    public class EstadoCivil : Enumeration
    {
        public static readonly EstadoCivil Solteiro = new EstadoCivil(1, "Solteiro(a)");
        public static readonly EstadoCivil Casado = new EstadoCivil(2, "Casado(a)");
        public static readonly EstadoCivil Divorciado = new EstadoCivil(3, "Divorciado(a)");
        public static readonly EstadoCivil Viuvo = new EstadoCivil(4, "Viúvo(a)");
        public static readonly EstadoCivil Separado = new EstadoCivil(5, "Separado(a)");

        protected EstadoCivil()
        {
        }

        private EstadoCivil(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Result<EstadoCivil> Get(Maybe<string> name)
        {
            if (name.HasNoValue)
                return Result.Failure<EstadoCivil>("Estado civil não especifícado");

            if (name.Value == Solteiro.Name)
                return Result.Ok(Solteiro);

            if (name.Value == Casado.Name)
                return Result.Ok(Casado);

            if (name.Value == Divorciado.Name)
                return Result.Ok(Divorciado);

            if (name.Value == Viuvo.Name)
                return Result.Ok(Viuvo);

            if (name.Value == Separado.Name)
                return Result.Ok(Separado);

            return Result.Failure<EstadoCivil>("Estado civil é inválido: " + name);
        }
    }
}
