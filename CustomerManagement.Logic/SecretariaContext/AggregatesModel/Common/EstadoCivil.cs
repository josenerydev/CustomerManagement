using CSharpFunctionalExtensions;

using CustomerManagement.Logic.SeedWork;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.Common
{
    public class EstadoCivil : AggregateRoot
    {
        public static readonly EstadoCivil Solteiro = new EstadoCivil(1, "Solteiro(a)");
        public static readonly EstadoCivil Casado = new EstadoCivil(2, "Casado(a)");
        public static readonly EstadoCivil Divorciado = new EstadoCivil(3, "Divorciado(a)");
        public static readonly EstadoCivil Viuvo = new EstadoCivil(4, "Viúvo(a)");
        public static readonly EstadoCivil Separado = new EstadoCivil(5, "Separado(a)");

        public virtual string Value { get; protected set; }

        protected EstadoCivil()
        {
        }

        private EstadoCivil(int id, string value)
        {
            Id = id;
            Value = value;
        }

        public static Result<EstadoCivil> Get(Maybe<string> value)
        {
            if (value.HasNoValue)
                return Result.Failure<EstadoCivil>("Estado civil não especifícado");

            if (value.Value == Solteiro.Value)
                return Result.Ok(Solteiro);

            if (value.Value == Casado.Value)
                return Result.Ok(Casado);

            if (value.Value == Divorciado.Value)
                return Result.Ok(Divorciado);

            if (value.Value == Viuvo.Value)
                return Result.Ok(Viuvo);

            if (value.Value == Separado.Value)
                return Result.Ok(Separado);

            return Result.Failure<EstadoCivil>("Estado civil é inválido: " + value);
        }
    }
}
