using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Model
{
    class Pessoa
    {
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private string cpf;

        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        private string telefone;

        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        private Endereco enderecoPessoa;

        public Endereco EnderecoPessoa
        {
            get { return enderecoPessoa; }
            set { enderecoPessoa = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}