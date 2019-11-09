using CSharpFunctionalExtensions;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.AlunoAggregate
{
    public class DataNascimento : ValueObject
    {
        public string Value { get; }

        public DataNascimento(string value)
        {
            Value = value;
        }

        public static Result<DataNascimento> Create(Maybe<string> dataNascimentoOrNothing)
        {
            return dataNascimentoOrNothing.ToResult("Data de nascimento não pode está vazia")
                .Map(dataNascimento => dataNascimento.Trim())
                .Ensure(dataNascimento => dataNascimento != string.Empty, "Data de nascimento não pode está vazia")
                .Ensure(dataNascimento => Regex.IsMatch(dataNascimento, @"(^(((0[1-9]|1[0-9]|2[0-8])[\/](0[1-9]|1[012]))|((29|30|31)[\/](0[13578]|1[02]))|((29|30)[\/](0[4,6,9]|11)))[\/](19|[2-9][0-9])\d\d$)|(^29[\/]02[\/](19|[2-9][0-9])(00|04|08|12|16|20|24|28|32|36|40|44|48|52|56|60|64|68|72|76|80|84|88|92|96)$)"), "Data de nascimento inválida")
                .Ensure(dataNascimento => DateTime.ParseExact(dataNascimento,"dd/MM/yyyy", CultureInfo.InvariantCulture).Date > DateTime.Now.Date,"Data de nascimento não pode ser maior que a data atual")
                .Map(dataNascimento => new DataNascimento(dataNascimento));
        }

        public static explicit operator DataNascimento(string dataNascimento)
        {
            return Create(dataNascimento).Value;
        }

        public static implicit operator string(DataNascimento dataNascimento)
        {
            return dataNascimento.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
