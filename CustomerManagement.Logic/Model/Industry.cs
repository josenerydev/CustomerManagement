using CSharpFunctionalExtensions;

using CustomerManagement.Logic.SeedWork;

namespace CustomerManagement.Logic.Model
{
    public class Industry : Entity
    {
        public static readonly Industry Cars = new Industry(1, nameof(Cars));
        public static readonly Industry Pharmacy = new Industry(2, nameof(Pharmacy));
        public static readonly Industry Other = new Industry(3, nameof(Other));

        public virtual string Name { get; protected set; }

        protected Industry()
        {
        }

        private Industry(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Result<Industry> Get(Maybe<string> name)
        {
            if (name.HasNoValue)
                return Result.Failure<Industry>("Industry name is not specified");

            if (name.Value == Cars.Name)
                return Result.Ok(Cars);

            if (name.Value == Pharmacy.Name)
                return Result.Ok(Pharmacy);

            if (name.Value == Other.Name)
                return Result.Ok(Other);

            return Result.Failure<Industry>("Industry name is invalid: " + name);
        }
    }
}
