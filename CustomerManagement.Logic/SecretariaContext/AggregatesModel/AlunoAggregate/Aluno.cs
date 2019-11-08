using CustomerManagement.Logic.SecretariaContext.AggregatesModel.Common;
using CustomerManagement.Logic.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.AlunoAggregate
{
    public class Aluno : AggregateRoot
    {
        public string Foto { get; set; }
        public Nome Nome { get; set; }

        // No lugar de código
        public int Matricula { get; set; }
        public Cep Cep { get; set; }
        public Cidade Cidade { get; set; }
        public UF UF { get; set; }
        public Logradouro Logradouro { get; set; }
        public Bairro Bairro { get; set; }
        public Telefone Telefone1 { get; set; }
        public Telefone Telefone2 { get; set; }

        // Dados Adicionais

        public Cpf CPF { get; set; }

        public RG RG { get; set; }

        public string Sexo { get; set; }
        // Masculino, Feminino, Outros

        public EstadoCivil EstadoCivil { get; set; }
        // Casado, Divorciado, Solteiro

        public DataNascimento DataNascimento { get; set; }

        public string Naturalidade { get; set; }
        public string Nacionalidade { get; set; }

        public string Carreira { get; set; }
        public Email Email { get; set; }
        public LinguaEstrangeira LinguaEstrangeira { get; set; }
        // Inglês e espanhol

        public string ColegioAnterior { get; set; }
        // Nome; Cidade; UF

    }
}
