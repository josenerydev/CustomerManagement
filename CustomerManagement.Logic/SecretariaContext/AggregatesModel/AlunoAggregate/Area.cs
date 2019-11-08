using CSharpFunctionalExtensions;

using System.Collections.Generic;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.AlunoAggregate
{
    public class Area : ValueObject
    {
        public string Value { get; }

        private Area(string value)
        {
            Value = value;
        }

        public static Result<Area> Create(Maybe<string> areaOrNothing)
        {
            return areaOrNothing.ToResult("Área não pode está vazia")
                .Map(area => area.Trim())
                .Ensure(area => area != string.Empty, "Área não pode está vazio")
                .Ensure(area => area.Length <= 20, "Área não pode conter mais que 20 caracteres")
                .Map(area => new Area(area));
        }

        public static explicit operator Area(string area)
        {
            return Create(area).Value;
        }

        public static implicit operator string(Area area)
        {
            return area.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
