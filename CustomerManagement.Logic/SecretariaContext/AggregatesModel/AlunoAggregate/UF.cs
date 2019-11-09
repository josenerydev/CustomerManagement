using CSharpFunctionalExtensions;

using CustomerManagement.Logic.SeedWork;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.AlunoAggregate
{
    public class UF : Enumeration
    {
        public static readonly UF AC = new UF(1, "AC");
        public static readonly UF AL = new UF(2, "AL");
        public static readonly UF AP = new UF(3, "AP");
        public static readonly UF AM = new UF(4, "AM");
        public static readonly UF BA = new UF(5, "BA");
        public static readonly UF CE = new UF(6, "CE");
        public static readonly UF DF = new UF(7, "DF");
        public static readonly UF ES = new UF(8, "ES");
        public static readonly UF GO = new UF(9, "GO");
        public static readonly UF MA = new UF(10, "MA");
        public static readonly UF MT = new UF(11, "MT");
        public static readonly UF MS = new UF(12, "MS");
        public static readonly UF MG = new UF(13, "MG");
        public static readonly UF PA = new UF(14, "PA");
        public static readonly UF PB = new UF(15, "PB");
        public static readonly UF PR = new UF(16, "PR");
        public static readonly UF PE = new UF(17, "PE");
        public static readonly UF PI = new UF(18, "PI");
        public static readonly UF RJ = new UF(19, "RJ");
        public static readonly UF RN = new UF(20, "RN");
        public static readonly UF RS = new UF(21, "RS");
        public static readonly UF RO = new UF(22, "RO");
        public static readonly UF RR = new UF(23, "RR");
        public static readonly UF SC = new UF(24, "SC");
        public static readonly UF SP = new UF(25, "SP");
        public static readonly UF SE = new UF(26, "SE");
        public static readonly UF TO = new UF(27, "TO");

        protected UF()
        {
        }

        private UF(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Result<UF> Get(Maybe<string> name)
        {
            if (name.HasNoValue)
                return Result.Failure<UF>("UF não especifícada");

            if (name.Value == AC.Name)
                return Result.Ok(AC);

            if (name.Value == AL.Name)
                return Result.Ok(AL);

            if (name.Value == AP.Name)
                return Result.Ok(AP);

            if (name.Value == AM.Name)
                return Result.Ok(AM);

            if (name.Value == BA.Name)
                return Result.Ok(BA);

            if (name.Value == CE.Name)
                return Result.Ok(CE);

            if (name.Value == DF.Name)
                return Result.Ok(DF);

            if (name.Value == ES.Name)
                return Result.Ok(ES);

            if (name.Value == GO.Name)
                return Result.Ok(GO);

            if (name.Value == MA.Name)
                return Result.Ok(MA);

            if (name.Value == MT.Name)
                return Result.Ok(MT);

            if (name.Value == MS.Name)
                return Result.Ok(MS);

            if (name.Value == MG.Name)
                return Result.Ok(MG);

            if (name.Value == PA.Name)
                return Result.Ok(PA);

            if (name.Value == PB.Name)
                return Result.Ok(PB);

            if (name.Value == PR.Name)
                return Result.Ok(PR);

            if (name.Value == PE.Name)
                return Result.Ok(PE);

            if (name.Value == PI.Name)
                return Result.Ok(PI);

            if (name.Value == RJ.Name)
                return Result.Ok(RJ);

            if (name.Value == RN.Name)
                return Result.Ok(RN);

            if (name.Value == RS.Name)
                return Result.Ok(RS);

            if (name.Value == RO.Name)
                return Result.Ok(RO);

            if (name.Value == RR.Name)
                return Result.Ok(RR);

            if (name.Value == SC.Name)
                return Result.Ok(SC);

            if (name.Value == SP.Name)
                return Result.Ok(SP);

            if (name.Value == SE.Name)
                return Result.Ok(SE);

            if (name.Value == TO.Name)
                return Result.Ok(TO);

            return Result.Failure<UF>("UF é inválida: " + name);
        }
    }
}
