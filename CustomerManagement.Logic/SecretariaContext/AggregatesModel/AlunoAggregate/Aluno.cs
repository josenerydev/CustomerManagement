using CustomerManagement.Logic.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.AlunoAggregate
{
    public class Aluno : AggregateRoot
    {
        public string Foto { get; set; }
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }

        // Dados Adicionais

        public string CPF { get; set; }

        public string RG { get; set; }

        public string Sexo { get; set; }

        public string EstadoCivil { get; set; }
        // Casado, Divorciado, Solteiro

        public string DataNascimento { get; set; }

        public string NaturalDe { get; set; }
        public string Nacionalidade { get; set; }

        public string Carreira { get; set; }
        public string Email { get; set; }
        public string LinguaEstrangeira { get; set; }

        public string ColegioAnterior { get; set; }
        // Nome; Cidade; UF

    }
}
