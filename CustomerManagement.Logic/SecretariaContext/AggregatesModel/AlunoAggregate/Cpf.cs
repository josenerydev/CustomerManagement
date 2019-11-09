using CSharpFunctionalExtensions;

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.AlunoAggregate
{
    public class Cpf : ValueObject
    {
        public string Value { get; }

        private Cpf(string value)
        {
            Value = value;
        }

        public static Result<Cpf> Create(Maybe<string> cpfOrNothing)
        {
            return cpfOrNothing.ToResult("O CPF não deve estar vazio")
                .Map(cpf => cpf.Trim())
                .Ensure(cpf => cpf != string.Empty, "O CPF não deve estar vazio")
                .Ensure(cpf => Regex.IsMatch(cpf, @"^[0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2}"), "CPF inválido")
                .Map(cpf => new Cpf(cpf));
        }

        public static explicit operator Cpf(string cpf)
        {
            return Create(cpf).Value;
        }

        public static implicit operator string(Cpf cpf)
        {
            return cpf.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
