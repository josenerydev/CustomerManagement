using CSharpFunctionalExtensions;

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.Common
{
    public class Profissao : ValueObject
    {
        public string Value { get; }

        private Profissao(string value)
        {
            Value = value;
        }

        public static Result<Profissao> Create(Maybe<string> profissaoOrNothing)
        {
            return profissaoOrNothing.ToResult("Profissão não pode está vazio")
                .Map(profissao => profissao.Trim())
                .Ensure(profissao => profissao != string.Empty, "Profissão não pode está vazio")
                .Ensure(profissao => profissao.Length <= 60, "Profissão não pode conter mais que 20 caracteres")
                .Ensure(profissao => Regex.IsMatch(profissao, @"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$"), "Profissão é inválida")
                .Map(profissao => new Profissao(profissao));
        }

        public static explicit operator Profissao(string profissao)
        {
            return Create(profissao).Value;
        }

        public static implicit operator string(Profissao profissao)
        {
            return profissao.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
