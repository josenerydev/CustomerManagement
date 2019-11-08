using CSharpFunctionalExtensions;

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.Common
{
    public class RG : ValueObject
    {
        public string Value { get; }

        private RG(string value)
        {
            Value = value;
        }

        public static Result<RG> Create(Maybe<string> rgOrNothing)
        {
            return rgOrNothing.ToResult("O RG não deve estar vazio")
                .Map(rg => rg.Trim())
                .Ensure(rg => rg != string.Empty, "O RG não deve estar vazio")
                .Ensure(rg => Regex.IsMatch(rg, @"^[0-9]{2,3}\.?[0-9]{2,3}\.?[0-9]{3}\-?[A-Za-z0-9]{0,1}$"), "RG inválido")
                .Map(rg => new RG(rg));
        }

        public static explicit operator RG(string rg)
        {
            return Create(rg).Value;
        }

        public static implicit operator string(RG rg)
        {
            return rg.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
