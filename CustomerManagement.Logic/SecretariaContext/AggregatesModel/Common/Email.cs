using CSharpFunctionalExtensions;

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.Common
{
    public class Email : ValueObject
    {
        public string Value { get; }

        private Email(string value)
        {
            Value = value;
        }

        public static Result<Email> Create(Maybe<string> emailOrNothing)
        {
            return emailOrNothing.ToResult("O email não deve estar vazio")
                .Map(email => email.Trim())
                .Ensure(email => email != string.Empty, "O email não deve estar vazio")
                .Ensure(email => email.Length <= 256, "O email é muito longo")
                .Ensure(email => Regex.IsMatch(email, @"^(.+)@(.+)$"), "Email é inválido")
                .Map(email => new Email(email));
        }

        public static explicit operator Email(string email)
        {
            return Create(email).Value;
        }

        public static implicit operator string(Email email)
        {
            return email.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
