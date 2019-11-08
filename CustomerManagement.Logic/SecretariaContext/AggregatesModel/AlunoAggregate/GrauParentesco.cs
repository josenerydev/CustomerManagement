using CSharpFunctionalExtensions;
using CustomerManagement.Logic.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.AlunoAggregate
{
    public class GrauParentesco : Enumeration
    {
        protected GrauParentesco()
        {
        }

        private GrauParentesco(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Result<GrauParentesco> Get(Maybe<string> name)
        {
            if (name.HasNoValue)
                return Result.Failure<GrauParentesco>("Grau de parentesco não especifícado");

            return Result.Failure<GrauParentesco>("Grau de parentesco é inválido: " + name);
        }
    }
}
