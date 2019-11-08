using CSharpFunctionalExtensions;

using System.Collections.Generic;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.AlunoAggregate
{
    public class UrlFoto : ValueObject
    {
        public string Value { get; }

        private UrlFoto(string value)
        {
            Value = value;
        }

        public static Result<UrlFoto> Create(Maybe<string> urlFotoOrNothing)
        {
            return urlFotoOrNothing.ToResult("Url da foto não pode está vazia")
                .Map(url => url.Trim())
                .Ensure(url => url != string.Empty, "Url da foto não pode está vazia")
                .Map(url => new UrlFoto(url));
        }

        public static explicit operator UrlFoto(string urlFoto)
        {
            return Create(urlFoto).Value;
        }

        public static implicit operator string(UrlFoto urlFoto)
        {
            return urlFoto.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
