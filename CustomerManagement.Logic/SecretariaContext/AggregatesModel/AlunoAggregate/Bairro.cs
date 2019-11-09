using CSharpFunctionalExtensions;

using System.Collections.Generic;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.AlunoAggregate
{
    public class Bairro : ValueObject
    {
        public string Value { get; }

        private Bairro(string value)
        {
            Value = value;
        }

        public static Result<Bairro> Create(Maybe<string> bairroOrNothing)
        {
            return bairroOrNothing.ToResult("O bairro não deve estar vazio")
                .Map(bairro => bairro.Trim())
                .Ensure(bairro => bairro != string.Empty, "O bairro não deve estar vazio")
                .Ensure(bairro => bairro.Length <= 60, "O bairro não pode ter mais de 60 caracteres")
                .Map(bairro => new Bairro(bairro));
        }

        public static explicit operator Bairro(string bairro)
        {
            return Create(bairro).Value;
        }

        public static implicit operator string(Bairro bairro)
        {
            return bairro.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
