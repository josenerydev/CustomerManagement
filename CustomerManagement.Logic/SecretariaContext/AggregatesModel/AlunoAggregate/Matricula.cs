using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.AlunoAggregate
{
    public class Matricula : ValueObject
    {
        public string Value { get; }

        private Matricula(string value)
        {
            Value = value;
        }

        public static Result<Matricula> Create(Maybe<string> matriculaOrNothing)
        {
            return matriculaOrNothing.ToResult("Matrícula não pode está vazia")
                .Map(matricula => matricula.Trim())
                .Ensure(matricula => matricula != string.Empty, "Matrícula não pode está vazia")
                .Ensure(matricula => matricula.Length == 10 ,"Matrícula deve conter 10 dígitos")
                .Ensure(matricula => Regex.IsMatch(matricula, @"^[0-9]+$"), "Matrícula é inválido")
                .Map(matricula => new Matricula(matricula));
        }

        public static explicit operator Matricula(string matricula)
        {
            return Create(matricula).Value;
        }

        public static implicit operator string(Matricula matricula)
        {
            return matricula.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
