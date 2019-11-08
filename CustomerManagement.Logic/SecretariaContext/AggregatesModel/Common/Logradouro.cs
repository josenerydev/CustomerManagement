using CSharpFunctionalExtensions;

using System.Collections.Generic;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.Common
{
    public class Logradouro : ValueObject
    {
        public string Value { get; }

        private Logradouro(string value)
        {
            Value = value;
        }

        public static Result<Logradouro> Create(Maybe<string> logradouroOrNothing)
        {
            return logradouroOrNothing.ToResult("O logradouro não deve estar vazio")
                .Map(logradouro => logradouro.Trim())
                .Ensure(logradouro => logradouro != string.Empty, "O logradouro não deve estar vazio")
                .Ensure(logradouro => logradouro.Length <= 60, "O logradouro não pode ter mais de 60 caracteres")
                .Map(logradouro => new Logradouro(logradouro));
        }

        public static explicit operator Logradouro(string logradouro)
        {
            return Create(logradouro).Value;
        }

        public static implicit operator string(Logradouro logradouro)
        {
            return logradouro.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
