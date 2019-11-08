using CSharpFunctionalExtensions;

using CustomerManagement.Logic.SecretariaContext.AggregatesModel.Common;
using CustomerManagement.Logic.SeedWork;

using System.Collections.Generic;

namespace CustomerManagement.Logic.SecretariaContext.AggregatesModel.AlunoAggregate
{
    public class Aluno : AggregateRoot
    {
        private readonly string _urlFoto;
        public virtual UrlFoto UrlFoto => (UrlFoto)_urlFoto;

        private readonly string _nome;
        public virtual Nome Nome => (Nome)_nome;

        private readonly string _matricula;
        public virtual Matricula Matricula => (Matricula)_matricula;

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

        public virtual Sexo Sexo { get; protected set; }

        public virtual EstadoCivil EstadoCivil { get; protected set; }

        private readonly string _dataNascimento;
        public virtual DataNascimento DataNascimento => (DataNascimento)_dataNascimento;

        public virtual IList<Responsavel> Responsaveis { get; protected set; }

        private readonly string _naturalidade;
        public virtual Naturalidade Naturalidade => (Naturalidade)_naturalidade;

        private readonly string _nacionalidade;
        public virtual Nacionalidade Nacionalidade => (Nacionalidade)_nacionalidade;

        public virtual Carreira Carreira { get; protected set; }

        private readonly string _emailPrincipal;
        public virtual Email EmailPrincipal => (Email)_emailPrincipal;

        private string _emailSecundario;
        public virtual Maybe<Email> EmailSecundario
        {
            get => _emailSecundario == null ? null : (Email)_emailSecundario;
            protected set => _emailSecundario = value.Unwrap(x => x.Value);
        }

        public virtual LinguaEstrangeira LinguaEstrangeira { get; protected set; }

        public virtual IList<Colegio> ColegiosAnteriores { get; protected set; }

        protected Aluno()
        {
        }

        public Aluno(UrlFoto urlFoto,
            Nome nome,
            Matricula matricula,
            Cep cep,
            Cidade cidade,
            UF uf,
            Logradouro logradouro,
            Numero numero,
            Complemento complemento,
            Bairro bairro,
            Telefone telefonePrincipal,
            Maybe<Telefone> telefoneSecundario,
            Cpf cpf,
            RG rg,
            Sexo sexo,
            EstadoCivil estadoCivil,
            DataNascimento dataNascimento,
            Naturalidade naturalidade,
            Nacionalidade nacionalidade,
            Carreira carreira,
            Email emailPrincipal,
            Maybe<Email> emailSecundario,
            LinguaEstrangeira linguaEstrangeira)
            : this()
        {

        }
    }
}
