using CSharpFunctionalExtensions;

using CustomerManagement.Logic.SeedWork;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.Common
{
    public class Sexo : Enumeration
    {
        public static readonly Sexo Feminino = new Sexo(1, "Feminino");
        public static readonly Sexo Masculino = new Sexo(2, "Masculino");
        protected Sexo()
        {
        }

        private Sexo(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Result<Sexo> Get(Maybe<string> name)
        {
            if (name.HasNoValue)
                return Result.Failure<Sexo>("Sexo não foi especifícado");

            if (name.Value == Feminino.Name)
                return Result.Ok(Feminino);

            if (name.Value == Masculino.Name)
                return Result.Ok(Masculino);

            return Result.Failure<Sexo>("Sexo é inválido: " + name);
        }
    }
}
