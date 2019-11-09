using CSharpFunctionalExtensions;

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.AlunoAggregate
{
    public class Naturalidade : ValueObject
    {
        public string Value { get; }

        private Naturalidade(string value)
        {
            Value = value;
        }

        public static Result<Naturalidade> Create(Maybe<string> naturalidadeOrNothing)
        {
            return naturalidadeOrNothing.ToResult("Naturalidade não pode está vazio")
                .Map(naturalidade => naturalidade.Trim())
                .Ensure(naturalidade => naturalidade != string.Empty, "Naturalidade não pode está vazio")
                .Ensure(naturalidade => naturalidade.Length <= 60, "Naturalidade não pode conter mais que 60 caracteres")
                .Ensure(naturalidade => Regex.IsMatch(naturalidade, @"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$"), "Naturalidade é inválida")
                .Map(naturalidade => new Naturalidade(naturalidade));
        }

        public static explicit operator Naturalidade(string naturalidade)
        {
            return Create(naturalidade).Value;
        }

        public static implicit operator string(Naturalidade naturalidade)
        {
            return naturalidade.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
