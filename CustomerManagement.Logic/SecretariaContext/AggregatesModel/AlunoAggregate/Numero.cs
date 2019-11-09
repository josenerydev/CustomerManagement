using CSharpFunctionalExtensions;

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.AlunoAggregate
{
    public class Numero : ValueObject
    {
        public string Value { get; }

        private Numero(string value)
        {
            Value = value;
        }

        public static Result<Numero> Create(Maybe<string> numeroOrNothing)
        {
            return numeroOrNothing.ToResult("Número não pode está vazio")
                .Map(numero => numero.Trim())
                .Ensure(numero => numero != string.Empty, "Número não pode está vazio")
                .Ensure(numero => numero.Length <= 20, "Número não pode conter mais que 20 caracteres")
                .Ensure(numero => Regex.IsMatch(numero, @"^[a-z0-9]+$"), "Número é inválido")
                .Map(numero => new Numero(numero));
        }

        public static explicit operator Numero(string numero)
        {
            return Create(numero).Value;
        }

        public static implicit operator string(Numero numero)
        {
            return numero.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
