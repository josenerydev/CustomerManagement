using CSharpFunctionalExtensions;

using System.Collections.Generic;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.Common
{
    public class Nome : ValueObject
    {
        public string Value { get; }

        private Nome(string value)
        {
            Value = value;
        }

        public static Result<Nome> Create(Maybe<string> nomeOrNothing)
        {
            return nomeOrNothing.ToResult("Nome não pode está em vazio")
                .Map(nome => nome.Trim())
                .Ensure(nome => nome != string.Empty, "Nome não pode está em vazio")
                .Ensure(nome => nome.Length <= 200, "Nome não pode conter mais que 200 caracteres")
                .Map(nome => new Nome(nome));
        }

        public static explicit operator Nome(string nome)
        {
            return Create(nome).Value;
        }

        public static implicit operator string(Nome nome)
        {
            return nome.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
