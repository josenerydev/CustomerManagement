using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.AlunoAggregate
{
    public class Responsavel
    {
        public string Nome { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Profissão { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }

        public bool ResponsavelFinanceiro { get; set; }
        public bool ResponsavelPedagogico { get; set; }
        public string GrauDeParentesco { get; set; }
    }
}
