using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Model
{
    class DadosEmpresa
    {
        private string cnpj;

        public string Cnpj
        {
            get { return cnpj; }
            set { cnpj = value; }
        }

        private string telefone;

        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        private Endereco enderecoEmpresa;

        internal Endereco EnderecoEmpresa
        {
            get { return enderecoEmpresa; }
            set { enderecoEmpresa = value; }
        }

        private string ie;

        public string Ie
        {
            get { return ie; }
            set { ie = value; }
        }

        private string nomeFantasia;

        public string NomeFantasia
        {
            get { return nomeFantasia; }
            set { nomeFantasia = value; }
        }
    }
}
