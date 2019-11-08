using CSharpFunctionalExtensions;

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.Common
{
    public class Complemento : ValueObject
    {
        public string Value { get; }

        private Complemento(string value)
        {
            Value = value;
        }

        public static Result<Complemento> Create(Maybe<string> complementoOrNothing)
        {
            return complementoOrNothing.ToResult("Complemento não pode está vazio")
                .Map(complemento => complemento.Trim())
                .Ensure(complemento => complemento != string.Empty, "Complemento não pode está vazio")
                .Ensure(complemento => complemento.Length <= 20, "Complemento não pode conter mais que 20 caracteres")
                .Ensure(complemento => Regex.IsMatch(complemento, @"^[a-z0-9]+$"), "Complemento é inválido")
                .Map(complemento => new Complemento(complemento));
        }

        public static explicit operator Complemento(string complemento)
        {
            return Create(complemento).Value;
        }

        public static implicit operator string(Complemento complemento)
        {
            return complemento.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
