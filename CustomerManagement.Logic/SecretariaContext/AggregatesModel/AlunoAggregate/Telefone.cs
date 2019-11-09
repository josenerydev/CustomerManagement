using CSharpFunctionalExtensions;

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.AlunoAggregate
{
    public class Telefone : ValueObject
    {
        public string Value { get; }

        private Telefone(string value)
        {
            Value = value;
        }

        public static Result<Telefone> Create(Maybe<string> telefoneOrNothing)
        {
            return telefoneOrNothing.ToResult("O Telefone não deve estar vazio")
                .Map(telefone => telefone.Trim())
                .Ensure(telefone => telefone != string.Empty, "O Telefone não deve estar vazio")
                .Ensure(telefone => Regex.IsMatch(telefone, @"^(?:(?:\+|00)?(55)\s?)?(?:\(?([1-9][0-9])\)?\s?)?(?:((?:9\d|[2-9])\d{3})\-?(\d{4}))$"), "O Telefone inválido")
                .Map(telefone => new Telefone(telefone));
        }

        public static explicit operator Telefone(string telefone)
        {
            return Create(telefone).Value;
        }

        public static implicit operator string(Telefone telefone)
        {
            return telefone.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
