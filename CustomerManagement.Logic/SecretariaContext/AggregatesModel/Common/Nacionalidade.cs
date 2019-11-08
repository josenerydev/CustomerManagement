using CSharpFunctionalExtensions;

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.Common
{
    public class Nacionalidade : ValueObject
    {
        public string Value { get; }

        private Nacionalidade(string value)
        {
            Value = value;
        }

        public static Result<Nacionalidade> Create(Maybe<string> nacionalidadeOrNothing)
        {
            return nacionalidadeOrNothing.ToResult("Nacionalidade não pode está vazio")
                .Map(nacionalidade => nacionalidade.Trim())
                .Ensure(nacionalidade => nacionalidade != string.Empty, "Nacionalidade não pode está vazio")
                .Ensure(nacionalidade => nacionalidade.Length <= 20, "Nacionalidade não pode conter mais que 20 caracteres")
                .Ensure(nacionalidade => Regex.IsMatch(nacionalidade, @"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$"), "Nacionalidade é inválida")
                .Map(nacionalidade => new Nacionalidade(nacionalidade));
        }

        public static explicit operator Nacionalidade(string nacionalidade)
        {
            return Create(nacionalidade).Value;
        }

        public static implicit operator string(Nacionalidade nacionalidade)
        {
            return nacionalidade.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
