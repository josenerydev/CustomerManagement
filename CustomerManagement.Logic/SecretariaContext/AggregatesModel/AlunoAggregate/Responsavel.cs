using CustomerManagement.Logic.SecretariaContext.AggregatesModel.Common;
using CustomerManagement.Logic.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.AlunoAggregate
{
    public class Responsavel : Entity
    {
        public Nome Nome { get; set; }
        public Cep Cep { get; set; }
        public Cidade Cidade { get; set; }
        public UF UF { get; set; }
        public Logradouro Logradouro { get; set; }
        public Numero Numero { get; set; }
        public Complemento Complemento { get; set; }
        public Bairro Bairro { get; set; }
        public Telefone Telefone1 { get; set; }
        public Telefone Telefone2 { get; set; }
        public Cpf Cpf { get; set; }
        public RG Rg { get; set; }
        public Profissao Profissão { get; set; }
        public Sexo Sexo { get; set; }
        public Email Email { get; set; }

        public bool ResponsavelFinanceiro { get; set; }
        public bool ResponsavelPedagogico { get; set; }
        public string GrauDeParentesco { get; set; }
    }
}
