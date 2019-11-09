using CSharpFunctionalExtensions;

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.AlunoAggregate
{
    public class Cep : ValueObject
    {
        public string Value { get; }

        public Cep(string value)
        {
            Value = value;
        }

        public static Result<Cep> Create(Maybe<string> cepOrNothing)
        {
            return cepOrNothing.ToResult("Cep não pode está vazio")
                .Map(cep => cep.Trim())
                .Ensure(cep => cep != string.Empty, "Cep não pode está vazio")
                .Ensure(cep => Regex.IsMatch(cep, @"^[0-9]{2}.[0-9]{3}-[0-9]{3}$"), "Cep inválido")
                .Map(cep => new Cep(cep));
        }

        public static explicit operator Cep(string cep)
        {
            return Create(cep).Value;
        }

        public static implicit operator string(Cep cep)
        {
            return cep.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
