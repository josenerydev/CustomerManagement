using CSharpFunctionalExtensions;

using System.Collections.Generic;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.Common
{
    public class Cidade : ValueObject
    {
        public string Value { get; }

        private Cidade(string value)
        {
            Value = value;
        }

        public static Result<Cidade> Create(Maybe<string> cidadeOrNothing)
        {
            return cidadeOrNothing.ToResult("Cidade não pode está vazio")
                .Map(cidade => cidade.Trim())
                .Ensure(cidade => cidade != string.Empty, "Cidade não pode está vazio")
                .Ensure(cidade => cidade.Length <= 60, "Cidade não pode ter mais que 60 caracteres")
                .Map(cidade => new Cidade(cidade));
        }

        public static explicit operator Cidade(string cidade)
        {
            return Create(cidade).Value;
        }

        public static implicit operator string(Cidade cidade)
        {
            return cidade.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
