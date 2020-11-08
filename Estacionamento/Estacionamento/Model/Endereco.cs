using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Model
{
    class Endereco
    {
        private string codigoEndereco;

        public string CodigoEndereco
        {
            get { return codigoEndereco; }
            set { codigoEndereco = value; }
        }

        private string logradouro;

        public string Logradouro
        {
            get { return logradouro; }
            set { logradouro = value; }
        }

        private string bairro;

        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        private string cidade;

        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private uint numero;

        public uint Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        private string complemento;

        public string Complemento
        {
            get { return complemento; }
            set { complemento = value; }
        }

        private string cep;

        public string Cep
        {
            get { return cep; }
            set { cep = value; }
        }
    }
}
