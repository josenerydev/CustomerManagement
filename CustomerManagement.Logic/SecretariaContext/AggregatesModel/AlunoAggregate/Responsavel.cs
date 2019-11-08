using CSharpFunctionalExtensions;
using CustomerManagement.Logic.SecretariaContext.AggregatesModel.Common;
using CustomerManagement.Logic.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.AlunoAggregate
{
    public class Responsavel : Entity
    {
        private readonly string _nome;
        public virtual Nome Nome => (Nome)_nome;

        private readonly string _cep;
        public virtual Cep Cep => (Cep)_cep;

        private readonly string _cidade;
        public virtual Cidade Cidade => (Cidade)_cidade;
        public virtual UF UF { get; protected set; }

        private readonly string _logradouro;
        public virtual Logradouro Logradouro => (Logradouro)_logradouro;

        private readonly string _numero;
        public virtual Numero Numero => (Numero)_numero;

        private readonly string _complemento;
        public virtual Complemento Complemento => (Complemento)_complemento;

        private readonly string _bairro;
        public virtual Bairro Bairro => (Bairro)_bairro;

        private readonly string _telefonePrincipal;
        public virtual Telefone TelefonePrincipal => (Telefone)_telefonePrincipal;

        private string _telefoneSecundario;
        public virtual Maybe<Telefone> TelefoneSecundario
        {
            get => _telefoneSecundario == null ? null : (Telefone)_telefoneSecundario;
            protected set => _telefoneSecundario = value.Unwrap(x => x.Value);
        }

        private readonly string _cpf;
        public virtual Cpf CPF => (Cpf)_cpf;

        private readonly string _rg;
        public virtual RG RG => (RG)_rg;

        private readonly string _profissao;
        public virtual Profissao Profissão => (Profissao)_profissao;

        public virtual Sexo Sexo { get; protected set; }

        private readonly string _emailPrincipal;
        public virtual Email EmailPrincipal => (Email)_emailPrincipal;

        private string _emailSecundario;
        public virtual Maybe<Email> EmailSecundario
        {
            get => _emailSecundario == null ? null : (Email)_emailSecundario;
            protected set => _emailSecundario = value.Unwrap(x => x.Value);
        }

        public bool ResponsavelFinanceiro { get; set; }
        public bool ResponsavelPedagogico { get; set; }

        public virtual GrauParentesco GrauParentesco { get; protected set; }
    }
}
